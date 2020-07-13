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
    public class HospitalPartnerPackageFactory : IHospitalPartnerPackageFactory
    {
        public OrganizationPackageEditModel CreateModel(Package package, HospitalPartnerPackage accountPackage)
        {
            return new OrganizationPackageEditModel
            {
                PackageId = package.Id,
                PackageName = package.Name,
                Gender = (Gender)package.Gender,
                IsRecommended = accountPackage.IsRecommended
            };
        }

        public IEnumerable<OrganizationPackageEditModel> CreateModel(IEnumerable<Package> packages, IEnumerable<HospitalPartnerPackage> accountPackages)
        {
            if (accountPackages.IsNullOrEmpty()) return null;

            var list =
                accountPackages.Select(
                    accountPackage => CreateModel(packages.FirstOrDefault(x => x.Id == accountPackage.PackageId), accountPackage))
                    .ToList();
            return list;
        }

        public HospitalPartnerPackage CreateDomain(OrganizationPackageEditModel model, long hospitalPartnerId)
        {
            return new HospitalPartnerPackage
            {
                HospitalPartnerId = hospitalPartnerId,
                PackageId = model.PackageId,
                IsRecommended = model.IsRecommended
            };
        }

        public IEnumerable<HospitalPartnerPackage> CreateDomain(IEnumerable<OrganizationPackageEditModel> modelList, long hospitalPartnerId)
        {
            if (modelList.IsNullOrEmpty()) return null;

            var list = modelList.Select(model => new HospitalPartnerPackage
            {
                HospitalPartnerId = hospitalPartnerId,
                PackageId = model.PackageId,
                IsRecommended = model.IsRecommended
            }).ToList();

            return list;
        }
       
    }
}