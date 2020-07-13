using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerEventCriticalDataFactory
    {
        CustomerEventCriticalDataListModel Create(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
            IEnumerable<OrderedPair<long, string>> ecAndTestPair, IEnumerable<CustomerCriticalData> customersCriticalData, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<AssignedPhysicianViewModel> assignedPhysicians,
            IEnumerable<CustomerResultStatusViewModel> testResults, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, long>> eventCustomerResultIdNotesIdPairs, IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs);
    }
}
