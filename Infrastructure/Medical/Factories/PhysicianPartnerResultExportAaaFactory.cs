using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportAaaFactory : IPhysicianPartnerResultExportAaaFactory
    {
        public PhysicianPartnerResultExportModel SetAaaData(PhysicianPartnerResultExportModel model, PpAaaTestResult testResult)
        {

            if (testResult.Finding != null) model.AaaResult = testResult.Finding.Label;

            model.AaaLargestSagittalMeasurement = testResult.AortaSize != null ? testResult.AortaSize.Reading != null ? testResult.AortaSize.Reading.ToString() : "" : "";

            model.AaaLargestSagittalLocation = string.Join(",", testResult.AortaRangeSaggitalView != null ? testResult.AortaRangeSaggitalView.Select(s => s.Label).ToArray() : new[] { "" });


            model.AaaLargestTransverseMeasurement1 = testResult.TransverseView != null ? testResult.TransverseView.FirstValue != null ? testResult.TransverseView.FirstValue.Reading.ToString() : "" : "";

            model.AaaLargestTransverseMeasurement2 = testResult.TransverseView != null ? testResult.TransverseView.SecondValue != null ? testResult.TransverseView.SecondValue.Reading.ToString() : "" : "";


            model.AaaLargestMeasurementTransverseLocation = string.Join(",", testResult.AortaRangeTransverseView != null ? testResult.AortaRangeTransverseView.Select(s => s.Label).ToArray() : new[] { "" });


            model.AaaAorticDissection = testResult.AorticDissection != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            model.AaaPlaque = testResult.Plaque != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            model.AaaThrombus = testResult.Thrombus != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count > 0)
                model.AaaAorticStenosis = PhysicianPartnerResultExportHelper.YesString;
            else
                model.AaaAorticStenosis = PhysicianPartnerResultExportHelper.NoString;

            model.AaaTechnicallyLimitedButReadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable);
            model.AaaRepeatStudyUnreadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy);

            model.AaaUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.AaaCritical = PhysicianPartnerResultExportHelper.YesString;
            else
                model.AaaCritical = PhysicianPartnerResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.AaaPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            var aaaDiagnosisCodes = new System.Collections.Generic.List<OrderedPair<string, string>>();
            if (testResult.DiagnosisCode != null)
            {
                foreach (var diagnosisCode in PhysicianPartnerResultExportHelper.AaaDiagnosisCodes)
                {
                    if (testResult.DiagnosisCode.Reading.Contains(diagnosisCode))
                        aaaDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.YesString));
                    else
                        aaaDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString));
                }
            }
            else
            {
                aaaDiagnosisCodes.AddRange(PhysicianPartnerResultExportHelper.AaaDiagnosisCodes.Select(diagnosisCode => new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString)));
            }

            model.AaaDiagnosisCodes = aaaDiagnosisCodes;

            return model;
        }
    }
}
