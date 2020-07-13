using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportUrineMicroalbuminFactory : IPcpResultExportUrineMicroalbuminFactory
    {
        public PcpResultExportModel SetUrineMicroalbuminData(PcpResultExportModel model, UrineMicroalbuminTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.UrineMicroalbuminResult = testResult.Finding.Label;

            model.UrineMicroalbuminSerialKey = GetResultReading(testResult.SerialKey);
            model.UrineMicroalbuminValue = GetOutputFromNullableStringResultReading(testResult.MicroalbuminValue);

            model.UrineMicroalbuminTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.UrineMicroalbuminRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            model.UrineMicroalbuminUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.UrineMicroalbuminCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.UrineMicroalbuminCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.UrineMicroalbuminPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }

        private string GetResultReading(ResultReading<string> reading)
        {
            return reading != null && !string.IsNullOrEmpty(reading.Reading) ? reading.Reading : "";
        }

        //private string GetOutputFromNullableDecimalResultReading(ResultReading<decimal?> reading)
        //{
        //    return reading != null && reading.Reading.HasValue ? reading.Reading.Value.ToString() : "";
        //}
        private string GetOutputFromNullableStringResultReading(ResultReading<string> reading)
        {
            return reading != null && reading.Reading != "" ? reading.Reading.ToString() : string.Empty;
        }

    }
}