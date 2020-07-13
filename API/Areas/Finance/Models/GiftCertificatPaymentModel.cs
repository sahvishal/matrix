namespace API.Areas.Finance.Models
{
    public class GiftCertificatPaymentModel
    {
        public string ClaimCode { get; set; }

        public decimal Amount { get; set; }

        public decimal BalancePaymentAmount { get; set; }

    }
}