using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{

    public class OnlineProductShippingEditModel
    {
        public IEnumerable<ProductOrderItemViewModel> AllProducts { get; set; }
        public IEnumerable<ShippingOptionOrderItemViewModel> AllShippingOptions { get; set; }

        public IEnumerable<long> SelectedProductIds { get; set; }
        public long SelectedShippingOptionId { get; set; }

        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public EventType EventType { get; set; }
        public string Guid { get; set; }
        public bool IsHospitalPartnerEvent { get; set; }

        public bool EnableImageUpsell { get; set; }
    }
}
