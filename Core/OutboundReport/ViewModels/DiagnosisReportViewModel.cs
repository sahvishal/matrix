namespace Falcon.App.Core.OutboundReport.ViewModels
{
    public class DiagnosisReportViewModel
    {
        public string CustomerId { get; set; }

        public string EventId { get; set; }

        public string Diagnosis { get; set; }

        public bool Accepted { get; set; }

        public string ClinicalMonitor { get; set; }

        public string ClinicalEvaluation { get; set; }

        public string ClinicalAssessment { get; set; }

        public string ClinicalTreatment { get; set; }

        public string ClinicalComment { get; set; }

        public string Icd { get; set; }

        public string IsIcd10 { get; set; }
    }
}
