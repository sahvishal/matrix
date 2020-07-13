using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum UploadActivityType
    {
        [Description("Mail Only")]
        MailOnly = 1,//331,

        [Description("Only Call")]
        OnlyCall = 2,//332,

        [Description("Both Mail And Call")]
        BothMailAndCall = 3,//333,

        [Description("Do not Call/Do not Email")]
        DoNotCallDoNotMail = 4,//364
        
        [Description("None")]
        None=5,
    }
}
