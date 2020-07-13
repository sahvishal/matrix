using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class UpdatePublishedCampaignEditModel : ViewModelBase
    {
        public long CampaignId { get; set; }
        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }      
    }
}
