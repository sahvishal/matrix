using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICorporateAccountListModelFactory
    {
        CorporateAccountListModel Create(IEnumerable<CorporateAccount> accounts, IEnumerable<OrderedPair<long, string>> accountIdPackagesPair, OrganizationListModel orgListModel);
    }
}