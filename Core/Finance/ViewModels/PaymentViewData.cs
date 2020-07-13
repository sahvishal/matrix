namespace Falcon.App.Core.Finance.ViewModels
{
    public class PaymentViewData
    {
        public string PaymentInstrumentName { get; set; }
        public string InstrumentNumber { get; set; }
        public string InstrumentDate { get; set; }
        public string ProcessorResponse { get; set; }
        public string DateCreated { get; set; }
        public string CreatorUserName { get; set; }
        public string CreatorRoleName { get; set; }
        public string CreationMode { get; set; }
        public decimal Amount { get; set; }
    }
}