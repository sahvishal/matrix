using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class PreQualificationTestTemplate : DomainObjectBase
    {
        public string TemplateName { get; set; }
        public long TestId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
