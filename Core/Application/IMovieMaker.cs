namespace Falcon.App.Core.Application
{
    public interface IMovieMaker
    {
        string ExecutableDirectoryPath { get; set; }
        string GenerateMoviefromImageGroup(string sourcePath, string destinationPath, string fileName = "");
        string GenerateMoviefromAvi(string sourceFilePath, string destinationPath, string fileName = "");

        string GenerateMPEG(string sourceFilePath, string destinationPath, string fileName = "");

        string GenerateMoviefromAviWithoutRedis(string sourceFilePath, string destinationPath, string fileName = "");
        string GenerateMPEGWithoutRedis(string sourceFilePath, string destinationPath, string fileName = "");
    }
}