using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportDiabeticNeuropathyFactory : IPcpResultExportDiabeticNeuropathyFactory
    {
        public PcpResultExportModel SetDiabeticNeuropathyData(PcpResultExportModel model, DiabeticNeuropathyTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.DiabeticNeuropathyResult = testResult.Finding.Label;

            model.DiabeticNeuropathyAmplitude = testResult.Amplitude != null ? testResult.Amplitude.Reading != null ? testResult.Amplitude.Reading.ToString() : "" : "";
            model.DiabeticNeuropathyConductionVelocity = testResult.ConductionVelocity != null ? testResult.ConductionVelocity.Reading != null ? testResult.ConductionVelocity.Reading.ToString() : "" : "";

            model.DiabeticNeuropathyRightLeg = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightLeg, useBlankValue);
            model.DiabeticNeuropathyLeftLeg = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftLeg, useBlankValue);

            model.DiabeticNeuropathyUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            model.DiabeticNeuropathyTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.DiabeticNeuropathyRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);


            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.DiabeticNeuropathyCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.DiabeticNeuropathyCritical = PcpResultExportHelper.NoString;

            return model;
        }
    }
}