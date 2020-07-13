using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportLeadFactory : IPcpResultExportLeadFactory
    {
        public PcpResultExportModel SetLeadData(PcpResultExportModel model, LeadTestResult testResult, IEnumerable<ResultReading<int>> readings, bool useBlankValue = false)
        {
            if (testResult.RightResultReadings != null)
            {
                model.LeadRightCfaPsv = GetOutputFromNullableDecimalResultReading(testResult.RightResultReadings.CFAPSV);
                model.LeadRightPsfaPsv = GetOutputFromNullableDecimalResultReading(testResult.RightResultReadings.PSFAPSV);

                model.LeadRightNoVisualPlaque = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightResultReadings.NoVisualPlaque, useBlankValue);
                model.LeadRightVisuallyDemonstratedPlaque = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightResultReadings.VisuallyDemonstratedPlaque, useBlankValue);
                model.LeadRightModerateStenosis = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightResultReadings.ModerateStenosis, useBlankValue);
                model.LeadRightPossibleOcclusion = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.RightResultReadings.PossibleOcclusion, useBlankValue);
            }

            if (testResult.LeftResultReadings != null)
            {
                model.LeadLeftCfaPsv = GetOutputFromNullableDecimalResultReading(testResult.LeftResultReadings.CFAPSV);
                model.LeadLeftPsfaPsv = GetOutputFromNullableDecimalResultReading(testResult.LeftResultReadings.PSFAPSV);

                model.LeadLeftNoVisualPlaque = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftResultReadings.NoVisualPlaque, useBlankValue);
                model.LeadLeftVisuallyDemonstratedPlaque = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftResultReadings.VisuallyDemonstratedPlaque, useBlankValue);
                model.LeadLeftModerateStenosis = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftResultReadings.ModerateStenosis, useBlankValue);
                model.LeadLeftPossibleOcclusion = PcpResultExportHelper.GetOutputFromNullableBoolTypeResultReading(testResult.LeftResultReadings.PossibleOcclusion, useBlankValue);
            }

            model.LeadResult = GetLeadResult(testResult, readings);

            model.LeadRightLowVelocity = testResult.LowVelocityRight != null ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            model.LeadLeftLowVelocity = testResult.LowVelocityLeft != null ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);


            model.LeadUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.LeadCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.LeadCritical = PcpResultExportHelper.NoString;

            model.LeadTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.LeadRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);

            if (testResult.PhysicianInterpretation != null)
                model.LeadPhysicianNotes = testResult.PhysicianInterpretation.Remarks;


            return model;
        }

        private string GetLeadResult(LeadTestResult testResult, IEnumerable<ResultReading<int>> readings)
        {
            var readingLabel = string.Empty;
            if (testResult.LeftResultReadings != null && testResult.RightResultReadings != null)
            {

                var leftResultReadings = testResult.LeftResultReadings;
                var rightResultReading = testResult.RightResultReadings;

                if ((leftResultReadings.NoVisualPlaque != null && leftResultReadings.NoVisualPlaque.Reading != null) || (rightResultReading.NoVisualPlaque != null && rightResultReading.NoVisualPlaque.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftNoVisualPlaque);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.VisuallyDemonstratedPlaque != null && leftResultReadings.VisuallyDemonstratedPlaque.Reading != null) || (rightResultReading.VisuallyDemonstratedPlaque != null && rightResultReading.VisuallyDemonstratedPlaque.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftVisuallyDemonstratedPlaque);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.ModerateStenosis != null && leftResultReadings.ModerateStenosis.Reading != null) || (rightResultReading.ModerateStenosis != null && rightResultReading.ModerateStenosis.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftModerateStenosis);
                    readingLabel = reading.LableText;
                }

                if ((leftResultReadings.PossibleOcclusion != null && leftResultReadings.PossibleOcclusion.Reading != null) || (rightResultReading.PossibleOcclusion != null && rightResultReading.PossibleOcclusion.Reading != null))
                {
                    var reading = readings.First(x => x.Label == ReadingLabels.LeftPossibleOcclusion);
                    readingLabel = reading.LableText;
                }
            }

            return readingLabel;
        }

        private string GetOutputFromNullableDecimalResultReading(ResultReading<decimal?> reading)
        {
            return reading != null && reading.Reading.HasValue ? reading.Reading.Value.ToString() : "";
        }
        
    }
}