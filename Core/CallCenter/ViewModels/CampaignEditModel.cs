using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignEditModel : ViewModelBase
    {
        public long CampaignId { get; set; }
        public string Name { get; set; }
        public string CampaignCode { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long TypeId { get; set; }
        public long ModeId { get; set; }
        public long AccountId { get; set; }
        public string[] CustomTags { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<CampaignActivityEditModel> CampaignActivity { get; set; }
        public IEnumerable<CampaignAssignmentEditModel> Assignments { get; set; }
    }
}
