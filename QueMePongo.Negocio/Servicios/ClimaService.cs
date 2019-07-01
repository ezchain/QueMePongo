using Newtonsoft.Json;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Interfaces.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;


namespace QueMePongo.Negocio.Servicios
{

    public class ClimaService : IClimaService
    {
        private readonly string Coordenadas = "-34.6131,-58.3723";
        //private readonly string  urlDark = "https://api.darksky.net/forecast/";
        public string Pais { get; set; } = "Argentina";
        public string TokenDarkAPI { get; set; } = "c339eae7cb592c2c91f24d0ffbf0585c";
        public string TokenApiXU { get; set; } = "7acb51b545a04c32904202709191106";


        //Task<Clima> ClimaDARKAPI { get; set; }
        //Task<Clima> ClimaAPIXU { get; set; }
        //public string requestString = "https://api.darksky.net/forecast/c339eae7cb592c2c91f24d0ffbf0585c/-34.6131,-58.3723?lang=es&units=si";
        //public string requestString2 = "http://api.apixu.com/v1/current.json?key=7acb51b545a04c32904202709191106&q=Argentina&lang=es";
        public IApiClima PrimerProovedor { get; set; }
        public IApiClima SegundoProovedor { get; set; }
        public ClimaService()
        {
        }
        #region Metodos Publicos


        public async Task<Clima> ObtenerClima()
        {
            this.PrimerProovedor = new DarkApi(TokenDarkAPI, Coordenadas);
            this.SegundoProovedor = new ApiXU(TokenApiXU, Pais);
            return await ElegirResponse();
        }
        #endregion

        #region Metodos Privados

        private async Task<Clima> ElegirResponse()
        {
            Task<Clima> ClimaProveedor1;
            Task<Clima> ClimaProveedor2;

            Task.WaitAll(ClimaProveedor1 = this.PrimerProovedor.ObtenerClima(), ClimaProveedor2 = this.SegundoProovedor.ObtenerClima());

            if (ClimaProveedor1.Result != null)
            {
                return await ClimaProveedor1;
            }
            else if (ClimaProveedor2.Result != null)
            {
                return await ClimaProveedor2;
            }
            else
            {
                throw new Exception("Hubo un error al consultar a los proveedores de clima");
            }
        }

        #endregion

    }

    public class DarkApi : IApiClima
    {
        private readonly string urlBase = "https://api.darksky.net/forecast/";
        private readonly string defaultConfiguration = "?lang=es&units=si";
        public string RequestString { get; set; }

        public DarkApi(string token, string coordenadas)
        {
            this.RequestString = urlBase + token + "/" + coordenadas + defaultConfiguration;
        }

        public async Task<Clima> ObtenerClima()
        {
            try
            {
                ZipHttpClient client = new ZipHttpClient("https://api.darksky.net/");
                var response = await client.HttpRequest(this.RequestString);
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
                var responseContent = await response.Content.ReadAsStringAsync();
                ClimaDarkAPI ClimaResponse = new ClimaDarkAPI();
                ClimaResponse = JsonConvert.DeserializeObject<ClimaDarkAPI>(responseContent);
                return ClimaResponse;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

    public class ApiXU : IApiClima
    {
        private readonly string urlBase = "http://api.apixu.com/v1/current.json?key=";
        private readonly string defaultConfiguration = "&lang=es";
        public string RequestString { get; set; }

        public ApiXU(string token, string pais)
        {
            this.RequestString = urlBase + token + "&q=" + pais + defaultConfiguration;
        }


        public async Task<Clima> ObtenerClima()
        {
            try
            {
                ZipHttpClient client = new ZipHttpClient("http://api.apixu.com/v1");

                //HttpClient client = new HttpClient();
                // var response = await HttpRequest(requestString);
                var response = await client.HttpRequest(RequestString);
                if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
                var responseContent = await response.Content.ReadAsStringAsync();

                Clima ClimaResponse = new ClimaAPIXU();
                ClimaResponse = JsonConvert.DeserializeObject<ClimaAPIXU>(responseContent);
                return ClimaResponse;
            }
            catch (Exception e)
            {
                return null;
            }


        }
    }
    public class ZipHttpClient
    {
        readonly string baseUri = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHttpClient"/> class.
        /// </summary>
        /// <param name="baseUri">The root domain and URL for making requests.</param>
        public ZipHttpClient(string baseUri)
        {
            this.baseUri = baseUri;
        }

        /// <summary>
        /// Make a request to the <see cref="baseUri"/> with <paramref name="requestString"/>
        /// concatenated to the end.
        /// </summary>
        /// <param name="requestString">
        /// The actual URL after the root domain to make the request to.
        /// </param>
        /// <returns>The <see cref="HttpRequestMessage"/> from the URL.</returns>
        public async Task<HttpResponseMessage> HttpRequest(string requestString)
        {
            using (var handler = new HttpClientHandler())
            {
                if (handler.SupportsAutomaticDecompression)
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(baseUri);
                    return await client.GetAsync(requestString);
                }
            }
        }
    }

}
