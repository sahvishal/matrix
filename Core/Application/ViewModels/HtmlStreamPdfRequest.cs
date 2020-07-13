namespace Falcon.App.Core.Application.ViewModels
{
    public class HtmlStreamPdfRequest
    {
        public HtmlStreamPdfRequest()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
        public string Guid { get; set; }
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public string DestinationPath { get; set; }
        public string HtmlStream { get; set; }
    }
}
