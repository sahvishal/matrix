using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class BcbsMiPcpResultMailedReportListModelFactory : IBcbsMiPcpResultMailedReportListModelFactory
    {
        public BcbsMiPcpResultMailedReportListModel Create(IEnumerable<ShippingDetail> shippingDetails,
            IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers,
            IEnumerable<PrimaryCarePhysician> primarycarePhysicians, IEnumerable<Event> events)
        {
            var listModel = new BcbsMiPcpResultMailedReportListModel();
            var collection = new List<BcbsMiPcpResultMailedReportModel>();

            foreach (var shippingDetail in shippingDetails)
            {
                var eventCustomerId = shippingDetailIdEventCustomerIdPairs.Where(sdec => sdec.FirstValue == shippingDetail.Id).Select(sdec => sdec.SecondValue).First();
                var eventCustomer = eventCustomers.First(ec => ec.Id == eventCustomerId);
                var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);
                var pcp = primarycarePhysicians.FirstOrDefault(p => p.CustomerId == eventCustomer.CustomerId);

                var dateofService = events.First(e => e.Id == eventCustomer.EventId);

                var model = new BcbsMiPcpResultMailedReportModel()
                {
                    CustomerName = customer.Name.FullName,
                    CustomerId = customer.CustomerId,
                    MemberId = customer.InsuranceId,
                    Hicn = customer.Hicn,
                    Dob = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value : (DateTime?)null,
                    Market = customer.Market,
                    PcpName = pcp != null ? pcp.Name.FullName : string.Empty,
                    PcpAddress = (pcp != null && pcp.Address != null) ? pcp.Address.ToString() : string.Empty,
                    PcpPhoneNumber = (pcp != null && pcp.Primary != null) ? pcp.Primary.ToString() : string.Empty,
                    PcpResultMailedDate = shippingDetail.ShipmentDate.HasValue ? shippingDetail.ShipmentDate.Value : (DateTime?)null,
                    GroupName = string.IsNullOrEmpty(customer.GroupName) ? string.Empty : customer.GroupName,
                    DateofService = dateofService.EventDate
                };

                collection.Add(model);
            }



            listModel.Collection = collection;

            return listModel;
        }
    }
}
