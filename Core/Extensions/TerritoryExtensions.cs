using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Extensions
{
    // Possible ViewData extensions model:
    // Create ViewData for domain object and ".ViewData()" extension method.
    // "ViewDataExtensions" class? Tight coupling...
    public static class TerritoryExtensions
    {
        public static List<TerritoryViewData> ViewData(this IEnumerable<Territory> territories)
        {
            return territories.Select(t => new TerritoryViewData
            {
                TerritoryId = t.Id,
                ParentTerritoryId = t.ParentTerritoryId ?? 0,
                TerritoryName = t.Name,
                Description = t.Description,
                TerritoryTypeName = t.TerritoryType.ToString()
            }).ToList();
        }
    }
}