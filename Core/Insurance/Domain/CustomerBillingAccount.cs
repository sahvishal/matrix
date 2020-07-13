using System;

namespace Falcon.App.Core.Insurance.Domain
{
    public class CustomerBillingAccount
    {
        public long CustomerId { get; set; }
        public long BillingAccountId { get; set; }
        public long BillingPatientId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
