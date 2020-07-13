namespace Falcon.App.Core.Application
{
    public interface IPgpFileEncryption
    {void EncryptFile(string outputFileName, string inputFileName, string encKeyFileName);
    }
}
