using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Insurance.Domain
{
    public class Encounter : DomainObjectBase
    {
        public long BillingAccountId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
