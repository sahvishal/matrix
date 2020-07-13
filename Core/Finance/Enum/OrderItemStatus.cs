using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Finance.Enum
{
    public abstract class OrderItemStatus : TypeSafeEnum
    {
        private readonly int _statusCode;
        private readonly OrderStatusState _orderStatusState;

        public int StatusCode { get { return _statusCode; } }
        public OrderStatusState OrderStatusState { get { return _orderStatusState; } }

        public abstract string ItemTypeName { get; }

        protected OrderItemStatus(int statusCode, string name, OrderStatusState orderStatusState)
            : base(name)
        {
            _statusCode = statusCode;
            _orderStatusState = orderStatusState;
        }
    }
}