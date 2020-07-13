namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodCriteriaViewModel
    {
        public long NumberofCustomer { get; set; }
        public decimal Ammount { get; set; }
        
        public long MinCustomer { get; set; }
        public long? MaxCustomer { get; set; }
        public long TypeId { get; set; }       
    }
}