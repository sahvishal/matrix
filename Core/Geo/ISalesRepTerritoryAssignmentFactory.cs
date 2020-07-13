using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Geo
{
    public interface ISalesRepTerritoryAssignmentFactory
    {
        SalesRepTerritoryAssignment CreateSalesRepTerritoryAssignment(long userId, 
            RegistrationMode eventType, long salesRepId);

        IEnumerable<SalesRepTerritoryAssignment> CreateSalesRepTerritoryAssignments
            (IEnumerable<OrderedPair<OrganizationRoleUser, RegistrationMode>> owningUsersAndEventTypes,
             IEnumerable<OrderedPair<long, long>> userSalesReps);
    }
}