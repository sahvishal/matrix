using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadService
    {
        CallUploadListModel GetCallUploadDetails(int pageNumber, int pageSize, CallUploadListModelFilter filter, out int totalRecords);
        long SaveGmsDialerCall(GmsDialerCallModel model, long orgRoleUserId, ILogger logger);
        long SaveViciDialerCall(ViciDialerCallModel model, long orgRoleUserId);
    }
}
