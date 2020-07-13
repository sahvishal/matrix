using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class WellnessSeminar : DomainObjectBase
    {
        public long EventId { get; set; }
        public long SalesRepId { get; set; }
        public long HostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public DateTime SeminarDate { get; set; }
        public Address Address { get; set; }
        public DateTime SeminarStartTime { get; set; }
        public DateTime SeminarEndTime { get; set; }
        public int AttendedCount { get; set; }
        public string OrganizationName { get; set; }
        public WorkshopsType SeminarType { get; set; }

        public WellnessSeminar()
        { }

        public WellnessSeminar(long seminarId)
            : base(seminarId)
        { }
    }
}