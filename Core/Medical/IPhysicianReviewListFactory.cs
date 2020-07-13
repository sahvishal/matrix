using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianReviewListFactory
    {
        PhysicianReviewListModel Create(IEnumerable<PhysicianEvaluation> evaluations,
                                        IEnumerable<OrderedPair<long, string>> physiciansIdNamePair,
                                        IEnumerable<EventCustomer> eventCustomers,
                                        IEnumerable<Customer> customers, IEnumerable<Order> orders,
                                        IEnumerable<OrderedPair<long, string>> packages,
                                        IEnumerable<OrderedPair<long, string>> tests,
                                        IEnumerable<OrderedPair<long, long>> criticalEventIdCustomerIdPair,
                                        IEnumerable<Event> events,
                                        IEnumerable<OrderedPair<long, long>> pdfGeneratedEventIdCustomerIdPair,
                                        IEnumerable<Pod> pods, IEnumerable<long> halfStudyEventCustomerIds, IEnumerable<long> evaluationPendingEventCustomerIds);
    }
}
