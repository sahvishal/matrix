using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class OrderPlaceEditModel
    {
        public IEnumerable<EventTestOrderItemViewModel> AllEventTests { get; set; }
        public IEnumerable<EventPackageOrderItemViewModel> AllEventPackages { get; set; }
        public IEnumerable<ProductOrderItemViewModel> AllProducts { get; set; }
        public IEnumerable<ShippingOptionOrderItemViewModel> AllShippingOptions { get; set; }

        public long SelectedPackageId { get; set; }
        public IEnumerable<long> SelectedTestIds { get; set; }
        public IEnumerable<long> SelectedProductIds { get; set; }
        public long SelectedShippingOptionId { get; set; }
        public bool EnableImageUpsell { get; set; }
        public EventType EventType { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public bool RecommendPackageForEvent { get; set; }
        public bool UpsellTestAvailable { get; set; }
        public bool IsAdditionalTestAvailable { get; set; }
        public bool IsBloodPanelTestTaken { get; set; }
        public string BloodPanelTestName { get; set; }

        public long BloodPanelTestId { get; set; }

    }
}