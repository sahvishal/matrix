using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class CustomerWithNoEventsInAreaReportListModelFactory : ICustomerWithNoEventsInAreaReportListModelFactory
    {
        public CustomerWithNoEventsInAreaReportListModel Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customTags)
        {
            var model = new CustomerWithNoEventsInAreaReportListModel();
            var collection = new List<CustomerWithNoEventsInAreaReportModel>();

            customers.ToList().ForEach(c =>
            {
                var customerTag = "N/A";
                if (customTags != null && customTags.Any())
                {
                    var customTag = (from ct in customTags where ct.CustomerId == c.CustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }

                var customerZipCode = "N/A";
                if (c.Address != null)
                {
                    if (c.Address.ZipCode != null)
                        customerZipCode = c.Address.ZipCode.ToString();
                }
                var callQueueExcludedCustomerReportModel = new CustomerWithNoEventsInAreaReportModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    MemberId = (!string.IsNullOrEmpty(c.InsuranceId)) ? c.InsuranceId : "N/A",
                    ZipCode = customerZipCode,
                    Tag = (!string.IsNullOrEmpty(c.Tag)) ? c.Tag : "N/A",
                    CustomTags = customerTag
                };

                collection.Add(callQueueExcludedCustomerReportModel);
            });


            model.Collection = collection;
            return model;
        }
    }
}
