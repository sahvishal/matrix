namespace Falcon.App.Core.Operations.ViewModels
{
    public class AssignedPhysicianViewModel
    {
        public AssignedPhysicianBasicInfoModel Primary { get; set; }
        public AssignedPhysicianBasicInfoModel Overread { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool IsDefaultAssignment { get; set; }
        public long EventCustomerId { get; set; }
    }
}