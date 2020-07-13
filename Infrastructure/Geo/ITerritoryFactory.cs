using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Geo
{
    public interface ITerritoryFactory
    {
        List<Territory> CreateTerritories(IEnumerable<TerritoryEntity> territoryEntities);
        Territory CreateTerritory(TerritoryEntity territoryEntity);
        TerritoryEntity CreateTerritoryEntity(Territory territory, DateTime dateCreated, 
            DateTime dateModified);
        SalesRepTerritory CreateSalesRepTerritory(TerritoryEntity territoryEntity,
            List<OrderedPair<OrganizationRoleUser, RegistrationMode>> owningUsersAndEventTypes,
            List<OrderedPair<long, long>> userSalesReps);
    }
}