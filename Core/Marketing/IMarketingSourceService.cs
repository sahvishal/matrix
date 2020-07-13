using System.Collections.Generic;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Marketing
{
    public interface IMarketingSourceService
    {
        MarketingSourceEditModel Save(MarketingSourceEditModel model);
        MarketingSourceEditModel Get(long id);
        MarketingSourceListModel GetPagedRecords(int pageNumber, int pageSize, MarketingSourceListModelFilter filter ,out int totalRecords);
        IEnumerable<string> FetchMarketingSourceByZip(string zipCode, bool showOnline = false);
        void Delete(long id);
    }
}