using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Marketing
{
    [TestFixture]
    [Ignore("The database must be in a stable state for this test to run successfully.")]
    public class GiftCertificateRepositoryTester
    {
        private readonly IUniqueItemRepository<GiftCertificate> _repository = new GiftCertificateRepository();
        private readonly GiftCertificate _giftCertificate;

        public GiftCertificateRepositoryTester()
        {
            _giftCertificate = new GiftCertificate
                                   {
                                       Amount = 5.00m,
                                       ClaimCode = "ADFDD89023kD8",
                                       DataRecorderMetaData = new DataRecorderMetaData { DataRecorderCreator = new OrganizationRoleUser(1), DateCreated = DateTime.Now },
                                       GiftCertificateTypeId = 3,
                                       Message = "Integration Test Saving New GiftCertificate"
                                   };
        }

        private const long KNOWN_GIFT_CERTIFICATE_ID = 2;

        [Test]
        public void GetByIdReturnsGiftCertificateForKnownId()
        {
            GiftCertificate giftCertificate = _repository.GetById(KNOWN_GIFT_CERTIFICATE_ID);

            Assert.IsNotNull(giftCertificate, "GetById returned null GiftCertificate.");
            Assert.IsInstanceOf<GiftCertificate>(giftCertificate, "GetById returned the wrong type of object.");
        }

        [Test]
        public void SavePersistsNewGiftCertificate()
        {
            GiftCertificate persistedGiftCertificate = _repository.Save(_giftCertificate);

            Assert.AreEqual(_giftCertificate.Amount, persistedGiftCertificate.Amount);
        }

        [Test]
        public void SaveUpdatesExistingGiftCertificate()
        {
            const decimal expectedValueAfterUpdate = -100000000m;

            GiftCertificate persistedGiftCertificate = _repository.Save(_giftCertificate);
            
            persistedGiftCertificate.Amount = expectedValueAfterUpdate;
            long expectedId = persistedGiftCertificate.Id;

            persistedGiftCertificate = _repository.Save(persistedGiftCertificate);

            Assert.AreEqual(expectedValueAfterUpdate, persistedGiftCertificate.Amount);
            Assert.AreEqual(expectedId, persistedGiftCertificate.Id);
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<GiftCertificate>))]
        public void GiftCertificateIsDeletedWhenDeleteCalled()
        {
            GiftCertificate persistedGiftCertificate = _repository.Save(_giftCertificate);

            long certificateId = persistedGiftCertificate.Id;

            _repository.Delete(persistedGiftCertificate);

            _repository.GetById(certificateId);
        }
    }
}