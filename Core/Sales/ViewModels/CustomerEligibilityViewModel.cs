namespace Falcon.App.Core.Sales.ViewModels
{
    public class CustomerEligibilityViewModel
    {
        public long CustomerId { get; set; }
        public string IsEligible { get; set; }
        public int ForYear { get; set; }
    }
}
