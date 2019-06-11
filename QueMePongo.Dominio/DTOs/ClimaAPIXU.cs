using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.DTOs
{
    public class ClimaAPIXU : Clima
    {
        [JsonProperty(PropertyName = "current")]
        public Current current { get; set; }

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
