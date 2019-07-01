using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
    public class DataBlock
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double? Temperature { get; set; }
    }
    
}
