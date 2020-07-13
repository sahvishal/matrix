using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultMailedReportListModelFactory
    {
        PcpResultMailedReportListModel Create(IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs,
                                                         IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<PrimaryCarePhysician> primarycarePhysicians);
    }
}
