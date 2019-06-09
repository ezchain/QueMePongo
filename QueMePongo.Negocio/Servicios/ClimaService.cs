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
        //    private readonly string  urlDark = "https://api.darksky.net/forecast/";
        //    public string Token { get; set; } = "c339eae7cb592c2c91f24d0ffbf0585c";
        //    public string Coordenadas { get; set; } = "/-34.6131,-58.3723";
        //    public string Lenguaje { get; set; } = "lang = es";
        public Clima Clima { get; set; }
        Task Inicializacion { get; set; }
        public string requestString = "https://api.darksky.net/forecast/c339eae7cb592c2c91f24d0ffbf0585c/-34.6131,-58.3723?lang=es&units=si";


        public ClimaService()
        {

        }
        #region Metodos Publicos

        public async Task<Clima> ObtenerClimaDarkAPI()
        {
            HttpClient client = new HttpClient();
            var response = await client.HttpRequest(requestString);
            var responseContent = await response.Content.ReadAsStringAsync();
            Clima ClimaResponse = new Clima();

            ClimaResponse = JsonConvert.DeserializeObject<Clima>(responseContent);
            return ClimaResponse;
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
                    client.BaseAddress = new Uri("https://api.darksky.net/forecast/c339eae7cb592c2c91f24d0ffbf0585c/-34.6131,-58.3723?lang=es");
                    return await client.GetAsync(requestString);
                }
            }

        }
        #endregion



    }
}
