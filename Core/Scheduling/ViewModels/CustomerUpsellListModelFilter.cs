using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerUpsellListModelFilter : ModelFilterBase
    {
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }
        [DisplayName("Pod")]
        public string Vehicle { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string Territory { get; set; }
        [DisplayName("Upsell By")]
        public long UpSellRole { get; set; }

        [DisplayName("Corporate Account")]
        public long CorporateAccountId { get; set; }

    }
}