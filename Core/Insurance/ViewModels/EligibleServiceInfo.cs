using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleServiceInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty(PropertyName = "coverage_status")]
        public int CoverageStatus { get; set; }

        [JsonProperty(PropertyName = "coverage_status_label")]
        public string CoverageStatusLabel { get; set; }

        [JsonProperty(PropertyName = "financials")]
        public EligibleFinancials FinancialData { get; set; }
    }
}
