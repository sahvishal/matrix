using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignAcivityDetailViewModel
    {
        public Campaign Campaign { get; set; }
        public List<CampaignActivityViewModel> CampaignActivity { get; set; }
    }
}
