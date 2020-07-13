using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class MedicalVendorPaymentMapperTester
    {
        private MockRepository _mocks;
        private IDataRecorderMetaDataFactory _mockedFactory;
        
        private IMapper<MedicalVendorPayment, PhysicianPaymentEntity> _mapper;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _mockedFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _mapper = new MedicalVendorPaymentMapper(_mockedFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _mocks = null;
        }

        #region GetTestMedicalVendorPaymentEntity()

        private static PhysicianPaymentEntity GetTestMedicalVendorPaymentEntity(PaymentStatus paymentStatus)
        {
            return GetTestMedicalVendorPaymentEntity(0, string.Empty, DateTime.MinValue, paymentStatus, 0);
        }

        private static PhysicianPaymentEntity GetTestMedicalVendorPaymentEntity(long medicalVendorPaymentId, 
            string notes)
        {
            return GetTestMedicalVendorPaymentEntity(medicalVendorPaymentId, notes, 
                DateTime.MinValue, 0, 0);
        }

        private static PhysicianPaymentEntity GetTestMedicalVendorPaymentEntity(long medicalVendorPaymentId, 
            string notes, DateTime dateCreated, PaymentStatus paymentStatus, long dataRecorderCreatorId)
        {
            return new PhysicianPaymentEntity(medicalVendorPaymentId)
            {
                Notes = notes,
                DateCreated = dateCreated,
                PaymentStatus = (byte)paymentStatus,
                DataRecoderCreatorId = dataRecorderCreatorId
            };
        }

        #endregion

        private void ExpectCreateDataRecorderMetaData(PhysicianPaymentEntity medicalVendorPaymentEntity)
        {
            long dataRecoderCreatorId = medicalVendorPaymentEntity.DataRecoderCreatorId;
            DateTime dateCreated = medicalVendorPaymentEntity.DateCreated;
            var dataRecorderMetaData = new DataRecorderMetaData 
                {DataRecorderCreator = new OrganizationRoleUser(), DateCreated = dateCreated};
            Expect.Call(_mockedFactory.CreateDataRecorderMetaData(dataRecoderCreatorId, dateCreated)).
                Return(dataRecorderMetaData);
        }

        [Test]
        public void MapFromEntityMapsEntityPropertiesToDomainProperties()
        {
            const long expectedMedicalVendorPaymentId = 234;
            const string expectedNotes = "Notes";
            var medicalVendorPaymentEntity = GetTestMedicalVendorPaymentEntity
                (expectedMedicalVendorPaymentId, expectedNotes);

            ExpectCreateDataRecorderMetaData(medicalVendorPaymentEntity);

            _mocks.ReplayAll();
            var medicalVendorPayment = _mapper.Map(medicalVendorPaymentEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedMedicalVendorPaymentId, medicalVendorPayment.Id, 
                "MedicalVendorPaymentId was not set.");
            Assert.AreEqual(expectedNotes, medicalVendorPayment.Notes, 
                "The notes were not set.");
        }

        [Test]
        public void MapSetsPaymentStatusToUnpaidWhenStatusIs1()
        {
            const PaymentStatus expectedPaymentStatus = PaymentStatus.Unpaid;
            var medicalVendorPaymentEntity = GetTestMedicalVendorPaymentEntity(expectedPaymentStatus);

            ExpectCreateDataRecorderMetaData(medicalVendorPaymentEntity);

            _mocks.ReplayAll();
            var medicalVendorPayment = _mapper.Map(medicalVendorPaymentEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedPaymentStatus, medicalVendorPayment.PaymentStatus);
        }
        
        [Test]
        public void MapMapsPaymentPropertiesToCorrectEntityProperties()
        {
            var medicalVendorPayment = new MedicalVendorPayment(3)
            {
                Notes = "Notes",
                DataRecorderMetaData = new DataRecorderMetaData 
                    {DataRecorderCreator = new OrganizationRoleUser(3), DateCreated = new DateTime()}
            };

            _mocks.ReplayAll();
            PhysicianPaymentEntity medicalVendorPaymentEntity = _mapper.Map(medicalVendorPayment);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorPayment.Id, medicalVendorPaymentEntity.PhysicianPaymentId);
            Assert.AreEqual(medicalVendorPayment.Notes, medicalVendorPaymentEntity.Notes);
            Assert.AreEqual(medicalVendorPayment.DataRecorderMetaData.DataRecorderCreator.Id, 
                            medicalVendorPaymentEntity.DataRecoderCreatorId);
            Assert.AreEqual(medicalVendorPayment.DataRecorderMetaData.DateCreated, 
                medicalVendorPaymentEntity.DateCreated);
        }

        [Test]
        public void MapSetsModifierIdAndDateToNullWhenModifierIsNull()
        {
            var medicalVendorPayment = new MedicalVendorPayment
            {
                DataRecorderMetaData = new DataRecorderMetaData 
                    { DataRecorderCreator = new OrganizationRoleUser(3), DateCreated = new DateTime() }
            };
            medicalVendorPayment.DataRecorderMetaData.DataRecorderModifier = null;

            _mocks.ReplayAll();
            PhysicianPaymentEntity medicalVendorPaymentEntity = _mapper.Map(medicalVendorPayment);
            _mocks.VerifyAll();

            Assert.IsNull(medicalVendorPaymentEntity.DataRecoderModifierId);
            Assert.IsNull(medicalVendorPaymentEntity.DateModifed);
        }

        [Test]
        public void MapSetsModifierIdAndDateToValuesWhenModifierIsNotNull()
        {
            var medicalVendorPayment = new MedicalVendorPayment
            {
                DataRecorderMetaData = new DataRecorderMetaData 
                    { DataRecorderCreator = new OrganizationRoleUser(3), DateCreated = new DateTime() }
            };
            medicalVendorPayment.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(5);
            medicalVendorPayment.DataRecorderMetaData.DateModified = new DateTime(2005, 3, 1);

            _mocks.ReplayAll();
            PhysicianPaymentEntity medicalVendorPaymentEntity = _mapper.Map(medicalVendorPayment);
            _mocks.VerifyAll();

            Assert.AreEqual(medicalVendorPayment.DataRecorderMetaData.DataRecorderModifier.Id, 
                medicalVendorPaymentEntity.DataRecoderModifierId);
            Assert.AreEqual(medicalVendorPayment.DataRecorderMetaData.DateModified, 
                medicalVendorPaymentEntity.DateModifed);
        }

        [Test]
        public void MapSetsPaymentStatusToByteValueOfUnpaidWhenUnpaidGiven()
        {
            var medicalVendorPayment = new MedicalVendorPayment
            {
                PaymentStatus = PaymentStatus.Unpaid,
                DataRecorderMetaData = new DataRecorderMetaData 
                    { DataRecorderCreator = new OrganizationRoleUser(3), DateCreated = new DateTime() }
            };

            _mocks.ReplayAll();
            PhysicianPaymentEntity medicalVendorPaymentEntity = _mapper.Map(medicalVendorPayment);
            _mocks.VerifyAll();

            Assert.AreEqual((byte)medicalVendorPayment.PaymentStatus, 
                medicalVendorPaymentEntity.PaymentStatus);
        }
    }
}