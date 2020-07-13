using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpSummaryLogReportListModelFactory : IPcpSummaryLogReportListModelFactory
    {

        public PcpSummaryLogReportListModel Create(IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<PrimaryCarePhysician> primarycarePhysicians, IEnumerable<Event> eventsCollection)
        {
            var listModel = new PcpSummaryLogReportListModel();
            var collection = new List<PcpSummaryLogReportModel>();
            var vendorCode = "HLTF";
            var lineOfBusiness = "EMR";

            foreach (var shippingDetail in shippingDetails)
            {
                var eventCustomerId = shippingDetailIdEventCustomerIdPairs.Where(sdec => sdec.FirstValue == shippingDetail.Id).Select(sdec => sdec.SecondValue).First();
                var eventCustomer = eventCustomers.First(ec => ec.Id == eventCustomerId);
                var eventData = eventsCollection.First(x => x.Id == eventCustomer.EventId);
                var customer = customers.First(c => c.CustomerId == eventCustomer.CustomerId);
                var pcp = primarycarePhysicians.FirstOrDefault(p => p.CustomerId == eventCustomer.CustomerId);

                var model = new PcpSummaryLogReportModel()
                {
                    VendorCode = vendorCode,
                    MedicareNumber = customer.Hicn,
                    LineOfBusiness = lineOfBusiness,
                    MemberState = customer.Address.State,
                    MemberCounty = customer.AdditionalField4,
                    MemberFirstName = customer.Name.FirstName,
                    MemberLastName = customer.Name.LastName,
                    SubscriberID = customer.CustomerId.ToString(),
                    MemberID = customer.AdditionalField3,
                    DOB = customer.DateOfBirth,
                    Gender = customer.Gender.GetDescription(),
                    PcpFirstName = pcp != null && pcp.Name != null ? pcp.Name.FirstName : string.Empty,
                    PcpLastName = pcp != null && pcp.Name != null ? pcp.Name.LastName : string.Empty,
                    PcpPhoneNumber = pcp != null && pcp.Primary != null ? pcp.Primary.DomesticPhoneNumber : string.Empty,
                    PcpAddress1 = pcp != null && pcp.Address != null ? pcp.Address.StreetAddressLine1 : string.Empty,
                    PcpAddress2 = pcp != null && pcp.Address != null ? pcp.Address.StreetAddressLine2 : string.Empty,
                    PcpCity = pcp != null && pcp.Address != null ? pcp.Address.City : string.Empty,
                    PcpState = pcp != null && pcp.Address != null ? pcp.Address.State : string.Empty,
                    PcpZIP = pcp != null && pcp.Address != null && pcp.Address.ZipCode != null ? pcp.Address.ZipCode.Zip : string.Empty,
                    EventDate = eventData.EventDate,
                    EventId = eventData.Id,
                    PcpMailedDate = shippingDetail.ShipmentDate,
                    ResultFileName = customer.CustomerId + "_" + eventData.EventDate.ToString("MMddyyyy") + ".pdf"     //file name format: customerId_eventDate.pdf
                };

                collection.Add(model);
            }

            listModel.Collection = collection;
            return listModel;
        }
    }
}
