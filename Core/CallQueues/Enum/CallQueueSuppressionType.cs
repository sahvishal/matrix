using System.ComponentModel;

namespace Falcon.App.Core.CallQueues.Enum
{
    public enum CallQueueSuppressionType
    {
        [Description("Left Voice Mail")]
        LeftVoiceMail = 344,

        [Description("Refused Customer")]
        RefuseCustomer = 345,

        Others = 346,

        [Description("Max Contact")]
        MaxAttempts = 347
    }
}
