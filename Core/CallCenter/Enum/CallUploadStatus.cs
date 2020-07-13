using System.ComponentModel;

namespace Falcon.App.Core.CallCenter.Enum
{
    public enum CallUploadStatus
    {       
        [Description("Upload - Succeeded")]
        Uploaded = 259,
        [Description("Parse - In Progress")]
        Parsing = 260,
        [Description("Parse - Failed")]
        ParseFailed = 261,
        [Description("Parse - Succeeded")]
        Parsed = 262,
        [Description("Parse - Invalid File Format")]
        InvalidFileFormat = 263,
        [Description("Parse - File Not Found")]
        FileNotFound = 264
    }
}
