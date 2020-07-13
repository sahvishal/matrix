using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICurrentMedicationRepository
    {
        IEnumerable<CurrentMedication> GetByCustomerId(long customerId);
        void SaveCurrentMedication(long customerId, List<OrderedPair<long, string>> ndcIds, long createdByOrgRoleUserId);
    }
}
