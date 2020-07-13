using System.ComponentModel;

namespace Falcon.App.Core.Operations.Enum
{
    public enum MergeCustomerUploadStatus
    {
        [Description("Upload - Succeeded")]
        Uploaded = 259,
        [Description("Merge - In Progress")]
        Parsing = 260,
        [Description("Merge - Failed")]
        ParseFailed = 261,
        [Description("Merge - Succeeded")]
        Parsed = 262,
        [Description("Merge - Invalid File Format")]
        InvalidFileFormat = 263,
        [Description("Merge - File Not Found")]
        FileNotFound = 264
    }
}
