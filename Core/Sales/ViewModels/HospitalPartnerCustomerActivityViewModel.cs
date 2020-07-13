using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerCustomerActivityViewModel
    {
        public string Status { get; set; }

        public string Outcome { get; set; }

        public string Notes { get; set; }

        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

        [DisplayName("Updated On")]
        [Format("MM/dd/yyyy")]
        public DateTime UpdateOn { get; set; }
    }
}
