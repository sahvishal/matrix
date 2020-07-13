using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleAmountDetail
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "percent")]
        public decimal Percent { get; set; }

        [JsonProperty(PropertyName = "time_period")]
        public int? TimePeriod { get; set; }

        [JsonProperty(PropertyName = "time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        [JsonProperty(PropertyName = "insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty(PropertyName = "insurance_type_label")]
        public string InsuranceTypeLabel { get; set; }

        [JsonProperty(PropertyName = "pos")]
        public int? Pos { get; set; }

        [JsonProperty(PropertyName = "pos_label")]
        public string PosLabel { get; set; }

        [JsonProperty(PropertyName = "authorization_required")]
        public bool? AuthorizationRequired { get; set; }
    }
}
