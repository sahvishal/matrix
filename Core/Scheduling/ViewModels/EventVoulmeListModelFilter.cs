using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class EventVolumeListModelFilter : ModelFilterBase
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [DisplayName("Pod")]
        public string Vehicle { get; set; }
        public string ZipCode { get; set; }
        public string Territory { get; set; }

        public bool IsPublicEvent { get; set; }
        public bool IsPrivateEvent { get; set; }

        //public EventVoulmeListModelFilter()
        //{
        //    // Can't keep it empty, throws an exception while executing the query expressions
        //    Vehicle = ZipCode = Territory = "";
        //}
        //Temp Solution
        public bool IsEmpty()
        {
            return FromDate == null && ToDate == null && string.IsNullOrWhiteSpace(Vehicle) && string.IsNullOrWhiteSpace(ZipCode) && string.IsNullOrWhiteSpace(Territory) && !IsPublicEvent && !IsPrivateEvent;
        }
    }
}