using System;
using System.Collections.Generic;
using System.Data;
using Falcon.DataAccess.Franchisee;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.App.Core.Enum;
using Falcon.App.UI.App.Common;

public partial class App_Common_ucWeekCalendar : System.Web.UI.UserControl
{
    private string _dtEventDate;

    public App_Common_ucWeekCalendar()
    {
        ViewType = "Day";
    }

    /// <summary>
    /// Set the view type as Day or Week
    /// </summary>
    public string ViewType { get; set; }

    /// <summary>
    /// set the Event date and fill the records
    /// </summary>
    public string EventDate
    {
        set
        {
            _dtEventDate = value;
            DateTime dtDate;
            if (DateTime.TryParse(_dtEventDate, out dtDate) == true)
            {
                DateTime startDate;
                DateTime endDate;
                string pClass = string.Empty;
                string spanClass = string.Empty;
                if (ViewType == "Week")
                {
                    startDate = dtDate.AddDays(0 - Convert.ToInt32(dtDate.DayOfWeek));
                    endDate = dtDate.AddDays(6 - Convert.ToInt32(dtDate.DayOfWeek));
                    pClass = "'daystyle_day_clnder'";
                    spanClass = "'daystyle_block_clnder'";
                }
                else
                {
                    startDate = dtDate;
                    endDate = dtDate;
                    lstWeekView.RepeatColumns = 1;
                    pClass = "'daystyle_day_clnder'";
                    spanClass = "'daystyle_block_clnder'";
                }
                DataTable tblAppointments = GetCalendarData(startDate, endDate);

                var tblData = new DataTable();
                tblData.Columns.Add("Date");
                tblData.Columns.Add("Day");
                tblData.Columns.Add("Description");
                for (DateTime count = startDate; count <= endDate; count = count.AddDays(1))
                {
                    tblAppointments.DefaultView.RowFilter = "EventDate='" + count + "'";
                    if (tblAppointments.DefaultView.Count > 0)
                    {
                        string strDayappointments = string.Empty;
                        for (int icount = 0; icount < tblAppointments.DefaultView.Count; icount++)
                        {
                            string strData = "<span class=" + pClass + " ><span  class=" + spanClass + " id='" + tblAppointments.DefaultView[icount][0] + "' style='cursor:hand'   >";
                            strData = strData + tblAppointments.DefaultView[icount][2] + "</span></span>";
                            strDayappointments = strDayappointments + strData;
                        }
                        tblData.Rows.Add(new object[] { count.ToShortDateString(), count.DayOfWeek, strDayappointments });
                    }
                    else
                    {
                        string strData = "<span class=" + pClass + " ><span  class=" + spanClass + " > &nbsp;</span></span>";
                        tblData.Rows.Add(new object[] { count.ToShortDateString(), count.DayOfWeek, strData });
                    }
                }
                lstWeekView.DataSource = tblData;
                lstWeekView.DataBind();
            }
        }
    }


    public Boolean ViewEvent { get; set; }

    public Boolean ViewTask { get; set; }

    public Boolean ViewMeeting { get; set; }

    public Boolean ViewCall { get; set; }

    public Boolean ViewSeminar { get; set; }

    public string HostName
    {
        get;
        set;
    }
    public long FranchiseeId
    {
        get;
        set;
    }
    public long SalesRepId
    {
        get;
        set;
    }

    public string PodIds { get; set; }

    public string TerritoryIds { get; set; }


    private DataTable GetCalendarData(DateTime startDate, DateTime endDate)
    {
        var calendarHelper = new CalendarHelper(ViewEvent, ViewTask, ViewMeeting, ViewCall, ViewSeminar, HostName, FranchiseeId, SalesRepId, PodIds, TerritoryIds);
        return calendarHelper.GetCalendarDataByFilters(startDate, endDate);
    }

}
