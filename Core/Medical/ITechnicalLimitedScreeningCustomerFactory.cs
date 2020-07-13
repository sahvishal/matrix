using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ITechnicalLimitedScreeningCustomerFactory
    {
        TechnicalLimitedScreeningCustomerListModel Create(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Pod> pods, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
                                                          IEnumerable<OrderedPair<long, string>> ecAndTestPair, IEnumerable<TestUnabletoScreenViewModel> unableToScreenViewModel, bool isNewResultFlow);
    }
}