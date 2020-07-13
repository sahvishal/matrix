using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Infrastructure.Finance
{
    [TestFixture]
    public class ElectronicProductRepositoryTester
    {
        private readonly IUniqueItemRepository<ElectronicProduct> _electronicProductRepository = new ElectronicProductRepository();

        [Test]
        [Ignore("Need access to protected member")]
        public void EntityIdFieldReturnsProductIdFromProductFields()
        {
            //EntityField2 expectedEntityIdField = ProductFields.ProductId;
            //string expectedEntityFieldName = string.Format("{0}.{1}", expectedEntityIdField.ContainingObjectName, expectedEntityIdField.Name);

            //EntityField2 entityIdField = _productRepository.EntityIdField;
            //string entityFieldName = string.Format("{0}.{1}", entityIdField.ContainingObjectName, entityIdField.Name);

            //Assert.AreEqual(expectedEntityFieldName, entityFieldName, "EntityIdField returned incorrect EntityField.");
        }
    }
}