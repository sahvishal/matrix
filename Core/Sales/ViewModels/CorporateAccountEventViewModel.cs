using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CorporateAccountEventViewModel : ViewModelBase
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
    }
}