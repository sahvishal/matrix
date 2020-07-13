using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users.Impl
{
    public class PhysicianLabTestModelFactory : IPhysicianLabTestModelFactory
    {
        public IEnumerable<PhysicianLabTestModel> CreateMultiple(IEnumerable<PhysicianLabTest> physicianLicenses, IEnumerable<State> states)
        {
            return physicianLicenses.Select(pl => Create(pl, states));
        }

        public PhysicianLabTestModel Create(PhysicianLabTest physicianLabTest, IEnumerable<State> states)
        {
            return new PhysicianLabTestModel
            {
                LabTestLicenseId = physicianLabTest.Id,
                IfobtLicenseNo = physicianLabTest.IfobtLicenseNo,
                MicroalbumineLicenseNo = physicianLabTest.MicroalbumineLicenseNo,
                DateCreated = physicianLabTest.DateCreated,
                State = states.Where(s => s.Id == physicianLabTest.StateId).Select(s => s.Name).FirstOrDefault(),
                StateId = physicianLabTest.StateId,
                IsActive = physicianLabTest.IsActive,
                IsDefault = physicianLabTest.IsDefault


            };
        }

        public IEnumerable<PhysicianLabTest> CreateMultiple(IEnumerable<PhysicianLabTestModel> physicianLicenseModels, long orgRoleUserId)
        {
            return physicianLicenseModels.Select(pl => Create(pl, orgRoleUserId));
        }

        public PhysicianLabTest Create(PhysicianLabTestModel physicianLicenseModel, long orgroleUserId)
        {
            return new PhysicianLabTest()
            {
                Id = physicianLicenseModel.LabTestLicenseId,
                IfobtLicenseNo = physicianLicenseModel.IfobtLicenseNo,
                MicroalbumineLicenseNo = physicianLicenseModel.MicroalbumineLicenseNo,
                PhysicianId = orgroleUserId,
                StateId = physicianLicenseModel.StateId,
                DateCreated = physicianLicenseModel.DateCreated,
                IsActive = physicianLicenseModel.IsActive,
                IsDefault = physicianLicenseModel.IsDefault
            };
        }
    }
}