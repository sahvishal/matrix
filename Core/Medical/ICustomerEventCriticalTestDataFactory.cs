using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerEventCriticalTestDataFactory
    {
        CustomerEventCriticalTestDataEditModel Create(long eventId, long testId, Customer customer, CustomerCriticalData criticalData, EventCustomer eventCustomer, IEnumerable<OrderedPair<long, string>> physicians, PrimaryCarePhysician pcp, 
            EventCustomerResult eventCustomerResult);
        CustomerCriticalData Create(CustomerEventCriticalTestDataEditModel model);

        CustomerEventCriticalTestDataViewModel Create(CustomerCriticalData criticalData, Customer customer, PrimaryCarePhysician pcp, IEnumerable<OrderedPair<long, string>> idNamePairs, string testName);
    }
}