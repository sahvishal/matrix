using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleFinancials
    {
        [JsonProperty(PropertyName = "copayment")]
        public EligibleCoPayment CoPayment { get; set; }

        [JsonProperty(PropertyName = "coinsurance")]
        public EligibleCoInsurance CoInsurance { get; set; }
    }
}
