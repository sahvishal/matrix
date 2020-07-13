using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medicare.ViewModels;
using System;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationService
    {
        IEnumerable<MedicationUploadViewModel> GetUploadList(int pageNumber, int pageSize, MedicationUploadListModelFilter filter,
            out int totalRecords);
        void SaveMedications(IEnumerable<MedicationEditModel> medications, long customerId, long orgRoleUserId);

        IEnumerable<MedicationEditModel> GetMedications(long customerId);
    }
}
