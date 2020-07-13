using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum PhysicianQueueDateTypeFilter
    {
        [Description("Event Date")]
        EventDate = 1,
        [Description("Pre-Audit Date")]
        PreAuditDate = 2
    }
}