using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum PathwayRecommendation
    {
        None = 140,
        [Description("PCP")]
        Pcp = 141,
        Specialist = 142
    }
}