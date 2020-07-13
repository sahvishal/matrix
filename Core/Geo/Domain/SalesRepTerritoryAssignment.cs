using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class SalesRepTerritoryAssignment
    {
        public SalesRepresentative SalesRep { get; set; }
        public RegistrationMode EventTypeSetupPermission { get; set; }

        // Used in Ajax calls.
        public string EventTypeSetupPermissionName { get { return EventTypeSetupPermission.ToString(); } }
    }
}