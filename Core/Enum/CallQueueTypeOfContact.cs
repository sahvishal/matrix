using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum CallQueueTypeOfContact
    {
        [Description("Web Prospect")]
        WebProspect,

        [Description("Prospect")]
        Prospect,

        [Description("DM Prospect")]
        DMProspect,

        [Description("Existing Customer")]
        ExistingCustomer
    }
}