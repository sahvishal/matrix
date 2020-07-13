using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligiblePatientAddress
    {
        [JsonProperty(PropertyName = "street_line_1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "street_line_2")]
        public string Address2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }
    }
}
