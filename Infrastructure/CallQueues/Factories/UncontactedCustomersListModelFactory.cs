using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class UncontactedCustomersListModelFactory : IUncontactedCustomersListModelFactory
    {
        public UncontactedCustomersReportListModel Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> customerTags, IEnumerable<CustomerEligibility> customerEligibilities)
        {
            var model = new UncontactedCustomersReportListModel();
            var collection = new List<UncontactedCustomersReportModel>();

            customers.ToList().ForEach(c =>
            {
                var customerTag = "N/A";
                if (customerTags != null && customerTags.Any())
                {
                    var customTag = (from ct in customerTags where ct.CustomerId == c.CustomerId select ct.Tag).ToArray();

                    if (customTag != null && customTag.Any())
                    {
                        customerTag = string.Join(", ", customTag);
                    }
                }
                var eligibility = customerEligibilities.FirstOrDefault(x => x.CustomerId == c.CustomerId);
               
                var isEligible = "N/A";
                if (eligibility != null && eligibility.IsEligible.HasValue)
                {
                    if (eligibility.IsEligible.Value)
                        isEligible = EligibleStatus.Yes.ToString();
                    else
                        isEligible = EligibleStatus.No.ToString();
                }

                var customerZipCode = "N/A";
                if (c.Address != null)
                {
                    if (c.Address.ZipCode != null)
                        customerZipCode = c.Address.ZipCode.ToString();
                }

                var uncontactedCustomersModel = new UncontactedCustomersReportModel
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name.FullName,
                    Tag = c.Tag,
                    ZipCode = customerZipCode,
                    IsEligible = isEligible,
                    CustomTag = customerTag
                };
                collection.Add(uncontactedCustomersModel);
            });

            model.Collection = collection;
            return model;
        }
    }
}
