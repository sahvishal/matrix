using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestPerformedExternally : DomainObjectBase
    {
        public long CustomerEventScreeningTestId { get; set; }
        public bool EntryCompleted { get; set; }
        public long ResultEntryTypeId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}