using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadRepository
    {
        CallUpload GetById(long id);
        CallUpload Save(CallUpload domainObject);
        IEnumerable<CallUpload> GetFilesToParse();
        IEnumerable<CallUpload> GetByFilter(int pageNumber, int pageSize, CallUploadListModelFilter filter, out int totalRecords);
        
    }
}