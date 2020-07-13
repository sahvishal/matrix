using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvAbiFactory : IPcpResultExportAwvAbiFactory
    {
        public PcpResultExportModel SetAwvAbiData(PcpResultExportModel model, AwvAbiTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.AbiResult = testResult.Finding.Label;

            model.AbiSystolicRArm = testResult.RightResultReadings != null ? testResult.RightResultReadings.SystolicArm != null ? testResult.RightResultReadings.SystolicArm.Reading.ToString() : "" : "";
            model.AbiSystolicRAnkle = testResult.RightResultReadings != null ? testResult.RightResultReadings.SystolicAnkle != null ? testResult.RightResultReadings.SystolicAnkle.Reading.ToString() : "" : "";
            model.AbiRightAbi = testResult.RightResultReadings != null ? testResult.RightResultReadings.ABI != null ? testResult.RightResultReadings.ABI.Reading.ToString() : "" : "";

            model.AbiSystolicLArm = testResult.LeftResultReadings != null ? testResult.LeftResultReadings.SystolicArm != null ? testResult.LeftResultReadings.SystolicArm.Reading.ToString() : "" : "";
            model.AbiSystolicLAnkle = testResult.LeftResultReadings != null ? testResult.LeftResultReadings.SystolicAnkle != null ? testResult.LeftResultReadings.SystolicAnkle.Reading.ToString() : "" : "";
            model.AbiLeftAbi = testResult.LeftResultReadings != null ? testResult.LeftResultReadings.ABI != null ? testResult.LeftResultReadings.ABI.Reading.ToString() : "" : "";
             
            model.AbiRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy);

            model.AbiUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.AbiCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.AbiCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.AbiPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
