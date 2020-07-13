using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("Need access to protected member")]
    public class GiftCertificateRepositoryTester
    {
        private readonly IUniqueItemRepository<GiftCertificate> _giftCertificateRepository = new GiftCertificateRepository();

        [Test]
        public void EntityIdFieldReturnsGiftCertificateIdFromGiftCertificateFields()
        {
            //EntityField2 expectedEntityIdField = GiftCertificateFields.GiftCertificateId;
            //string expectedEntityFieldName = string.Format("{0}.{1}", expectedEntityIdField.ContainingObjectName, expectedEntityIdField.Name);

            //EntityField2 entityIdField = _giftCertificateRepository.EntityIdField;
            //string entityFieldName = string.Format("{0}.{1}", entityIdField.ContainingObjectName, entityIdField.Name);

            //Assert.AreEqual(expectedEntityFieldName, entityFieldName, "EntityIdField returned incorrect EntityField.");
        }
    }
}