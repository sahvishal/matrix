using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum LifeStyleDataDictionaryAnswerType
    {
        [Description("Not Answered")]
        NotAnswered = 0,
        [Description("Almost always")]
        AlmostAlways,
        Often,
        Sometimes,
        Rarely,
        Never,
    }
}
