using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class ClientEventVolumeListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [DisplayName("Pod")]
        public string Vehicle { get; set; }
        [DisplayName("Sponser")]
        public long? Sponsers { get; set; }

        public bool IsEmpty()
        {
            return FromDate == null && ToDate == null && string.IsNullOrWhiteSpace(Vehicle) && Sponsers == null;
        }
    }
}
