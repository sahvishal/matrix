using System.Collections.Generic;
using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibleAmounts
    {
        [JsonProperty(PropertyName = "in_network")]
        public IEnumerable<EligibleAmountDetail> InNetWork { get; set; }

        [JsonProperty(PropertyName = "out_network")]
        public IEnumerable<EligibleAmountDetail> OutNetWork { get; set; } 
    }
}
