using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum HealthAssessmentQuestionLabel
    {
        [Description("Primary Care")]
        PrimaryCare,
        [Description("Mammogram/Prostate Screening")]
        MammogramProstateScreening,
        Colonoscopy,
        Cancer,
        [Description("Weight or Bariatric")]
        WeightBariatric
    }
}
