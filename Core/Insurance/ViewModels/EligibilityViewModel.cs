namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligibilityViewModel
    {
        public long EligibilityId { get; set; }

        public decimal AmountCovered { get; set; }

        public decimal CoPayAmount { get; set; }

        public EligibleResponse Response { get; set; }
    }
}
