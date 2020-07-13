namespace Falcon.App.Core.Scheduling.Domain
{
    public class EventHospitalPartner
    {
        public long EventId { get; set; }
        public long HospitalPartnerId { get; set; }
        public bool AttachHospitalMaterial { get; set; }
        public bool CaptureSsn { get; set; }
        public bool RestrictEvaluation { get; set; }
    }
}
