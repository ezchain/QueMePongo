using Newtonsoft.Json;
using QueMePongo.Dominio.DTOs;

namespace QueMePongo.Negocio.ProveedoresDeClima
{
    public class ProveedorDarkSky : ProveedorDeClimaBase
    {
        protected override string UrlBase => "https://api.darksky.net/forecast/";
        protected override string Token => "c339eae7cb592c2c91f24d0ffbf0585c";
        protected override string Coordenadas => _coordenadas;
        protected override string RequestString =>
            $"{UrlBase}/{Token}/{_coordenadas}?lang=es&units=si";

        private readonly string _coordenadas;

        public ProveedorDarkSky(string coordenadas)
        {
            _coordenadas = coordenadas;
        }

        protected override Clima MapStringToClima(string responseContent)
        {
            return JsonConvert.DeserializeObject<ClimaDarkAPI>(responseContent);
        }
    }
}
