using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.PrintOrder.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PrintOrderItemTracking : DomainObjectBase
    {
        public long PrintOrderItemShippingId { get; set; }
        public long PrintOrderItemId { get; set; }
        public string TrackingNumber { get; set; }
        
        public string ShippingService { get; set; }
        public DateTime? ScheduledDeliveryDate { get; set; }
      
        public string ShipToName { get; set; }
        public string ShipToAttentionOf { get; set; }
        ///public Boolean ConfirmationState { get; set; }
        public ItemConfirmationMode? ConfirmationMode { get; set; }
        public string ConfirmedBy { get; set; }
        public string PackageReference1 { get; set; }
        public string PackageReference2 { get; set; }
        public string PackageReference3 { get; set; }

        public string ShippedToAddress1 { get; set; }
        public string ShippedToAddress2 { get; set; }
        public string ShippedToCity { get; set; }
        public string ShippedToState { get; set; }
        public string ShippedToZip { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }

        public DateTime DateCreated     { get;set;}
        public OrganizationRoleUser CreatedByOrgRoleUser { get; set;}
        public DateTime? DateUpdated     { get;set;}
        public OrganizationRoleUser UpdatedByOrgRoleUser { get; set;}
	
	    public PrintOrderItemTracking() { }
        public PrintOrderItemTracking(long printOrderItemShippingId) : base(printOrderItemShippingId) { }
    }
}
