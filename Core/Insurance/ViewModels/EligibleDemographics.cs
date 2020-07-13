using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleDemographics
    {
        [JsonProperty(PropertyName = "subscriber")]
        public EligiblePatientInfo Subscriber { get; set; }

        [JsonProperty(PropertyName = "dependent")]
        public EligiblePatientInfo Dependent { get; set; }
    }
}
