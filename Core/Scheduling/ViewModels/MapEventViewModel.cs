using Falcon.App.Core.Scheduling.Enum;
using System;
namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MapEventViewModel
    {
        public long Id { get; set; }
        public string Host { get; set; }                    
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }
        public string SponsoredBy { get; set; }
        public string Pods { get; set; }
        public EventType EventType { get; set; }
        public int TotalAppointmentSlots { get; set; }        
        public int BookedSlots { get; set; }
        public string EventDate { get; set; }
    }
}
