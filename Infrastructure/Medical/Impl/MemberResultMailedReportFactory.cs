using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberResultMailedReportFactory : IMemberResultMailedReportFactory
    {
        public MemberResultMailedReportListModel Create(IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<EventCustomer> eventCustomers,
            IEnumerable<Customer> customers, IEnumerable<Address> addresses)
        {
            var listModel = new MemberResultMailedReportListModel();
            var collection = new List<MemberResultMailedReportViewModel>();

            foreach (var shippingDetail in shippingDetails)
            {
                var eventCustomerId = shippingDetailIdEventCustomerIdPairs.Where(sdec => sdec.FirstValue == shippingDetail.Id).Select(sdec => sdec.SecondValue).First();
                var eventCustomer = eventCustomers.First(ec => ec.Id == eventCustomerId);
                var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);
                var address = addresses.First(a => a.Id == shippingDetail.ShippingAddress.Id);

                var viewData = new MemberResultMailedReportViewModel
                {
                    CustomerName = customer.NameAsString,
                    CustomerId = customer.CustomerId,
                    MemberId = customer.InsuranceId,
                    HICN = customer.Hicn,
                    DateOfBirth = customer.DateOfBirth,
                    Market = customer.Market,
                    MemberAddress = address.ToString(),
                    ResultsMailedDate = shippingDetail.ShipmentDate.Value,
                };

                collection.Add(viewData);
            }

            listModel.Collection = collection;

            return listModel;
        }
    }
}
