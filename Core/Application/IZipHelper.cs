namespace Falcon.App.Core.Application
{
    public interface IZipHelper
    {
        string ExtractZipFiles(string zipFilePath);
        string ExtractZipFiles(string zipFilePath, string destinationFolderPath);
        string CreateZipFiles(string inputFolderPath, bool pickRecursive = false);
        void CreateZipFiles(string inputFolderPath, string outputPath, bool pickRecursive = false, string fileSearchPattern = "", string password = "");
        void CreateZipOfSingleFileWithOutputPath(string inputFilePath, string outputFilePath, string password = "");
        string CreateZipOfSingleFile(string inputFilePath, string password);
    }
}