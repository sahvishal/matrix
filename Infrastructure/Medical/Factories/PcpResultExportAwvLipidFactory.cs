using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvLipidFactory : IPcpResultExportAwvLipidFactory
    {
        public PcpResultExportModel SetAwvLipidData(PcpResultExportModel model, AwvLipidTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.TotalCholestrol != null)
            {
                if (testResult.TotalCholestrol.Reading != null)
                    model.AwvLipidTotalCholesterol = testResult.TotalCholestrol.Reading;

                if (testResult.TotalCholestrol.Finding != null)
                    model.AwvLipidTotalCholesterolFinding = testResult.TotalCholestrol.Finding.Label;
            }
            if (testResult.HDL != null)
            {
                if (testResult.HDL.Reading != null)
                    model.AwvLipidHdl = testResult.HDL.Reading;

                if (testResult.HDL.Finding != null)
                    model.AwvLipidHdlFinding =
                        testResult.HDL.Finding.Label.Replace("Male", "").Replace("Female", "").Replace("-", "").Trim();
            }

            if (testResult.LDL != null)
            {
                if (testResult.LDL.Reading != null)
                    model.AwvLipidLdl = testResult.LDL.Reading.ToString();

                if (testResult.LDL.Finding != null)
                    model.AwvLipidLdlFinding = testResult.LDL.Finding.Label;
            }

            if (testResult.TriGlycerides != null)
            {
                if (testResult.TriGlycerides.Reading != null)
                    model.AwvLipidTriGlycerides = testResult.TriGlycerides.Reading;

                if (testResult.TriGlycerides.Finding != null)
                    model.AwvLipidTriglyceridesFinding = testResult.TriGlycerides.Finding.Label;
            }

            if (testResult.TCHDLRatio != null)
            {
                if (testResult.TCHDLRatio.Reading != null && testResult.TCHDLRatio.Reading.HasValue)
                    model.AwvLipidTchdlRatio = testResult.TCHDLRatio.Reading.Value.ToString("0.0");

                if (testResult.TCHDLRatio.Finding != null)
                    model.AwvLipidTcHdlFinding = testResult.TCHDLRatio.Finding.Label;
            }

            if (testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0)
                model.AwvLipidUnabletoScreen = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.AwvLipidUnabletoScreen = PcpResultExportHelper.NoString;

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.AwvLipidCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.AwvLipidCritical = PcpResultExportHelper.NoString;

            return model;
        }


    }
}