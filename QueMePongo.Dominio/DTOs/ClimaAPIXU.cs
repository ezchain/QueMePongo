using Newtonsoft.Json;

namespace QueMePongo.Dominio.DTOs
{
    public class ClimaApiXU : Clima
    {
        [JsonProperty(PropertyName = "current")]
        public Current current { get; set; }

        protected override double? Temperatura => current.Temperature;
    }

    public class Current
    {
        [JsonProperty(PropertyName = "temp_c")]
        public double? Temperature { get; set; }

        [JsonProperty(PropertyName = "condition")]
        public Condition condition { get; set; }
    }

    public class Condition
    {
        [JsonProperty(PropertyName = "text")]
        public string Summary { get; set; }

    }
}
