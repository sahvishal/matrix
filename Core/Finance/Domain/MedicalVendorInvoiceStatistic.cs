namespace Falcon.App.Core.Finance.Domain
{
    public class MedicalVendorInvoiceStatistic : PhysicianInvoiceBase
    {
        public MedicalVendorInvoiceStatistic(long medicalVendorInvoiceId, decimal invoiceAmount,
                                             int numberOfEvaluations, decimal averageHourlyRate)
            : base(medicalVendorInvoiceId)
        {
            _invoiceAmount = invoiceAmount;
            _numberOfEvaluations = numberOfEvaluations;
            _averageHourlyRate = averageHourlyRate;
        }

        private readonly decimal _invoiceAmount;
        public override decimal InvoiceAmount { get { return _invoiceAmount; } }

        private readonly int _numberOfEvaluations;
        public override int NumberOfEvaluations { get { return _numberOfEvaluations; } }

        private readonly decimal _averageHourlyRate;
        public decimal AverageHourlyRate{ get { return _averageHourlyRate; } }

        // Used in web service call via jQuery.
        public string PaymentStatusName { get { return PaymentStatus.ToString(); } }
        public string ApprovalStatusName { get { return ApprovalStatus.ToString(); } }
    }
}