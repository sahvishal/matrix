using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorInvoiceRepositoryTester : RepositoryTesterBase
    {
        private IValidator<PhysicianInvoice> _mockedValidator;
        private IMedicalVendorInvoiceFactory _medicalVendorInvoiceFactory;
        private IMedicalVendorInvoiceItemFactory _medicalVendorInvoiceItemFactory;

        private IMedicalVendorInvoiceRepository _medicalVendorInvoiceRepository;

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _mockedValidator = _mocks.StrictMock<IValidator<PhysicianInvoice>>();
            _medicalVendorInvoiceFactory = _mocks.StrictMock<IMedicalVendorInvoiceFactory>();
            _medicalVendorInvoiceItemFactory = _mocks.StrictMock<IMedicalVendorInvoiceItemFactory>();
            _medicalVendorInvoiceRepository = new MedicalVendorInvoiceRepository(_persistenceLayer, _mockedValidator, _medicalVendorInvoiceFactory,
                _medicalVendorInvoiceItemFactory);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<PhysicianInvoice>))]
        public void GetMedicalVendorInvoiceThrowsExceptionWhenGivenInvalidId()
        {
            const long invalidInvoiceId = 0;
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(false);

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.GetMedicalVendorInvoice(invalidInvoiceId);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<PhysicianInvoice>))]
        public void GetMedicalVendorInvoiceThrowsExceptionWhenGivenInvalidGuid()
        {
            Guid invalidGuid = Guid.NewGuid();
            ExpectFetchEntityUsingUniqueConstraint(false);

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.GetMedicalVendorInvoice(invalidGuid);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeMedicalVendorInvoiceApprovalStatusThrowsExceptionWhenGivenStatusIsInvalid()
        {
            const ApprovalStatus invalidApprovalStatus = 0;

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.ChangeMedicalVendorInvoiceApprovalStatus(1, invalidApprovalStatus);
            _mocks.VerifyAll();
        }

        [Test]
        public void ChangeMedicalVendorInvoiceApprovalStatusSetsApprovalDateToNullWhenUnapprovedStatusGiven()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectUpdateEntitiesDirectly(1);

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.ChangeMedicalVendorInvoiceApprovalStatus(1, ApprovalStatus.Unapproved);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeMedicalVendorInvoicePaymentStatusThrowsExceptionWhenGivenApprovalStatusIsInvalid()
        {
            const PaymentStatus invalidPaymentStatus = 0;

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.ChangeMedicalVendorInvoicePaymentStatus(1, invalidPaymentStatus, DateTime.Now);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveMedicalVendorInvoiceThrowsExceptionWhenGivenNullMedicalVendorInvoice()
        {
            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(InvalidObjectException<PhysicianInvoice>))]
        public void SaveMedicalVendorInvoiceThrowsExceptionWhenGivenInvalidMedicalVendorInvoice()
        {
            var medicalVendorInvoice = new PhysicianInvoice();

            Expect.Call(_mockedValidator.IsValid(medicalVendorInvoice)).Return(false);
            Expect.Call(_mockedValidator.GetBrokenRuleErrorMessages()).Return(new List<string>());

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(medicalVendorInvoice);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void SaveMedicalVendorInvoiceThrowsExceptionWhenSavingInvoiceFails()
        {
            var medicalVendorInvoice = new PhysicianInvoice();

            Expect.Call(_mockedValidator.IsValid(medicalVendorInvoice)).Return(true);
            ExpectGetDataAccessAdapterAndDispose(2);
            ExpectFetchEntityCollection();
            ExpectTransaction("MedicalVendorInvoiceRepository.SaveMedicalVendorInvoice", false);
            ExpectSaveEntity(false, true);
            Expect.Call(_medicalVendorInvoiceFactory.CreateMedicalVendorInvoiceEntity(medicalVendorInvoice))
                .Return(new PhysicianInvoiceEntity());

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(medicalVendorInvoice);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void SaveMedicalVendorInvoiceThrowsExceptionWhenSavingInvoiceItemsFail()
        {
            var medicalVendorInvoice = new PhysicianInvoice();
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(3);

            Expect.Call(_mockedValidator.IsValid(medicalVendorInvoice)).Return(true);
            ExpectGetDataAccessAdapterAndDispose(2);
            ExpectFetchEntityCollection();
            ExpectTransaction("MedicalVendorInvoiceRepository.SaveMedicalVendorInvoice", false);
            ExpectSaveEntity(true, true);
            ExpectSaveEntityCollection(0);
            Expect.Call(_medicalVendorInvoiceFactory.CreateMedicalVendorInvoiceEntity(medicalVendorInvoice))
                .Return(medicalVendorInvoiceEntity);
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntities
                (medicalVendorInvoiceEntity.PhysicianInvoiceId, medicalVendorInvoice.MedicalVendorInvoiceItems))
                .Return(new EntityCollection<PhysicianInvoiceItemEntity>());

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(medicalVendorInvoice);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(OverlappingInvoiceException))]
        public void SaveMedicalVendorInvoiceThrowsExceptionWhenOverlappingInvoiceFound()
        {
            var medicalVendorInvoice = new PhysicianInvoice();
            Expect.Call(_mockedValidator.IsValid(medicalVendorInvoice)).Return(true);
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection(new EntityCollection<PhysicianInvoiceEntity> {new PhysicianInvoiceEntity()});

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(medicalVendorInvoice);
            _mocks.VerifyAll();
        }

        [Test]
        public void SaveMedicalVendorInvoiceCommitsTransactionOnSuccessfulPersistence()
        {
            var medicalVendorInvoice = new PhysicianInvoice();
            var medicalVendorInvoiceEntity = new PhysicianInvoiceEntity(3);

            const bool expectCommit = true;
            Expect.Call(_mockedValidator.IsValid(medicalVendorInvoice)).Return(true);
            ExpectGetDataAccessAdapterAndDispose(2);
            ExpectFetchEntityCollection();
            ExpectTransaction("MedicalVendorInvoiceRepository.SaveMedicalVendorInvoice", expectCommit);
            ExpectSaveEntity(true, true);
            ExpectSaveEntityCollection(1);
            Expect.Call(_medicalVendorInvoiceFactory.CreateMedicalVendorInvoiceEntity(medicalVendorInvoice))
                .Return(medicalVendorInvoiceEntity);
            Expect.Call(_medicalVendorInvoiceItemFactory.CreateMedicalVendorInvoiceItemEntities
                (medicalVendorInvoiceEntity.PhysicianInvoiceId, medicalVendorInvoice.MedicalVendorInvoiceItems))
                .Return(new EntityCollection<PhysicianInvoiceItemEntity>());

            _mocks.ReplayAll();
            _medicalVendorInvoiceRepository.SaveMedicalVendorInvoice(medicalVendorInvoice);
            _mocks.VerifyAll();
        }

        [Test]
        public void HasInvoicePendingApprovalReturnsFalseWhenNoEntitiesReturned()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection();

            _mocks.ReplayAll();
            bool hasInvoicePendingApproval = _medicalVendorInvoiceRepository.HasInvoicePendingApproval(1);
            _mocks.VerifyAll();

            Assert.IsFalse(hasInvoicePendingApproval);
        }

        [Test]
        public void HasInvoicePendingApprovalReturnsTrueWhenOneEntityReturned()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection(new EntityCollection<PhysicianInvoiceEntity> {new PhysicianInvoiceEntity()});

            _mocks.ReplayAll();
            bool hasInvoicePendingApproval = _medicalVendorInvoiceRepository.HasInvoicePendingApproval(1);
            _mocks.VerifyAll();

            Assert.IsTrue(hasInvoicePendingApproval);
        }

        [Test]
        public void HasInvoicePendingApprovalReturnsTrueWhenMoreThanOneEntityReturned()
        {
            var medicalVendorInvoiceEntitiesToReturn = new EntityCollection<PhysicianInvoiceEntity>
                {new PhysicianInvoiceEntity(), new PhysicianInvoiceEntity(), new PhysicianInvoiceEntity()};
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollection(medicalVendorInvoiceEntitiesToReturn);

            _mocks.ReplayAll();
            bool hasInvoicePendingApproval = _medicalVendorInvoiceRepository.HasInvoicePendingApproval(1);
            _mocks.VerifyAll();

            Assert.IsTrue(hasInvoicePendingApproval);
        }

        [Test]
        public void GetOldestUnapprovedInvoiceForMedicalVendorUserReturnsNullWhenNoUnapprovedInvoicesExistsForId()
        {
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntityCollectionWithSortExpression();

            _mocks.ReplayAll();
            PhysicianInvoice medicalVendorInvoice =  _medicalVendorInvoiceRepository.
                GetOldestUnapprovedInvoiceForMedicalVendorUser(1);
            _mocks.VerifyAll();

            Assert.IsNull(medicalVendorInvoice);
        }

        [Test]
        public void GetOldestUnapprovedInvoiceForMedicalVendorUserReturnsInvoiceWhenUnapprovedInvoiceExists()
        {
            var collectionToReturn = new EntityCollection<PhysicianInvoiceEntity> { new PhysicianInvoiceEntity(3) };
            ExpectGetDataAccessAdapterAndDispose(2);
            ExpectFetchEntityCollectionWithSortExpression(collectionToReturn);
            ExpectFetchEntity(true);
            ExpectFetchEntityCollection();
            Expect.Call(_medicalVendorInvoiceFactory.CreateMedicalVendorInvoice(null, (EntityCollection<PhysicianInvoiceItemEntity>)null))
                .IgnoreArguments().Return(new PhysicianInvoice());

            _mocks.ReplayAll();
            PhysicianInvoice medicalVendorInvoice = _medicalVendorInvoiceRepository.
                GetOldestUnapprovedInvoiceForMedicalVendorUser(1);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorInvoice);
        }
    }
}