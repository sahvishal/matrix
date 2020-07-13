using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerScheduleModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [DisplayName("Pod")]
        public string Vehicle { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }
        
    }
}