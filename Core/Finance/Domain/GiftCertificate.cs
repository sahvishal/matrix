using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.Core.Finance.Domain
{
    public class GiftCertificate : DomainObjectBase, IOrderable
    {
        public long GiftCertificateTypeId { get; set; }
        public string ClaimCode { get; set; }
        public decimal Amount { get; set; }

        public string FromName { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string Message { get; set; }

        public DateTime? ExpirationDate { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long? ApplicablePackageId { get; set; }

        public GiftCertificate()
        { }

        public GiftCertificate(long giftCertificateId)
            : base(giftCertificateId)
        { }

        public decimal Price { get; set; }

        public decimal BalanceAmount { get { return Price - Amount; } }

        public string Description
        {
            get { return string.Format("{0:C} Gift Certificate for {1}", Price, ToName); }
        }

        public OrderItemType OrderItemType
        {
            get { return OrderItemType.GiftCertificateItem; }
        }
    }
}