using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventNote : DomainObjectBase
    {
        public string Note { get; set; }
        public long? HealthPlanId { get; set; }
        public DateTime? EventDateFrom { get; set; }
        public DateTime? EventDateTo { get; set; }
        public long? PodId { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
