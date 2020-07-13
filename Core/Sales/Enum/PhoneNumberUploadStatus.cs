using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum PhoneNumberUploadStatus
    {
        [Description("Upload - In Progress")]
        Uploading = 89,
        [Description("Upload - Failed")]
        UploadFailed = 90,
        [Description("Upload - Succeeded")]
        Uploaded = 91,
        [Description("Parse - In Progress")]
        Parsing = 92,
        [Description("Parse - Failed")]
        ParseFailed = 93,
        [Description("Parse - Succeeded")]
        Parsed = 94,
        [Description("Parse - Invalid File Format")]
        InvalidFileFormat = 95,
        [Description("Parse - File Not Found")]
        FileNotFound = 96
    }
}