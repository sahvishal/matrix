using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportFlushotFactory : IPcpResultExportFlushotFactory
    {
        public PcpResultExportModel SetAwvFluShotData(PcpResultExportModel model, AwvFluShotTestResult testResult, bool useBlankValue = false)
        {

            model.FluShotLotNumber = GetResultReading(testResult.LotNumber);
            model.FluShotManufacturer = GetResultReading(testResult.Manufacturer);

            model.FluShotUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.FluShotCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.FluShotCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.FluShotPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }

        public PcpResultExportModel SetFluShotData(PcpResultExportModel model, FluShotTestResult testResult, bool useBlankValue = false)
        {

            model.FluShotLotNumber = GetResultReading(testResult.LotNumber);
            model.FluShotManufacturer = GetResultReading(testResult.Manufacturer);

            model.FluShotUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.FluShotCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.FluShotCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.FluShotPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }

        private string GetResultReading(ResultReading<string> reading)
        {
            return reading != null && !string.IsNullOrEmpty(reading.Reading) ? reading.Reading : "";
        }
    }
}