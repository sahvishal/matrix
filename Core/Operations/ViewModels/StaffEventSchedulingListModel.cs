using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventSchedulingListModel : ListModelBase<StaffEventSchedulingModel, EventStaffAssignmentListModelFilter>
    {
        public override IEnumerable<StaffEventSchedulingModel> Collection { get; set; }

        public override EventStaffAssignmentListModelFilter Filter { get; set; }
    }
}
