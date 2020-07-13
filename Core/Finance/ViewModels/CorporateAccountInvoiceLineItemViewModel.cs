using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CorporateAccountInvoiceLineItemViewModel : ViewModelBase
    {
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Event Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Corporate")]
        public string AccountName { get; set; }

        [DisplayName("Code")]
        public string CorpCode { get; set; }

        [Hidden]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Employee Id")]
        public string EmployeeId { get; set; }

        [DisplayName("Purchased")]
        public string OrderPurchased { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [DisplayName("Price")]
        public decimal OrderCost { get; set; }

    }
}