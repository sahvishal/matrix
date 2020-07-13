using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class CustomerCdContentTrackingModelFactory : ICustomerCdContentTrackingModelFactory
    {
        public CustomerCdContentTrackingListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long,long>> orderIds,
            IEnumerable<CdContentGeneratorTracking> cdContentGeneratorTrackings, IEnumerable<OrderedPair<long,string >> idNamePairs)
        {
            var model = new CustomerCdContentTrackingListModel();

            var customerCdContentTrackingModels = new List<CustomerCdContentTrackingModel>();

            eventCustomers.ToList().ForEach(ec =>
                                                {
                                                    var customer =
                                                        customers.Where(c => c.CustomerId == ec.CustomerId).
                                                            FirstOrDefault();

                                                    var orderId =
                                                        orderIds.Where(o => o.SecondValue == ec.Id).Select(
                                                            o => o.FirstValue).FirstOrDefault();

                                                    var cdContentGeneratorTracking =
                                                        cdContentGeneratorTrackings.Where(
                                                            ccgt => ccgt.EventCustomerResultId == ec.Id).Select(
                                                                ccgt => ccgt).FirstOrDefault();

                                                    var downloadedBy = string.Empty;
                                                    if(cdContentGeneratorTracking!=null && cdContentGeneratorTracking.DownloadedByOrgRoleUserId.HasValue)
                                                    {
                                                        downloadedBy =
                                                            idNamePairs.Where(
                                                                inp =>
                                                                inp.FirstValue ==
                                                                cdContentGeneratorTracking.DownloadedByOrgRoleUserId.Value).Select(inp => inp.SecondValue).FirstOrDefault();
                                                    }

                                                    customerCdContentTrackingModels.Add(
                                                        new CustomerCdContentTrackingModel
                                                            {
                                                                EventId = ec.EventId,
                                                                CustomerId = customer.CustomerId,
                                                                Name = customer.Name.FullName,
                                                                OrderId = orderId,
                                                                CdContentGenerated =
                                                                    cdContentGeneratorTracking != null
                                                                        ? cdContentGeneratorTracking.IsContentGenerated
                                                                        : false,

                                                                CdContentDownloaded =
                                                                    cdContentGeneratorTracking != null
                                                                        ? cdContentGeneratorTracking.IsContentDownloaded
                                                                        : false,
                                                                DownloadedBy = downloadedBy,
                                                                DownloadedTime =
                                                                    cdContentGeneratorTracking != null
                                                                        ? cdContentGeneratorTracking.DownloadedDate
                                                                        : null,
                                                                CdContentTrackingId =
                                                                    cdContentGeneratorTracking != null
                                                                        ? cdContentGeneratorTracking.Id
                                                                        : 0
                                                            }
                                                        );

                                                });
            model.Collection = customerCdContentTrackingModels;
            return model;
        }
    }
}
