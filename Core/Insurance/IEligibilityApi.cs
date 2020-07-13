using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Insurance.ViewModels;

namespace Falcon.App.Core.Insurance
{
    public interface IEligibilityApi
    {
        EligibleResponse GetCoverage(EligibilityRequestEditModel eligbleRequest, InsuranceCompany insuranceCompany, InsuranceServiceType insuranceServiceType);
    }
}
