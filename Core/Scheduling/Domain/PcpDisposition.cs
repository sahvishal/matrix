using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class PcpDisposition : DomainObjectBase
    {
        public long PcpDispositionId { get; set; }
        public long EventCustomerId { get; set; }
        public PcpAppointmentDisposition Disposition { get; set; }
        public string Notes { get; set; }
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
    }
}
