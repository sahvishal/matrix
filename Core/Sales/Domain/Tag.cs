using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class Tag : DomainObjectBase
    {
        public long Source { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsSystemDefined { get; set; }
        public bool IsActive { get; set; }

        public bool ForAppointmentConfirmation { get; set; }

        public bool? ForPreAssessment { get; set; }

        public long? CallStatus { get; set; }
        public bool ForWarmTransfer { get; set; }
        public Tag()
        { }

        public Tag(long tagId)
            : base(tagId)
        { }
    }
}
