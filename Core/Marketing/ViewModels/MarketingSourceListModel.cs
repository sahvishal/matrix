using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class MarketingSourceListModel
    {
        public IEnumerable<MarketingSourceBasicModel> MarketingSourceBasicModels { get; set; }
        public MarketingSourceListModelFilter Filter { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}