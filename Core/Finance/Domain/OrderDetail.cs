using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    public class OrderDetail : DomainObjectBase
    {
        public OrderDetail()
            : this(0)
        { }

        public OrderDetail(long orderDetailId)
            : base(orderDetailId)
        {
            Quantity = 1;
        }

        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        
        public long ForOrganizationRoleUserId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }
        public OrderItemType DetailType { get; set; }
        public decimal Price { get; set; }

        public SourceCodeOrderDetail SourceCodeOrderDetail { get; set; }
        public EventCustomerOrderDetail EventCustomerOrderDetail { get; set; }
        private List<ShippingDetailOrderDetail> _shippingDetailOrderDetails;
        public List<ShippingDetailOrderDetail> ShippingDetailOrderDetails
        {
            get
            {
                if (_shippingDetailOrderDetails == null)
                    _shippingDetailOrderDetails = new List<ShippingDetailOrderDetail>();
                return _shippingDetailOrderDetails;
            }
            set
            {
                _shippingDetailOrderDetails = value;
            }
        }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public bool IsCompleted { get { return OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess; } }
        public long? SourceId { get; set; }
    }
}