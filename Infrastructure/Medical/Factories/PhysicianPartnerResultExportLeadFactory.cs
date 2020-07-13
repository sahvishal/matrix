using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportLeadFactory : IPhysicianPartnerResultExportLeadFactory
    {
        public PhysicianPartnerResultExportModel SetLeadData(PhysicianPartnerResultExportModel model, LeadTestResult testResult)
        {
            if (testResult.RightResultReadings != null)
            {
                if (testResult.RightResultReadings.Finding != null)
                    model.LeadRightResult = testResult.RightResultReadings.Finding.Label;

                if (testResult.RightResultReadings.CFAPSV != null && testResult.RightResultReadings.CFAPSV.Reading != null && testResult.RightResultReadings.CFAPSV.Reading.HasValue)
                    model.LeadRightCfaMeasurement = testResult.RightResultReadings.CFAPSV.Reading.Value.ToString("00.00");

                if (testResult.RightResultReadings.PSFAPSV != null && testResult.RightResultReadings.PSFAPSV.Reading != null && testResult.RightResultReadings.PSFAPSV.Reading.HasValue)
                    model.LeadRightPsfaMeasurement = testResult.RightResultReadings.PSFAPSV.Reading.Value.ToString("00.00");
            }

            if (testResult.LeftResultReadings != null)
            {
                if (testResult.LeftResultReadings.Finding != null)
                    model.LeadLeftResult = testResult.LeftResultReadings.Finding.Label;

                if (testResult.LeftResultReadings.CFAPSV != null && testResult.LeftResultReadings.CFAPSV.Reading != null && testResult.LeftResultReadings.CFAPSV.Reading.HasValue)
                    model.LeadLeftCfaMeasurement = testResult.LeftResultReadings.CFAPSV.Reading.Value.ToString("00.00");

                if (testResult.LeftResultReadings.PSFAPSV != null && testResult.LeftResultReadings.PSFAPSV.Reading != null && testResult.LeftResultReadings.PSFAPSV.Reading.HasValue)
                    model.LeadLeftPsfaMeasurement = testResult.LeftResultReadings.PSFAPSV.Reading.Value.ToString("00.00");
            }

            model.LeadUnuauallyLowVelocityRight = testResult.LowVelocityRight != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            model.LeadUnuauallyLowVelocityLeft = testResult.LowVelocityLeft != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            

            model.LeadTechnicallyLimitedButReadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable);
            model.LeadRepeatStudyUnreadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy);

            model.LeadUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.LeadCritical = PhysicianPartnerResultExportHelper.YesString;
            else
                model.LeadCritical = PhysicianPartnerResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.LeadPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            var leadDiagnosisCodes = new System.Collections.Generic.List<OrderedPair<string, string>>();
            if (testResult.DiagnosisCode != null)
            {
                foreach (var diagnosisCode in PhysicianPartnerResultExportHelper.LeadDiagnosisCodes)
                {
                    if (testResult.DiagnosisCode.Reading.Contains(diagnosisCode))
                        leadDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.YesString));
                    else
                        leadDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString));
                }
            }
            else
            {
                leadDiagnosisCodes.AddRange(PhysicianPartnerResultExportHelper.LeadDiagnosisCodes.Select(diagnosisCode => new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString)));
            }

            model.LeadDiagnosisCodes = leadDiagnosisCodes;

            return model;
        }
    }
}
