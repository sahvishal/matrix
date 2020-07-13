using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class DailyRecapModelFactory : IDailyRecapModelFactory
    {
        public DailyRecapListModel Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, int>> totalRegistration, IEnumerable<OrderedPair<long, int>> customersAttended,
            IEnumerable<OrderedPair<long, int>> noShowCustomers, IEnumerable<OrderedPair<long, int>> cancelledCustomers, IEnumerable<OrderedPair<long, decimal>> eventOrderAmounts,
            IEnumerable<OrderedPair<long, int>> eventIdLeftWithoutScreeningCustomerCountPairs, IEnumerable<OrderedPair<long, int>> totalGcIssued)
        {
            var model = new DailyRecapListModel();
            var dailyRecapModels = new List<DailyRecapModel>();

            events.ToList().ForEach(e =>
                                        {
                                            var host = hosts.FirstOrDefault(h => h.Id == e.HostId);

                                            var eventPods = pods.Where(p => e.PodIds.Contains(p.Id)).ToList();

                                            var total = totalRegistration.FirstOrDefault(bs => bs.FirstValue == e.Id).SecondValue;

                                            var actual = customersAttended.FirstOrDefault(bs => bs.FirstValue == e.Id).SecondValue;

                                            var noShow = noShowCustomers.FirstOrDefault(bs => bs.FirstValue == e.Id).SecondValue;

                                            var cancelled = cancelledCustomers.FirstOrDefault(bs => bs.FirstValue == e.Id).SecondValue;

                                            var orderAmount = eventOrderAmounts.SingleOrDefault(eo => eo.FirstValue == e.Id).SecondValue;

                                            var leftWithoutScreeningCustomerCount = eventIdLeftWithoutScreeningCustomerCountPairs.SingleOrDefault(ec => ec.FirstValue == e.Id).SecondValue;

                                            var giftCertificateIssuedForEvent = totalGcIssued.FirstOrDefault(x => x.FirstValue == e.Id);

                                            dailyRecapModels.Add(new DailyRecapModel()
                                                                     {
                                                                         EventId = e.Id,
                                                                         EventDate = e.EventDate,
                                                                         Location =
                                                                             host.OrganizationName + " - " +
                                                                             host.Address.City + ", " +
                                                                             host.Address.State + ", " + host.Address.ZipCode.Zip,
                                                                         Pod =
                                                                             string.Join(", ",
                                                                                         eventPods.Select(
                                                                                             ep => ep.Name)),
                                                                         Revenue = orderAmount,
                                                                         TotalRegistration = total,
                                                                         CustomersAttended = actual,
                                                                         CustomersNoShow = noShow,
                                                                         CustomersCancelled = cancelled,
                                                                         EventSignOff = e.IsSignOff ? "Yes" : "No",
                                                                         AvgRevenue = actual > 0 ? orderAmount / actual : (total - cancelled - noShow) > 0 ? orderAmount / (total - cancelled - noShow) : 0,
                                                                         LeftWithoutScreeningCustomerCount = leftWithoutScreeningCustomerCount,
                                                                         GiftCertificateDeliveredCount = giftCertificateIssuedForEvent != null ? giftCertificateIssuedForEvent.SecondValue : 0
                                                                     });

                                        });

            model.Collection = dailyRecapModels;
            return model;
        }
    }
}
