using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventStaffAssignmentListModel : ViewModelBase
    {
        public IEnumerable<EventStaffAssignmentViewModel> StaffEventAssignments { get; set; }
        public EventStaffAssignmentListModelFilter Filter { get; set; }

        public string SelectedPod { get; set; }
        public string SelectedStaff { get; set; }
        
        public EventStaffAssignmentListModel()
        {
            Filter = new EventStaffAssignmentListModelFilter();
        }

        public EventStaffAssignmentListModel(EventStaffAssignmentListModelFilter filter)
        {
            Filter = filter;
        }

    }
}