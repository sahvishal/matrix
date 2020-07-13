namespace Falcon.App.Core.Medical
{
    public interface IConvertPdfToTiff
    {
        void SavePdfAsTiffImage(string source, string destinationForTiff);
    }
}