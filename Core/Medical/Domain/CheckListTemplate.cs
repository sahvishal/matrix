using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class CheckListTemplate : DomainObjectBase
    {
        public string Name { get; set; }
        //public long? HealthPlanId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDefault { get; set; }
        public long Type { get; set; }
    }
}