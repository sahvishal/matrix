using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakeOrderable : IOrderable
    {
        public long Id { get; private set; }

        public decimal Price
        {
            get { return 12m; }
        }

        public string Description
        {
            get { return "Fake item"; }
        }

        public OrderItemType OrderItemType
        {
            get { return (OrderItemType)(-1); }
        }

        public FakeOrderable() :
            this(1)
        {}

        public FakeOrderable(long id)
        {
            Id = id;
        }
    }
}