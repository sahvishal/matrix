using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Domain;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadLogRepository
    {
        CallUploadLog GetById(long id);
        IEnumerable<CallUploadLog> GetByCallUploadId(long callUploadId);
        CallUploadLog SaveCallUploadLog(CallUploadLog domainObject);

        IEnumerable<CallUploadLog> GetCustomerForApplyRule(string outReachType);
    }
}