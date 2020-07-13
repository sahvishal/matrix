using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo
{
    public interface ITerritoryZipCodeUpdater
    {
        IEnumerable<Territory> GetAllChildrenWithZipCodes(IEnumerable<ZipCode> zipCodes, long parentTerritoryId);
        void RemoveZipCodesFromTerritories(IEnumerable<ZipCode> zipCodesToRemove, IEnumerable<Territory> territoriesToUpdate);
    }
}