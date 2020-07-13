using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IRapsUploadRepository
    {
        RapsUpload GetById(long id);
        RapsUpload Save(RapsUpload domainObject);
        IEnumerable<RapsUpload> GetFilesToParse();
        IEnumerable<RapsUploadModel> GetUploadList(int pageNumber, int pageSize, RapsUploadListModelFilter filter, out int totalRecords);
    }
}
