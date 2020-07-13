using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class PreQualificationQuestion : DomainObjectBase
    {
        public string Question { get; set; }
        public long TestId { get; set; }
        public string ControlValues { get; set; }
        public string ControlValueDelimiter { get; set; }
        public bool IsActive { get; set; }
        public int Index { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DisqualifiedReason { get; set; }
        public long? ParentId { get; set; }
        public long? TypeId { get; set; } 
    }
}
