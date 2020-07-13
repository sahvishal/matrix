using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IGiftCertificateReportFactory
    {
        ListModelBase<GiftCertificateReportViewModel, GiftCertificateReportFilter> Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders,
            IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests);
    }
}
