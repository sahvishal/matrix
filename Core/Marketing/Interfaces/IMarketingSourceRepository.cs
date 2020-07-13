using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Marketing.Interfaces
{
    public interface IMarketingSourceRepository
    {
        List<string> GetAll();
        IEnumerable<string> GetMarketingSourceByTerritory(long[] territoryId, bool showOnline = false);
        void DeleteMarketingSourceTerritories(long marketingSourceId);
        IEnumerable<MarketingSource> GetPagedRecords(int pageNumber, int pageSize, MarketingSourceListModelFilter filter, out int totalRecords);
        void SaveMarketingSourceTerritories(long marketingSourceId, IEnumerable<long> territoryIds);
        IEnumerable<OrderedPair<long, long>> GetMarketingSourceTerritories(IEnumerable<long> marketingSourceIds);
        void Deactivate(long marketingSourceId);
        IEnumerable<string> GetGlobalMarketingSources(bool showOnline = false);
    }
}
