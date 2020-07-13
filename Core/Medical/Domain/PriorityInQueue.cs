using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PriorityInQueue : DomainObjectBase
    {
        public long EventCustomerResultId { get; set; }
        public long? NoteId { get; set; }
        public long InQueuePriority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified{ get; set; }
        public long CreatedByOrgRoleUserId { get; set; }
        public long? ModifiedByOrgRoleUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
