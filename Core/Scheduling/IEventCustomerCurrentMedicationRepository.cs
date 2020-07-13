using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerCurrentMedicationRepository
    {
        IEnumerable<EventCustomerCurrentMedication> GetByCustomerId(long customerId);
        //void SaveAll(long eventCustomerId,IEnumerable<OrderedPair<long,string>> ndcPairs);
        void Save(long eventCustomerId, IEnumerable<EventCustomerCurrentMedication> domain);
    }
}
