namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventStaffBasicInfoModel
    {
        public long ScheduledStaffOrgRoleUserId { get; set; }
        public long? ActualStaffOrgRoleUserId { get; set; }
        public string FullName { get; set; }
        public long EventRoleId { get; set; }
        public string EventRole { get; set; }
        public string Notes { get; set; }
        public long PodId { get; set; }
        public string EmployeeId { get; set; }
    }
}