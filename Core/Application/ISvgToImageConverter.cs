namespace Falcon.App.Core.Application
{
    public interface ISvgToImageConverter
    {
        string GenerateImage(string svgFilePath);
    }
}