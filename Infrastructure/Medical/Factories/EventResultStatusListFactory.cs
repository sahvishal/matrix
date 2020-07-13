using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class EventResultStatusListFactory : IEventResultStatusListFactory
    {
        public EventResultStatusListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> totalCustomersCount, IEnumerable<OrderedPair<long, int>> missingResultsCount,
            IEnumerable<OrderedPair<long, int>> preAuditPendingCount, IEnumerable<OrderedPair<long, int>> reviewPendingCount, IEnumerable<OrderedPair<long, int>> postAuditPendingCount,
            IEnumerable<OrderedPair<long, int>> resultsDeliveredCount, IEnumerable<long> resultsUploaded, IEnumerable<long> resultsParsed, IEnumerable<OrderedPair<long, int>> unStableStatesCount, IEnumerable<Pod> pods)
        {
            var model = new EventResultStatusListModel();
            var eventResultStatusViewModels = new List<EventResultStatusViewModel>();

            events.ToList().ForEach(e =>
                                        {
                                            var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();

                                            var resultUploaded = resultsUploaded.Where(ru => ru == e.Id).FirstOrDefault();

                                            var resultParsed = resultsParsed.Where(rp => rp == e.Id).FirstOrDefault();

                                            var missingResult = missingResultsCount.Where(ms => ms.FirstValue == e.Id).FirstOrDefault();

                                            var unStableState =
                                                unStableStatesCount.Where(us => us.FirstValue == e.Id).FirstOrDefault();

                                            var perAuditPending = preAuditPendingCount.Where(pa => pa.FirstValue == e.Id).FirstOrDefault();

                                            var reviewPending = reviewPendingCount.Where(r => r.FirstValue == e.Id).FirstOrDefault();

                                            var postAuditPending = postAuditPendingCount.Where(pa => pa.FirstValue == e.Id).FirstOrDefault();

                                            var resultsDelivered = resultsDeliveredCount.Where(r => r.FirstValue == e.Id).FirstOrDefault();

                                            var totalCustomers = totalCustomersCount.Where(tc => tc.FirstValue == e.Id).FirstOrDefault();
                                            IEnumerable<Pod> podList = null;
                                            if (e.PodIds != null)
                                                podList = pods != null ? pods.Where(x => e.PodIds.Contains(x.Id)) : null;

                                            eventResultStatusViewModels.Add(
                                                new EventResultStatusViewModel()
                                                    {
                                                        EventId = e.Id,
                                                        EventDate = e.EventDate,
                                                        Location = host.OrganizationName + " - " +
                                                                   host.Address.City + ", " +
                                                                   host.Address.State + ", " + host.Address.ZipCode.Zip,
                                                        Uploaded = resultUploaded > 0 ? true : false,
                                                        Parsed = resultParsed > 0 ? true : false,
                                                        UnStableState = unStableState != null ? unStableState.SecondValue : 0,
                                                        MissingResults =
                                                            missingResult != null ? missingResult.SecondValue : 0,
                                                        PreAuditsPending =
                                                            perAuditPending != null ? perAuditPending.SecondValue : 0,
                                                        ReviewPending =
                                                            reviewPending != null ? reviewPending.SecondValue : 0,
                                                        PostAuditsPending =
                                                            postAuditPending != null ? postAuditPending.SecondValue : 0,
                                                        ResultsDelivered =
                                                            resultsDelivered != null ? resultsDelivered.SecondValue : 0,
                                                        TotalCustomers =
                                                            totalCustomers != null ? totalCustomers.SecondValue : 0,

                                                        PodName = podList != null ? string.Join(",", podList.Select(x => x.Name)) : "N/A"
                                                    }
                                                );
                                        });

            model.Collection = eventResultStatusViewModels;
            return model;
        }
    }
}
