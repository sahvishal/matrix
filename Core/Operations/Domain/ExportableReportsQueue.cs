using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class ExportableReportsQueue : DomainObjectBase
    {
        public long ReportId { get; set; }
        public string FilterData { get; set; }
        public long RequestedBy { get; set; }
        public DateTime RequestedOn { get; set; }
        public long? FileId { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }
        public long StatusId { get; set; }

    }
}
