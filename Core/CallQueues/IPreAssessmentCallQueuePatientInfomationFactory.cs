using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
    public interface IPreAssessmentCallQueuePatientInfomationFactory
    {
        CallQueueCustomerEditModel GetCallQueueCustomerEditModel(PreAssessmentCustomerContactViewModel model, bool isHealthPlanCallQueue);
        CallQueuePatientInfomationViewModel SetCustomerInfo(Customer customer, CustomerEligibility customerEligibility, Falcon.App.Core.Medical.Domain.ActivityType activityType);
        CallQueuePatientInfomationViewModel SetProspectCustomerInfo(ProspectCustomer domain);
        CallQueuePatientInfomationViewModel SetCustomerTagInfo(ProspectCustomer domain, CallQueuePatientInfomationViewModel model);
    }
}
