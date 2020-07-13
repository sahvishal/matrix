using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation]
    public class CorporateAccountListModelFactory : ICorporateAccountListModelFactory
    {
        public CorporateAccountListModel Create(IEnumerable<CorporateAccount> accounts, IEnumerable<OrderedPair<long, string>> accountIdPackagesPair, OrganizationListModel orgListModel)
        {
            var model = new CorporateAccountListModel();
            var basicModels = new CorporateAccountModel[accounts.Count()];
            var index = 0;
            foreach (var account in accounts)
            {
                basicModels[index++] = new CorporateAccountModel
                                     {
                                         ContractNotes = account.ContractNotes,
                                         DefaultPackages = accountIdPackagesPair != null ? accountIdPackagesPair.Where(ap => ap.FirstValue == account.Id).Select(ap => ap.SecondValue).ToArray() : null,
                                         OrganizationBasicInfoModel = orgListModel.Organizations.FirstOrDefault(o => o.Id == account.Id),
                                         IsHealthPlan = account.IsHealthPlan
                                     };

            }
            model.CorporateAccounts = basicModels;
            return model;
        }
    }
}