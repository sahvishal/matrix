using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories.Order;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database must be in a stable state for this test to run successfully.")]
    public class RefundRepositoryTester
    {
        private readonly IUniqueItemRepository<Refund> _repository = new RefundRepository();
        private const long KNOWN_REFUND_ID = 2;

        [Test]
        public void GetByIdReturnsRefundForKnownId()
        {
            Refund refund = _repository.GetById(KNOWN_REFUND_ID);

            Assert.IsNotNull(refund, "GetById returned null Refund.");
            Assert.IsInstanceOf<Refund>(refund, "GetById returned the wrong type of object.");
        }
    }
}