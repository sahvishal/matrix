using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Domain
{
    public class Activity : DomainObjectBase
    {
        public string Subject { get; set; }
        public string Notes { get; set; }
        public long AssignedToOrganizationRoleUserId { get; set; }
        public long ExecutedByOrganizationRoleUserId { get; set; }

        public ActivityStatus Status { get; set; }

        public DataRecorderMetaData RecorderMetaData { get; set; }
 
    }
}