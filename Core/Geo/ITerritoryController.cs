using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Geo
{
    public interface ITerritoryController
    {
        List<TerritoryViewData> GetAllParentTerritoryViewData();
        List<TerritoryViewData> GetFranchiseeTerritoryViewData(long franchiseeId);
        List<OrderedPair<SalesRepTerritory, SalesRepTerritoryAssignment>> GetTerritoriesAndAssignmentsForSalesRep(long salesRepId);
        List<TerritoryViewData> GetChildTerritories(long parentTerritoryId);
        OrderedPair<Territory, List<string>> GetTerritoryAndOwnerNames(long territoryId);
        bool UnassignSalesRepFromTerritory(long salesRepId, long territoryId);
        bool AssignSalesRepToTerritory(long salesRepId, long territoryId, RegistrationMode eventType);
        List<TerritoryViewData> GetTerritoryViewDataAvailableForSalesRep(long franchiseeId, long salesRepId);
        List<Territory> GetTerritoriesForFranchisee(long franchiseeId);
        List<Territory> GetAllTerritories();
        List<SalesRepTerritory> GetTerritoriesForSalesRep(long salesRepId);
        bool DeleteTerritory(long territoryId);
    }
}