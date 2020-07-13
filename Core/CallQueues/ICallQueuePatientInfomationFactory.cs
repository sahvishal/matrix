using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallQueues
{
    public interface ICallQueuePatientInfomationFactory
    {
        CallQueuePatientInfomationViewModel SetCustomerInfo(Customer customer, CustomerEligibility customerEligibility, ActivityType activityType);
        CallQueuePatientInfomationViewModel SetProspectCustomerInfo(ProspectCustomer domain);

        CallQueuePatientInfomationViewModel SetCustomerTagInfo(ProspectCustomer domain, CallQueuePatientInfomationViewModel model);

        CallQueueCustomerEditModel GetCallQueueCustomerEditModel(CustomerContactViewModel model, bool isHealthPlanCallQueue);
    }
}