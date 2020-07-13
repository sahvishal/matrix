using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Finance.ViewModels
{
    // You don't need the filter model or the paging model here.
    public class CustomerItemizedReceiptModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DisplayCode { get; set; }
        public long EventId { get; set; }
        public Address Address { get; set; } // Do we need to keep the Address Type instead of string

        public string Host { get; set; }
        public Address HostAddress { get; set; }
        public string Package { get; set; }

        public decimal TotalAmount
        {
            get
            {
                if (!Items.IsNullOrEmpty())
                {
                    return Items.Sum(i => i.Amount);
                }
                return 0;
            }
        }

        public decimal OrderAmount { get; set; }
        public decimal Discounts
        {
            get
            {
                return TotalAmount - OrderAmount;
            }
        }

        public decimal PaidAmount { get; set; }
        public decimal AmountDue
        {
            get
            {
                return OrderAmount - PaidAmount;
            }
        }

        public string PaymentMode { get; set; } // Check or Credit card
        public string DoctorSignatureImagePath { get; set; }
        public IEnumerable<CustomerReceiptItem> Items { get; set; }
    }

    public class CustomerReceiptItem
    {
        public DateTime DatePurchased { get; set; }
        public long ItemId { get; set; }
        public OrderItemType ItemType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

}
