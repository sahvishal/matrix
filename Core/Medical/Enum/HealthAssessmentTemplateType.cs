using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum HealthAssessmentTemplateType
    {
        Event = 152,
        Package = 153,
        Test = 154,
        [Description("Hospital Partner")]
        HospitalPartner = 155
    }
}
