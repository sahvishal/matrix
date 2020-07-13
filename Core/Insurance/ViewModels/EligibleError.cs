using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleError
    {
        [JsonProperty(PropertyName = "response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty(PropertyName = "response_description")]
        public string ResponseDescription { get; set; }

        [JsonProperty(PropertyName = "agency_qualifier_code")]
        public string ResponseQualifierRCode { get; set; }

        [JsonProperty(PropertyName = "agency_qualifier_description")]
        public string ResponseQualifierRescription { get; set; }

        [JsonProperty(PropertyName = "reject_reason_code")]
        public string RejectionReasonCode { get; set; }

        [JsonProperty(PropertyName = "reject_reason_description")]
        public string RejectionReasonDescription { get; set; }

        [JsonProperty(PropertyName = "follow-up_action_code")]
        public string FollowUpActionCode { get; set; }

        [JsonProperty(PropertyName = "follow-up_action_description")]
        public string FollowUpActionDescription { get; set; }
    }
}
