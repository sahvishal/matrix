using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    public class PcpResultExportOsteoporosisFactory : IPcpResultExportOsteoporosisFactory
    {
        public PcpResultExportModel SetOsteoporosisData(PcpResultExportModel model, OsteoporosisTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.EstimatedTScore != null)
            {
                if (testResult.EstimatedTScore.Reading != null)
                    model.BoneMassEstimatedTScore = testResult.EstimatedTScore.Reading.Value.ToString();

                if (testResult.EstimatedTScore.Finding != null)
                    model.BoneMassResult = testResult.EstimatedTScore.Finding.Label;
            }

            model.BoneMassUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.BoneMassCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.BoneMassCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.BoneMassPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}