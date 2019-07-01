using Newtonsoft.Json;

namespace QueMePongo.Dominio.DTOs
{
    public class ClimaDarkAPI : Clima
    {
        [JsonProperty(PropertyName = "currently")]
        public DataBlock Currently { get; set; }

        [JsonProperty(PropertyName = "daily")]
        public DataBlock Daily { get; set; }

        [JsonProperty(PropertyName = "hourly")]
        public DataBlock Hourly { get; set; }

        protected override double? Temperatura => Currently.Temperature;
    }

    public class DataBlock
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double? Temperature { get; set; }
    }
}
