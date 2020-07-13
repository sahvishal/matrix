using Falcon.App.Core.Medical.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISuspectConditionUploadLogRepository
    {
        SuspectConditionUploadLog GetById(long id);
        IEnumerable<SuspectConditionUploadLog> GetBySuspectConditionUploadId(long suspectConditionUploadId);
        SuspectConditionUploadLog SaveSuspectConditionUploadLog(SuspectConditionUploadLog domainObject);
        void BulkSaveSuspectConditionUploadLog(IEnumerable<SuspectConditionUploadLog> domainObjectCollection);
        int GetUploadFailedCount(long suspectConditionUploadId);
    }
}
