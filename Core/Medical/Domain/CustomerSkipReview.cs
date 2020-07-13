using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class CustomerSkipReview : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public long DefaultPhysicianId { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsSkipEvaluation { get; set; }
    }
}
