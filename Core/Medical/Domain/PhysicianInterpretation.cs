using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianInterpretation : DomainObjectBase
    {
        public string Remarks { get; set; }
        public bool IsCritical { get; set; }
        public bool FollowUp { get; set; }

        public DataRecorderMetaData RecorderMetaData { get; set; }

        public PhysicianInterpretation()
        { }

        public PhysicianInterpretation(long id)
            : base(id)
        { }
    }
}