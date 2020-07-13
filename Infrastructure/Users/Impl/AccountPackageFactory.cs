using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class AccountPackageFactory : IAccountPackageFactory
    {
        public OrganizationPackageEditModel CreateModel(Package package, AccountPackage accountPackage)
        {
            return new OrganizationPackageEditModel
            {
                PackageId = package.Id,
                PackageName = package.Name,
                Gender = (Gender)package.Gender,
                IsRecommended = accountPackage.IsRecommended
            };
        }

        public IEnumerable<OrganizationPackageEditModel> CreateModel(IEnumerable<Package> packages, IEnumerable<AccountPackage> accountPackages)
        {
            if (accountPackages.IsNullOrEmpty()) return null;

            var list =
                accountPackages.Select(
                    accountPackage => CreateModel(packages.FirstOrDefault(x => x.Id == accountPackage.PackageId), accountPackage))
                    .ToList();
            return list;
        }

        public AccountPackage CreateDomain(OrganizationPackageEditModel model, long accountId)
        {
            return new AccountPackage
            {
                AccountId = accountId,
                PackageId = model.PackageId,
                IsRecommended = model.IsRecommended
            };
        }

        public IEnumerable<AccountPackage> CreateDomain(IEnumerable<OrganizationPackageEditModel> modelList, long accountId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => new AccountPackage
            {
                AccountId = accountId,
                PackageId = model.PackageId,
                IsRecommended = model.IsRecommended
            }).ToList();

            return list;
        }
    }
}