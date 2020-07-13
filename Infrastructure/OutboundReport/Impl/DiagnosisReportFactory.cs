using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.ViewModels;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class DiagnosisReportFactory : IDiagnosisReportFactory
    {
        public EventCustomerDiagnosis Create(DiagnosisReportViewModel model, long eventCustomerId)
        {
            return new EventCustomerDiagnosis
            {
                EventCustomerId = eventCustomerId,
                Diagnosis = model.Diagnosis,
                Accepted = model.Accepted,
                ClinicalMonitor = model.ClinicalMonitor,
                ClinicalEvaluation = model.ClinicalEvaluation,
                ClinicalAssessment = model.ClinicalAssessment,
                ClinicalTreatment = model.ClinicalTreatment,
                ClinicalComment = model.ClinicalComment,
                Icd = model.Icd,
                IsIcd10 = true,
                DateCreated = DateTime.Now
            };
        }
    }
}
