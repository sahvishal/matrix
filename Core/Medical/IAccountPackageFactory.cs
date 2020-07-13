using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IAccountPackageFactory
    {
        OrganizationPackageEditModel CreateModel(Package package, AccountPackage accountPackage);
        IEnumerable<OrganizationPackageEditModel> CreateModel(IEnumerable<Package> packages, IEnumerable<AccountPackage> accountPackages);
        AccountPackage CreateDomain(OrganizationPackageEditModel model, long accountId);
        IEnumerable<AccountPackage> CreateDomain(IEnumerable<OrganizationPackageEditModel> modelList, long accountId);
    }
}
