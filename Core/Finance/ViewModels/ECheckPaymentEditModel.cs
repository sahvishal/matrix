using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ECheckPaymentEditModel
    {
        public Check ECheck { get; set; }
        public ECheckPayment ECheckPayment { get; set; }
    }
}