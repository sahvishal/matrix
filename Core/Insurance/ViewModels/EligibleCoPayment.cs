using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleCoPayment
    {
        [JsonProperty(PropertyName = "amounts")]
        public EligibleAmounts Amounts { get; set; }
    }
}
