using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.ViewModels
{
    [NoValidationRequired]
    public class FileModel
    {
        public long Id { get; set; }
        public string Caption { get; set; }
        public string FileName { get; set; }
        public string FolderPath { get; set; }
        public decimal FileSize { get; set; }
        public long FileType { get; set; }
        public string PhisicalPath { get; set; }
        public string Url { get; set; }
        public string MimeType { get; set; }
        public bool IsTemporaryLocated { get; set; }
        public long UploadedBy { get; set; }
        public string ViewPath { get; set; }
    }
}
