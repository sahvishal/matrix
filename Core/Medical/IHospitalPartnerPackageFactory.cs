using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IHospitalPartnerPackageFactory
    {
        OrganizationPackageEditModel CreateModel(Package package, HospitalPartnerPackage accountPackage);
        IEnumerable<OrganizationPackageEditModel> CreateModel(IEnumerable<Package> packages, IEnumerable<HospitalPartnerPackage> accountPackages);
        HospitalPartnerPackage CreateDomain(OrganizationPackageEditModel model, long hospitalPartnerId);
        IEnumerable<HospitalPartnerPackage> CreateDomain(IEnumerable<OrganizationPackageEditModel> modelList, long hospitalPartnerId);
    }
}