using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class EventPhysicianTest : DomainObjectBase
    {
        public long EventId { get; set; }
        public long PhysicianId { get; set; }
        public long TestId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long AssignedByOrgRoleUserId { get; set; }
        public long ModifiedByOrgRoleUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
