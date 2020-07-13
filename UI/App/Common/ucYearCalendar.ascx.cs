using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Lib;
using EEvent = Falcon.Entity.Other.EEvent;
using Falcon.App.Core.Enum;

public partial class App_Common_ucYearCalendar : System.Web.UI.UserControl
{
    private string dtEventDate;

    public string EventDate
    {
        set
        {
            dtEventDate = value;
            DateTime dtDate;
            if (DateTime.TryParse(dtEventDate, out dtDate))
            {
                _tblAppointments = new DataTable();
                _tblAppointments.Columns.Add("AppointMentID");
                _tblAppointments.Columns.Add("AppointmentType");
                _tblAppointments.Columns.Add("AppointmentInfo");
                _tblAppointments.Columns.Add("EventDate");
                _tblAppointments.Columns.Add("Description");
                dcAppointments1.VisibleDate = dtDate.AddMonths(-1);
                dcAppointments2.VisibleDate = dtDate;
                dcAppointments3.VisibleDate = dtDate.AddMonths(1);
                dcAppointments4.VisibleDate = dtDate.AddMonths(2);
                SetCalendar();
            }
        }
    }

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

    
    private DataTable _tblAppointments;

    private DataTable GetEventData(DateTime startDate, DateTime endDate, string strOwner)
    {
        
        
        var masterDal = new MasterDAL();

        List<EEvent> eventForCalendar = masterDal.GetEventForCalendar(SalesRepId, startDate.ToShortDateString(), endDate.ToShortDateString(), 0, HostName, FranchiseeId, PodIds, TerritoryIds);

        if (!string.IsNullOrEmpty(TerritoryIds))
        {
            var territoryIds = new List<long>();
            TerritoryIds.Split(',').ToList().ForEach(territoryId => territoryIds.Add(Convert.ToInt64(territoryId)));
            ITerritoryRepository territoryRepository = new TerritoryRepository();
            List<Territory> territories = territoryRepository.GetTerritories(territoryIds);
            List<string> territoryZipCodes =
                territories.SelectMany(territory => territory.ZipCodes.Select(zipCode => zipCode.Zip)).ToList();
            eventForCalendar =
                eventForCalendar.Where(eventData => territoryZipCodes.Contains(eventData.Host.Address.Zip)).ToList();
        }

        if (eventForCalendar != null)
        {
            for (int count = 0; count < eventForCalendar.Count; count++)
            {
                string strEventDescription = "";
                string eventData = "\"" + eventForCalendar[count].Name.Replace("'", "").Replace("\n", "") + " \"";
                string eventStatus = "\"" + Convert.ToString(Enum.Parse(typeof(EventStatus), eventForCalendar[count].EventStatus.ToString())).Replace("\n", "").Replace("'", "") + " \"";

                string currentEventDate = "\"" + Convert.ToDateTime(eventForCalendar[count].EventDate).ToLongDateString() + " \"";
                string eventStartTime = "\"" + Convert.ToDateTime(eventForCalendar[count].EventStartTime).ToShortTimeString() + " \"";
                string eventEndTime = "\"" + Convert.ToDateTime(eventForCalendar[count].EventEndTime).ToShortTimeString() + " \"";
                string timeZone = "\"" + eventForCalendar[count].TimeZone + " \"";
                string address1 = "\"" + eventForCalendar[count].Host.Address.Address1.Replace("\n", "").Replace("'", "") + " \"";
                string address2 = "\"" + eventForCalendar[count].Host.Address.Address2.Replace("\n", "").Replace("'", "") + " \"";
                string city = "\"" + eventForCalendar[count].Host.Address.City + " \"";
                string state = "\"" + eventForCalendar[count].Host.Address.State + " \"";
                string country = "\"" + eventForCalendar[count].Host.Address.Country + " \"";
                string zip = "\"" + eventForCalendar[count].Host.Address.Zip + " \"";
                string franchisee = "\"" + eventForCalendar[count].Franchisee.Name.Replace("\n", "").Replace("'", "") + " \"";

                string salesRep = "\"" + eventForCalendar[count].FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName + "  " + eventForCalendar[count].FranchiseeFranchiseeUser.FranchiseeUser.User.LastName + " \"";
                string controlID = "\"Event" + eventForCalendar[count].EventID + strOwner + "\"";

                string customerCount;
                TimeSpan dateDifference = Convert.ToDateTime(eventForCalendar[count].EventDate).Subtract(DateTime.Now);
                int days = dateDifference.Days;

                if (days < 0)
                {
                    customerCount = "\" Registered:" + eventForCalendar[count].RegisteredCustomersCount + " | Attended:" + eventForCalendar[count].AttendedCustomersCount + " | Cancel:" + eventForCalendar[count].CancelCustomersCount + " \"";
                }
                else if (days == 0)
                {
                    customerCount = "\"Registered:" + eventForCalendar[count].RegisteredCustomersCount + " | Attended:" + eventForCalendar[count].AttendedCustomersCount + " | On Site :" + eventForCalendar[count].OnSiteCustomersCount + " \"";
                }
                else
                {
                    customerCount = "\"Registered:" + eventForCalendar[count].RegisteredCustomersCount + " | Paid:" + eventForCalendar[count].PaidCustomersCount + " | UnPaid :" + eventForCalendar[count].UnpaidCustomersCount + " |Cancel :" + eventForCalendar[count].CancelCustomersCount + " \"";
                }

                strEventDescription = eventData + "," + eventStatus + "," + currentEventDate + "," + eventStartTime + "," + eventEndTime + "," + timeZone + "," + customerCount + "," + address1.Trim() + "," + address2 + "," + city + "," + state + "," + country + "," + zip + "," + franchisee + "," + salesRep + "," + controlID;
                string strEventView = string.Empty;

                strEventView = "onclick = 'window.location=\"EventDetails.aspx?EventID=" + eventForCalendar[count].EventID.ToString() + "\"'";
                
                string strAddress = CommonCode.AddressMultiLine(eventForCalendar[count].Host.Address.Address1, eventForCalendar[count].Host.Address.Address2, eventForCalendar[count].Host.Address.City, eventForCalendar[count].Host.Address.State, eventForCalendar[count].Host.Address.Zip);
				string podName =string.Empty;
                 var jTipData = "Event Details for " + eventData.Replace("\"", string.Empty) + "[" + eventForCalendar[count].EventID + "] " + "<span class=\"whitetxt12\">(" + eventStatus.Replace("\"", string.Empty).Trim() + ")</span>" +
                        "|<p class=\"jtprowtop \"><span class=\"lbljtip\">Date &amp; Time:</span>" +
                        "<span class=\"dtlsjtip\">" +
                        currentEventDate.Replace("\"", string.Empty) + "<br />" +
                        eventStartTime.Replace("\"", string.Empty) + "&ndash;" + eventEndTime.Replace("\"", string.Empty) + "<br />" +
                        timeZone.Replace("\"", string.Empty) +
                        "</span>" +
                        "</p><p class=\"jtprow\"><span class=\"lbljtip\"> Address: </span>" +
                        "<span class=\"dtlsjtip\">" +
                        strAddress.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Owner: </span>" +
                        "<span class=\"dtlsjtip\">" +
                        salesRep.Replace("\"", string.Empty) + "<br />(" + franchisee.Replace("\"", string.Empty) + ")" +
                        "</span></p>";
                        podName = "<p class=\"jtprow\"><span class=\"lbljtip\"> Pod Name: </span>";
                        podName = podName + "<span class=\"dtlsjtip\">";
                        if (eventForCalendar[count].EventPod != null)
                        {
                            for (int podcount = 0; podcount < eventForCalendar[count].EventPod.Count; podcount++)
                            {
                                podName = podName + eventForCalendar[count].EventPod[podcount].Pod.Name.Replace("\"", string.Empty) + "<br />";
                            }
                        }
                        podName = podName + "</span></p>";
                        jTipData = jTipData + podName +
                        "<p class=\"jtprow\"><span class=\"lbljtip\"> Statistics/Health: </span> </p>" +
                        "<p class=\"jtprowtop\"><span class=\"custcauntjtp\"><span class=\"ttxt\"> Registered Customers </span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].RegisteredCustomersCount.ToString().Replace("\"", string.Empty) + "</span>" + "<br />" +
                        "<span class=\"ttxt\"> Attended Customers</span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].AttendedCustomersCount.ToString().Replace("\"", string.Empty) + "</span>" + "<br />" +
                        "<span class=\"ttxt\"> Canceled Customers</span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].CancelCustomersCount.ToString().Replace("\"", string.Empty) + "</span></span></p>";

                string strEventName = "<a  class='jtip'  title='" + jTipData + "'" + strEventView + " ><img src='../Images/addevent-square.gif' height='14px' width='14px' /><span class='celltxt_clnder'>&nbsp;</span></a>";

                _tblAppointments.Rows.Add(new object[] { "Event" + eventForCalendar[count].EventID.ToString() + strOwner, "Event", strEventName, eventForCalendar[count].EventDate, strEventDescription });
            }
        }

        FillBlockedDays(startDate, endDate, strOwner);
        return _tblAppointments;
    }
    /// <summary>
    /// Fill the data in the calendar
    /// </summary>
    private void SetCalendar()
    {
        DateTime startDate = new DateTime(dcAppointments1.VisibleDate.Year, dcAppointments1.VisibleDate.Month, 1).AddDays(0);
        DateTime endDate = new DateTime(dcAppointments1.VisibleDate.Date.AddMonths(1).Year, dcAppointments1.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(-1);
        dcAppointments1.DataSource = GetEventData(startDate, endDate, dcAppointments1.ID);
        dcAppointments1.ShowTitle = true;


        startDate = new DateTime(dcAppointments2.VisibleDate.Year, dcAppointments2.VisibleDate.Month, 1).AddDays(0);
        endDate = new DateTime(dcAppointments2.VisibleDate.Date.AddMonths(1).Year, dcAppointments2.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(-1);
        dcAppointments2.DataSource = GetEventData(startDate, endDate, dcAppointments2.ID);
        dcAppointments2.ShowTitle = true;


        startDate = new DateTime(dcAppointments3.VisibleDate.Year, dcAppointments3.VisibleDate.Month, 1).AddDays(0);
        endDate = new DateTime(dcAppointments3.VisibleDate.Date.AddMonths(1).Year, dcAppointments3.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(-1);
        dcAppointments3.DataSource = GetEventData(startDate, endDate, dcAppointments3.ID);
        dcAppointments3.ShowTitle = true;


        startDate = new DateTime(dcAppointments4.VisibleDate.Year, dcAppointments4.VisibleDate.Month, 1).AddDays(0);
        endDate = new DateTime(dcAppointments4.VisibleDate.Date.AddMonths(1).Year, dcAppointments4.VisibleDate.Date.AddMonths(1).Month, 1).AddDays(-1);
        dcAppointments4.DataSource = GetEventData(startDate, endDate, dcAppointments4.ID);
        dcAppointments4.ShowTitle = true;
    }

    protected void dcAppointments_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Controls.Clear();

            var htmlGenericControl = new HtmlGenericControl
                         {
                             InnerHtml = e.Day.DayNumberText + "<span  class='celltxt_clnder' >&nbsp;</span>"
                         };
            e.Cell.Controls.Add(htmlGenericControl);
        }
    }

    private List<EBlockedDay> GetBlockedDayForCalendar(long intUserShellID, string strStartDate, string strEndDate, string strRoleType)
    {
        var otherDal = new OtherDAL();
        switch (strRoleType)
        {
            case "Franchisor":
                return otherDal.GetBlockedDayForCalendar(intUserShellID, strStartDate, strEndDate, 1);

            case "Franchisee":
                return otherDal.GetBlockedDayForCalendar(intUserShellID, strStartDate, strEndDate, 0);
            default:
                return otherDal.GetBlockedDayForCalendar(intUserShellID, strStartDate, strEndDate, 0);

        }
    }

    private void FillBlockedDays(DateTime startDate, DateTime endDate, string strOwner)
    {
        var otherDal = new OtherDAL();
        var objBlockedDay = new List<EBlockedDay>();
        var sessionContext = IoC.Resolve<ISessionContext>();
        if (sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin))
        {
            objBlockedDay = GetBlockedDayForCalendar(0, startDate.ToString(), endDate.ToString(), "Franchisor");

        }
        else if (sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
        {
            objBlockedDay = GetBlockedDayForCalendar(sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, startDate.ToString(), endDate.ToString(), "Franchisee");

        }

        if (objBlockedDay != null && objBlockedDay.Count > 0)
        {
            for (int count = 0; count < objBlockedDay.Count; count++)
            {
                string strBlockedReason = string.Empty;

                if ((objBlockedDay[count].IsGlobal == false) && (sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin)))
                {
                    string ControlID = "\"BlockedDay" + objBlockedDay[count].BlockedDayID + strOwner + "\"";

                    string strFranchisee = string.Empty;
                    for (int i = 0; i < objBlockedDay[count].BlockDayFranchisee.Count; i++)
                    {
                        if (strFranchisee != string.Empty)
                        {
                            strFranchisee = strFranchisee + "<br>" + (i + 1) + ": " + objBlockedDay[count].BlockDayFranchisee[i].Franchisee.Name;
                        }
                        else
                        {
                            strFranchisee = (i + 1) + ": " + objBlockedDay[count].BlockDayFranchisee[i].Franchisee.Name;

                        }
                    }
                    strFranchisee = "\"" + strFranchisee + " \"";
                    string strBlockedDayDescription = strFranchisee + "," + ControlID;
                    strBlockedReason = "<a  onmouseout='hideTipBubble(\"BlockedDay\")'   onmouseover='ShowBlockedDayFranchisee(" + strBlockedDayDescription + ")'> <img src='../Images/block-square.gif' />  " + objBlockedDay[count].BlockedReason + "</a>";
                }

                else
                {
                    strBlockedReason = "<img src='../Images/block-square.gif' /> " + objBlockedDay[count].BlockedReason;
                }


                _tblAppointments.Rows.Add(new object[] { "BlockedDay" + objBlockedDay[count].BlockedDayID.ToString() + strOwner, "BlockedDay", strBlockedReason, objBlockedDay[count].BlockedDate, string.Empty });
            }
        }

    }

}

