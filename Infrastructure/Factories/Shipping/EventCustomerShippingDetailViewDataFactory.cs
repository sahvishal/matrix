using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Factories.Shipping
{
    [DefaultImplementation]
    public class EventCustomerShippingDetailViewDataFactory : IEventCustomerShippingDetailViewDataFactory
    {

        public List<EventCustomerShippingDetailViewData> Create(IEnumerable<ShippingDetail> shippingDetails, IEnumerable<OrderedPair<long, long>> shippingDetailIdEventCustomerIdPairs, IEnumerable<EventCustomer> eventCustomers,
            IEnumerable<Customer> customers, IEnumerable<Event> events, IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Core.Finance.Domain.Order> orders, IEnumerable<OrderedPair<long, string>> orderPackageIdNamePairs,
            IEnumerable<OrderedPair<long, string>> orderTestIdNamePairs, IEnumerable<Address> addresses, IEnumerable<ShippingOption> shippingOptions, int totalCount, IEnumerable<OrderedPair<long, string>> orderIdProductnamePairs)
        {
            var eventCustomerShippingDetailViewDatas = new List<EventCustomerShippingDetailViewData>();

            foreach (var shippingDetail in shippingDetails)
            {


                var eventCustomerId = shippingDetailIdEventCustomerIdPairs.Where(sdec => sdec.FirstValue == shippingDetail.Id).Select(sdec => sdec.SecondValue).First();
                var eventCustomer = eventCustomers.Where(ec => ec.Id == eventCustomerId).First();
                var customer = customers.Where(c => c.CustomerId == eventCustomer.CustomerId).First();
                var eventData = events.Where(e => e.Id == eventCustomer.EventId).First();
                var eventCustomerResult = !eventCustomerResults.IsNullOrEmpty() ? eventCustomerResults.Where(ecr => ecr.Id == eventCustomerId).FirstOrDefault() : null;
                var address = addresses.Where(a => a.Id == shippingDetail.ShippingAddress.Id).First();
                var shippingOption = shippingOptions.Where(so => so.Id == shippingDetail.ShippingOption.Id).First();
                var order = orders.Where(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId).FirstOrDefault();
                var package = order == null ? null : orderPackageIdNamePairs.Where(p => p.FirstValue == order.Id).FirstOrDefault();
                var test = order == null ? null : orderTestIdNamePairs.Where(p => p.FirstValue == order.Id).ToList();

                var product = order == null ? null : orderIdProductnamePairs.Where(p => p.FirstValue == order.Id).FirstOrDefault();

                var viewData = new EventCustomerShippingDetailViewData
                           {
                               ShippingDetailId = shippingDetail.Id,
                               ActualPrice = shippingDetail.ActualPrice,
                               
                               CustomerCity = address.City,
                               CustomerId = customer.CustomerId,
                               CustomerName = customer.Name.FullName,
                               CustomerState = address.State,
                               CustomerStreetAddressLine1 = address.StreetAddressLine1,
                               CustomerStreetAddressLine2 = address.StreetAddressLine2,
                               CustomerZip = address.ZipCode.Zip,
                               CustomerEmail = customer.Email.ToString(),
                               
                               EventDate = eventData.EventDate,
                               EventId = eventData.Id,
                               EventName = eventData.Name,
                               ShippingOptionName = shippingOption.Name,
                               ShippingRequestedOn = shippingDetail.DataRecorderMetaData.DateCreated,
                               Status = shippingDetail.Status,
                               PackageName = package != null ? package.SecondValue : string.Empty,
                               AdditionalTest = !test.IsNullOrEmpty() ? string.Join(" + ", test.Select(t => t.SecondValue).ToArray()) : string.Empty,
                               ProductName = product != null ? product.SecondValue : string.Empty,
                               IsPdfGenerated = eventCustomerResult != null ? eventCustomerResult.IsClinicalFormGenerated : false,
                               IsResultPdfGenerated = eventCustomerResult != null ? eventCustomerResult.IsResultPdfGenerated : false,
                               IsPaid = (order != null && order.DiscountedTotal <= order.TotalAmountPaid) ? true : false,
                               IsExclusivelyRequested = shippingDetail.IsExclusivelyRequested,
                               TotalCount = totalCount
                           };
                eventCustomerShippingDetailViewDatas.Add(viewData);
            }

            return eventCustomerShippingDetailViewDatas;

                //eventCustomerShippingDetailViewDatas.OrderBy(ecsdvd => ecsdvd.EventDate).ThenBy(ecsdvd => ecsdvd.EventId)
                //    .ThenBy(ecsdvd => ecsdvd.ShippingOptionName).ThenBy(ecsdvd => ecsdvd.CustomerName).ToList();
        }

    }


}