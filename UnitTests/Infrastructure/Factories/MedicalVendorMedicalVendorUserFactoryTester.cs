using System.Collections.Generic;
using System.Linq;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Factories;
using NUnit.Framework;
using Falcon.App.Infrastructure.Interfaces;
using System;

namespace HealthYes.Web.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class MedicalVendorMedicalVendorUserFactoryTester
    {
        private readonly IMedicalVendorMedicalVendorUserFactory _medicalVendorMedicalVendorUserFactoryfactory = 
            new MedicalVendorMedicalVendorUserFactory();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorMedicalVendorUserThrowsExceptionWhenNullUserEntityGiven()
        {
            _medicalVendorMedicalVendorUserFactoryfactory.CreateMedicalVendorMedicalVendorUser(0, null);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserSetsIdToGivenId()
        {
            const long medicalVendorMedicalVendorUserId = 3;

            MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserId, string.Empty, string.Empty, string.Empty);

            Assert.AreEqual(medicalVendorMedicalVendorUserId, medicalVendorMedicalVendorUser.Id);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserMapsNameFieldsCorrectly()
        {
            var expectedName = new Name("Test", "Testly", "McTester");

            MedicalVendorMedicalVendorUser user = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(0, expectedName.FirstName, expectedName.MiddleName, expectedName.LastName);

            Assert.AreEqual(expectedName.FullName, user.Name.FullName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorMedicalVendorUserThrowsExceptionWhenNullRowGiven()
        {
            _medicalVendorMedicalVendorUserFactoryfactory.CreateMedicalVendorMedicalVendorUser((MedicalVendorInvoiceItemRow)null);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserReturnsUserWhenGivenValidRow()
        {
            var medicalVendorInvoiceItemRow = (MedicalVendorInvoiceItemRow)new MedicalVendorInvoiceItemTypedView().Rows.Add();
            
            MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(medicalVendorInvoiceItemRow);

            Assert.IsNotNull(medicalVendorMedicalVendorUser);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserReturnsUserWhenGivenValidUserEntity()
        {
            MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(0, new UserEntity());

            Assert.IsNotNull(medicalVendorMedicalVendorUser);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUsersReturnsEmptyListWhenEmptyViewGiven()
        {
            List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUsers(new MedicalVendorMedicalVendorUserTypedView());

            Assert.IsNotNull(medicalVendorMedicalVendorUsers);
            Assert.IsEmpty(medicalVendorMedicalVendorUsers);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUsersReturnsOneUserWhenOneRowGiven()
        {
            var medicalVendorMedicalVendorUserView = new MedicalVendorMedicalVendorUserTypedView();
            medicalVendorMedicalVendorUserView.Rows.Add();

            List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUsers(medicalVendorMedicalVendorUserView);

            Assert.IsTrue(medicalVendorMedicalVendorUsers.HasSingleItem(), "{0} item(s) returned.", 
                medicalVendorMedicalVendorUsers.Count);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUsersReturnsNumberOfUsersEqualToNumberOfRows()
        {
            var medicalVendorMedicalVendorUserView = new MedicalVendorMedicalVendorUserTypedView();
            medicalVendorMedicalVendorUserView.Rows.Add();

            for (int i = 2; i < 10; i++)
            {
                medicalVendorMedicalVendorUserView.Rows.Add();
                List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = _medicalVendorMedicalVendorUserFactoryfactory.
                   CreateMedicalVendorMedicalVendorUsers(medicalVendorMedicalVendorUserView);

                Assert.AreEqual(i, medicalVendorMedicalVendorUsers.Count, "{0} items expected but {1} returned.",
                    i, medicalVendorMedicalVendorUsers.Count);
            }
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUsersMapsTwoRowsToTwoObjects()
        {
            const long expectedId1 = 11;
            const long expectedId2 = 22;
            var medicalVendorMedicalVendorUserView = new MedicalVendorMedicalVendorUserTypedView();
            medicalVendorMedicalVendorUserView.Rows.Add(expectedId1);
            medicalVendorMedicalVendorUserView.Rows.Add(expectedId2);

            List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers = _medicalVendorMedicalVendorUserFactoryfactory
                .CreateMedicalVendorMedicalVendorUsers(medicalVendorMedicalVendorUserView);

            Assert.IsTrue(medicalVendorMedicalVendorUsers.Where(m => m.Id == expectedId1).Count() == 1, 
                "MVMVUser {0} not returned.", expectedId1);
            Assert.IsTrue(medicalVendorMedicalVendorUsers.Where(m => m.Id == expectedId2).Count() == 1,
                "MVMVUser {0} not returned.", expectedId2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorMedicalVendorUsersThrowsExceptionWhenNullViewGiven()
        {
            _medicalVendorMedicalVendorUserFactoryfactory.CreateMedicalVendorMedicalVendorUsers(null);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserReturnsUser()
        {
            var medicalVendorMedicalVendorUserView = new MedicalVendorMedicalVendorUserTypedView();
            medicalVendorMedicalVendorUserView.Rows.Add();
            var medicalVendorMedicalVendorUserRow = (MedicalVendorMedicalVendorUserRow)medicalVendorMedicalVendorUserView.Rows[0];

            MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserRow);

            Assert.IsNotNull(medicalVendorMedicalVendorUser);
        }

        [Test]
        public void CreateMedicalVendorMedicalVendorUserMapsRowPropertiesToUserProperties()
        {
            const long medicalVendorMedicalVendorUserId = 1;
            const long medicalVendorId = 2;
            const string expectedMedicalVendorName = "MedicalVendorName";
            const string expectedRoleName = "RoleName";
            var expectedName = new Name("FirstName", "MiddleName", "LastName");
            var medicalVendorMedicalVendorUserView = new MedicalVendorMedicalVendorUserTypedView();
            medicalVendorMedicalVendorUserView.Rows.Add(medicalVendorMedicalVendorUserId, medicalVendorId, 
                expectedMedicalVendorName, expectedRoleName, expectedName.FirstName, expectedName.MiddleName, expectedName.LastName);
            var medicalVendorMedicalVendorUserRow = (MedicalVendorMedicalVendorUserRow)medicalVendorMedicalVendorUserView.Rows[0];

            MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser = _medicalVendorMedicalVendorUserFactoryfactory.
                CreateMedicalVendorMedicalVendorUser(medicalVendorMedicalVendorUserRow);

            Assert.AreEqual(medicalVendorMedicalVendorUserId, medicalVendorMedicalVendorUser.Id);
            Assert.AreEqual(medicalVendorId, medicalVendorMedicalVendorUser.MedicalVendorId);
            Assert.AreEqual(expectedMedicalVendorName, medicalVendorMedicalVendorUser.MedicalVendorName);
            Assert.AreEqual(expectedRoleName, medicalVendorMedicalVendorUser.RoleName);
            Assert.AreEqual(expectedName.FirstName, medicalVendorMedicalVendorUser.Name.FirstName);
            Assert.AreEqual(expectedName.MiddleName, medicalVendorMedicalVendorUser.Name.MiddleName);
            Assert.AreEqual(expectedName.LastName, medicalVendorMedicalVendorUser.Name.LastName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateMedicalVendorMedicalVendorUserThrowsExceptionWhenGivenNullRow()
        {
            _medicalVendorMedicalVendorUserFactoryfactory.CreateMedicalVendorMedicalVendorUser((MedicalVendorMedicalVendorUserRow)null);
        }
    }
}