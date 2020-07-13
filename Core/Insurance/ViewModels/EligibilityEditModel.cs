using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibilityEditModel
    {
        public long EligibilityId { get; set; }

        public decimal AmountCovered { get; set; }

        public EligibilityRequestEditModel Request { get; set; }

        public EligibleResponse Response { get; set; }

        public ChargeCard CardDetail { get; set; }

        public string ChargeCardResponse { get; set; }

        public bool HideCardDetails { get; set; }

        public EligibilityEditModel()
        {
            Request = new EligibilityRequestEditModel();
            CardDetail = new ChargeCard();
        }
    }
}
