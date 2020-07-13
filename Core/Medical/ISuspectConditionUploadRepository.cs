using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ISuspectConditionUploadRepository
    {
        SuspectConditionUpload GetById(long id);
        SuspectConditionUpload Save(SuspectConditionUpload domainObject);
        IEnumerable<SuspectConditionUploadModel> GetUploadList(int pageNumber, int pageSize, SuspectConditionUploadListModelFilter filter, out int totalRecords);
    }
}
