using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Application
{
    public interface IPgpFileEncryptionHelper
    {
        string EncryptFile(CorporateAccount account, string sourcePath);
    }
}