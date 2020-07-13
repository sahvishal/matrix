using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class CustomTagFactory : ICustomTagFactory
    {
        public IEnumerable<CustomTagViewModel> Create(IEnumerable<CorporateTag> corporateTags, IEnumerable<Organization> organizations, IEnumerable<OrderedPair<string, long>> tagCustomerCountPairs)
        {
            var model = new List<CustomTagViewModel>();
            if (corporateTags != null && corporateTags.Count() > 0)
            {
                foreach (var corporateTag in corporateTags)
                {
                    var tagCustomerCount = tagCustomerCountPairs.SingleOrDefault(m => m.FirstValue.ToLower().Trim() == corporateTag.Tag.ToLower().Trim());
                    long customerCount = 0;
                    if (tagCustomerCount != null)
                        customerCount = tagCustomerCount.SecondValue;

                    var organization = organizations.Single(x => x.Id == corporateTag.CorporateId);

                    var customTagViewModel = new CustomTagViewModel
                    {
                        TagId = corporateTag.Id,
                        AccountName = organization.Name,
                        CustomTag = corporateTag.Tag,
                        CustomerCount = customerCount,
                        IsDisable = corporateTag.IsDisabled
                    };

                    model.Add(customTagViewModel);
                }
            }

            return model;
        }


    }
}
