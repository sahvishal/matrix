using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssessmentTemplate : DomainObjectBase
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPublished { get; set; }
        public bool IsActive { get; set; }
        public long? TemplateType { get; set; }
        public DateTime? PublicationDate { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }
        public IEnumerable<long> QuestionIds { get; set; }
        public long Category { get; set; }
        public string Notes { get; set; }
    }
}
