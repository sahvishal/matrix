using Falcon.App.Core.Insurance.Enum;
using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligiblePlan
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "coverage_status")]
        public EligibleCoverageStatus CoverageStatus { get; set; }

        [JsonProperty(PropertyName = "coverage_status_label")]
        public string CoverageStatusLabel { get; set; }

        [JsonProperty(PropertyName = "plan_number")]
        public string PlanNumber { get; set; }

        [JsonProperty(PropertyName = "plan_name")]
        public string PlanName { get; set; }

        [JsonProperty(PropertyName = "group_name")]
        public string GroupName { get; set; }

        [JsonProperty(PropertyName = "financials")]
        public EligibleFinancials FinancialData { get; set; }
    }
}
