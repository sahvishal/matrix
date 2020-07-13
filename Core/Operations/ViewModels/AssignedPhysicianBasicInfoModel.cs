namespace Falcon.App.Core.Operations.ViewModels
{
    public class AssignedPhysicianBasicInfoModel
    {
        public long PhysicianId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public bool IsOverReadPhysician { get; set; }
    }
}
