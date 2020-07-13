using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum SuspectConditionUploadStatus
    {
        [Description("Upload - Started")]
        UploadStarted = 350,

        [Description("Upload - Succeeded")]
        Uploaded = 281,

        [Description("Parse - In Progress")]
        Parsing = 282,

        [Description("Parse - Failed")]
        ParseFailed = 283,

        [Description("Parse - Succeeded")]
        Parsed = 284,

        [Description("Parse - File Not Found")]
        FileNotFound = 286
    }
}
