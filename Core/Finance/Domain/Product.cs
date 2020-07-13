using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Interfaces;

namespace Falcon.App.Core.Finance.Domain
{
    public class Product : DomainObjectBase, IOrderable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get { return string.Format("Product for {0:C} ", Price); } }
        public OrderItemType OrderItemType
        {
            get { return OrderItemType.ProductItem; }
        }
        public DateTime DateCreated { get; set; }
        

        public Product()
        { }

        public Product(long productId)
            : base(productId)
        { }
    }
}