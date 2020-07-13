using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostPayment : DomainObjectBase
    {
        public long HostId { get; set; }
        public long EventId { get; set; }
        public decimal Amount { get; set; }
        public HostPaymentType PaymentMode { get; set; }
        public DateTime DueDate { get; set; }
        public string PayableTo { get; set; }
        public string MailingOrganizationName { get; set; }
        public string MailingAttentionOf { get; set; }
        public Address PaymentMailingAddress { get; set; }
        public HostPaymentStatus Status { get; set; }
        public OrganizationRoleUser PaymentRecordedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public List<HostPaymentTransaction> HostPaymentTransactions { get; set; }

        public HostPayment() { }

        public HostPayment(long hostPaymentId) : base(hostPaymentId) { }

    }
}