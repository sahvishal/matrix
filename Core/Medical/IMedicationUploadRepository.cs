using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationUploadRepository
    {
        MedicationUpload GetById(long id);
        MedicationUpload Save(MedicationUpload domainObject);
        IEnumerable<MedicationUpload> GetFilesToParse();
        IEnumerable<MedicationUploadViewModel> GetUploadList(int pageNumber, int pageSize, MedicationUploadListModelFilter filter, out int totalRecords);
    }
}
