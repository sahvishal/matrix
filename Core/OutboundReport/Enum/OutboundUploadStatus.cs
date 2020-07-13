using System.ComponentModel;

namespace Falcon.App.Core.OutboundReport.Enum
{
    public enum OutboundUploadStatus
    {
        Pending = 308,

        Parsing = 309,

        [Description("Parse Failed")]
        ParseFailed = 310,

        Parsed = 311,

        [Description("Invalid File Format")]
        InvalidFileFormat = 312
    }
}
