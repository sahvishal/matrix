using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportQualityMeasuresFactory : IPcpResultExportQualityMeasuresFactory
    {
        public PcpResultExportModel SetQualityMeasuresData(PcpResultExportModel model, QualityMeasuresTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.FunctionalAssessmentScore != null)
                model.QualityMeasuresFunctionalAssessmentScore = testResult.FunctionalAssessmentScore.Label;

            if (testResult.PainAssessmentScore != null)
                model.QualityMeasuresPainAssessmentScore = testResult.PainAssessmentScore.Label;
            
            if (testResult.MemoryRecallScore != null)
                model.QualityMeasuresMemoryRecallScore = testResult.MemoryRecallScore.Reading.HasValue ? testResult.MemoryRecallScore.Reading.Value.ToString() : string.Empty;

            if (testResult.ClockFail != null && testResult.ClockFail.Reading)
                model.QualityMeasuresClock = "Fail";

            if (testResult.ClockPass != null && testResult.ClockPass.Reading)
                model.QualityMeasuresClock = "Pass";

            if (testResult.GaitFail != null && testResult.GaitFail.Reading)
                model.QualityMeasuresGait = "Fail";

            if (testResult.GaitPass != null && testResult.GaitPass.Reading)
                model.QualityMeasuresGait = "Pass";


            model.QualityMeasuresUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.QualityMeasuresCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.QualityMeasuresCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.QualityMeasuresPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}