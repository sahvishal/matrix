using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportIfobtFactory : IPcpResultExportIfobtFactory
    {
        public PcpResultExportModel SetIfobtlobinData(PcpResultExportModel model, IFOBTTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.IfobtFinding = testResult.Finding.Label;

            model.IfobtSerialKey = GetResultReading(testResult.SerialKey);

            model.IfobtUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.IfobtCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.IfobtCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.IfobtPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }

        private string GetResultReading(ResultReading<string> reading)
        {
            return reading != null && !string.IsNullOrEmpty(reading.Reading) ? reading.Reading : "";
        }
    }
}