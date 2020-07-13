using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportPhq9Factory : IPcpResultExportPhq9Factory
    {
        public PcpResultExportModel SetPhq9Data(PcpResultExportModel model, Phq9TestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Phq9Score != null)
                model.Phq9Score = testResult.Phq9Score.Reading;

            model.Phq9UnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.Phq9Critical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.Phq9Critical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.Phq9PhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}