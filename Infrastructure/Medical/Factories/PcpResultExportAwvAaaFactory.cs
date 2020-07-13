using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvAaaFactory : IPcpResultExportAwvAaaFactory
    {
        public PcpResultExportModel SetAwvAaaData(PcpResultExportModel model, AwvAaaTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.AaaResult = testResult.Finding.Label;

            model.AaaLargestSagittalMeasurement = testResult.AortaSize != null ? testResult.AortaSize.Reading != null ? testResult.AortaSize.Reading.ToString() : "" : "";

            model.AaaLargestSagittalLocation = string.Join(",", testResult.AortaRangeSaggitalView != null ? testResult.AortaRangeSaggitalView.Select(s => s.Label).ToArray() : new[] { "" });

            model.AaaLargestTransverseMeasurement1 = testResult.TransverseView != null ? testResult.TransverseView.FirstValue != null ? testResult.TransverseView.FirstValue.Reading.ToString() : "" : "";

            model.AaaLargestTransverseMeasurement2 = testResult.TransverseView != null ? testResult.TransverseView.SecondValue != null ? testResult.TransverseView.SecondValue.Reading.ToString() : "" : "";

            model.AaaLargestMeasurementTransverseLocation = string.Join(",", testResult.AortaRangeTransverseView != null ? testResult.AortaRangeTransverseView.Select(s => s.Label).ToArray() : new[] { "" });

            model.AaaPeakSystolicVelocityMeasurement = testResult.PeakSystolicVelocity != null ? testResult.PeakSystolicVelocity.Reading != null ? testResult.PeakSystolicVelocity.Reading.ToString() : "" : "";

            model.AaaPeakSystolicVelocityLocation = string.Join(",", testResult.PeakSystolicVelocityStandardFindings != null ? testResult.PeakSystolicVelocityStandardFindings.Select(s => s.Label).ToArray() : new[] { "" });

            model.AaaResidualLumenMeasurement1 = testResult.ResidualLumenStandardFindings != null ? testResult.ResidualLumenStandardFindings.FirstValue != null ? testResult.ResidualLumenStandardFindings.FirstValue.Reading.ToString() : "" : "";

            model.AaaResidualLumenMeasurement2 = testResult.ResidualLumenStandardFindings != null ? testResult.ResidualLumenStandardFindings.SecondValue != null ? testResult.ResidualLumenStandardFindings.SecondValue.Reading.ToString() : "" : "";

            model.AaaAorticDissection = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AorticDissection, useBlankValue);

            model.AaaPlaque = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Plaque, useBlankValue);

            model.AaaThrombus = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Thrombus, useBlankValue);

            if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.Count > 0)
                model.AaaAorticStenosis = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.AaaAorticStenosis = PcpResultExportHelper.NoString;

            model.AaaTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.AaaRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            model.AaaUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.AaaCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.AaaCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.AaaPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
