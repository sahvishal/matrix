using System;
using HealthYes.Web.Core.Domain.PrintOrder.Enum;

namespace HealthYes.Web.Core.Domain.PrintOrder
{
   public class PrintOrderItemShippingStatus: DomainObjectBase
    {
       public long PrintOrderItemShippingStatusId { get; set; }
        public long PrintOrderItemId { get; set; }
        public ItemShippingStatus Status { get; set; }
        public ItemConfirmationMode? ConfirmationMode { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrganizationRoleUser PaymentRecordedBy { get; set; }

        public PrintOrderItemShippingStatus() { }
        public PrintOrderItemShippingStatus(long printOrderItemShippingStatusId) : base(printOrderItemShippingStatusId) { }
    }
}
