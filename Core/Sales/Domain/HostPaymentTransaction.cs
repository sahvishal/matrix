using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostPaymentTransaction : DomainObjectBase
    {
        public long HostPaymentId { get; set; }
        public HostPaymentStatus TransactionType { get; set; }
        public HostPaymentType TransactionMethod { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public OrganizationRoleUser TransactionRecordedBy { get; set; }

        public HostPaymentTransaction() { }
        public HostPaymentTransaction(long hostPaymentId) : base(hostPaymentId) { }
    }
}
