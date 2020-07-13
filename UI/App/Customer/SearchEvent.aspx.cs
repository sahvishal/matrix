using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Other;
using Falcon.App.Lib;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Lib;

public partial class App_Customer_SearchEvent : Page
{
    private string _guid;
    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? _guid : Request.QueryString["guid"];
        }
        set { _guid = value; }
    }

    private RegistrationFlowModel RegistrationFlow
    {
        get
        {
            if (!string.IsNullOrEmpty(GuId))
            {
                return Session[GuId] as RegistrationFlowModel;
            }
            return null;
        }
        set { Session[GuId] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Title = "Search Events";
        var objmaster = (Customer_CustomerMaster)Master;
        objmaster.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";
        objmaster.SetPageView("EventRegistration");

        if (!IsPostBack)
        {
            ViewState["SortExp"] = "Distance";
            ViewState["SortDir"] = SortDirection.Ascending;

            var customerEventRegistrationViewDataRepository = new CustomerEventRegistrationViewDataRepository();
            var customerEventRegistrationSummary = customerEventRegistrationViewDataRepository.GetCustomerEventRegistrationViewData(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            if (customerEventRegistrationSummary != null && customerEventRegistrationSummary.Count > 0)
            {
                txtZip.Text = customerEventRegistrationSummary.Select(s => s.EventAddress.ZipCode.Zip).First();
            }
            else
            {
                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customer = customerRepository.GetCustomer(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                txtZip.Text = customer.Address.ZipCode.Zip;
            }

            SearchEvent();
        }
        if (Request.Params["__EVENTTARGET"] == "VerifyInvitationCode")
            VerifyInvitation(Request.Params["__EVENTARGUMENT"]);
    }

    protected void lnkSelectEvent_Click(object sender, EventArgs e)
    {
        var lnkEvent = (ImageButton)sender;
        long eventId = Convert.ToInt64(lnkEvent.CommandArgument);
        long customerId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        if (PackageRegistrationValidators.EventValidation(customerId, eventId))
        {
            IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository =
                new EventCustomerRegistrationViewDataRepository();

            var data =
                eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(customerId,
                                                                                   Convert.ToInt64(
                                                                                       lnkEvent.CommandArgument));
            if (data != null)
            {
                var packageAndTest = data.PackageName;
                packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                     ? data.AdditinalTest
                                     : packageAndTest +
                                       (string.IsNullOrEmpty(data.AdditinalTest)
                                            ? string.Empty
                                            : ", " + data.AdditinalTest);

                divErrorMsg.InnerHtml = "You are already registered for this event (" + data.EventName +
                                        " ) at " + data.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                        data.AppointmentStartTime.ToString("hh:mm tt") + " for the " +
                                        packageAndTest +
                                        ". Duplicate registrations, on one event, for the same customer are not allowed.";
                divErrorMsg.Visible = true;
                return;
            }
        }

        var service = IoC.Resolve<IRefundRequestService>();
        var result = service.CheckifCancelAppointmentRequestExistsforaCustomer(eventId, customerId);
        if (result)
        {
            var settings = IoC.Resolve<ISettings>();
            divErrorMsg.InnerHtml = "Your appointment has been cancelled for this event, the cancellation request is in process. Re-registration is not allowed unless the request is resolved. Please call on this number " + settings.CustomerPortalPhoneTollFree;
            divErrorMsg.Visible = true;
            return;
        }

        if (string.IsNullOrEmpty(GuId) || RegistrationFlow == null)
        {
            GuId = Guid.NewGuid().ToString();
            var registrationFlow = new RegistrationFlowModel
                                       {
                                           GuId = GuId,
                                           EventId = eventId
                                       };
            RegistrationFlow = registrationFlow;
        }
        else
            RegistrationFlow.EventId = eventId;

        if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
        {
            var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
            var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
            if (slots.Where(s => s.EventId != eventId).Any())
            {
                eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
                RegistrationFlow.AppointmentSlotIds = null;
            }

        }


        Response.RedirectUser("UpdateEventCustomerProfile.aspx?guid=" + RegistrationFlow.GuId);

    }

    protected void dgEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgEvent.PageIndex = e.NewPageIndex;
        dgEvent.DataSource = ViewState["Event"];
        dgEvent.DataBind();
    }

    protected void dgEvent_Sorting(object sender, GridViewSortEventArgs e)
    {
        var dtEvent = (DataTable)ViewState["Event"];

        if (e.SortExpression != ViewState["SortExp"].ToString())
        {
            dtEvent.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                dtEvent.DefaultView.Sort = e.SortExpression + " desc";
                ViewState["SortDir"] = SortDirection.Descending;
            }
            else
            {
                dtEvent.DefaultView.Sort = e.SortExpression + " asc";
                ViewState["SortDir"] = SortDirection.Ascending;
            }
        }

        ViewState["SortExp"] = e.SortExpression;
        dtEvent = dtEvent.DefaultView.ToTable();

        dgEvent.DataSource = dtEvent;
        dgEvent.DataBind();


        ViewState["Event"] = dtEvent;
    }

    private void SearchEvent()
    {
        var otherDal = new OtherDAL();
        int distance = 0;


        if (!int.TryParse(otherDal.GetConfigurationValue("Eventdistance"), out distance))
            distance = 0;

        ViewState["SortExp"] = txtZip.Text == string.Empty ? "Name" : "Distance";


        var eventService = IoC.Resolve<IEventService>();

        List<EventHostViewData> eventHostViewData = eventService.GetEventHostViewData(ViewType.CustomerPortal, txtState.Text, txtCity.Text,
                                                               string.Empty, txtZip.Text, distance,
                                                               txtFrom.Text.Length > 0
                                                                   ? (DateTime?)Convert.ToDateTime(txtFrom.Text)
                                                                   : null,
                                                               txtTo.Text.Length > 0
                                                                   ? (DateTime?)Convert.ToDateTime(txtTo.Text)
                                                                   : null);


        var eventsDataTable = new DataTable();
        eventsDataTable.Columns.Add("Id");
        eventsDataTable.Columns.Add("Name");
        eventsDataTable.Columns.Add("Date");
        eventsDataTable.Columns.Add("Host");
        eventsDataTable.Columns.Add("Address");
        eventsDataTable.Columns.Add("Distance");
        eventsDataTable.Columns.Add("GoogleMap");
        eventsDataTable.Columns.Add("IsSlotsAvailable", typeof(bool));
        eventsDataTable.Columns.Add("IsNoSlotsAvailable", typeof(bool));
        eventsDataTable.Columns.Add("TempUnavailable", typeof(bool));
        eventsDataTable.Columns.Add("EventType");

        if (eventHostViewData != null)
        {
            foreach (var eventHost in eventHostViewData)
            {
                if (eventHostViewData.IndexOf(eventHost) > 9)
                    break;

                string strAddress = CommonCode.AddressMultiLine(eventHost.StreetAddressLine1, eventHost.StreetAddressLine2, eventHost.City, eventHost.State, eventHost.Zip);
                //string strGoogleMap = eventHost.StreetAddressLine1 + "," + eventHost.City + "," + eventHost.State + "," + eventHost.Zip;
                string strGoogleMap = CommonCode.GetGoogleMapAddress(eventHost.StreetAddressLine1, eventHost.City, eventHost.State, eventHost.Zip, eventHost.Latitude + "," + eventHost.Longitude, eventHost.UseLatitudeAndLongitudeForMapping);

                bool slotsAvailable = true;
                bool noSlotsAvailable = true;
                bool tempUnavailable = true;

                if (Convert.ToString(Enum.Parse(typeof(EventStatus), eventHost.EventStatus)).Equals("Suspended"))
                {
                    slotsAvailable = false;
                    noSlotsAvailable = false;
                }
                else
                {
                    tempUnavailable = false;
                    if (eventHost.AvailableAppointmentSlots > 0)
                    {
                        noSlotsAvailable = false;
                    }
                    else
                    {
                        slotsAvailable = false;
                    }
                }

                eventsDataTable.Rows.Add(new object[] { eventHost.EventId, eventHost.Name, 
                    Convert.ToDateTime(eventHost.EventDate).ToString("MM/dd/yyyy"),
                    eventHost.OrganizationName, strAddress, eventHost.DistanceFromZip,   
                    strGoogleMap, slotsAvailable, noSlotsAvailable, tempUnavailable,eventHost.EventType });

            }
        }
        if (eventsDataTable.Rows.Count > 0)
        {
            ViewState["Event"] = eventsDataTable;
            dgEvent.DataSource = eventsDataTable;

            dgEvent.Visible = true;
            dgEvent.DataBind();
            dvSearchResult1.InnerText = "Total: ";
            dvSearchResult.InnerText = eventsDataTable.Rows.Count + " Result found";

        }
        else
        {
            dgEvent.Visible = false;
            dvSearchResult.InnerText = "No Result found";
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchEvent();
    }

    protected void dgEvent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                var selectEventLink = e.Row.FindControl("lnkSelectEvent") as ImageButton;
                if (selectEventLink != null)
                {
                    var drvCurrent = e.Row.DataItem as DataRowView;
                    if (drvCurrent != null)
                    {
                        var eventType = Enum.Parse(typeof(RegistrationMode), Convert.ToString(drvCurrent["EventType"])).ToString();
                        if (eventType == RegistrationMode.Private.ToString())
                        {
                            selectEventLink.Attributes.Add("onclick", "return SelectEvent(" + Convert.ToString(drvCurrent["Id"]) + ")");
                        }
                    }
                }
                break;
        }
    }


    protected void VerifyInvitation(string invitationCode)
    {
        // verifiy events
        long eventId = 0;
        long customerId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        if (!string.IsNullOrEmpty(hidEventID.Value))
        {
            eventId = Convert.ToInt64(hidEventID.Value);
        }
        //var invitationCode = txtInvitationCode.Text;

        IEventRepository eventRepository = new EventRepository();

        if (!eventRepository.ValidateInvitationCode(eventId, invitationCode))
        {
            divErrorMsg.InnerHtml = "You had enter the wrong invitation code.<br> Please enter correct invitation code and try again.";
            divErrorMsg.Visible = true;
            return;
        }

        if (PackageRegistrationValidators.EventValidation(customerId, eventId))
        {
            IEventCustomerRegistrationViewDataRepository eventCustomerRegistrationViewDataRepository = new EventCustomerRegistrationViewDataRepository();

            var data = eventCustomerRegistrationViewDataRepository.GetEventCustomerOrders(customerId, eventId);
            if (data != null)
            {
                var packageAndTest = data.PackageName;
                packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                     ? data.AdditinalTest
                                     : packageAndTest +
                                       (string.IsNullOrEmpty(data.AdditinalTest)
                                            ? string.Empty
                                            : ", " + data.AdditinalTest);

                divErrorMsg.InnerHtml = "You are already registered for this event (" + data.EventName +
                                        " ) at " + data.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                        data.AppointmentStartTime.ToString("hh:mm tt") + " for the " +
                                        packageAndTest +
                                        ". Duplicate registrations, on one event, for the same customer are not allowed.";
                divErrorMsg.Visible = true;
                return;
            }
        }

        var service = IoC.Resolve<IRefundRequestService>();
        var result = service.CheckifCancelAppointmentRequestExistsforaCustomer(eventId, customerId);
        if (result)
        {
            var settings = IoC.Resolve<ISettings>();
            divErrorMsg.InnerHtml = "Your appointment has been cancelled for this event, the cancellation request is in process. Re-registration is not allowed unless the request is resolved. Please call on this number " + settings.CustomerPortalPhoneTollFree;
            divErrorMsg.Visible = true;
            return;
        }

        if (string.IsNullOrEmpty(GuId) || RegistrationFlow == null)
        {
            GuId = Guid.NewGuid().ToString();
            var registrationFlow = new RegistrationFlowModel
            {
                GuId = GuId,
                EventId = eventId
            };
            RegistrationFlow = registrationFlow;
        }
        else
            RegistrationFlow.EventId = eventId;

        if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
        {
            var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
            var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
            if (slots.Where(s => s.EventId != eventId).Any())
            {
                eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
                RegistrationFlow.AppointmentSlotIds = null;
            }

        }

        Response.RedirectUser("UpdateEventCustomerProfile.aspx?guid=" + RegistrationFlow.GuId);

    }
}
