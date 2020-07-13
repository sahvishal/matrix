using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class EventHostDepositViewData
    {
        public bool IsDeposit { get; set; }
        public long Id { get; set; }
        public long EventId { get; set; }
        public string Name { get; set; }
        public string EventStreetAddressLine1 { get; set; }
        public string EventStreetAddressLine2 { get; set; }
        public string EventCity { get; set; }
        public string EventState { get; set; }
        public string EventCountry { get; set; }
        public string EventZip { get; set; }
        public DateTime EventDate { get; set; }
        public EventStatus EventStatus { get; set; }
        public long HostId { get; set; }
        public string TaxIdNumber { get; set; }
        public decimal Amount { get; set; }
        public HostPaymentType PaymentMode { get; set; }
        public DateTime? DueDate { get; set; }
        public string PayableTo { get; set; }
        public string MailingOrganizationName { get; set; }
        public long AddressId { get; set; }
        public string MailingAttentionOf { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public HostPaymentStatus Status { get; set; }
        public bool? IsActive { get; set; }
        public int? DepositFullRefundDueDays { get; set; }
        public DateTime? DepositFullRefundDueDate { get; set; }
        public DepositType? DepositApplicablityMode { get; set; }
        public List<HostPaymentTransaction> HostPaymentTransactions { get; set; }
    }
}