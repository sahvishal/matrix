using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class HealthAssesmentArchiveAnswer
    {
        public HealthAssessmentAnswer HealthAssessmentAnswer { get; set; }
        public long Version { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}