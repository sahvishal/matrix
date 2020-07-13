using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical
{
    public interface IEventCustomerResultStatusListFactory
    {
        EventCustomerResultStatusListModel Create(Event theEvent, Host eventHost, IEnumerable<EventTest> eventTests, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers,
                                            IEnumerable<EventPackage> packages, IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs, IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs, IEnumerable<ResultArchive> fileUploads,
                                            IEnumerable<ResultArchiveLog> parsingResults, List<CustomerResultStatusViewModel> customerResults, IEnumerable<EventCustomerResult> eventCustomerResults,
                                            IEnumerable<OrderedPair<long, string>> physcianComments, Notes emrNotes, IEnumerable<AssignedPhysicianViewModel> assignedPhysicians, IEnumerable<Order> orders, CorporateAccount account,
                                            IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<PriorityInQueue> priorityInQueues, bool printcheck, bool isNewResultFlow, IEnumerable<OrderedPair<long, long>> eventCustomerResultIdTestIdNotPerformedPairs, QuestionnaireType questionnaireType);

        EventCustomerResultStatusListModel Create(Event theEvent, Host eventHost, IEnumerable<EventTest> eventTests, EventCustomer eventCustomer, Customer customer, IEnumerable<EventPackage> packages,
                                                  IEnumerable<OrderedPair<long, long>> ecIdPackageIdpairs, IEnumerable<OrderedPair<long, long>> ecIdTestIdPairs, IEnumerable<ResultArchiveLog> parsingResults,
                                                  CustomerResultStatusViewModel customerResult, EventCustomerResult eventCustomerResult, bool isNewResultFlow, CorporateAccount account, QuestionnaireType questionnaireType);
    }
}