using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportDpnFactory : IPcpResultExportDpnFactory
    {
        public PcpResultExportModel SetDpnData(PcpResultExportModel model, DpnTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.DpnResult = testResult.Finding.Label;

            model.DpnAmplitude = testResult.Amplitude != null ? testResult.Amplitude.Reading != null ? testResult.Amplitude.Reading.ToString() : "" : "";
            model.DpnConductionVelocity = testResult.ConductionVelocity != null ? testResult.ConductionVelocity.Reading != null ? testResult.ConductionVelocity.Reading.ToString() : "" : "";

            model.DpnRightLeg = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightLeg, useBlankValue);
            model.DpnLeftLeg = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftLeg, useBlankValue);

            model.DpnUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.DpnCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.DpnCritical = PcpResultExportHelper.NoString;

            return model;
        }
    }
}