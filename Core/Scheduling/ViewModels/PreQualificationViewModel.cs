using System;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class PreQualificationViewModel
    {
        public string Guid { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public long? HighBloodPressure { get; set; }
        public long? Smoker { get; set; }
        public long? HeartDisease { get; set; }
        public long? Diabetic { get; set; }
        public long? ChestPain { get; set; }
        public long? DiagnosedHeartProblem { get; set; }
        public long? HighCholestrol { get; set; }
        public long? OverWeight { get; set; }
        public bool SkipPreQualificationQuestion { get; set; }
        public bool AgreedWithPrequalificationQuestion { get; set; }
        public bool AskPreQualificationQuestion { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
    }
}
