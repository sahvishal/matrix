using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class ShippingOptionViewModel
    {
        public bool IsHospitalPartnerEvent { get; set; }
        public IEnumerable<ShippingOptionOrderItemViewModel> AllShippingOptions { get; set; }
    }
}
