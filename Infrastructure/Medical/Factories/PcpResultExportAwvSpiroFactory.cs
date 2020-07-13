using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvSpiroFactory : IPcpResultExportAwvSpiroFactory
    {
        public PcpResultExportModel SetAwvSpiroData(PcpResultExportModel model, AwvSpiroTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.SpirometryResult = testResult.Finding.Label;

            model.SpirometryIncidentalFindingRestrictive = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Restrictive, useBlankValue);
            model.SpirometryIncidentalFindingObstructive = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Obstructive,useBlankValue);
            model.SpirometryPoorEffort = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PoorEffort, useBlankValue);

            model.SpirometryTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.SpirometryRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            model.SpirometryUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.SpirometryCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.SpirometryCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.SpirometryPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
