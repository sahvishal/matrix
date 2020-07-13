using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IEncounterRepository
    {
        Encounter GetById(long id);
        Encounter GetByEventCustomerId(long eventCustomerId);
        IEnumerable<Encounter> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        Encounter Save(Encounter domain);
        void SaveEventCustomerEncounter(long eventCustomerId, long encounterId);
        IEnumerable<EventCustomerEncounter> GetEventCustomerEncounterByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}
