using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using System;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationRepository
    {
        Medication SaveMedication(Medication domainObject);
        IEnumerable<Medication> GetByCustomerId(long customerId);
        IEnumerable<Medication> GetMedicationForSync(long lastMaxIdColumn, long? customerId = null);
        IEnumerable<Medication> GetByCustomerIdAndServiceDate(long customerId, DateTime serviceDate);
        void SaveMedications(IEnumerable<Medication> domainList, long orgRoleUserId);
        void UpdateMedications(IEnumerable<Medication> models, long orgRoleUserId);
        void MarkForDelete(long customerId, long orgRoleUserId, long[] medicationIdNotToDelete);
    }
}
