
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ISendMediaFileHelper
    {
        OrderedPair<string, string> GetSftpFileAndFolder(CorporateAccount account, Customer customer, Event eventData, string test, string fileExtension, bool convertFileType = false);
    }
}
