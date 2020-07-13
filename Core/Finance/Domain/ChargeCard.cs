using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class ChargeCard : DomainObjectBase
    {
        [DisplayName("Card Type")]
        public ChargeCardType TypeId { get; set; }
        [DisplayName("Card holder")]
        public string NameOnCard { get; set; }
        public string Number { get; set; }
        public string CVV { get; set; }
        public string CardIssuer { get; set; }
        public bool IsDebit { get; set; }
        [DisplayName("Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public ChargeCard()
        {}

        public ChargeCard(long chargeCardId)
            : base(chargeCardId)
        {}
    }
}