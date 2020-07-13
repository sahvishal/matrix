using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class EventStaffAssignment : DomainObjectBase
    {
        public long  EventId { get; set; }
        public long PodId { get; set; }        
        public long ScheduledStaffOrgRoleUserId { get; set; }
        public long? ActualStaffOrgRoleUserId { get; set; }
        public string Notes { get; set; }
        public long StaffEventRoleId { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

    }
}