using Falcon.App.Core.Finance.Domain;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain.Order
{
    [TestFixture]
    public class OrderDetailTester
    {
        [Test]
        public void IsCompletedReturnsTrueWhenOrderItemStatusIsInFinalState()
        {
            var orderDetail = new OrderDetail {OrderItemStatus = FakeOrderItemStatus.CompleteFakeStatus};

            bool completionStatus = orderDetail.IsCompleted;

            Assert.IsTrue(completionStatus, "IsCompleted returned false when true was expected.");
        }

        [Test]
        public void IsCompletedReturnsFalseWhenOrderItemStatusIsInInitialState()
        {
            var orderDetail = new OrderDetail { OrderItemStatus = FakeOrderItemStatus.IncompleteFakeStatus };

            bool completionStatus = orderDetail.IsCompleted;

            Assert.IsFalse(completionStatus, "IsCompleted returned true when false was expected.");
        }
    }
}