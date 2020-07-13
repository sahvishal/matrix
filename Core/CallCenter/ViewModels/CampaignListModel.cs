using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignListModel
    {
        public IEnumerable<CampaignViewModel> Collection { get; set; }
        public CampaignListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
