using Newtonsoft.Json;
using QueMePongo.Dominio.DTOs;

namespace QueMePongo.Negocio.ProveedoresDeClima
{
    public class ProveedorApiXU : ProveedorDeClimaBase
    {
        protected override string UrlBase => "http://api.apixu.com/v1/current.json";
        protected override string Token => "7acb51b545a04c32904202709191106";
        protected override string Coordenadas => _coordenadas;
        protected override string RequestString =>
            $"{UrlBase}?key={Token}&q={_coordenadas}?lang=es";

        private readonly string _coordenadas;

        public ProveedorApiXU(string coordenadas)
        {
            _coordenadas = coordenadas;
        }

        protected override Clima MapStringToClima(string responseContent)
        {
            return JsonConvert.DeserializeObject<ClimaApiXU>(responseContent);
        }
    }
}
