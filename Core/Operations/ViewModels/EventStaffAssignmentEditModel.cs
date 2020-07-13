using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventStaffAssignmentEditModel : ViewModelBase
    {
        public EventBasicInfoViewModel Event { get; set; }
        
        [DisplayName("Default Assignment (Pod based)")]
        public bool IsDefaultStaffAssignment { get; set; }

        public long ScheduledByOrgRoleId { get; set; }

        public IEnumerable<EventStaffBasicInfoModel> EventStaffAssignements { get; set; }
    }
}