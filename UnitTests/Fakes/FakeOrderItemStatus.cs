using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Enum;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeOrderItemStatus : OrderItemStatus
    {
        public static readonly OrderItemStatus StatusZero = new FakeOrderItemStatus(0, "Status Zero", OrderStatusState.Initial);
        public static readonly OrderItemStatus IncompleteFakeStatus = new FakeOrderItemStatus(0, "Fake Incomplete", OrderStatusState.Initial);
        public static readonly OrderItemStatus CompleteFakeStatus = new FakeOrderItemStatus(1, "Fake Complete", OrderStatusState.FinalSuccess);

        public FakeOrderItemStatus(int statusCode, string name, OrderStatusState orderStatusState):
            base(statusCode, name, orderStatusState)
        {}

        public override string ItemTypeName { get { throw new NotImplementedException(); } }
    }
}