using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportSpiroFactory : IPhysicianPartnerResultExportSpiroFactory
    {
        public PhysicianPartnerResultExportModel SetSpiroData(PhysicianPartnerResultExportModel model, SpiroTestResult testResult)
        {
            if (testResult.Finding != null) model.SpiroResult = testResult.Finding.Label;

            model.SpiroPoorEffort = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PoorEffort);
            model.SpiroRestrictive = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Restrictive);
            model.SpiroObstructive = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Obstructive);


            model.SpiroTechnicallyLimitedButReadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable);
            model.SpiroRepeatStudyUnreadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy);

            model.SpiroUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.SpiroCritical = PhysicianPartnerResultExportHelper.YesString;
            else
                model.SpiroCritical = PhysicianPartnerResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.SpiroPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
