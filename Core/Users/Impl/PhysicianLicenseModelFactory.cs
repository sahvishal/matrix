using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{
    public class PhysicianLicenseModelFactory:IPhysicianLicenseModelFactory
    {
        public IEnumerable<PhysicianLicenseModel>CreateMultiple(IEnumerable<PhysicianLicense> physicianLicenses, IEnumerable<State> states)
        {
            return physicianLicenses.Select(pl => Create(pl, states));
        }

        public PhysicianLicenseModel Create(PhysicianLicense physicianLicense,IEnumerable<State> states)
        {
            return new PhysicianLicenseModel
                       {
                           LicenseId = physicianLicense.Id,
                           LicenseNumber = physicianLicense.LicenseNumber,
                           Expirydate = physicianLicense.Expirydate,
                           DateCreated = physicianLicense.DateCreated,
                           State = states.Where(s=>s.Id==physicianLicense.StateId).Select(s=>s.Name).FirstOrDefault(),
                           StateId = physicianLicense.StateId
                       };
        }

        public IEnumerable<PhysicianLicense> CreateMultiple(IEnumerable<PhysicianLicenseModel> physicianLicenseModels, long orgRoleUserId)
        {
            return physicianLicenseModels.Select(pl => Create(pl, orgRoleUserId));
        }

        public PhysicianLicense Create(PhysicianLicenseModel physicianLicenseModel, long orgroleUserId)
        {
            return new PhysicianLicense()
                       {
                           Id = physicianLicenseModel.LicenseId,
                           LicenseNumber = physicianLicenseModel.LicenseNumber,
                           PhysicianId = orgroleUserId,
                           StateId = physicianLicenseModel.StateId,
                           Expirydate = physicianLicenseModel.Expirydate,
                           DateCreated = physicianLicenseModel.DateCreated
                       };
        }
    }
}
