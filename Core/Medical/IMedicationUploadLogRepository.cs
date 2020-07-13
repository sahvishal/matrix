using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationUploadLogRepository
    {
        MedicationUploadLog GetById(long id);
        IEnumerable<MedicationUploadLog> GetByMedicationUploadId(long medicationUploadId);
        MedicationUploadLog SaveMedicationUploadLog(MedicationUploadLog domainObject);
        void BulkSaveMedicationUploadLog(IEnumerable<MedicationUploadLog> domainObjectCollection);
    }
}
