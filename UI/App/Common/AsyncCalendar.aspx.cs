using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.Entity.User;
using System.Text;
using System.IO;

namespace Falcon.App.UI.App.Common
{
    public partial class AsyncCalendar : System.Web.UI.Page
    {


        private string ViewType { get { return !string.IsNullOrEmpty(Request.QueryString["Type"]) ? Request.QueryString["Type"] : string.Empty; } }

        private string ViewDate { get { return !string.IsNullOrEmpty(Request.QueryString["Date"]) ? Request.QueryString["Date"] : string.Empty; } }

        private bool ViewEvent { get { return !string.IsNullOrEmpty(Request.QueryString["E"]) ? Convert.ToBoolean(Request.QueryString["E"]) : false; } }

        private bool ViewTask { get { return !string.IsNullOrEmpty(Request.QueryString["T"]) ? Convert.ToBoolean(Request.QueryString["T"]) : false; } }

        private bool ViewMeeting { get { return !string.IsNullOrEmpty(Request.QueryString["M"]) ? Convert.ToBoolean(Request.QueryString["M"]) : false; } }

        private bool ViewCall { get { return !string.IsNullOrEmpty(Request.QueryString["C"]) ? Convert.ToBoolean(Request.QueryString["C"]) : false; } }

        private bool ViewSeminar { get { return !string.IsNullOrEmpty(Request.QueryString["S"]) ? Convert.ToBoolean(Request.QueryString["S"]) : false; } }

        private string HostName { get { return !string.IsNullOrEmpty(Request.QueryString["HN"]) ? Request.QueryString["HN"] : string.Empty; } }

        private string TerritoryIds
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["TI"])
                           ? Request.QueryString["TI"].Remove(Request.QueryString["TI"].Length - 1, 1) == "0"
                                 ? string.Empty
                                 : Request.QueryString["TI"].Remove(Request.QueryString["TI"].Length - 1, 1)
                           : string.Empty;
            }
        }

        private string PodIds { get { return !string.IsNullOrEmpty(Request.QueryString["SPI"]) ? Request.QueryString["SPI"].Remove(Request.QueryString["SPI"].Length - 1, 1) : string.Empty; } }

        private long SalesRepId { get { return !string.IsNullOrEmpty(Request.QueryString["SRI"]) ? Convert.ToInt64(Request.QueryString["SRI"]) : default(long); } }

        private long FranchiseeId { get { return !string.IsNullOrEmpty(Request.QueryString["FI"]) ? Convert.ToInt64(Request.QueryString["FI"]) : default(long); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ViewType) && !string.IsNullOrEmpty(ViewDate))
            {
                SetView(ViewType, ViewDate);
            }
            Response.End();
        }

        private DataTable GetCalendarData(DateTime startDate, DateTime endDate)
        {
            var calendarHelper = new CalendarHelper(ViewEvent, ViewTask, ViewMeeting, ViewCall, ViewSeminar, HostName, FranchiseeId, SalesRepId, PodIds, TerritoryIds);
            return calendarHelper.GetCalendarDataByFilters(startDate, endDate);
        }

        /// <summary>
        /// Fill the data in the calendar
        /// </summary>
        private void SetCalendar()
        {
            DateTime startDate = new DateTime(dcAppointments.VisibleDate.Year, dcAppointments.VisibleDate.Month, 1).AddDays(0);
            DateTime endDate = new DateTime(dcAppointments.VisibleDate.Date.AddMonths(1).Year, dcAppointments.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(0);
            dcAppointments.DataSource = GetCalendarData(startDate, endDate);
            dcAppointments.ShowTitle = false;
        }


        private void SetView(string viewType, string viewDate)
        {
            DateTime dtDate;
            if (DateTime.TryParse(viewDate, out dtDate))
            {
                var lastDayOfThisMonth = new DateTime();

                switch (viewType)
                {
                    case "Month":
                        dcAppointments.VisibleDate = dtDate;
                        SetCalendar();
                        lastDayOfThisMonth = new DateTime(dtDate.Year, dtDate.Month, 1).AddMonths(1).AddDays(-1);
                        YearView.EventDate = string.Empty;
                        WeekView.EventDate = string.Empty;
                        dvCalYear.Visible = false;
                        dvCalWeek.Visible = false;
                        dvCalMonth.Visible = true;
                        break;
                    case "Year":
                        YearView.HostName = HostName;
                        YearView.FranchiseeId = FranchiseeId;
                        YearView.SalesRepId = SalesRepId;
                        if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep)) YearView.SalesRepId = 0;
                        YearView.PodIds = PodIds;
                        YearView.TerritoryIds = TerritoryIds;
                        YearView.EventDate = dtDate.ToShortDateString();
                        dtDate = dtDate.AddMonths(-1);
                        lastDayOfThisMonth = new DateTime(dtDate.Year, dtDate.Month, 1).AddMonths(4).AddDays(-1);
                        WeekView.EventDate = string.Empty;
                        dvCalMonth.Visible = false;
                        dvCalWeek.Visible = false;
                        dvCalYear.Visible = true;
                        break;

                    case "Week":
                        YearView.EventDate = string.Empty;
                        WeekView.ViewCall = ViewCall;
                        WeekView.ViewEvent = ViewEvent;
                        WeekView.ViewMeeting = ViewMeeting;
                        WeekView.ViewTask = ViewTask;
                        WeekView.ViewSeminar = ViewSeminar;
                        WeekView.ViewType = viewType;
                        WeekView.HostName = HostName;
                        WeekView.FranchiseeId = FranchiseeId;
                        WeekView.SalesRepId = SalesRepId;
                        WeekView.PodIds = PodIds;
                        WeekView.TerritoryIds = TerritoryIds;
                        WeekView.EventDate = dtDate.ToShortDateString();
                        dvCalMonth.Visible = false;
                        dvCalYear.Visible = false;
                        dvCalWeek.Visible = true;
                        break;
                    case "Day":
                        YearView.EventDate = string.Empty;
                        WeekView.ViewCall = ViewCall;
                        WeekView.ViewEvent = ViewEvent;
                        WeekView.ViewMeeting = ViewMeeting;
                        WeekView.ViewTask = ViewTask;
                        WeekView.ViewSeminar = ViewSeminar;
                        WeekView.ViewType = viewType;
                        WeekView.HostName = HostName;
                        WeekView.FranchiseeId = FranchiseeId;
                        WeekView.SalesRepId = SalesRepId;
                        WeekView.PodIds = PodIds;
                        WeekView.TerritoryIds = TerritoryIds;
                        WeekView.EventDate = dtDate.ToShortDateString();
                        dvCalMonth.Visible = false;
                        dvCalYear.Visible = false;
                        dvCalWeek.Visible = true;
                        break;
                }
                RenderCalendarData();
            }
        }

        private void RenderCalendarData()
        {
            HtmlForm calendarForm = form1;
            calendarForm.Controls.Clear();
            calendarForm.Controls.Add(dvCalendar);
            var formatProvider = new StringBuilder();
            var htmlTextWriter = new HtmlTextWriter(new StringWriter(formatProvider));
            calendarForm.RenderControl(htmlTextWriter);
            string renderedHtml = formatProvider.ToString();
            renderedHtml = renderedHtml.Substring(renderedHtml.IndexOf("<div id=\"dvCalendar\""), renderedHtml.LastIndexOf("</div>") - renderedHtml.IndexOf("<div id=\"dvCalendar\"") - 92);
            Response.Write(renderedHtml);
        }
        
    }
}
