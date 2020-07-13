using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Scheduling.Domain
{
    public class PreQualificationResult : DomainObjectBase
    {
        public long EventId { get; set; }
        public long? CustomerId { get; set; }
        public long? TempCartId { get; set; }
        public long SignUpModeId { get; set; }
        public long? CallId { get; set; }
        public long? HighBloodPressure { get; set; }
        public long? Smoker { get; set; }
        public long? HeartDisease { get; set; }
        public long? Diabetic { get; set; }
        public long? ChestPain { get; set; }
        public long? DiagnosedHeartProblem { get; set; }
        public long? HighCholestrol { get; set; }
        public long? OverWeight { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool AgreedWithPrequalificationQuestion { get; set; }
        public bool SkipPreQualificationQuestion { get; set; }
        public long? AgeOverPreQualificationQuestion { get; set; }
    }
}