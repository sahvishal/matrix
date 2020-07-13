using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Service;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("Please revisit after the payments and earning for physician are in place.")]
    public class MedicalVendorEarningServiceTester
    {
        private MockRepository _mocks;
        private IMedicalVendorEarningAggregateRepository _medicalVendorEarningAggregateRepository;
        private IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private IMedicalVendorEarningFactory _medicalVendorEarningFactory;

        private IMedicalVendorEarningService _medicalVendorEarningService;

        [SetUp]
        protected virtual void SetUp()
        {
            _mocks = new MockRepository();
            _medicalVendorEarningAggregateRepository = _mocks.StrictMock<IMedicalVendorEarningAggregateRepository>();
            _organizationRoleUserRepository = _mocks.StrictMock<IOrganizationRoleUserRepository>();
            _medicalVendorEarningFactory = _mocks.StrictMock<IMedicalVendorEarningFactory>();
            
            _medicalVendorEarningService = new MedicalVendorEarningService(_medicalVendorEarningAggregateRepository,
                _organizationRoleUserRepository, _medicalVendorEarningFactory);
        }

        [TearDown]
        protected virtual void TearDown()
        {
            _mocks = null;
        }

        #region Expectations

        private void ExpectCreateMedicalVendorEarning(MedicalVendorEarningAggregate medicalVendorEarningAggregate,
            long dataCreatorId, DateTime dateCreated, MedicalVendorEarning medicalVendorEarningToReturn)
        {
            Expect.Call(_medicalVendorEarningFactory.CreateMedicalVendorEarning(medicalVendorEarningAggregate, dataCreatorId, dateCreated))
                .Return(medicalVendorEarningToReturn);
        }

        private void ExpectGetOrganizationRoleUser(OrganizationRoleUser organizationRoleUser)
        {
            //Expect.Call(_organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUser.UserId,
            //    organizationRoleUser.RoleId, organizationRoleUser.OrganizationId))
            //    .Return(organizationRoleUser);
        }

        private void ExpectGetMedicalVendorEarningAggregate(long customerEventTestId, bool isEventCustomerActive,
            MedicalVendorEarningAggregate aggregateToReturn)
        {
            Expect.Call(_medicalVendorEarningAggregateRepository.GetMedicalVendorEarningAggregate(0, customerEventTestId,
                isEventCustomerActive)).Return(aggregateToReturn);
        }

        #endregion

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenerateMedicalVendorEarningThrowsExceptionWhenGivenOrganizationRoleUserIsNull()
        {
            //_medicalVendorEarningService.GenerateMedicalVendorEarning(0, 1, null, new DateTime(), true);
            _medicalVendorEarningService.GenerateMedicalVendorEarning(1, 1, new DateTime(), true);
        }

        [Test]
        public void GenerateMedicalVendorEarningDoesNotFetchOrganizationRoleUserWhenIdAlreadyProvided()
        {
            const long customerEventTestId = 1;
            const bool isEventCustomerActive = true;
            var dateCreated = new DateTime();
            var organizationRoleUserWithId = new OrganizationRoleUser(3);
            var medicalVendorEarningAggregate = new MedicalVendorEarningAggregate();
            ExpectGetMedicalVendorEarningAggregate(customerEventTestId, isEventCustomerActive, medicalVendorEarningAggregate);
            ExpectCreateMedicalVendorEarning(medicalVendorEarningAggregate, organizationRoleUserWithId.Id, 
                dateCreated, new MedicalVendorEarning());

            _mocks.ReplayAll();
            //_medicalVendorEarningService.GenerateMedicalVendorEarning(0, customerEventTestId, organizationRoleUserWithId, 
            //    dateCreated, isEventCustomerActive);

            _medicalVendorEarningService.GenerateMedicalVendorEarning(organizationRoleUserWithId.Id, customerEventTestId, 
                dateCreated, isEventCustomerActive);
            _mocks.VerifyAll();
        }

        [Test]
        public void GenerateMedicalVendorEarningFetchesOrganizationRoleUserWhenIdNotProvided()
        {
            const long customerEventTestId = 1;
            const bool isEventCustomerActive = true;
            var dateCreated = new DateTime();
            var organizationRoleUserWithoutId = new OrganizationRoleUser {UserId = 5, RoleId = 6, OrganizationId = 1};
            var medicalVendorEarningAggregate = new MedicalVendorEarningAggregate();
            ExpectGetMedicalVendorEarningAggregate(customerEventTestId, isEventCustomerActive, medicalVendorEarningAggregate);
            ExpectGetOrganizationRoleUser(organizationRoleUserWithoutId);
            ExpectCreateMedicalVendorEarning(medicalVendorEarningAggregate, organizationRoleUserWithoutId.Id,
                            dateCreated, new MedicalVendorEarning());

            _mocks.ReplayAll();
            //_medicalVendorEarningService.GenerateMedicalVendorEarning(0, customerEventTestId, organizationRoleUserWithoutId,
            //    dateCreated, isEventCustomerActive);
            _medicalVendorEarningService.GenerateMedicalVendorEarning(organizationRoleUserWithoutId.Id, customerEventTestId, 
                dateCreated, isEventCustomerActive);
            _mocks.VerifyAll();
        }
    }
}