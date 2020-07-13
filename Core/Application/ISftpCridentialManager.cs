using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Application
{
    public interface ISftpCridentialManager
    {
        void SerializeandSave(string fileName, SftpCridential records);
        SftpCridential Deserialize(string fileName);
    }
}