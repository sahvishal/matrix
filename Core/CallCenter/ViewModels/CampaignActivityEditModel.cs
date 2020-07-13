using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CampaignActivityEditModel : ViewModelBase
    {
        public long ActivityId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string Name { get; set; }
        public long ActivityType { get; set; }

        public long DirectMailType { get; set; }
        public int Sequence { get; set; }
        public bool IsNew { get; set; }
        public bool IsValid { get; set; }
        public bool IsForValidate { get; set; }

        public DateTime? CampaignStartDate { get; set; }
        public DateTime? CampaignEndDate { get; set; }
        public IEnumerable<CampaignActivityAssignmentEditModel> Assignments { get; set; }
        public long CampaigndId { get; set; }

        public bool ActivityEditMode { get; set; }
    }
}