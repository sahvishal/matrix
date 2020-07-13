using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISuspectConditionService
    {
        IEnumerable<SuspectConditionUploadModel> GetUploadList(int pageNumber, int pageSize, SuspectConditionUploadListModelFilter filter,
            out int totalRecords);

        void ParseSuspectCondition(List<SuspectConditionUploadLog> suspectConditionUploadLogs, List<SuspectConditionUploadLog> failedRecordsList);
    }
}
