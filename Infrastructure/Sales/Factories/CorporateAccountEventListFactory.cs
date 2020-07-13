using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Sales.Factories
{
    [DefaultImplementation(Interface = typeof(ICorporateAccountEventListFactory))]
    public class CorporateAccountEventListFactory : ICorporateAccountEventListFactory
    {
        public IEnumerable<CorporateAccountEventViewModel> Create(IEnumerable<Event> events, IEnumerable<Host> hosts, IEnumerable<OrderedPair<long, int>> screenedCustomersCount,
            IEnumerable<OrderedPair<long, int>> normalCustomersCount, IEnumerable<OrderedPair<long, int>> criticalCustomersCount, IEnumerable<OrderedPair<long, int>> abnormalCustomersCount)
        {
            var corporateAccountEventViewModels = new List<CorporateAccountEventViewModel>();

            events.ToList().ForEach(e =>
            {
                var host = hosts.Where(h => h.Id == e.HostId).FirstOrDefault();

                var secreenedCustomers = screenedCustomersCount.Where(sc => sc.FirstValue == e.Id).FirstOrDefault();

                var normalCustomers = normalCustomersCount.Where(ec => ec.FirstValue == e.Id).FirstOrDefault();

                var criticalCustomers = criticalCustomersCount.Where(cc => cc.FirstValue == e.Id).FirstOrDefault();

                var abnormalCustomers = abnormalCustomersCount.Where(ac => ac.FirstValue == e.Id).FirstOrDefault();

                var normal = normalCustomers != null ? normalCustomers.SecondValue : 0;

                var critical = criticalCustomers != null ? criticalCustomers.SecondValue : 0;

                var abnormal = abnormalCustomers != null ? abnormalCustomers.SecondValue : 0;

                corporateAccountEventViewModels.Add(new CorporateAccountEventViewModel
                {
                    EventId = e.Id,
                    EventDate = e.EventDate,
                    HostAddress =
                        host.OrganizationName + " - " +
                        host.Address.City + ", " +
                        host.Address.State + ", " +
                        host.Address.ZipCode.Zip,
                    ScreenedCustomers =
                        secreenedCustomers != null
                            ? secreenedCustomers.
                                  SecondValue
                            : 0,
                    NormalCustomers = normal,
                    CriticalCustomers = critical,
                    AbnormalCustomers = abnormal
                });
            });

            return corporateAccountEventViewModels;
        }
    }
}