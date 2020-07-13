using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestNotPerformed : DomainObjectBase
    {
        public long CustomerEventScreeningTestId { get; set; }
        public long TestNotPerformedReasonId { get; set; }
        public string Notes { get; set; }
        public bool IsManual { get; set; }
        public DataRecorderMetaData RecorderMetaData { get; set; }
    }
}