using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleCoInsurance
    {
        [JsonProperty(PropertyName = "percents")]
        public EligibleAmounts Percents { get; set; }
    }
}
