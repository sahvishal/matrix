using System;
using System.Collections.Generic;
namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CampaignType { get; set; }
        public string CampaignMode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPublish { get; set; }
        public long RegisteredCustomerCount { get; set; }
        public long ReceivedCallCount { get; set; }
        public long DirectMailCount { get; set; }
        public long EmailCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy{ get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string CorporateAccount { get; set; }
        public string CustomTags { get; set; }
        public List<CampaignActivityViewModel> CampaignActivity { get; set; }
    }
}
