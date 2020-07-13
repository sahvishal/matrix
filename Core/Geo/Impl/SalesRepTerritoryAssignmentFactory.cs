using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Geo.Impl
{
    public class SalesRepTerritoryAssignmentFactory : ISalesRepTerritoryAssignmentFactory
    {
        public SalesRepTerritoryAssignment CreateSalesRepTerritoryAssignment(long userId, 
            RegistrationMode eventType, long salesRepId)
        {
            return new SalesRepTerritoryAssignment
            {
                SalesRep = new SalesRepresentative(userId)
                {
                    SalesRepresentativeId = salesRepId
                },
                EventTypeSetupPermission = eventType
            };
        }

        public IEnumerable<SalesRepTerritoryAssignment> CreateSalesRepTerritoryAssignments
            (IEnumerable<OrderedPair<OrganizationRoleUser, RegistrationMode>> owningUsersAndEventTypes,
            IEnumerable<OrderedPair<long, long>> userSalesReps)
        {
            var salesRepTerritoryAssignments = new List<SalesRepTerritoryAssignment>();
            foreach (var owningUserAndEventType in owningUsersAndEventTypes)
            {
                OrderedPair<OrganizationRoleUser, RegistrationMode> type = owningUserAndEventType;
                long salesRepId = userSalesReps.
                    Single(user => user.FirstValue == type.FirstValue.UserId).SecondValue;
                SalesRepTerritoryAssignment assignment = CreateSalesRepTerritoryAssignment          
                    (owningUserAndEventType.FirstValue.UserId, owningUserAndEventType.SecondValue,
                    salesRepId);
                salesRepTerritoryAssignments.Add(assignment);
            }
            return salesRepTerritoryAssignments;
        }
    }
}