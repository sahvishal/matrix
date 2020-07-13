using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IEventStaffAssignmentService
    {
        IEnumerable<EventStaffBasicInfoModel> GetEventStaffBasicInfoModel(long eventId, IEnumerable<OrderedPair<long, string>> eventPods, IEnumerable<EventStaffAssignment> eventStaffAssignments,
            IEnumerable<StaffEventRole> eventRoles, IEnumerable<PodStaff> podsStaffs, out bool isDefault);

        EventStaffAssignmentEditModel Save(EventStaffAssignmentEditModel eventStaffAssignmentEditModel);
        void Save(long eventId, long podId, long scheduledByOrgRoleId, IEnumerable<EventStaffBasicInfoModel> eventStaff);
        void SavePodDefaultTeamToEventStaff(long eventId, List<long> podIds, long scheduledByOrgRoleId);
        StaffEventScheduleUploadListModel GetStaffEventScheduleUploadDetails(int pageNumber, int pageSize, StaffEventScheduleUploadModelFilter filter, out int totalRecords);
        EventStaffAssignmentListModel GetforStaffCalendar(bool isCurrentRoleTechnician, EventStaffAssignmentListModelFilter filter = null);
    }
}