using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class ChargeCardPaymentEditModel
    {
        public ChargeCard ChargeCard { get; set; }
        public ChargeCardPayment ChargeCardPayment { get; set; }

        public ChargeCardPaymentEditModel()
        {
            ChargeCard = new ChargeCard();
            ChargeCardPayment = new ChargeCardPayment();
        }
    }
}