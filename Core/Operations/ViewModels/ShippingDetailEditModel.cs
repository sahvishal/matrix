using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class ShippingDetailEditModel : ViewModelBase
    {
        public long ShippingDetailId { get; set; }

        public int Status { get; set; }

        public string ShippingOptionName { get; set; }
    }
}
