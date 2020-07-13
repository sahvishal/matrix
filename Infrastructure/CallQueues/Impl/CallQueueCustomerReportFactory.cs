using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class CallQueueCustomerReportFactory : ICallQueueCustomerReportFactory
    {
        public CallQueueCustomersReportModelListModel GetCallQueueCustomersList(IEnumerable<CallQueueCustomer> callQueueCustomers, IEnumerable<Customer> customers,
            IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, CorporateAccount corporateAccount, bool isQueueGenerated, HealthPlanCallQueueCriteria criteriaModel)
        {

            var list = new List<CallQueueCustomersReportModel>();

            foreach (var cqc in callQueueCustomers)
            {
                var customer = customers.First(c => c.CustomerId == cqc.CustomerId.Value);
                var customTags = string.Empty;
                if (corporateCustomerCustomTags != null && corporateCustomerCustomTags.Any() && cqc.CustomerId.HasValue)
                {
                    var tags = corporateCustomerCustomTags.Where(x => x.CustomerId == cqc.CustomerId.Value).OrderByDescending(x => x.DataRecorderMetaData.DateCreated);

                    if (tags != null && tags.Any())
                    {
                        customTags = string.Join(",", tags.Select(x => x.Tag));
                    }
                }

                list.Add(new CallQueueCustomersReportModel
                {
                    CustomTag = customTags,
                    CustomerId = customer.CustomerId,
                    MemberId = customer.InsuranceId,
                    Name = customer.Name.ToString(),
                    Tag = corporateAccount.Tag,
                    ZipCode = customer.Address.ZipCode.Zip
                });
            }

            if (list.IsNullOrEmpty())
                return new CallQueueCustomersReportModelListModel
                {
                    IsQueueGenerated = isQueueGenerated,
                    CallQueueCriteria = criteriaModel
                };

            return new CallQueueCustomersReportModelListModel
            {
                Collection = list,
                IsQueueGenerated = isQueueGenerated,
                CallQueueCriteria = criteriaModel
            };
        }
    }
}