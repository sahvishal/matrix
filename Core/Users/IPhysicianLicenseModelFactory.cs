using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IPhysicianLicenseModelFactory
    {
        IEnumerable<PhysicianLicenseModel> CreateMultiple(IEnumerable<PhysicianLicense> physicianLicenses,
                                                          IEnumerable<State> states);

        PhysicianLicenseModel Create(PhysicianLicense physicianLicense, IEnumerable<State> states);

        IEnumerable<PhysicianLicense> CreateMultiple(IEnumerable<PhysicianLicenseModel> physicianLicenseModels,
                                                     long orgRoleUserId);

        PhysicianLicense Create(PhysicianLicenseModel physicianLicenseModel, long orgroleUserId);
    }
}
