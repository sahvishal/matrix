using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportVisionFactory : IPcpResultExportVisionFactory
    {
        public PcpResultExportModel SetVisionData(PcpResultExportModel model, VisionTestResult testResult, bool useBlankValue = false)
        {
            var rightEyeCylindrical = (testResult.RightEyeCylindrical != null && testResult.RightEyeCylindrical.Reading.HasValue)
                ? testResult.RightEyeCylindrical.Reading.Value.ToString()
                : "";

            var rightEyeSpherical = (testResult.RightEyeSpherical != null && testResult.RightEyeSpherical.Reading.HasValue)
                ? testResult.RightEyeSpherical.Reading.Value.ToString()
                : "";

            model.VisionLevelRightEye = rightEyeCylindrical + "/" + rightEyeSpherical;

            var leftEyeCylindrical = (testResult.LeftEyeCylindrical != null && testResult.LeftEyeCylindrical.Reading.HasValue)
                ? testResult.LeftEyeCylindrical.Reading.Value.ToString()
                : "";

            var leftEyeSpherical = (testResult.LeftEyeSpherical != null && testResult.LeftEyeSpherical.Reading.HasValue)
                ? testResult.LeftEyeSpherical.Reading.Value.ToString()
                : "";

            model.VisionLevelLeftEye = leftEyeCylindrical + "/" + leftEyeSpherical;

            model.VisionUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.VisionCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.VisionCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.VisionPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
