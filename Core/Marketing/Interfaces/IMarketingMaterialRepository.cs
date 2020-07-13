using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IMarketingMaterialRepository
    {
        MarketingMaterial GetMarketingMaterialById(long id);
        List<MarketingMaterial> GetMarketingMaterialsByIds(List<long> ids);

        MarketingMaterial SaveMarketingMaterial(MarketingMaterial mm);
        void DeleteMarketingMaterial(MarketingMaterial mm);
    }
}