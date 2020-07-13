using System;
using System.ComponentModel;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventStaffAssignmentListModelFilter : ModelFilterBase
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Date { get; set; }

        [DisplayName("Staff")]
        public long StaffId { get; set; }

        [DisplayName("Pod")]
        public long PodId { get; set; }

        /// <summary>
        /// Choose from 'month', 'basicWeek', 'basicDay', 'agendaWeek', 'agendaDay'
        /// </summary>
        public string DefaultCalendarView { get; set; }

        /// <summary>
        /// Choose from 'Event', 'Staff'
        /// </summary>
        public string DefaultView { get; set; }

        public long AccountId { get; set; }

        public EventStaffAssignmentListModelFilter()
        {
        }

        public EventStaffAssignmentListModelFilter(DateTime filterDate)
        {
            DefaultView = "Event";
            DefaultCalendarView = "month";
            Month = filterDate.Month;
            Year = filterDate.Year;
            Date = filterDate.Day;
        }

        //PageNumber and PageSize Used for Export Only
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public UserSessionModel UserSessionModel { get; set; }
        public long RoleId { get; set; }
    }
}