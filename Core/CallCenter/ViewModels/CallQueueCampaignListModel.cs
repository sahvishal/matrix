using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallQueueCampaignListModel
    {
        public IEnumerable<CampaignBasicInfo> Campaign { get; set; }
        public CampaignCallQueueFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}