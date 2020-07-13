using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class PackageSelectionInfoEditModel
    {
        public int? Gender { get; set; }

        public DateTime? Dob { get; set; }

        public long HighBloodPressure { get; set; }

        public long Smoker { get; set; }

        public long HeartDisease { get; set; }

        public long Diabetic { get; set; }

        public long ChestPain { get; set; }

        public long DiagnosedHeartProblem { get; set; }

        public long HighCholestrol { get; set; }

        public long OverWeight { get; set; }

        public long AgeOverPreQualificationQuestion { get; set; }

        public bool SkipPreQualificationQuestion { get; set; }

        public bool ShowPreQualifiedQuestion { get; set; }

        public bool IsValueFilled
        {
            get
            {
                if (!ShowPreQualifiedQuestion && IsBasicInfoFilled)
                    return true;

                if (IsBasicInfoFilled && HighBloodPressure > 0 && Smoker > 0 && HeartDisease > 0 && Diabetic > 0 && ChestPain > 0 && DiagnosedHeartProblem > 0 && HighCholestrol > 0 && OverWeight > 0)
                    return true;

                return false;
            }
        }

        public bool IsBasicInfoFilled
        {
            get
            {
                if ((Gender.HasValue && Gender.Value > 0) && Dob.HasValue)
                    return true;

                return false;
            }
        }
    }
}
