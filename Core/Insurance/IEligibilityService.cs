using System.Collections.Generic;
using Falcon.App.Core.Insurance.ViewModels;

namespace Falcon.App.Core.Insurance
{
    public interface IEligibilityService
    {
        EligibilityEditModel CheckEligibility(EligibilityEditModel model, long? orgRoleUserId);
        EligibilityViewModel GetEligibilityDetail(long eligibilityId, long eventId, long packageId, IEnumerable<long> testIds);
        bool CheckTestCoveredByinsurance(long eventId, long packageId, IEnumerable<long> testIds);
        IEnumerable<InsuranceDetailViewModel> GetInsuranceDetailByEventCustomerIds(IEnumerable<long> eventCustomerIds);
    }
}