using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo.Impl
{
    public class TerritoryZipCodeUpdater : ITerritoryZipCodeUpdater
    {
        private readonly ITerritoryRepository _territoryRepository;

        public TerritoryZipCodeUpdater(ITerritoryRepository territoryRepository)
        {
            _territoryRepository = territoryRepository;
        }

        public IEnumerable<Territory> GetAllChildrenWithZipCodes(IEnumerable<ZipCode> zipCodes, long parentTerritoryId)
        {
            List<ZipCode> uncheckedZipCodes = zipCodes.ToList();
            List<Territory> childTerritories = _territoryRepository.GetChildTerritories(parentTerritoryId);
            var childTerritoriesWithSpecifiedZipCodes = new List<Territory>();
            foreach (var childTerritory in childTerritories)
            {
                foreach (var zipCode in childTerritory.ZipCodes)
                {
                    if (uncheckedZipCodes.Contains(zipCode))
                    {
                        childTerritoriesWithSpecifiedZipCodes.Add(childTerritory);
                        childTerritoriesWithSpecifiedZipCodes.AddRange(GetAllChildrenWithZipCodes(uncheckedZipCodes, childTerritory.Id));
                        uncheckedZipCodes.Remove(zipCode);
                        break;
                    }
                }
            }
            return childTerritoriesWithSpecifiedZipCodes;
        }

        public void RemoveZipCodesFromTerritories(IEnumerable<ZipCode> zipCodesToRemove, IEnumerable<Territory> territoriesToUpdate)
        {
            foreach (var childTerritory in territoriesToUpdate)
            {
                childTerritory.ZipCodes = childTerritory.ZipCodes.Except(zipCodesToRemove).ToList();
                _territoryRepository.SaveTerritory(childTerritory);
            }
        }
    }
}