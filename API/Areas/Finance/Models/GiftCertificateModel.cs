using System;
using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Finance.Models
{
    [NoValidationRequired]
    public class GiftCertificateModel : ResponseBaseModel
    {
        public string ClaimCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public decimal BalanceAmount { get { return Price - Amount; } }
    }
}