using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostFacilityViability : DomainObjectBase
    {
        public Int64 HostId { get; set; }
        public HostViabilityRanking Ranking { get; set; }

        public Int16? NumberOfPlugPoints { get; set; }
        public bool? RoomNeedsCleared { get; set; }
        public string Notes { get; set; }
        public string RoomSize { get; set; }
        public InternetAccess InternetAccess { get; set; }
        public bool? IsConfirmedVisually { get; set; }
                        
        public OrganizationRoleUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }                
    }
}
