using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeOrderItem : OrderItem
    {
        public override OrderItemType OrderItemType
        {
            get { return (OrderItemType)(-1); }
        }
    }
}