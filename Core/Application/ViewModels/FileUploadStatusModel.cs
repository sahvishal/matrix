namespace Falcon.App.Core.Application.ViewModels
{
    public class FileUploadStatusModel
    {
 
        public string FileName { get; set; }
        public string Url { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string DeleteUrl { get; set; }
        public string Error { get; set; }
        public string Progress { get; set; }
    }
}