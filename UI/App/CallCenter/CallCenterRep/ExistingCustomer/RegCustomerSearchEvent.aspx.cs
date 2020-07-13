using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Extensions;
using System.Web.UI.HtmlControls;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Finance;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class RegCustomerSearchEvent : Page
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
            }
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
        }

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerType"]))
                {
                    switch (Request.QueryString["CustomerType"])
                    {
                        case "Existing":
                            return CustomerType.Existing;
                        default:
                            return CustomerType.New;
                    }
                }
                return CustomerType.New;
            }
        }

        public Roles CurrentRole
        {
            get
            {
                return (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;
            }
        }
        protected String FirstName
        {
            get { return Convert.ToString(Request.QueryString["FirstName"]); }
        }

        protected String LastName
        {
            get { return Convert.ToString(Request.QueryString["LastName"]); }
        }

        protected String CallBackNumber
        {
            get { return Convert.ToString(Request.QueryString["CallBackNo"]); }
        }

        protected String Zip
        {
            get { return Convert.ToString(Request.QueryString["Zip"]); }
        }

        private long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        private long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
            set
            {
                RegistrationFlow.EventId = value;
            }
        }

        private SortDirection CurrentSortDirection
        {
            get
            {
                if (ViewState["SortDir"] != null && !string.IsNullOrEmpty(ViewState["SortDir"].ToString()))
                {
                    return (SortDirection)Enum.Parse(typeof(SortDirection), ViewState["SortDir"].ToString());
                }
                return SortDirection.Ascending;
            }
            set
            {
                ViewState["SortDir"] = value;
            }
        }

        private string CurrentSortExpression
        {
            get
            {
                if (ViewState["SortExp"] != null && !string.IsNullOrEmpty(ViewState["SortExp"].ToString()))
                {
                    return ViewState["SortExp"].ToString();
                }
                return "Distance";
            }
            set
            {
                ViewState["SortExp"] = value;
            }
        }

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        private EventCustomer _eventCustomer = null;
        private EventCustomer EventCustomer
        {
            get
            {
                if (_eventCustomer == null)
                {
                    var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                    _eventCustomer = eventCustomerRepository.Get(EventId, CustomerId);

                }
                return _eventCustomer;
            }
        }

        private Core.Users.Domain.Customer _customer;
        public Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    _customer = IoC.Resolve<ICustomerRepository>().GetCustomer(CustomerId);
                }

                return _customer;
            }
        }

        private IEventRepository _eventRepository;
        private IEventRepository EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = IoC.Resolve<IEventRepository>());
            }
        }

        private IEventCustomerPackageTestDetailService _packageTestDetailService;
        private IEventCustomerPackageTestDetailService PackageTestDetailService
        {
            get
            {
                return _packageTestDetailService ?? (_packageTestDetailService = IoC.Resolve<IEventCustomerPackageTestDetailService>());
            }
        }

        private ICorporateAccountRepository _accountRepository;

        private ICorporateAccountRepository CorporateAccountRepository
        {
            get
            {
                return _accountRepository ?? (_accountRepository = IoC.Resolve<ICorporateAccountRepository>());
            }
        }

        private CorporateAccount _accountByEventId;

        private CorporateAccount AccountByEventId
        {
            get
            {
                if (_accountByEventId == null && EventId > 0)
                {
                    _accountByEventId = CorporateAccountRepository.GetbyEventId(EventId);
                }

                return _accountByEventId;
            }
        }

        private CorporateAccount _accountByTag;

        private CorporateAccount AccountByTag
        {
            get
            {
                if (_accountByTag == null && Customer != null && !string.IsNullOrEmpty(Customer.Tag))
                {
                    _accountByTag = CorporateAccountRepository.GetByTag(Customer.Tag);
                }

                return _accountByTag;
            }
        }

        public string QuestionIdAnswerTestId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.QuestionIdAnswerTestId : string.Empty;
            }
            set
            {
                RegistrationFlow.QuestionIdAnswerTestId = value;
            }
        }

        public string DisqualifiedTest
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.DisqualifiedTest : string.Empty;
            }
            set
            {
                RegistrationFlow.DisqualifiedTest = value;
            }
        }

        public bool IsRedirectNonMammoEvent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = true;
            SetPageTitles();
            CustomerHasMammoTest = CheckPreApprovedTest(TestGroup.BreastCancer);
            if (!IsPostBack)
            {
                BindZipRadiusDropdown();
                if (CustomerId > 0)
                {
                    BindEventSearchDropdown(Customer);
                }
                else
                {
                    //EventSearchTypeDropdownList.Visible = false;
                    pTypeFilter.Visible = false;
                }

                BindPageData();

                if (Request.UrlReferrer != null) ViewState["UrlReferer"] = Request.UrlReferrer.PathAndQuery;

                var callCenterDal = new CallCenterDAL();
                List<EScript> scripts = callCenterDal.GetScript(callCenterDal.GetScriptType("Event and Package Selection", 2)[0].ScriptTypeID.ToString(), 4);

                spEventScript.InnerText = scripts[0].ScriptText;

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId);
                }
            }
            else
            {
                var eventTargetName = Request.Params.Get("__EVENTTARGET");
                IsRedirectNonMammoEvent = false;
                if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "continueWithSelectedEvent")
                {
                    var orgUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    var previousEventId = Convert.ToInt64(hfPreviousEventId.Value);
                    if (previousEventId > 0)
                        IoC.Resolve<Falcon.App.Core.Medical.IEventCustomerQuestionAnswerService>().UpdatePreQualifiedTestAnswers(CustomerId, EventId, previousEventId, orgUserId);
                    SelectEvent();
                }
                if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "redirectNonMammoEvent")
                {
                    IsRedirectNonMammoEvent = true;
                    BindEventGrid();
                }

            }


            CallBackProspectSpan.Style.Add(HtmlTextWriterStyle.Display, EventRepository.CheckCustomerRegisteredForFutureEvent(CustomerId) ? "none" : "block");
        }

        private void SetPageTitles()
        {
            var masterPage = Master as CallCenter_CallCenterMaster1;

            if (masterPage != null)
            {
                masterPage.SetTitle("Search Events");
                masterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
                masterPage.hideucsearch();
            }
            Page.Title = "Search Events";
            StepTitleContainer.InnerText = CustomerType == CustomerType.Existing ? "Existing Customer" : "Register New Customer";
        }


        protected void BindPageData()
        {
            //SetCustomer();
            var zipCode = string.Empty;
            if (CustomerType == CustomerType.Existing)
            {
                if (Customer != null && Customer.Address != null && Customer.Address.ZipCode != null
                    && !string.IsNullOrEmpty(Customer.Address.ZipCode.Zip))
                {
                    zipCode = Customer.Address.ZipCode.Zip;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Zip"]))
                {
                    zipCode = Request.QueryString["Zip"];
                }
                else
                {
                    long prospectCustomerId = 0;
                    if (RegistrationFlow != null)
                        prospectCustomerId = RegistrationFlow.ProspectCustomerId;

                    if (prospectCustomerId > 0)
                    {
                        var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                        var prospectCustomer = prospectCustomerRepository.GetById(prospectCustomerId);

                        if (prospectCustomer != null && prospectCustomer.Address != null &&
                            prospectCustomer.Address.ZipCode != null
                            && !string.IsNullOrEmpty(prospectCustomer.Address.ZipCode.Zip))
                        {
                            zipCode = prospectCustomer.Address.ZipCode.Zip;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(zipCode))
            {
                txtZip.Text = zipCode;
                int zip = 0;
                if (Int32.TryParse(txtZip.Text, out zip))
                    BindEventGrid();
            }
        }

        private bool EventValidation()
        {
            if (EventCustomer != null && EventCustomer.AppointmentId.HasValue)
            {
                var packageTestDetail = PackageTestDetailService.GetEventPackageDetails(EventCustomer.Id);
                var eventData = EventRepository.GetEventOnlyById(EventId);
                var appointment = IoC.Resolve<IAppointmentRepository>().GetById(EventCustomer.AppointmentId.Value);

                if (packageTestDetail != null)
                {
                    var packageAndTest = packageTestDetail.Package != null ? packageTestDetail.Package.Name : string.Empty;
                    var additinalTest = packageTestDetail.Tests.IsNullOrEmpty() ? string.Empty : string.Join(",", packageTestDetail.Tests.Select(x => x.Name).ToArray());

                    packageAndTest = string.IsNullOrEmpty(packageAndTest)
                                         ? additinalTest
                                         : packageAndTest +
                                           (string.IsNullOrEmpty(additinalTest)
                                                ? string.Empty
                                                : ", " + additinalTest);

                    divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divErrorMsg.InnerHtml = Customer.NameAsString + " is already registered for this event (" + eventData.Name + " ) at " +
                                            eventData.EventDate.ToString("dddd dd MMMM yyyy") + " " +
                                            appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
                                            ". Duplicate registrations for the same customer are not allowed.";
                }

                return false;
            }

            var service = IoC.Resolve<IRefundRequestService>();
            var result = service.CheckifCancelAppointmentRequestExistsforaCustomer(EventId, CustomerId);
            if (result)
            {
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                divErrorMsg.InnerText = "Customer has cancelled the appointment for this event, the cancellation request is in process. Re-registration is not allowed unless the request is resolved.";
                return false;
            }

            return true;
        }

        protected void lnkSelectEvent_Click(object sender, EventArgs e)
        {
            var lnkEvent = (LinkButton)sender;

            EventId = Convert.ToInt64(lnkEvent.CommandArgument);

            if (!EventValidation())
            {
                EventId = 0;
                return;
            }

            if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
            {
                var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
                var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
                if (slots.Where(s => s.EventId != EventId).Any())
                {
                    eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
                    RegistrationFlow.AppointmentSlotIds = null;
                }
            }

            if (RegistrationFlow.PackageId > 0 && EventId > 0)
            {
                var eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
                var eventPackages = eventPackageRepository.GetPackagesForEventByRole(EventId, (long)CurrentRole);
                if (eventPackages.Any(p => p.PackageId != RegistrationFlow.PackageId))
                {
                    RegistrationFlow.PackageId = 0;
                    RegistrationFlow.TestIds = null;
                    RegistrationFlow.AddOnTestIds = null;
                }
            }

            if (CustomerId > 0)
            {
                hfCustomerID.Value = CustomerId.ToString();
                hidEventID.Value = EventId.ToString();
                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();

                var customer = Customer;
                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    bool showEligibilityPopup = customerEligibility != null && customerEligibility.IsEligible.HasValue &&
                                                customerEligibility.IsEligible.Value == false;

                    var eventTestRepository = IoC.Resolve<IEventTestRepository>();
                    var eventTests = eventTestRepository.GetEventTestsByEventIds(new[] { EventId });
                    var preQualificationTemplateIds = eventTests.Where(x => x.PreQualificationQuestionTemplateId.HasValue).Select(x => x.PreQualificationQuestionTemplateId.Value).ToArray();

                    var preQualificationTestTemplateRepository = IoC.Resolve<IPreQualificationTestTemplateRepository>();
                    var preQualificationTestTemplates = preQualificationTestTemplateRepository.GetByIds(preQualificationTemplateIds);

                    var selectedTemplateIds = new List<long>(); //preQualificationTestTemplates.Select(x => x.TestId).ToArray();
                    foreach (var preQualificationTestTemplate in preQualificationTestTemplates)
                    {
                        if (CheckPreApprovedTest(new[] { preQualificationTestTemplate.TestId }))
                        {
                            selectedTemplateIds.Add(preQualificationTestTemplate.Id);
                        }
                    }

                    hfTemplateIds.Value = string.Join(",", selectedTemplateIds);

                    var eventCustomerQuestionAnswerService = IoC.Resolve<IEventCustomerQuestionAnswerService>();
                    hfQuestionIdAnswerTestId.Value = eventCustomerQuestionAnswerService.GetQuestionAnswerTestIdString(CustomerId, EventId);

                    var returningCustomer = IsSameYearReturningCustomer(customer, EventId);

                    var corporateAccount = AccountByEventId;

                    if (corporateAccount == null || string.IsNullOrEmpty(corporateAccount.Tag))
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a " + customer.Tag + " member for a retail event.  This is NOT ALLOWED. Please contact administrator.";

                        //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','','" + showEligibilityPopup + "','" + returningCustomer + "');", true);
                    }
                    else if (customer.Tag != corporateAccount.Tag)
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a " + customer.Tag + " member for a " + corporateAccount.Tag + " event.  This is NOT ALLOWED. Please contact administrator.";

                        //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','" + corporateAccount.Tag + "','" + showEligibilityPopup + "','" + returningCustomer + "','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);  
                    }
                    else if (customer.Tag == corporateAccount.Tag && customerEligibility != null &&
                             customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning",
                            "showCustomerNotEligibleWarning('" + returningCustomer + "');", true);
                    else if (customer.Tag == corporateAccount.Tag && returningCustomer)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning",
                            "showSameYearReturningCustomerWarning();", true);
                    else if (selectedTemplateIds.Any())
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_getPreQualificationQuestion",
                            "getPreQualificationQuestion('" + string.Join(",", selectedTemplateIds) + "');", true);
                    }
                    else
                        SelectEvent();
                }
                else
                {
                    var corporateAccount = AccountByEventId;

                    if (corporateAccount != null && !corporateAccount.AllowRegistrationWithImproperTags)
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a retail customer for a " + corporateAccount.Tag + " event.  This is NOT ALLOWED. Please contact administrator.";
                    }
                    else if (corporateAccount != null && corporateAccount.AllowRegistrationWithImproperTags)
                    {
                        bool showEligibilityPopup = customerEligibility != null && customerEligibility.IsEligible.HasValue &&
                                                customerEligibility.IsEligible.Value == false;

                        var returningCustomer = IsSameYearReturningCustomer(customer, EventId);

                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','" + corporateAccount.Tag + "','" + showEligibilityPopup + "','" + returningCustomer + "','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);
                    }
                    else if (customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning", "showCustomerNotEligibleWarning(false);", true);
                    }
                    else
                    {
                        SelectEvent();
                    }
                }

            }
            else
            {
                SelectEvent();
            }

        }

        public bool IsSameYearReturningCustomer(Core.Users.Domain.Customer customer, long eventId)
        {
            if (AccountByTag == null || !AccountByTag.IsHealthPlan) return false;

            return EventRepository.IsCustomerRegisterForCurrentEvent(customer.CustomerId, eventId);
        }


        private void SelectEvent()
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=Existing&Call=No&CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                else
                    Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=New&Call=No&FirstName=" + FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);
            }
            else
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=Existing&CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                else
                    Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=New&FirstName=" + FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + txtZip.Text + "&guid=" + GuId);
            }
        }
        protected void lnkEventName_Click(object sender, EventArgs e)
        {
            var dtEvent = ViewState["Event"] as DataTable;

            if (dtEvent != null)
            {
                switch (CurrentSortDirection)
                {
                    case SortDirection.Ascending:
                        CurrentSortExpression = "Name";
                        dtEvent.DefaultView.Sort = CurrentSortExpression + " desc";
                        CurrentSortDirection = SortDirection.Descending;
                        break;
                    case SortDirection.Descending:
                        CurrentSortExpression = "Name";
                        dtEvent.DefaultView.Sort = CurrentSortExpression + " asc";
                        CurrentSortDirection = SortDirection.Ascending;
                        break;
                }
                dtEvent = dtEvent.DefaultView.ToTable();

                dgEvent.DataSource = dtEvent;
                dgEvent.DataBind();

                ViewState["Event"] = dtEvent;
            }
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            hfIsSearchNonMammoEvent.Value = "No";
            hfPreviousEventId.Value = "0";
            BindEventGrid();
        }

        protected void dgEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgEvent.PageIndex = e.NewPageIndex;
            dgEvent.DataSource = (DataTable)ViewState["Event"];
            dgEvent.DataBind();
        }

        protected void dgEvent_Sorting(object sender, GridViewSortEventArgs e)
        {
            var dtEvent = ViewState["Event"] as DataTable;

            if (dtEvent != null)
            {
                if (e.SortExpression != CurrentSortExpression)
                {
                    dtEvent.DefaultView.Sort = e.SortExpression + " asc";
                    CurrentSortDirection = SortDirection.Ascending;
                }
                else
                {
                    switch (CurrentSortDirection)
                    {
                        case SortDirection.Ascending:
                            dtEvent.DefaultView.Sort = e.SortExpression + " desc";
                            CurrentSortDirection = SortDirection.Descending;
                            break;
                        case SortDirection.Descending:
                            dtEvent.DefaultView.Sort = e.SortExpression + " asc";
                            CurrentSortDirection = SortDirection.Ascending;
                            break;
                    }
                }

                CurrentSortExpression = e.SortExpression;
                dtEvent = dtEvent.DefaultView.ToTable();

                dgEvent.DataSource = dtEvent;
                dgEvent.DataBind();

                ViewState["Event"] = dtEvent;
            }
        }

        public bool CustomerHasMammoTest { get; set; }

        private void BindEventGrid()
        {
            IConfigurationSettingRepository configurationSettingRepository = new ConfigurationSettingRepository();
            string distanceFromZip = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.Eventdistance);
            bool onlyMammoEvents = false;

            if (Convert.ToInt32(ZipRadius.SelectedValue) > 0)
                distanceFromZip = ZipRadius.SelectedValue;
            var tag = string.Empty;

            if (CustomerId > 0 && (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.HealthPlan.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Corporate.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString()))
            {
                tag = Customer.Tag;

                if (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString())
                {
                    onlyMammoEvents = true;
                }
            }

            ViewState["SortExp"] = string.IsNullOrEmpty(txtZip.Text) ? "Name" : "Distance";
            var eventService = IoC.Resolve<IEventService>();

            if (CustomerHasMammoTest && !IsRedirectNonMammoEvent)
            {
                onlyMammoEvents = true;
            }
            var searchAllevents = false;
            if (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.All.ToString())
            {
                searchAllevents = true;
            }
            long? ProductTypeId = null;
            if (Customer != null && CustomerId > 0)
            {
                ProductTypeId = Customer.ProductTypeId;
            }
            if (CustomerType == CustomerType.Existing && ProductTypeId == null)
            {
                dbsearch.Visible = false;
                dbsearch.Style["display"] = string.Empty;

                divNoRecord.Visible = true;
                divNoRecord.Style["display"] = "";

                dgEvent.Visible = false;
                dvSearchResult1.InnerText = "";
                dvSearchResult.InnerText = "";
                return;
            }
            var events = eventService.GetEventHostViewData(ViewType.CallCenterRep, txtState.Text, txtCity.Text, txtInvitationCodeSearch.Text.Trim(), txtZip.Text, Convert.ToInt32(distanceFromZip),
                                                           txtFrom.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtFrom.Text) : null, txtTo.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtTo.Text) : null, 0,
                                                           CurrentRole == Roles.CallCenterRep, tag: tag, hasMammo: onlyMammoEvents, allEvents: searchAllevents, ProductType: ProductTypeId); //, customerId: CustomerId

            DataTable eventTable = GetEventTableColumns();

            if (events != null && !events.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(txtInvitationCodeSearch.Text.Trim()))
                {
                    ViewState["InvitationCode"] = txtInvitationCodeSearch.Text.Trim();
                }
                else
                {
                    ViewState["InvitationCode"] = null;
                }

                string googleAddressVerified = string.Empty;
                foreach (var eventHostViewData in events)
                {
                    string addressMultiLine = CommonCode.AddressMultiLine(eventHostViewData.StreetAddressLine1, eventHostViewData.StreetAddressLine2, eventHostViewData.City, eventHostViewData.State, eventHostViewData.Zip);

                    string googleMap = CommonCode.GetGoogleMapAddress(eventHostViewData.StreetAddressLine1, eventHostViewData.City, eventHostViewData.State, eventHostViewData.Zip, eventHostViewData.Latitude + "," + eventHostViewData.Longitude,
                                                                      eventHostViewData.UseLatitudeAndLongitudeForMapping);
                    googleAddressVerified = string.Empty;

                    if (eventHostViewData.GoogleAddressVerifiedBy.HasValue)
                    {
                        googleAddressVerified = GetAddressVerifiedUser(eventHostViewData.GoogleAddressVerifiedBy.Value);
                        if (string.IsNullOrEmpty(googleAddressVerified)) googleAddressVerified = "Address Not Verified" + CommonCode.GetGoogleAddressNotVerifiedJtip();
                    }

                    string eventType = string.Empty;

                    if (!string.IsNullOrEmpty(eventHostViewData.EventType))
                    {
                        eventType = eventHostViewData.EventType.Trim().Equals("Public") ? "<img src='/App/Images/public-icon.gif' title='Public Event' />" : "<img src='/App/Images/private-icon.gif' title='Private Event' style='padding:0px 5px 0px 0px;' />";
                    }

                    bool slotsAvailable = true;
                    bool noSlotsAvailable = true;
                    bool suspended = true;
                    bool cancelled = true;

                    switch (eventHostViewData.EventStatus)
                    {
                        case "Suspended":
                            slotsAvailable = false;
                            noSlotsAvailable = false;
                            cancelled = false;
                            break;
                        case "Canceled":
                            slotsAvailable = false;
                            noSlotsAvailable = false;
                            suspended = false;
                            break;
                        default:
                            suspended = false;
                            cancelled = false;
                            if (eventHostViewData.AvailableAppointmentSlots.HasValue && eventHostViewData.AvailableAppointmentSlots.Value > 0)
                                noSlotsAvailable = false;
                            else
                                slotsAvailable = false;
                            break;
                    }

                    eventTable.Rows.Add
                        (
                            new object[]
                                {
                                    eventHostViewData.EventId, eventHostViewData.Name,
                                    eventHostViewData.EventDate, eventHostViewData.PodNames(),
                                    eventHostViewData.OrganizationName, addressMultiLine,
                                    eventHostViewData.DistanceFromZip,
                                    eventHostViewData.IsDynamicScheduling.HasValue && eventHostViewData.IsDynamicScheduling.Value
                                        ? "Dynamic Scheduling"
                                        : eventHostViewData.AvailableAppointmentSlots + "/" + eventHostViewData.TotalAppointmentSlots,
                                    googleMap, slotsAvailable, noSlotsAvailable, eventHostViewData.EventType, eventType,
                                    suspended, cancelled, eventHostViewData.EventNotes,
                                    eventHostViewData.EventStatus, googleAddressVerified,
                                    eventHostViewData.HasBreastCancerTest.HasValue && eventHostViewData.HasBreastCancerTest.Value,
                                    eventHostViewData.IsDynamicScheduling.HasValue && eventHostViewData.IsDynamicScheduling.Value, eventHostViewData.IsFemaleOnly,eventHostViewData.SponseredBy
                                    ,eventHostViewData.AllowNonMammoPatients
                                });
                }
            }

            if (eventTable.Rows.Count > 0)
            {
                ViewState["Event"] = eventTable;
                dgEvent.DataSource = eventTable;

                dgEvent.Visible = true;
                dgEvent.DataBind();
                dvSearchResult1.InnerText = "Total: ";
                dvSearchResult.InnerText = eventTable.Rows.Count + " Result found";

                divNoRecord.Visible = false;
                divNoRecord.Style["display"] = "";

                dbsearch.Visible = true;
                dbsearch.Style["display"] = string.Empty;

            }
            else
            {
                dbsearch.Visible = false;
                dbsearch.Style["display"] = string.Empty;

                divNoRecord.Visible = true;
                divNoRecord.Style["display"] = "";

                dgEvent.Visible = false;
                dvSearchResult1.InnerText = "";
                dvSearchResult.InnerText = "";
            }
        }

        private static DataTable GetEventTableColumns()
        {
            var eventTable = new DataTable();
            eventTable.Columns.Add("Id");
            eventTable.Columns.Add("Name");
            eventTable.Columns.Add("Date", typeof(DateTime));
            eventTable.Columns.Add("Pods");
            eventTable.Columns.Add("Host");
            eventTable.Columns.Add("Address");
            eventTable.Columns.Add("Distance", typeof(Decimal));
            eventTable.Columns.Add("Slots");
            eventTable.Columns.Add("GoogleMap");
            eventTable.Columns.Add("IsSlotsAvailable", typeof(bool));
            eventTable.Columns.Add("IsNoSlotsAvailable", typeof(bool));
            eventTable.Columns.Add("EventType");
            eventTable.Columns.Add("EventTypeImage");
            eventTable.Columns.Add("TempUnavailable", typeof(bool));
            eventTable.Columns.Add("Cancelled", typeof(bool));
            eventTable.Columns.Add("EventNotes");
            eventTable.Columns.Add("EventStatus");
            eventTable.Columns.Add("GoogleAddressVerified");
            eventTable.Columns.Add("HasBreastCancer", typeof(bool));
            eventTable.Columns.Add("IsDynamicScheduling", typeof(bool));
            eventTable.Columns.Add("IsFemaleOnly", typeof(bool));
            eventTable.Columns.Add("SponseredBy");
            eventTable.Columns.Add("AllowNonMammoPatients", typeof(bool));
            return eventTable;
        }

        protected void dgEvent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    var selectEventLink = e.Row.FindControl("lnkSelectEvent") as LinkButton;
                    if (selectEventLink != null)
                    {
                        var eventIdSpan = e.Row.FindControl("spnEventID") as HtmlContainerControl;
                        var eventTypeSpan = e.Row.FindControl("spnEventType") as HtmlContainerControl;

                        if (eventIdSpan != null && eventTypeSpan != null && !string.IsNullOrEmpty(eventTypeSpan.InnerHtml.Trim()) && eventTypeSpan.InnerHtml.Trim().Equals("Private"))
                        {
                            if (ViewState["InvitationCode"] == null)
                                selectEventLink.Attributes.Add("onclick",
                                                               "return SelectEvent(" + eventIdSpan.InnerHtml.Trim() +
                                                               ",'" +
                                                               eventTypeSpan.InnerHtml.Trim() + "');");
                        }
                    }
                    break;
            }
        }

        protected void ibtnVerifyInvitation_Click(object sender, ImageClickEventArgs e)
        {
            // verifiy events
            long eventId = 0;
            if (!string.IsNullOrEmpty(hidEventID.Value))
            {
                eventId = Convert.ToInt64(hidEventID.Value);
                EventId = eventId;
            }
            var invitationCode = txtInvitationCode.Text.Trim();

            if (!EventRepository.ValidateInvitationCode(EventId, invitationCode))
            {
                divErrorMsg.InnerHtml = "You had enter the wrong invitation code.<br> Please enter correct invitation code and try again.";
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }

            if (!EventValidation())
                return;

            if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
            {
                var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
                var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
                if (slots.Where(s => s.EventId != EventId).Any())
                {
                    eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
                    RegistrationFlow.AppointmentSlotIds = null;
                }

            }

            if (CustomerId > 0)
            {
                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();

                var customer = Customer;
                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);
                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    bool showEligibilityPopup = customerEligibility != null && customerEligibility.IsEligible.HasValue &&
                                                customerEligibility.IsEligible.Value == false;
                    var returningCustomer = IsSameYearReturningCustomer(customer, EventId);

                    var corporateAccount = AccountByEventId;

                    if (corporateAccount == null || string.IsNullOrEmpty(corporateAccount.Tag))
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a " + customer.Tag + " member for a retail event.  This is NOT ALLOWED. Please contact administrator.";

                        //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','','" + showEligibilityPopup + "','" + returningCustomer + "');", true);
                    }
                    else if (customer.Tag != corporateAccount.Tag)
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a " + customer.Tag + " member for a " + corporateAccount.Tag + " event.  This is NOT ALLOWED. Please contact administrator.";

                        //Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','" + corporateAccount.Tag + "','" + showEligibilityPopup + "','" + returningCustomer + "','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);  
                    }
                    else if (customer.Tag == corporateAccount.Tag && customerEligibility != null &&
                             customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning",
                            "showCustomerNotEligibleWarning('" + returningCustomer + "');", true);
                    else if (customer.Tag == corporateAccount.Tag && returningCustomer)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning",
                            "showSameYearReturningCustomerWarning();", true);
                    else
                        SelectEvent();
                }
                else
                {
                    var corporateAccount = AccountByEventId;

                    if (corporateAccount != null && !corporateAccount.AllowRegistrationWithImproperTags)
                    {
                        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                        divErrorMsg.InnerHtml = "You are scheduling a retail customer for a " + corporateAccount.Tag + " event.  This is NOT ALLOWED. Please contact administrator.";
                    }
                    else if (corporateAccount != null && corporateAccount.AllowRegistrationWithImproperTags)
                    {
                        bool showEligibilityPopup = customerEligibility != null && customerEligibility.IsEligible.HasValue &&
                                                customerEligibility.IsEligible.Value == false;

                        var returningCustomer = IsSameYearReturningCustomer(customer, EventId);

                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + customer.Tag + "','" + corporateAccount.Tag + "','" + showEligibilityPopup + "','" + returningCustomer + "','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);
                    }
                    else if (customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning", "showCustomerNotEligibleWarning(false);", true);
                    }
                    else
                    {
                        SelectEvent();
                    }
                }
            }
            else
            {
                SelectEvent();
            }

        }

        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {
            var commonCode = new CommonCode();
            commonCode.EndCCRepCall(this.Page);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=" + CustomerType + "&Action=Back&Call=No" + "&guid=" + GuId);
            else
                Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/ExistingCustomer.aspx?CustomerType=" + CustomerType + "&Action=Back" + "&guid=" + GuId);

        }

        private string GetAddressVerifiedUser(long organizationRoleUserId)
        {
            string userName = string.Empty;
            if (organizationRoleUserId > 0)
            {
                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
                var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);
                if (organizationRoleUser != null)
                {
                    IUserRepository<Core.Users.Domain.Customer> userRepository =
                           new UserRepository<Core.Users.Domain.Customer>();
                    var user = userRepository.GetUser(organizationRoleUser.UserId);
                    if (user != null)
                    {
                        userName = "Address Verified By " + user.Name.FullName;
                    }
                }
            }
            return userName;
        }

        protected void EventRequestLBtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/EventRequest.aspx?CustomerType=Existing&Call=No&CustomerID=" +
                        Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                else
                    Response.RedirectUser(
                        "/App/CallCenter/CallCenterRep/ExistingCustomer/EventRequest.aspx?CustomerType=New&Call=No&FirstName=" +
                        FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);
            }
            else
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/EventRequest.aspx?CustomerType=Existing&CustomerID=" +
                        Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                else
                    Response.RedirectUser(
                        "/App/CallCenter/CallCenterRep/ExistingCustomer/EventRequest.aspx?CustomerType=New&FirstName=" +
                        FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + txtZip.Text + "&guid=" + GuId);

            }
        }

        private bool CheckPreApprovedTest(IEnumerable<long> testIdsToCheck)
        {
            var preApprovedTestRepository = IoC.Resolve<IPreApprovedTestRepository>();
            return preApprovedTestRepository.CheckPreApprovedTestForCustomer(CustomerId, testIdsToCheck);
        }

        private void BindEventSearchDropdown(Core.Users.Domain.Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Tag) && !CustomerHasMammoTest)
            {
                EventSearchTypeDropdownList.Items.Clear();
                pTypeFilter.Visible = false;
                return;
            }

            var filterTypes = new List<OrderedPair<string, string>> { new OrderedPair<string, string>(EventSearchFilterType.All.ToString(), EventSearchFilterType.All.GetDescription()) };
            var selectedValue = EventSearchFilterType.All.ToString();

            if (!string.IsNullOrEmpty(customer.Tag))
            {
                if (AccountByTag != null)
                {
                    if (AccountByTag.IsHealthPlan)
                    {
                        filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.HealthPlan.ToString(), EventSearchFilterType.HealthPlan.GetDescription()));
                        selectedValue = EventSearchFilterType.HealthPlan.ToString();
                    }
                    else
                    {
                        filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.Corporate.ToString(), EventSearchFilterType.Corporate.GetDescription()));
                        selectedValue = EventSearchFilterType.Corporate.ToString();
                    }
                }
            }

            //if (CustomerHasMammoTest)
            //{
            //    filterTypes.Add(new OrderedPair<string, string>(EventSearchFilterType.Mammo.ToString(), EventSearchFilterType.Mammo.GetDescription()));
            //    selectedValue = EventSearchFilterType.Mammo.ToString();
            //}

            EventSearchTypeDropdownList.Items.Clear();
            EventSearchTypeDropdownList.DataSource = filterTypes;
            EventSearchTypeDropdownList.DataTextField = "SecondValue";
            EventSearchTypeDropdownList.DataValueField = "FirstValue";
            EventSearchTypeDropdownList.SelectedValue = selectedValue;
            EventSearchTypeDropdownList.DataBind();
        }

        private void BindZipRadiusDropdown()
        {
            var zipRadius = Core.Geo.Enum.ZipRadius.FiveMiles.GetNameValuePairs().OrderBy(x => x.FirstValue);
            ZipRadius.DataSource = zipRadius;
            ZipRadius.DataTextField = "SecondValue";
            ZipRadius.DataValueField = "FirstValue";
            ZipRadius.DataBind();
            ZipRadius.Items.Insert(0, new ListItem("-- Miles --", "0"));
        }
    }
}