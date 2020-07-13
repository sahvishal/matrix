using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerEventViewModel:ViewModelBase
    {
        [DisplayName("EventId")]
        public long EventId { get; set; }

        [DisplayName("Event Location")]
        public string HostAddress { get; set; }

        [DisplayName("Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Customers")]
        public int ScreenedCustomers { get; set; }

        [DisplayName("Normals")]
        public int NormalCustomers { get; set; }

        [DisplayName("Criticals")]
        public int CriticalCustomers { get; set; }

        [DisplayName("Abnormals")]
        public int AbnormalCustomers { get; set; }

        [DisplayName("Urgent")]
        public int UrgentCustomers { get; set; }

        [Hidden]
        public DateTime? MailedDate { get; set; }

        public IEnumerable<NotesViewModel> Notes { get; set; }
    }
}
