using System.Collections.Generic;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanExportCustomerViewModelFactory
    {
        List<HealthPlanExportCustomerViewModel> Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians);

        List<BcbsMiIncorrectPhoneViewModel> CreateIncorrectPhoneListForBcbsMi(IEnumerable<Customer> customers,IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags,IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<DateAddedSettings> dateAddedSettings = null);

        List<BcbsMiHomeVisitRequestViewModel> CreateHomeVisitListForBcbsMi(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians);
    }
}
