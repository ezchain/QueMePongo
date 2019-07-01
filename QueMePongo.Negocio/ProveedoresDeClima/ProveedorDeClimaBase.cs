using QueMePongo.Dominio.DTOs;
using QueMePongo.Negocio.ClienteHttp;
using System;
using System.Threading.Tasks;

namespace QueMePongo.Negocio.ProveedoresDeClima
{
    public abstract class ProveedorDeClimaBase
    {
        protected abstract string RequestString { get; }
        protected abstract string UrlBase { get; }
        protected abstract string Token { get; }
        protected abstract string Coordenadas { get; }

        public async Task<Clima> ObtenerClima()
        {
            try
            {
                ZipHttpClient client = new ZipHttpClient(UrlBase);

                var response = await client.HttpRequest(RequestString);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                var responseContent = await response.Content.ReadAsStringAsync();

                return MapStringToClima(responseContent);
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected abstract Clima MapStringToClima(string responseContent);
    }
}
