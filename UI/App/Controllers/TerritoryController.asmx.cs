using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Core.Extensions;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    [GenerateScriptType(typeof(FranchiseeTerritory)), GenerateScriptType(typeof(HospitalPartnerTerritory)), GenerateScriptType(typeof(SalesRepTerritory))]
    public class TerritoryController : WebService, ITerritoryController
    {
        private readonly ITerritoryRepository _territoryRepository;

        public TerritoryController()
            : this(new TerritoryRepository())
        { }

        public TerritoryController(ITerritoryRepository territoryRepository)
        {
            _territoryRepository = territoryRepository;
        }

        [WebMethod (EnableSession = true)]
        public List<TerritoryViewData> GetAllParentTerritoryViewData()
        {
            return _territoryRepository.GetAllParentTerritories().ViewData();
        }

        [WebMethod (EnableSession = true)]
        public List<TerritoryViewData> GetFranchiseeTerritoryViewData(long franchiseeId)
        {
            return _territoryRepository.GetTerritoriesForFranchisee(franchiseeId).ViewData();
        }

        [WebMethod (EnableSession = true)]
        public List<Territory> GetAllTerritories()
        {
            return _territoryRepository.GetAllTerritories();
        }

        [WebMethod (EnableSession = true)]
        public List<Territory> GetFranchisorTerritories()
        {
            return _territoryRepository.GetAllParentTerritories().Where(
                                territory => territory.TerritoryType == TerritoryType.Franchisee).ToList();
        }

        [WebMethod (EnableSession = true)]
        public List<Territory> GetTerritoriesForFranchisee(long franchiseeId)
        {
            return _territoryRepository.GetTerritoriesForFranchisee(franchiseeId);
        }

        [WebMethod (EnableSession = true)]
        public List<SalesRepTerritory> GetTerritoriesForSalesRep(long salesRepId)
        {
            return _territoryRepository.GetTerritoriesForSalesRep(salesRepId);
        }

        [WebMethod (EnableSession = true)]
        public List<OrderedPair<SalesRepTerritory, SalesRepTerritoryAssignment>> GetTerritoriesAndAssignmentsForSalesRep(long salesRepId)
        {
            return _territoryRepository.GetTerritoriesForSalesRep(salesRepId).
                Select(srt => new OrderedPair<SalesRepTerritory, SalesRepTerritoryAssignment>(srt, srt.SalesRepTerritoryAssignments.
                Single(srta => srta.SalesRep.SalesRepresentativeId == salesRepId))).ToList();
        }

        [WebMethod (EnableSession = true)]
        public List<TerritoryViewData> GetChildTerritories(long parentTerritoryId)
        {
            return _territoryRepository.GetChildTerritories(parentTerritoryId).ViewData();
        }

        [WebMethod (EnableSession = true)]
        public OrderedPair<Territory, List<string>> GetTerritoryAndOwnerNames(long territoryId)
        {
            Territory territory;
            try
            {
                territory = _territoryRepository.GetTerritory(territoryId);
            }
            catch (ObjectNotFoundInPersistenceException<Territory>)
            {
                return null;
            }
            List<string> ownerNames = _territoryRepository.GetOwnerNamesForTerritory(territory);
            return new OrderedPair<Territory, List<string>>(territory, ownerNames);
        }

        [WebMethod (EnableSession = true)]
        public bool UnassignSalesRepFromTerritory(long salesRepId, long territoryId)
        {
            return _territoryRepository.UnassignSalesRepOwnerFromTerritory(salesRepId, territoryId);
        }

        [WebMethod (EnableSession = true)]
        public bool AssignSalesRepToTerritory(long salesRepId, long territoryId, RegistrationMode eventType)
        {
            return _territoryRepository.AssignSalesRepOwnerToTerritory(salesRepId, territoryId, eventType);
        }

        [WebMethod (EnableSession = true)]
        public List<TerritoryViewData> GetTerritoryViewDataAvailableForSalesRep(long franchiseeId, long salesRepId)
        {
            var territories = new List<Territory>();
            List<Territory> franchiseeTerritories = _territoryRepository.GetTerritoriesForFranchisee(franchiseeId);
            territories.AddRange(franchiseeTerritories);
            foreach (var franchiseeTerritory in franchiseeTerritories)
            {
                List<Territory> childTerritories = _territoryRepository.GetChildTerritories(franchiseeTerritory.Id);
                foreach (var childTerritory in childTerritories)
                {
                    List<Territory> grandchildTerritories = _territoryRepository.GetChildTerritories(childTerritory.Id);
                    territories.AddRange(grandchildTerritories);
                }
                territories.AddRange(childTerritories);
            }
            IEnumerable<long> assignedTerritoryIds = _territoryRepository.GetTerritoriesForSalesRep(salesRepId).Select(at => at.Id);
            return territories.Where(t => !assignedTerritoryIds.Contains(t.Id)).ViewData();
        }

        [WebMethod (EnableSession = true)]
        public bool CheckTerritoryForSalesRepByZipcode(long salesRepId, string zipCode)
        {
            List<SalesRepTerritory> salesRepTerritories = _territoryRepository.GetTerritoriesForSalesRep(salesRepId);

            if (!salesRepTerritories.IsEmpty())
            {
                var salesRepTerritory = _territoryRepository.GetTerritoriesForSalesRepByZipCode(
                    salesRepId, zipCode);
                if (!salesRepTerritory.IsEmpty())
                    return true;
                return false;
            }
            return true;
        }

        [WebMethod (EnableSession = true)]
        public bool DeleteTerritory(long territoryId)
        {
            return _territoryRepository.DeleteTerritory(territoryId);
        }

        [WebMethod (EnableSession = true)]
        public bool IsZipCodePresentInTerritory(long organizationRoleUserId, string zipCode)
        {
            return _territoryRepository.IsZipCodePresentInTerritory(organizationRoleUserId, zipCode);
        }
    }
}
