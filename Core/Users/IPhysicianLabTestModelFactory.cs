using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IPhysicianLabTestModelFactory
    {
        IEnumerable<PhysicianLabTestModel> CreateMultiple(IEnumerable<PhysicianLabTest> physicianLicenses,
            IEnumerable<State> states);

        PhysicianLabTestModel Create(PhysicianLabTest physicianLicense, IEnumerable<State> states);

        IEnumerable<PhysicianLabTest> CreateMultiple(IEnumerable<PhysicianLabTestModel> physicianLicenseModels,
            long orgRoleUserId);

        PhysicianLabTest Create(PhysicianLabTestModel physicianLicenseModel, long orgroleUserId);
    }
}