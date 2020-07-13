using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class Affiliate
        : DomainObjectBase
    {
        public Affiliate(long id)
            : base(id)
        { }

        public long UserId { get; set; }
        public long? ParentAffiliateId { get; set; }
        public string AffiliateCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //public bool IsGlobal { get; set; }
        //public long OwnerFranchiseeId { get; set; }
        //public PhoneNumber DefaultIncomingPhoneLine { get; set; }
        //public decimal MaxCommission { get; set; }
        //public decimal MaxParentCommission { get; set; }
        //public int PayCycle { get; set; }
        //public decimal PaymentThreshold { get; set; }
        //public long PaymentAddressId { get; set; }
        //public bool? IsPaymentByCheck { get; set; }
        //public bool IsDonation { get; set; }
        
        // more fields
    }
}