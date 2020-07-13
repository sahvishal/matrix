using System.Collections.Generic;
using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleResponse
    {
        [JsonProperty(PropertyName = "eligible_id")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "demographics")]
        public EligibleDemographics Demographics { get; set; }

        [JsonProperty(PropertyName = "primary_insurance")]
        public EligibleInsurance PrimaryInsurance { get; set; }

        [JsonProperty(PropertyName = "insurance")]
        public EligibleInsurance Insurance { get; set; }

        [JsonProperty(PropertyName = "plan")]
        public EligiblePlan Plan { get; set; }

        [JsonProperty(PropertyName = "services")]
        public IEnumerable<EligibleServiceInfo> Services { get; set; }

        [JsonProperty(PropertyName = "authorization_required")]
        public bool AuthorizationRequired { get; set; }

        [JsonProperty(PropertyName = "error")]
        public EligibleError Error { get; set; }

        public string RawResponse { get; set; }
    }
}
