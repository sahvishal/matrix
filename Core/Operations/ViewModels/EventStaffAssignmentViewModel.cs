using System.Collections.Generic;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventStaffAssignmentViewModel
    {
        public EventBasicInfoViewModel Event { get; set; }                
        public IEnumerable<EventStaffBasicInfoModel> AssignedStaff { get; set; }
        public bool IsDefaultStaffAssignment { get; set; }
                
    }
}