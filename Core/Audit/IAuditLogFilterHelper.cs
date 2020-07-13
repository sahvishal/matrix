using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Audit.ViewModel;

namespace Falcon.App.Core.Audit
{
    public interface IAuditLogFilterHelper
    {
        long GetEditModelIdValue(dynamic model);
        long GetIdValue(string propertyName, dynamic model);
        ActivityLogEditModel GetActivityLogEditModel(dynamic request, dynamic model, string activityType);
        void AsyncLogModel(ModelType modelType, ActivityLogEditModel logModel, dynamic model, bool fromAPI = false);
        void LogModel(ModelType modelType, ActivityLogEditModel logModel, dynamic model, bool fromAPI = false);
        ActivityLogEditModel GetActivityLogEditModel(string filePath, string requestType, dynamic model, string activityType);
    }
}