using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    /// <summary>
    /// this object is specifically made to be comsumed by FullCalendar jquery plugin EventObject
    /// </summary>
    public class EventJsonModel
    {
        public long Id { get; set; }
        public string title { get; set; }        
        public bool allDay { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string url { get; set; }        
        public bool editable { get; set; }
        
        //there are non-standard, but will be pass all long and eventReder of FullCalendar can be used to render them.
        public string[] Pods { get; set; }
        public IEnumerable<OrderedPair<string, string>> AssignedStaff { get; set; }
        public bool IsDefaultStaffAssignment { get; set; }
        public int TotalAppointmentSlots { get; set; }
        public int FilledAppintmentSlots { get; set; }

    }
}