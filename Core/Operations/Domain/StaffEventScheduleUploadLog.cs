using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class StaffEventScheduleUploadLog : DomainObjectBase
    {
        public long UploadId { get; set; }
        public string StaffName { get; set; }
        public string EmployeeId { get; set; }
        public string Pod { get; set; }
        public string Role { get; set; }
        public string EventDate { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
