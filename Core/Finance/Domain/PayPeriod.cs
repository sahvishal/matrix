using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class PayPeriod : DomainObjectBase
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public int NumberOfWeeks { get; set; }
        public DateTime EndDate { get; set; }
    }
}
