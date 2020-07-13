using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class EventCustomerDiagnosis : DomainObjectBase
    {
        public long EventCustomerId { get; set; }
        public string Diagnosis { get; set; }
        public bool Accepted { get; set; }
        public string ClinicalMonitor { get; set; }
        public string ClinicalEvaluation { get; set; }
        public string ClinicalAssessment { get; set; }
        public string ClinicalTreatment { get; set; }
        public string ClinicalComment { get; set; }
        public string Icd { get; set; }
        public bool IsIcd10 { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
