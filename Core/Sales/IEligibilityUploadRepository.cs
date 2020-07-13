using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Sales
{
    public interface IEligibilityUploadRepository
    {
        EligibilityUpload GetById(long id);
        EligibilityUpload Save(EligibilityUpload domainObject);
        IEnumerable<EligibilityUpload> GetFilesToParse();

        IEnumerable<EligibilityUpload> GetByFilter(int pageNumber, int pageSize, EligibilityUploadListModelFilter filter, out int totalRecords);
    }
}
