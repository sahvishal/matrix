using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.ViewModels
{
    public class CustomerInfo
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime? EventDate { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }

        [DisplayName("Date Sent")]
        [Hidden]
        public DateTime DateSent { get; set; }

        [DisplayName("File Type")]
        [Hidden]
        public long FileType { get; set; }

        [Hidden]
        public long EventCustomerId { get; set; }
    }
}