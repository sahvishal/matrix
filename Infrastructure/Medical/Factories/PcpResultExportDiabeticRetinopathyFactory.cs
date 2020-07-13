using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportDiabeticRetinopathyFactory : IPcpResultExportDiabeticRetinopathyFactory
    {
        public PcpResultExportModel SetDiabeticRetinopathyData(PcpResultExportModel model, DiabeticRetinopathyTestResult testResult, bool useBlankValue = false)
        {
            //model.DiabeticRetinopathyLevel = GetOutputFromStandaredFinding(testResult.DiabeticRetinopathyLevel);
            //model.DiabeticRetinopathyMacularEdemaLevel = GetOutputFromStandaredFinding(testResult.MacularEdemaLevel);

            //model.DiabeticRetinopathyHasSuspectedVeinOcclusion = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedVeinOcclusion, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedWetAmd = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedWetAmd, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedDryAmd = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedDryAmd, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedHtnRetinopathy = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedHtnRetinopathy, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedEpiretinalMembrane = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedEpiretinalMembrane, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedMacularHole = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedMacularHole, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedCataract = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedCataract, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedOtherDisease = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedOtherDisease, useBlankValue);
            //model.DiabeticRetinopathyHasSuspectedGlaucoma = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SuspectedGlaucoma, useBlankValue);

            //model.DiabeticRetinopathyTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            //model.DiabeticRetinopathyRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            //model.DiabeticRetinopathyUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            //if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
            //    model.DiabeticRetinopathyCritical = PcpResultExportHelper.YesString;
            //else if(!useBlankValue)
            //    model.DiabeticRetinopathyCritical = PcpResultExportHelper.NoString;

            //if (testResult.PhysicianInterpretation != null)
            //    model.DiabeticRetinopathyPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }

        private string GetOutputFromStandaredFinding(StandardFinding<int> finding)
        {
            return finding != null ? finding.Label : string.Empty;
        }
    }
}