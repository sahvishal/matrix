namespace Falcon.App.Core.Application.ViewModels
{
    public class ConvertSvgToImageRequest
    {
        public ConvertSvgToImageRequest()
        {
            Guid = System.Guid.NewGuid().ToString();
        }
        public string Guid { get; set; } 
        public string Arguments { get; set; } 
    }
}
