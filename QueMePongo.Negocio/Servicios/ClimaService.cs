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
           private readonly string  urlDark = "https://api.darksky.net/forecast/";
           public string Token { get; set; } = "c339eae7cb592c2c91f24d0ffbf0585c";
           public string Coordenadas { get; set; } = "/-34.6131,-58.3723";
           public string Lenguaje { get; set; } = "lang = es";
       
        Task<Clima> ClimaDARKAPI { get; set; }
        Task<Clima> ClimaAPIXU { get; set; }
        public string requestString = "https://api.darksky.net/forecast/c339eae7cb592c2c91f24d0ffbf0585c/-34.6131,-58.3723?lang=es&units=si";
        public string requestString2 = "http://api.apixu.com/v1/current.json?key=7acb51b545a04c32904202709191106&q=Argentina&lang=es";

        public ClimaService()
        {
            Task.WaitAll(this.ClimaDARKAPI = ObtenerClimaDarkAPI(),this.ClimaAPIXU = ObtenerClimaAPIXU());
            
        }
        #region Metodos Publicos


        public async Task<Clima> ObtenerClima()
        {
           // Task.WaitAll(ObtenerClimaDarkAPI());
            return await this.ClimaDARKAPI;
        }
        #endregion

        #region Metodos Privados

        private async Task<HttpResponseMessage> HttpRequest(string requestString)
        {
            using (var handler = new HttpClientHandler())
            {
                if (handler.SupportsAutomaticDecompression)
                {
                    handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }

                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(requestString);
                    return await client.GetAsync(requestString);
                }
            }

        }

        private async Task<Clima> ObtenerClimaDarkAPI()
        {
            ZipHttpClient client = new ZipHttpClient("https://api.darksky.net/");

            //HttpClient client = new HttpClient();
            // var response = await HttpRequest(requestString);
            var response = await client.HttpRequest(requestString);
            var responseContent = await response.Content.ReadAsStringAsync();
            ClimaDarkAPI ClimaResponse = new ClimaDarkAPI();



            ClimaResponse = JsonConvert.DeserializeObject<ClimaDarkAPI>(responseContent);
            return ClimaResponse;
        }

        private async Task<Clima> ObtenerClimaAPIXU()
        {
            ZipHttpClient client = new ZipHttpClient("http://api.apixu.com/v1");

            //HttpClient client = new HttpClient();
            // var response = await HttpRequest(requestString);
            var response = await client.HttpRequest(requestString2);
            var responseContent = await response.Content.ReadAsStringAsync();

            Clima ClimaResponse = new ClimaAPIXU();



            ClimaResponse = JsonConvert.DeserializeObject<ClimaAPIXU>(responseContent);
            return ClimaResponse;
        }
        #endregion




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
