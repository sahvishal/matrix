using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class OnlineCustomerPersonalInformationEditModel
    {
        public SchedulingCustomerEditModel CustomerEditModel { get; set; }

        public OnlineProductShippingEditModel ShippingOptions { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
    }
}