using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IEligibilityRepository
    {
        Eligibility GetById(long id);
        Eligibility GetByEventCustomerId(long eventCustomerId);
        IEnumerable<Eligibility> GetByEventCustomerIds(IEnumerable<long> eventCustomerIds);
        Eligibility Save(Eligibility domain);
        void SaveEventCustomerEligibility(long eventCustomerId, long eligibilityId, long chargeCardId);
        void DeleteEventCustomerEligibility(long eventCustomerId);
        EventCustomerEligibility GetEventCustomerEligibilityIdByEventCustomerId(long eventCustomerId);
        IEnumerable<EventCustomerEligibility> GetEventCustomerEligibilityIdByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}