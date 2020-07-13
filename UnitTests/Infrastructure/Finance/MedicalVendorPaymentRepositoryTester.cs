using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Web.UnitTests.Infrastructure.Application;
using NUnit.Framework;
using Rhino.Mocks;
using IPaymentInstrumentRepository = Falcon.App.Core.Finance.IPaymentInstrumentRepository;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorPaymentRepositoryTester : RepositoryTesterBase
    {
        private IMedicalVendorPaymentRepository _medicalVendorPaymentRepository;
        private IPaymentInstrumentRepository _paymentInstrumentRepository;
        private IMapper<MedicalVendorPayment, PhysicianPaymentEntity> _mockedMapper;
        private IValidator<MedicalVendorPayment> _validator;

        private readonly List<long> _validInvoiceIds = new List<long> { 3 };

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            _paymentInstrumentRepository = _mocks.StrictMock<IPaymentInstrumentRepository>();
            _mockedMapper = _mocks.StrictMock<IMapper<MedicalVendorPayment, PhysicianPaymentEntity>>();
            _validator = _mocks.StrictMock<IValidator<MedicalVendorPayment>>();

            _medicalVendorPaymentRepository = new MedicalVendorPaymentRepository
                (_persistenceLayer, _paymentInstrumentRepository, _validator, _mockedMapper);
        }

        [TearDown]
        protected override void TearDown()
        {
            base.TearDown();
            _medicalVendorPaymentRepository = null;
        }

        #region Delegates and Expectations

        private long _medicalVendorPaymentIdPassedToFactory;
        private delegate bool CreateMedicalVendorPaymentDelegate
            (PhysicianPaymentEntity medicalVendorPaymentEntity);
        private bool CreateMedicalVendorPayment(PhysicianPaymentEntity medicalVendorPaymentEntity)
        {
            _medicalVendorPaymentIdPassedToFactory = medicalVendorPaymentEntity.PhysicianPaymentId;
            return true;
        }

        private void ExpectCreateMedicalVendorPayment()
        {
            Expect.Call(_mockedMapper.Map((PhysicianPaymentEntity)null)).IgnoreArguments().
                Return(new MedicalVendorPayment()).
                Callback(new CreateMedicalVendorPaymentDelegate(CreateMedicalVendorPayment));
        }

        private void ExpectSaveEntityTransaction(MedicalVendorPayment medicalVendorPayment,
            PhysicianPaymentEntity medicalVendorPaymentEntity, bool rollBack)
        {
            Expect.Call(_mockedMapper.Map(medicalVendorPayment)).Return(medicalVendorPaymentEntity);
            ExpectTransaction("MedicalVendorPaymentRepository.MakePayment", !rollBack);
        }

        private void ExpectGetPaymentInstrumentsForMedicalVendorPayment(int medicalVendorPaymentId)
        {
            Expect.Call(_paymentInstrumentRepository.GetPaymentInstrumentsForPayment
                (medicalVendorPaymentId)).Return(new List<PaymentInstrument>());
        }

        #endregion

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<MedicalVendorPayment>))]
        public void GetMedicalVendorPaymentThrowsExceptionWhenNonexistentIdGiven()
        {
            const bool medicalVendorPaymentIdExists = false;
            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(medicalVendorPaymentIdExists);

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.GetMedicalVendorPayment(0);
            _mocks.VerifyAll();
        }

        [Test]
        public void GetMedicalVendorPaymentReturnsMedicalVendorPaymentForExistingId()
        {
            const int medicalVendorPaymentId = 34;
            const bool medicalVendorPaymentIdExists = true;

            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(medicalVendorPaymentIdExists);
            ExpectGetPaymentInstrumentsForMedicalVendorPayment(medicalVendorPaymentId);
            ExpectCreateMedicalVendorPayment();

            _mocks.ReplayAll();
            MedicalVendorPayment medicalVendorPayment = _medicalVendorPaymentRepository.
                GetMedicalVendorPayment(medicalVendorPaymentId);
            _mocks.VerifyAll();

            Assert.IsNotNull(medicalVendorPayment, "No medical vendor payment was returned.");
        }

        [Test]
        public void GetMedicalVendorPaymentPassesExistingIdToFactory()
        {
            const int expectedMedicalVendorPaymentId = 10;
            const bool medicalVendorPaymentIdExists = true;

            ExpectGetDataAccessAdapterAndDispose();
            ExpectFetchEntity(medicalVendorPaymentIdExists);
            ExpectGetPaymentInstrumentsForMedicalVendorPayment(expectedMedicalVendorPaymentId);
            ExpectCreateMedicalVendorPayment();

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.GetMedicalVendorPayment(expectedMedicalVendorPaymentId);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedMedicalVendorPaymentId, _medicalVendorPaymentIdPassedToFactory,
                "Returned MedicalVendorPaymentId did not match.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MakePaymentThrowsExceptionWhenNullPaymentGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(null, _validInvoiceIds);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MakePaymentThrowsExceptionWhenNullInvoiceIdsListGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(new MedicalVendorPayment(), null);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(EmptyCollectionException))]
        public void MakePaymentThrowsExceptionWhenEmptyInvoiceIdListGiven()
        {
            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(new MedicalVendorPayment(), new List<long>());
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(InvalidObjectException<MedicalVendorPayment>))]
        public void MakePaymentThrowsExceptionWhenPaymentIsNotValid()
        {
            var medicalVendorPayment = new MedicalVendorPayment 
                { PaymentInstruments = new List<PaymentInstrument> { new Check() } };
            Expect.Call(_validator.IsValid(medicalVendorPayment)).Return(false);
            Expect.Call(_validator.GetBrokenRuleErrorMessages()).Return(new List<string>());

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(medicalVendorPayment, _validInvoiceIds);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(EmptyCollectionException))]
        public void MakePaymentThrowsExceptionWhenPaymentInstrumentCollectionIsEmpty()
        {
            var medicalVendorPayment = new MedicalVendorPayment();
            medicalVendorPayment.PaymentInstruments.Clear();

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(medicalVendorPayment, _validInvoiceIds);
            _mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(PersistenceFailureException))]
        public void MakePaymentThrowsExceptionWhenSavingPaymentToPersistenceFails()
        {
            var medicalVendorPayment = new MedicalVendorPayment 
                {PaymentInstruments = new List<PaymentInstrument> {new Check()}};
            var medicalVendorPaymentEntity = new PhysicianPaymentEntity();

            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(false, true, medicalVendorPaymentEntity);
            ExpectSaveEntityTransaction(medicalVendorPayment, medicalVendorPaymentEntity, true);
            Expect.Call(_validator.IsValid(medicalVendorPayment)).Return(true);

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(medicalVendorPayment, _validInvoiceIds);
            _mocks.VerifyAll();
        }

        [Test]
        public void MakePaymentDoesNotBombWhenAllParametersAreCorrectAndPersistenceSucceeds()
        {
            var dataRecorderMetaData = new DataRecorderMetaData 
                {DataRecorderCreator = new OrganizationRoleUser(), 
                DataRecorderModifier = new OrganizationRoleUser()};
            var check = new Check {DataRecorderMetaData = dataRecorderMetaData};
            var medicalVendorPayment = new MedicalVendorPayment 
                { PaymentInstruments = new List<PaymentInstrument> { check } };
            var medicalVendorPaymentEntity = new PhysicianPaymentEntity();

            ExpectGetDataAccessAdapterAndDispose();
            ExpectSaveEntity(true, true, medicalVendorPaymentEntity);
            ExpectSaveEntityTransaction(medicalVendorPayment, medicalVendorPaymentEntity, false);
            ExpectSaveEntityCollection(_validInvoiceIds.Count);
            ExpectSaveEntity(true, true);
            ExpectSaveEntity(true);
            Expect.Call(_validator.IsValid(medicalVendorPayment)).Return(true);

            _mocks.ReplayAll();
            _medicalVendorPaymentRepository.MakePayment(medicalVendorPayment, _validInvoiceIds);
            _mocks.VerifyAll();
        }
    }
}