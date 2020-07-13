using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace Falcon.UnitTests.Infrastructure.Marketing
{
    [TestFixture]
    public class GiftCertificateMapperTester
    {
        private MockRepository _mocks;
        private IMapper<GiftCertificate,GiftCertificateEntity> _giftCertificateFactory;
        private IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        [SetUp]
        public void SetUp()
        {
            _mocks = new MockRepository();
            _dataRecorderMetaDataFactory = _mocks.StrictMock<IDataRecorderMetaDataFactory>();
            _giftCertificateFactory = new GiftCertificateMapper(_dataRecorderMetaDataFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _giftCertificateFactory = null;
        }

        private static GiftCertificate GetValidGiftCertificate()
        {
            return GetValidGiftCertificate(0);
        }

        private static GiftCertificate GetValidGiftCertificate(long giftCertificateId)
        {
            return new GiftCertificate(giftCertificateId) { DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser()}};
        }

        [Test]
        public void MapMapsGiftCertificateIdToDomainId()
        {
            const int expectedGiftCertificateId = 23894;
            var giftCertificateEntity = new GiftCertificateEntity(expectedGiftCertificateId);

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.AreEqual(expectedGiftCertificateId, giftCertificate.Id, 
                "GiftCertificate ID mapped incorrectly.");
        }

        [Test]
        public void MapMapsClaimCodeToDomainClaimCode()
        {
            const string expectedClaimCode = "DJIKJ#3283D";
            var giftCertificateEntity = new GiftCertificateEntity { ClaimCode = expectedClaimCode };

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.AreEqual(expectedClaimCode, giftCertificate.ClaimCode, 
                "GiftCertificate ClaimCode mapped incorrectly.");
        }

        [Test]
        public void MapMapsAmountToDomainAmount()
        {
            const decimal expectedAmount = 382.33m;
            var giftCertificateEntity = new GiftCertificateEntity { Amount = expectedAmount };

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.AreEqual(expectedAmount, giftCertificate.Price, 
                "GiftCertificate Amount mapped incorrectly.");
        }

        [Test]
        public void MapSetsDataRecorderMetaDataToMetaDataFromFactoryCall()
        {
            const int organizationRoleUserCreatorId = 38;
            var dateCreated = new DateTime(2003, 3, 3);
            var expectedDataRecorderMetaData = new DataRecorderMetaData
            {
                DataRecorderCreator = new OrganizationRoleUser(organizationRoleUserCreatorId),
                DateCreated = dateCreated
            };
            var giftCertificateEntity = new GiftCertificateEntity
                { OrgazizationRoleUserCreatorId = organizationRoleUserCreatorId, 
                DateCreated = dateCreated };
            
            Expect.Call(_dataRecorderMetaDataFactory.CreateDataRecorderMetaData
                (organizationRoleUserCreatorId, dateCreated)).Return(expectedDataRecorderMetaData);

            _mocks.ReplayAll();
            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);
            _mocks.VerifyAll();

            Assert.AreEqual(expectedDataRecorderMetaData, giftCertificate.DataRecorderMetaData,
                "GiftCertificate DataRecorderMetaData mapped incorrectly.");
        }

        [Test]
        public void MapMapsExpirationDateToDomainExpirationDate()
        {
            DateTime? expectedExpirationDate = new DateTime(2003, 2, 2);
            var giftCertificateEntity = new GiftCertificateEntity 
                { ExpirationDate = expectedExpirationDate };

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.IsNotNull(giftCertificate.ExpirationDate, 
                "GiftCertificate ExpirationDate should not be null.");
            Assert.AreEqual(expectedExpirationDate, giftCertificate.ExpirationDate, 
                "GiftCertificate ExpirationDate not mapped correctly.");
        }

        [Test]
        public void MapSetsExpirationDateToNullWhenEntityExpirationDateIsNull()
        {
            GiftCertificate giftCertificate = _giftCertificateFactory.Map(new GiftCertificateEntity());
            Assert.IsNull(giftCertificate.ExpirationDate, "GiftCertificate ExpirationDate should be null.");
        }

        [Test]
        public void MapMapsMessageFieldsCorrectly()
        {
            const string expectedFromName = "Goombella";
            const string expectedToName = "Mario";
            const string expectedMessage = "Hey!";
            var giftCertificateEntity = new GiftCertificateEntity
                { FromName = expectedFromName, ToName = expectedToName, Message = expectedMessage };

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.AreEqual(expectedFromName, giftCertificate.FromName, 
                "GiftCertificate FromName not mapped correctly.");
            Assert.AreEqual(expectedToName, giftCertificate.ToName, 
                "GiftCertificate ToName not mapped correctly.");
            Assert.AreEqual(expectedMessage, giftCertificate.Message, 
                "GiftCertificate MessageName not mapped correctly.");
        }

        [Test]
        public void MapMapsTypeIdToGiftCertificateTypeId()
        {
            const int expectedTypeId = 238549;
            var giftCertificateEntity = new GiftCertificateEntity { TypeId = expectedTypeId };

            GiftCertificate giftCertificate = _giftCertificateFactory.Map(giftCertificateEntity);

            Assert.AreEqual(expectedTypeId, giftCertificate.GiftCertificateTypeId, 
                "GiftCertificate GiftCertificateTypeId mapped incorrectly.");
        }

        [Test]
        public void MapMapsIdToGiftCertificateId()
        {
            const int expectedGiftCertificateId = 399;
            GiftCertificate giftCertificate = GetValidGiftCertificate(expectedGiftCertificateId);

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedGiftCertificateId, giftCertificateEntity.GiftCertificateId,
                "GiftCertificateEntity GiftCertificateID mapped incorrectly.");
        }

        [Test]
        public void MapMapsClaimCodeToEntityClaimCode()
        {
            const string expectedClaimCode = "SJDDJI38283JDJ338J";
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.ClaimCode = expectedClaimCode;

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedClaimCode, giftCertificateEntity.ClaimCode, 
                "GiftCertificateEntity ClaimCode mapped incorrectly.");
        }

        [Test]
        public void MapMapsMetaDataDateCreatedToEntityDateCreated()
        {
            var expectedDateTime = new DateTime(2003, 3, 4);
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.DataRecorderMetaData.DateCreated = expectedDateTime;

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedDateTime, giftCertificateEntity.DateCreated, 
                "GiftCertifcateEntity DateCreated mapped incorrectly.");
        }

        [Test]
        public void MapMapsMetaDataRecorderCreatorIdToOrganizationRoleUserCreatorId()
        {
            const int expectedOrganizationRoleUserCreatorId = 88;
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.DataRecorderMetaData.DataRecorderCreator = new OrganizationRoleUser(expectedOrganizationRoleUserCreatorId);

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedOrganizationRoleUserCreatorId, giftCertificateEntity.
                OrgazizationRoleUserCreatorId,
                "GiftCertificateEntity OrganizationRoleUserCreatorId mapped incorrectly.");
        }

        [Test]
        public void MapMapsExpirationDateToEntityExpirationDate()
        {
            DateTime? expectedDateTime = new DateTime(2009, 3, 3);
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.ExpirationDate = expectedDateTime;

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.IsNotNull(giftCertificateEntity.ExpirationDate, 
                "GiftCertificateEntity ExpirationDate should not be null.");
            Assert.AreEqual(expectedDateTime, giftCertificateEntity.ExpirationDate, 
                "GiftCertificateEntity ExpirationDate mapped incorrectly.");
        }

        [Test]
        public void MapSetsExpirationDateToNullWhenGivenNullDomainExpirationDate()
        {
            GiftCertificate giftCertificate = GetValidGiftCertificate();

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.IsNull(giftCertificateEntity.ExpirationDate, 
                "GiftCertificateEntity ExpirationDate should be null.");
        }

        [Test]
        public void MapMapsMessageFieldsToEntityCorrectly()
        {
            const string expectedFromName = "Pikachu";
            const string expectedToName = "Raichu";
            const string expectedMessage = "Pika";
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.FromName = expectedFromName;
            giftCertificate.ToName = expectedToName;
            giftCertificate.Message = expectedMessage;

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedFromName, giftCertificateEntity.FromName, 
                "GiftCertificateEntity FromName not mapped correctly.");
            Assert.AreEqual(expectedToName, giftCertificateEntity.ToName, 
                "GiftCertificateEntity ToName not mapped correctly.");
            Assert.AreEqual(expectedMessage, giftCertificateEntity.Message, 
                "GiftCertificateEntity MessageName not mapped correctly.");
        }

        [Test]
        public void MapMapsGiftCertificateTypeIdToTypeId()
        {
            const int expectedTypeId = 23845;
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.GiftCertificateTypeId = expectedTypeId;

            GiftCertificateEntity giftCertificateEntity = _giftCertificateFactory.Map(giftCertificate);

            Assert.AreEqual(expectedTypeId, giftCertificateEntity.TypeId, 
                "GiftCertificateEntity TypeID mapped incorrectly.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenGiftCertificateHasNullMetaData()
        {
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.DataRecorderMetaData = null;

            _giftCertificateFactory.Map(giftCertificate);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MapThrowsExceptionWhenGivenGiftCertificateHasNullDataRecorderCreator()
        {
            GiftCertificate giftCertificate = GetValidGiftCertificate();
            giftCertificate.DataRecorderMetaData.DataRecorderCreator = null;

            _giftCertificateFactory.Map(giftCertificate);
        }
    }
}