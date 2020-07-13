using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Lib;
using Falcon.DataAccess.Franchisee;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Franchisee;
using Falcon.Entity.Other;
using System.Data;
using Falcon.Entity.User;

namespace Falcon.App.UI.App.Common
{
    public class CalendarHelper
    {
        private readonly MasterDAL _masterDal = null;
        private DataTable _tblAppointments;


        private bool ViewEvent { get; set; }

        private bool ViewTask { get; set; }

        private bool ViewMeeting { get; set; }

        private bool ViewCall { get; set; }

        private bool ViewSeminar { get; set; }

        private string HostName { get; set; }

        private string TerritoryIds { get; set; }

        private string PodIds { get; set; }

        private long SalesRepId { get; set; }

        private long FranchiseeId { get; set; }

        public CalendarHelper(bool isViewEvent, bool isViewTask, bool isViewMeeting, bool isViewCall, bool isViewSeminar, string hostName, long franchiseeId, long salesRepId, string podIds, string territoryIds)
        {
            ViewEvent = isViewEvent;
            ViewMeeting = isViewMeeting;
            ViewCall = isViewCall;
            ViewSeminar = isViewSeminar;
            ViewTask = isViewTask;
            HostName = hostName;
            FranchiseeId = franchiseeId;
            SalesRepId = salesRepId;
            PodIds = podIds;
            TerritoryIds = territoryIds;
            _masterDal = new MasterDAL();

            }

        public DataTable GetCalendarDataByFilters(DateTime startDate, DateTime endDate)
        {
            _tblAppointments = new DataTable();
            _tblAppointments.Columns.Add("AppointMentID");
            _tblAppointments.Columns.Add("AppointmentType");
            _tblAppointments.Columns.Add("AppointmentInfo");
            _tblAppointments.Columns.Add("EventDate");
            _tblAppointments.Columns.Add("Description");

            if (ViewEvent) { GetEventDataByDate(startDate, endDate); }

            if (ViewMeeting) { GetMeetingDataByDate(startDate, endDate); }
            if (ViewCall) { GetCallDataByDate(startDate, endDate); }
            if (ViewTask) { GetTaskDataByDate(startDate, endDate); }

            GetBlockedDaysForCalendar(startDate, endDate);

            return _tblAppointments;
        }

      
        private void GetEventDataByDate(DateTime startDate, DateTime endDate)
        {
            List<EEvent> eventForCalendar;
            if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                eventForCalendar = _masterDal.GetEventForCalendar(0, startDate.ToShortDateString(), endDate.ToShortDateString(), 0, HostName, FranchiseeId, PodIds, TerritoryIds);
            else
                eventForCalendar = _masterDal.GetEventForCalendar(SalesRepId, startDate.ToShortDateString(), endDate.ToShortDateString(), 0, HostName, FranchiseeId, PodIds, TerritoryIds);
            var eventIds = new List<long>();
            ITerritoryRepository territoryRepository = new TerritoryRepository();

            if (!string.IsNullOrEmpty(TerritoryIds) && TerritoryIds!="0")
            {
                var territoryIds = TerritoryIds.Split(',').ToList().Select(ti => Convert.ToInt64(ti)).ToList();
                List<Territory> territories = territoryRepository.GetTerritories(territoryIds);
                List<string> territoryZipCodes =
                    territories.SelectMany(territory => territory.ZipCodes.Select(zipCode => zipCode.Zip)).ToList();
                eventForCalendar =
                    eventForCalendar.Where(eventData => territoryZipCodes.Contains(eventData.Host.Address.Zip)).ToList();

                if (SalesRepId > 0)
                {
                    var salesRepTerritories =
                        territoryRepository.GetTerritoriesForSalesRep(SalesRepId).Where(t => territoryIds.Contains(t.Id))
                            .ToList();

                    foreach (var calenderEvent in eventForCalendar)
                    {
                        var @event = calenderEvent;

                        var filteredSalesRepTerritories =
                            salesRepTerritories.Where(
                                st => st.ZipCodes.Select(z => z.Zip).Contains(@event.Host.Address.Zip));

                        foreach (var filteredSalesRepTerritory in filteredSalesRepTerritories)
                        {
                            SalesRepTerritory territory = filteredSalesRepTerritory;
                            if (filteredSalesRepTerritories.All(fstpt => fstpt.ParentTerritoryId != territory.Id))
                            {
                                var territoryAssignment = territory.SalesRepTerritoryAssignments.SingleOrDefault(srta => srta.SalesRep.SalesRepresentativeId == SalesRepId);

                                if (territoryAssignment != null && (int)territoryAssignment.EventTypeSetupPermission != 0 && calenderEvent.EventType.EventTypeID != (int)territoryAssignment.EventTypeSetupPermission)
                                {
                                    eventIds.Add(@event.EventID);
                                }
                            }
                        }
                    }
                }
            }

            if (eventForCalendar != null)
            {
                for (int count = 0; count < eventForCalendar.Count; count++)
                {
                    string eventData = "\"" + eventForCalendar[count].Name.Replace("\n", "").Replace("'", "") + " \"";
                    string eventStatus = "\"" + Convert.ToString(Enum.Parse(typeof(EventStatus), eventForCalendar[count].EventStatus.ToString())).Replace("\n", "").Replace("'", "") + " \"";

                    string eventDate = "\"" + Convert.ToDateTime(eventForCalendar[count].EventDate).ToLongDateString() + " \"";
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
                    string controlId = "\"Event" + eventForCalendar[count].EventID + "\"";

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

                    string strAddress = CommonCode.AddressMultiLine(eventForCalendar[count].Host.Address.Address1, eventForCalendar[count].Host.Address.Address2, eventForCalendar[count].Host.Address.City, eventForCalendar[count].Host.Address.State, eventForCalendar[count].Host.Address.Zip);
                    strAddress = "\"" + strAddress.Replace("\n", "").Replace("'", "") + " \"";

                    string strEventDescription = eventData + "," + eventStatus + "," + eventDate + "," + eventStartTime + "," + eventEndTime + "," + timeZone + "," + customerCount + "," + strAddress.Trim() + "," + address2 + "," + city + "," + state + "," + country + "," + zip + "," + franchisee + "," + salesRep + "," + controlId;
                    string strEventView = string.Empty;

                    if (!eventIds.Contains(eventForCalendar[count].EventID))
                        strEventView = "onclick = 'window.location=\"EventDetails.aspx?EventID=" + eventForCalendar[count].EventID.ToString() + "\"'";

                    //}

                    string salesRepInitials =
                        eventForCalendar[count].FranchiseeFranchiseeUser.FranchiseeUser.User.FirstName.Substring(0, 1) +
                        eventForCalendar[count].FranchiseeFranchiseeUser.FranchiseeUser.User.LastName.Substring(0, 1);
                    string podName = string.Empty;
                    var jTipData = "Event Details for " + eventData.Replace("\"", string.Empty) + "[" + eventForCalendar[count].EventID + "] " +"<span class=\"whitetxt12\">(" + eventStatus.Replace("\"", string.Empty).Trim() + ")</span>" +
                        "|<p class=\"jtprowtop \"><span class=\"lbljtip\"> Date &amp; Time: </span>" +
                        "<span class=\"dtlsjtip\">" +
                        eventDate.Replace("\"", string.Empty) + "<br />" +
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
                    
                    eventStatus = "<p class=\"jtprow\"><span class=\"lbljtip\"> Event Status: </span>";
                    eventStatus += "<span class=\"dtlsjtip\">" + ((EventStatus)eventForCalendar[count].EventStatus).ToString() + "</span></p>";

                    jTipData = jTipData + podName + eventStatus+
                    "<p class=\"jtprow\"><span class=\"lbljtip\"> Statistics/Health: </span> </p>" +
                    "<p class=\"jtprowtop\"><span class=\"custcauntjtp\"><span class=\"ttxt\"> Registered Customers </span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].RegisteredCustomersCount.ToString().Replace("\"", string.Empty) + "</span>" + "<br />" +
                    "<span class=\"ttxt\"> Attended Customers</span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].AttendedCustomersCount.ToString().Replace("\"", string.Empty) + "</span>" + "<br />" +
                    "<span class=\"ttxt\"> Canceled Customers</span>" + "<span class=\"dtxt\">" + ":&nbsp;" + eventForCalendar[count].CancelCustomersCount.ToString().Replace("\"", string.Empty) + "</span></span></p>";

                    string strEventName = "<a  class='jtip'  title='" + jTipData + "'" + strEventView + " ><img src='../Images/addevent-square.gif' /><span class='celltxt_clnder'>" + salesRepInitials + " " + eventForCalendar[count].Host.Name + "<br>" + eventForCalendar[count].Host.Address.City + ", " + eventForCalendar[count].Host.Address.State + " - " + eventForCalendar[count].Host.Address.Zip + "</span></a>";

                    _tblAppointments.Rows.Add(new object[] { "Event" + eventForCalendar[count].EventID.ToString(), "Event", strEventName, eventForCalendar[count].EventDate, strEventDescription });
                }
            }

        }

        private void GetMeetingDataByDate(DateTime startDate, DateTime endDate)
        {
            var contactMeetings = _masterDal.GetMeetingForCalendar(FranchiseeId,
                                                                        SalesRepId,
                                                                        HostName,
                                                                        startDate.ToShortDateString(),
                                                                        endDate.ToShortDateString(), 0);
            EContactMeeting[] eContactMeetings = null;
            if (contactMeetings != null)
                eContactMeetings = contactMeetings.ToArray();
            if (eContactMeetings != null && eContactMeetings.Length > 0)
            {
                for (int count = 0; count < eContactMeetings.Length; count++)
                {
                    string meetingSubject = "\"" + eContactMeetings[count].Subject + " \"";

                    string meetingStartDate = "";
                    if (eContactMeetings[count].StartDate.Trim().Length > 0)
                        meetingStartDate = "\"" + Convert.ToDateTime(eContactMeetings[count].StartDate).ToLongDateString() + " \"";

                    string meetingStartTime = "";
                    if (eContactMeetings[count].StartTime.Trim().Length > 0)
                        meetingStartTime = "\"" + Convert.ToDateTime(eContactMeetings[count].StartTime).ToShortTimeString() + " \"";

                    string meetingContact = "\"" + eContactMeetings[count].Contact.Title + " " + eContactMeetings[count].Contact.FirstName + " " + eContactMeetings[count].Contact.LastName + " \"";
                    string meetingVenue = "\"" + eContactMeetings[count].Venue.Replace("\n", "") + " \"";
                    string meetingStatus = "\"" + eContactMeetings[count].CallStatus.Status + " \"";
                    string meetingDescription = "\"" + eContactMeetings[count].Description + " \"";
                    string controlID = "\"Meeting" + eContactMeetings[count].ContactMeetingID + "\"";


                    string meetingDescription1 = meetingSubject + "," + meetingContact + "," + meetingStartDate + "," + meetingStartTime + "," + meetingVenue + "," + meetingStatus + "," + meetingDescription + "," + controlID;
                    string meetingView;

                    if (eContactMeetings[count].CallStatus.Status == "Completed")
                    {
                        meetingView = "onclick = 'alert(\"You cannot edit Meeting already completed\")' ";
                    }

                    else
                    {
                        meetingView = "onclick = 'window.location=\"../../App/Franchisor/AddMeeting.aspx?ContactMeetingID=" + eContactMeetings[count].ContactMeetingID + "&Referrer=Calendar\"'";
                    }

                    var jTipData = "Meeting Details: " +
                        "|<p class=\"jtprowtop\"><span class=\"lbljtip\"> Subject </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingSubject.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Contact to</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingContact.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Start on</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingStartDate.Replace("\"", string.Empty) + " at " + meetingStartTime.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Venue </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingVenue.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Status </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingStatus.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Description</span> " +
                         "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        meetingDescription.Replace("\"", string.Empty) + "</span></p>";

                    string strMeetingName = "<a  class='jtip'  title='" + jTipData + "'" + meetingView + " ><img src='../Images/appointments-square.gif' /> " + eContactMeetings[count].Subject + "</a>";

                    _tblAppointments.Rows.Add(new object[] { "Meeting" + eContactMeetings[count].ContactMeetingID.ToString(), "Meetings", strMeetingName, eContactMeetings[count].StartDate, meetingDescription1 });

                }
            }

        }

        private void GetCallDataByDate(DateTime startDate, DateTime endDate)
        {
            var listContactCall = _masterDal.GetCallForCalendar(FranchiseeId,
                                                                  SalesRepId,
                                                                  HostName,
                                                                  startDate.ToShortDateString(), endDate.ToShortDateString(), 0);
            EContactCall[] eContactCalls = null;
            if (listContactCall != null)
                eContactCalls = listContactCall.ToArray();
            if (eContactCalls != null && eContactCalls.Length > 0)
            {
                for (int counter = 0; counter < eContactCalls.Length; counter++)
                {
                    string callSubject = "\"" + eContactCalls[counter].Subject + " \"";

                    string callStartDate = "";
                    if (eContactCalls[counter].StartDate.Trim().Length > 0)
                    {
                        callStartDate = "\"" + Convert.ToDateTime(eContactCalls[counter].StartDate).ToLongDateString() +
                                        " \"";
                    }

                    string callStartTime = "\"\"";
                    if (eContactCalls[counter].StartTime.Trim().Length > 0)
                    {
                        callStartTime = "\"" + Convert.ToDateTime(eContactCalls[counter].StartTime).ToShortTimeString() +
                                        " \"";
                    }

                    string callContact = "\"" + eContactCalls[counter].Contact.Title + " " + eContactCalls[counter].Contact.FirstName + " " + eContactCalls[counter].Contact.LastName + " \"";
                    string callDuration = "\"" + (Convert.ToInt32(eContactCalls[counter].Duration) / 60) + " hrs. & " + Convert.ToInt32(eContactCalls[counter].Duration % 60) + " min. \"";
                    string callStatus = "\"" + eContactCalls[counter].CallStatus.Status + " \"";
                    string callDescription = "\"" + eContactCalls[counter].Notes + " \"";
                    string controlId = "\"Call" + eContactCalls[counter].ContactCallID + "\"";


                    string callDescriptions = callSubject + "," + callContact + "," + callStartDate + "," + callStartTime + "," + callDuration + "," + callStatus + "," + callDescription + "," + controlId;
                    string strCallView;

                    if (eContactCalls[counter].CallStatus.Status == "Completed")
                    {
                        strCallView = "onclick = 'alert(\"You cannot edit Call already completed\")' ";
                    }

                    else
                    {
                        strCallView = "onclick = 'window.location=\"../../App/Franchisor/AddCall.aspx?ContactCallID=" + eContactCalls[counter].ContactCallID + "&Referrer=Calendar\"'";
                    }

                    var jTipData =
                        "<p class=\"jtprowtop\"><span class=\"lbljtip\"> Subject</span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callSubject.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Contact to </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callContact.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Start on </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callStartDate.Replace("\"", string.Empty) + " at " + callStartTime.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\">Duration</span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callDuration.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Status</span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callStatus.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\">Description</span> " +
                         "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        callDescription.Replace("\"", string.Empty) + "</span></p>";


                    string strCallName = "<a  class='jtip' title='CallDetails|" + jTipData + "'" + strCallView + " > <img src='../Images/reminders-square.gif' /> " + eContactCalls[counter].Subject + "</a>";

                    _tblAppointments.Rows.Add(new object[] { "Call" + eContactCalls[counter].ContactCallID.ToString(), "Calls", strCallName, eContactCalls[counter].StartDate, callDescriptions });

                }
            }

        }

        private void GetTaskDataByDate(DateTime startDate, DateTime endDate)
        {
            ETask[] eTasks = null;
            var tasks = _masterDal.GetTaskForCalendar(FranchiseeId, SalesRepId, HostName, startDate.ToShortDateString(), endDate.ToShortDateString(), 0);

            if (tasks != null) eTasks = tasks.ToArray();

            if (eTasks != null && eTasks.Length > 0)
            {
                for (int count = 0; count < eTasks.Length; count++)
                {
                    string strTaskDescription = "";

                    string taskDueTime = "\"\"";
                    if (eTasks[count].DueTime.Trim().Length > 0)
                        taskDueTime = "\"" + Convert.ToDateTime(eTasks[count].DueTime).ToShortTimeString() + " \"";

                    string taskDueDate = "\"\"";
                    if (eTasks[count].DueDate.Trim().Length > 0)
                        taskDueDate = "\"" + Convert.ToDateTime(eTasks[count].DueDate).ToLongDateString() + " \"";

                    string taskStartDate = "\"\"";
                    if (eTasks[count].StartDate.Trim().Length > 0)
                        taskStartDate = "\"" + Convert.ToDateTime(eTasks[count].StartDate).ToLongDateString() + " \"";

                    string taskStartTime = "\"\"";
                    if (eTasks[count].StartTime.Trim().Length > 0)
                        taskStartTime = "\"" + Convert.ToDateTime(eTasks[count].StartTime).ToShortTimeString() + " \"";

                    string taskNotes = "\"" + eTasks[count].Notes.Replace("\n", "") + " \"";
                    string taskSubject = "\"" + eTasks[count].Subject.Replace("\n", "") + " \"";
                    string taskPriority = "\"" + eTasks[count].TaskPriorityType.Name + " \"";
                    string taskStatus = "\"" + eTasks[count].TaskStatusType.Name + " \"";
                    string controlID = "\"Task" + eTasks[count].TaskID + "\"";

                    //Added w\ Calendar enhancement starts
                    string taskEvent = String.Empty;
                    string taskHost = String.Empty;
                    string ownerName = String.Empty;
                    string taskEventIDQuery = String.Empty; //Used for passing eventid in query string (future release)

                    if(String.IsNullOrEmpty(eTasks[count].OwnerName))
                        ownerName = "\"NA" + "\"";
                    else
                        ownerName = "\"" + eTasks[count].OwnerName + "\"";

                    if (eTasks[count].EventID > 0)
                    {
                        taskEventIDQuery = eTasks[count].EventID.ToString();
                        taskEvent = "\"" + eTasks[count].EventName + " [" + taskEventIDQuery + "]<br/>" + Convert.ToDateTime(eTasks[count].EventDate).ToLongDateString() + " \"";
                        taskHost = "\"" + eTasks[count].HostOrgName + "<br/>" + eTasks[count].HostAddress + " \"";
                    }
                    else
                    {
                        taskEventIDQuery = "NA";
                        taskEvent = "\"" + taskEventIDQuery + " \"";
                        taskHost = "\"NA" + "\"";
                    }

                    
                    //Added w\ Calendar enhancement ends

                    strTaskDescription = taskSubject + "," + taskNotes + "," + taskStartDate + "," + taskStartTime + "," + taskDueDate + "," + taskDueTime + ","
                        + taskPriority + "," + taskStatus + "," + controlID;
                    string taskView = string.Empty;

                    if (eTasks[count].TaskStatusType.Name == "Completed")
                    {
                        taskView = "onclick = 'alert(\"You cannot edit Task already completed\")' ";
                    }

                    else
                    {
                        //taskView = "onclick = 'window.location=\"../../App/Franchisor/AddTask.aspx?TaskID=" + eTasks[count].TaskID + "&EventID=" + taskEventIDQuery + "&Referrer=Calendar\"'";
                        taskView = "onclick = 'window.location=\"../../App/Franchisor/AddTask.aspx?TaskID=" + eTasks[count].TaskID + "&Referrer=Calendar\"'";
                    }

                    var jTipData = "<p class=\"jtprowtop\"><span class=\"lbljtip\"> Event Detail</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskEvent.Replace("\"", string.Empty).Replace("'", "") +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Host Detail</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskHost.Replace("\"", string.Empty).Replace("'", "") +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Owner Name</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        ownerName.Replace("\"", string.Empty).Replace("'", "") +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Subject</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskSubject.Replace("\"", string.Empty).Replace("'", "") +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\">Notes</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskNotes.Replace("\"", string.Empty).Replace("'", "") +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Start on</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskStartDate.Replace("\"", string.Empty) + " at " + taskStartTime.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Due on</span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskDueDate.Replace("\"", string.Empty) + "at" + taskDueTime.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"><span class=\"lbljtip\"> Priority </span> " +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        "<img src=\"/App/Images/" + taskPriority.Replace("\"", string.Empty).Trim() + ".gif\" />  " + taskPriority.Replace("\"", string.Empty) +
                        "</span></p><p class=\"jtprow\"> <span class=\"lbljtip\"> Status </span>" +
                        "<span class=\"left\"><b>:</b>&nbsp;</span><span class=\"dtlsjtip\">" +
                        taskStatus.Replace("\"", string.Empty) + "</span></p>";

                    string strTaskName = "<a  class='jtip' title='Task Details|" + jTipData + "'" + taskView + " ><img src='../Images/task-square.gif' /> " + eTasks[count].Subject + "</a>";

                    _tblAppointments.Rows.Add(new object[] { "Task" + eTasks[count].TaskID.ToString(), "Task", strTaskName, eTasks[count].DueDate, strTaskDescription });
                }
            }

        }

        private void GetBlockedDaysForCalendar(DateTime startDate, DateTime endDate)
        {
            var blockedDays = new EBlockedDay[0];

            var role = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (role.CheckRole((long)Roles.FranchisorAdmin))
            {
                blockedDays = GetBlockedDayForCalendar(0, startDate.ToShortDateString(), endDate.ToShortDateString(), "Franchisor").ToArray();
            }
            else if (role.CheckRole((long)Roles.FranchiseeAdmin))
            {
                blockedDays = GetBlockedDayForCalendar(role.OrganizationRoleUserId, startDate.ToShortDateString(), endDate.ToShortDateString(), "Franchisee").ToArray();

            }


            if (blockedDays.Length > 0)
            {
                for (int count = 0; count < blockedDays.Length; count++)
                {
                    string blockedReason = string.Empty;

                    if ((blockedDays[count].IsGlobal == false) && (role.CheckRole((long)Roles.FranchisorAdmin)))
                    {
                        string controlID = "\"BlockedDay" + blockedDays[count].BlockedDayID + "\"";

                        string franchisee = string.Empty;
                        for (int i = 0; i < blockedDays[count].BlockDayFranchisee.Count; i++)
                        {
                            if (franchisee != string.Empty)
                            {
                                franchisee = franchisee + "<br>" + (i + 1) + ": " + blockedDays[count].BlockDayFranchisee[i].Franchisee.Name;
                            }
                            else
                            {
                                franchisee = (i + 1) + ": " + blockedDays[count].BlockDayFranchisee[i].Franchisee.Name;

                            }
                        }
                        franchisee = "\"" + franchisee + " \"";
                        string blockedDayDescription = franchisee + "," + controlID;
                        blockedReason = "<a  onmouseout='hideTipBubble(\"BlockedDay\")'   onmouseover='ShowBlockedDayFranchisee(" + blockedDayDescription + ")'> <img src='../Images/block-square.gif' />  " + blockedDays[count].BlockedReason + "</a>";
                    }

                    else
                    {
                        blockedReason = "<img src='../Images/block-square.gif' /> " + blockedDays[count].BlockedReason;
                    }


                    _tblAppointments.Rows.Add(new object[] { "BlockedDay" + blockedDays[count].BlockedDayID.ToString(), "BlockedDay", blockedReason, blockedDays[count].BlockedDate, string.Empty });
                }
            }

        }

        private static List<EBlockedDay> GetBlockedDayForCalendar(long intUserShellID, string strStartDate, string strEndDate, string strRoleType)
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
    }
}
