using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CreditCardReconcileModel: ViewModelBase
    {
        [DisplayName("Transaction Date")]
        public DateTime DateApproved { get; set; }
        
        public string Pod { get; set; }
        
        [DisplayName("Card Type")]
        public string CardType { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Receipt Number")]
        public string ReceiptNumber { get; set; }

        [DisplayName("Corporate Account")]
        public string CorporatePartner { get; set; }

        [DisplayName("Event Type")]
        public string EventType { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        
        public bool IsOnline { get; set; } // Online, Call Center, Technician
        public string Prepaid { get; set; }
        public decimal Amount { get; set; } // Obtained thorugh Credit Card
    }
}

