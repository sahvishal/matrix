using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.UI.App.Common.RegisterCustomer
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

        protected long CustomerId
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
            { RegistrationFlow.EventId = value; }
        }

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Customer"]))
                {
                    switch (Request.QueryString["Customer"])
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

        private IEventRepository _eventRepository;
        private IEventRepository EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = IoC.Resolve<IEventRepository>());
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

        private IEventCustomerPackageTestDetailService _packageTestDetailService;
        private IEventCustomerPackageTestDetailService PackageTestDetailService
        {
            get
            {
                return _packageTestDetailService ?? (_packageTestDetailService = IoC.Resolve<IEventCustomerPackageTestDetailService>());
            }
        }

        public bool CustomerHasMammoTest { get; set; }
        public bool IsRedirectNonMammoEvent { get; set; }

        #region Evnets
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitles();
            CustomerHasMammoTest = CheckPreApprovedTest(TestGroup.BreastCancer);
            if (!IsPostBack)
            {
                SetIntialValues();

                var callCenterDal = new CallCenterDAL();
                var listScriptType = callCenterDal.GetScriptType("Event and Package Selection", 2);
                var objEventScript = callCenterDal.GetScript(listScriptType[0].ScriptTypeID.ToString(), 4);
                spEventScript.InnerText = objEventScript[0].ScriptText;

                if (CustomerId > 0)
                {
                    BindEventSearchDropdown(Customer);
                }
                else
                {
                    EventSearchTypeDropdownList.Visible = false;
                    EventSearchTypeDropdownList.Visible = false;
                }

                SearchEvent();
            }
            else
            {
                IsRedirectNonMammoEvent = false;
                var eventTargetName = Request.Params.Get("__EVENTTARGET");
                if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "continueWithWarning")
                {
                    var orgUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    var previousEventId = Convert.ToInt64(hfPreviousEventId.Value);
                    if (previousEventId > 0)
                        IoC.Resolve<Falcon.App.Core.Medical.IEventCustomerQuestionAnswerService>().UpdatePreQualifiedTestAnswers(CustomerId, EventId, previousEventId, orgUserId);
                    SelectPackage();
                }
                if (!string.IsNullOrEmpty(eventTargetName) && eventTargetName == "redirectNonMammoEvent")
                {
                    IsRedirectNonMammoEvent = true;
                    SearchEvent();
                }
            }

          
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

            if (CustomerId > 0)
            {
                hfCustomerID.Value = CustomerId.ToString();
                hidEventID.Value = EventId.ToString();

                var customerEligibilityRepository = IoC.Resolve<ICustomerEligibilityRepository>();

                var customerEligibility = customerEligibilityRepository.GetByCustomerIdAndYear(Customer.CustomerId, DateTime.Today.Year);
                
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

                if (!string.IsNullOrEmpty(Customer.Tag))
                {
                    bool showEligibilityPopup = customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false;

                    if (AccountByEventId == null || string.IsNullOrEmpty(AccountByEventId.Tag))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + Customer.Tag + "','','" + showEligibilityPopup + "');", true);
                    else if (Customer.Tag != AccountByEventId.Tag)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + Customer.Tag + "','" + AccountByEventId.Tag + "','" + showEligibilityPopup + "','" + AccountByEventId.AllowRegistrationWithImproperTags + "');", true);
                    else if (Customer.Tag == AccountByEventId.Tag && customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning", "showCustomerNotEligibleWarning();", true);
                    else if (selectedTemplateIds.Any())
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_getPreQualificationQuestion",
                            "getPreQualificationQuestion('" + string.Join(",", selectedTemplateIds) + "');", true);
                    }
                    else if (Customer.Tag == AccountByEventId.Tag)
                        SelectPackage();
                }
                else if (customerEligibility != null && customerEligibility.IsEligible.HasValue && customerEligibility.IsEligible.Value == false)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "js_showCustomerNotEligibleWarning", "showCustomerNotEligibleWarning();", true);
                }
                else if (selectedTemplateIds.Any())
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "js_getPreQualificationQuestion",
                        "getPreQualificationQuestion('" + string.Join(",", selectedTemplateIds) + "');", true);
                }
                else
                {
                    SelectPackage();
                }
            }
            else
            {
                SelectPackage();
            }

        }


        private void SelectPackage()
        {
            if (CustomerType == CustomerType.Existing)
            {
                Response.RedirectUser("SelectPackage.aspx?Customer=Existing" + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("SelectPackage.aspx?guid=" + GuId);
            }
        }
        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            hfIsSearchNonMammoEvent.Value = "No";
            hfPreviousEventId.Value = "0";
            SearchEvent();
        }

        protected void ibtnVerifyInvitation_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(hidEventID.Value))
            {
                EventId = Convert.ToInt64(hidEventID.Value);
            }
            if (!ValidateInvitationCode) return;

            if (!EventValidation()) return;

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
                if (!string.IsNullOrEmpty(Customer.Tag))
                {
                    var corporateAccount = AccountByEventId;
                    if (corporateAccount == null || string.IsNullOrEmpty(corporateAccount.Tag))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + Customer.Tag + "','');", true);
                    else if (Customer.Tag != corporateAccount.Tag)
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_showTagChangeWarning", "showTagChangeWarning('" + Customer.Tag + "','" + corporateAccount.Tag + "','','" + corporateAccount.AllowRegistrationWithImproperTags + "');", true);
                    else if (Customer.Tag == corporateAccount.Tag)
                        SelectPackage();
                }
                else
                {
                    SelectPackage();
                }
            }
            else
            {
                SelectPackage();
            }
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

        protected void lnkEventName_Click(object sender, EventArgs e)
        {
            var dtEvent = (DataTable)ViewState["Event"];

            if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
            {
                ViewState["SortExp"] = "Name";
                dtEvent.DefaultView.Sort = ViewState["SortExp"] + " desc";
                ViewState["SortDir"] = SortDirection.Descending;
            }
            else
            {
                ViewState["SortExp"] = "Name";
                dtEvent.DefaultView.Sort = ViewState["SortExp"] + " asc";
                ViewState["SortDir"] = SortDirection.Ascending;
            }
            dtEvent = dtEvent.DefaultView.ToTable();

            dgEvent.DataSource = dtEvent;
            dgEvent.DataBind();

            ViewState["Event"] = dtEvent;
        }

        protected void dgEvent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.FindControl("lnkSelectEvent") != null)
                {
                    var lnkSelectEvent = (LinkButton)e.Row.FindControl("lnkSelectEvent");
                    var spnEventId = (HtmlContainerControl)e.Row.FindControl("spnEventID");
                    var spnEventType = (HtmlContainerControl)e.Row.FindControl("spnEventType");
                    if (spnEventType != null && spnEventType.InnerHtml.Trim() != "")
                    {
                        if (spnEventType.InnerHtml.Trim().Equals("Private"))
                        {
                            if (ViewState["InvitationCode"] == null || (string)ViewState["InvitationCode"] == "")
                                lnkSelectEvent.Attributes.Add("onclick", "return SelectEvent(" + spnEventId.InnerHtml.Trim() + ",'" + spnEventType.InnerHtml.Trim() + "');");
                        }
                    }
                }
            }
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"] == "Existing")
            {
                Response.RedirectUser("RegisterCustomer.aspx?Action=Back&Customer=Existing" + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("RegisterCustomer.aspx?Action=Back" + "&guid=" + GuId);
            }
        }

        #endregion

        #region Methods
        private void SearchEvent()
        {
            IConfigurationSettingRepository configurationSettingRepository = new ConfigurationSettingRepository();
            string strDistance = configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.Eventdistance);

            string zipCode = string.Empty;
            int zip = 0;
            if (Int32.TryParse(txtZip.Text, out zip))
                zipCode = zip.ToString();
            var tag = string.Empty;
            var hasMammo = false;

            if (CustomerId > 0 && (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.HealthPlan.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Corporate.ToString() || EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString()))
            {
                tag = Customer.Tag;

                if (EventSearchTypeDropdownList.SelectedValue == EventSearchFilterType.Mammo.ToString())
                {
                    hasMammo = true;
                }
            }

            if (CustomerHasMammoTest && !IsRedirectNonMammoEvent)
            {
                hasMammo = true;
            }
            long? ProductTypeId = null;
            if(Customer!=null && CustomerId>0)
            {
                ProductTypeId = Customer.ProductTypeId;
            }
            if (CustomerType == CustomerType.Existing && ProductTypeId==null)
            {
                dbsearch.Visible = false;
                dbsearch.Style["display"] = "";

                divNoRecord.Visible = true;
                divNoRecord.Style["display"] = "";

                dgEvent.Visible = false;
                dvSearchResult1.InnerText = "";
                dvSearchResult.InnerText = "";
                return;
            }
            var eventService = IoC.Resolve<IEventService>();
            var events = eventService.GetEventHostViewData(ViewType.Technician, txtState.Text, txtCity.Text, txtInvitationCodeSearch.Text, zipCode, Convert.ToInt32(strDistance), txtFrom.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtFrom.Text) : null,
                                                           txtTo.Text.Length > 0 ? (DateTime?)Convert.ToDateTime(txtTo.Text) : null, 0, CurrentRole == Roles.CallCenterRep, tag: tag, hasMammo: hasMammo, ProductType: ProductTypeId);

            var tbltemp = new DataTable();
            tbltemp.Columns.Add("Id");
            tbltemp.Columns.Add("Name");
            tbltemp.Columns.Add("Date", typeof(DateTime));
            tbltemp.Columns.Add("Host");
            tbltemp.Columns.Add("Address");
            tbltemp.Columns.Add("Distance", typeof(Decimal));
            tbltemp.Columns.Add("Slots");
            tbltemp.Columns.Add("GoogleMap");
            tbltemp.Columns.Add("EventType");
            tbltemp.Columns.Add("EventTypeImage");
            tbltemp.Columns.Add("GoogleAddressVerified");
            tbltemp.Columns.Add("HasBreastCancer", typeof(bool));
            tbltemp.Columns.Add("AllowNonMammoPatients", typeof(bool));

            if (events != null && events.Count > 0)
            {
                if (!string.IsNullOrEmpty(txtInvitationCodeSearch.Text))
                {
                    ViewState["InvitationCode"] = txtInvitationCodeSearch.Text;
                }
                else
                {
                    ViewState["InvitationCode"] = null;
                }
                string googleAddressVerified = string.Empty;

                foreach (var eventHostViewData in events)
                {
                    string strAddress = eventHostViewData.StreetAddressLine1 + "<br />" + eventHostViewData.City + "," +
                                        eventHostViewData.State + "," + eventHostViewData.Zip;

                    googleAddressVerified = string.Empty;

                    if (eventHostViewData.GoogleAddressVerifiedBy.HasValue)
                    {
                        googleAddressVerified = GetAddressVerifiedUser(eventHostViewData.GoogleAddressVerifiedBy.Value);
                        if (string.IsNullOrEmpty(googleAddressVerified)) googleAddressVerified = "Address Not Verified" + CommonCode.GetGoogleAddressNotVerifiedJtip();
                    }
                    //string strGoogleMap = eventHostViewData.StreetAddressLine1 + "," + eventHostViewData.City + "," + eventHostViewData.State + "," + eventHostViewData.Zip;
                    string strGoogleMap = CommonCode.GetGoogleMapAddress(eventHostViewData.StreetAddressLine1,
                                                                     eventHostViewData.City, eventHostViewData.State,
                                                                     eventHostViewData.Zip,
                                                                     eventHostViewData.Latitude + "," +
                                                                     eventHostViewData.Longitude,
                                                                     eventHostViewData.
                                                                         UseLatitudeAndLongitudeForMapping);

                    string strEventType = string.Empty;

                    if (eventHostViewData.EventType != "")
                    {
                        strEventType = eventHostViewData.EventType.Trim().Equals("Public") ? "<img src='/App/Images/public-icon.gif' title='Public Event' />" : "<img src='/App/Images/private-icon.gif' title='Private Event' style='padding:0px 5px 0px 0px;' />";
                    }
                    tbltemp.Rows.Add(new object[]
                                         {
                                             eventHostViewData.EventId, eventHostViewData.Name,
                                             eventHostViewData.EventDate.ToShortDateString(),
                                             eventHostViewData.OrganizationName, strAddress,
                                             eventHostViewData.DistanceFromZip,
                                             eventHostViewData.IsDynamicScheduling.HasValue &&
                                             eventHostViewData.IsDynamicScheduling.Value
                                                 ? "Dynamic Scheduling"
                                                 : eventHostViewData.AvailableAppointmentSlots + "/" + eventHostViewData.TotalAppointmentSlots,
                                             strGoogleMap,
                                             eventHostViewData.EventType, strEventType, googleAddressVerified,
                                             eventHostViewData.HasBreastCancerTest.HasValue && eventHostViewData.HasBreastCancerTest.Value
                                              ,eventHostViewData.AllowNonMammoPatients
                                         });
                }
            }
            if (tbltemp.Rows.Count > 0)
            {

                ViewState["Event"] = tbltemp;
                dgEvent.DataSource = tbltemp;

                dgEvent.Visible = true;
                dgEvent.DataBind();
                dvSearchResult1.InnerText = "Total: ";
                dvSearchResult.InnerText = tbltemp.Rows.Count + " Result found";

                divNoRecord.Visible = false;
                divNoRecord.Style["display"] = "";

                dbsearch.Visible = true;
                dbsearch.Style["display"] = "";
            }
            else
            {
                dbsearch.Visible = false;
                dbsearch.Style["display"] = "";

                divNoRecord.Visible = true;
                divNoRecord.Style["display"] = "";

                dgEvent.Visible = false;
                dvSearchResult1.InnerText = "";
                dvSearchResult.InnerText = "";

            }
        }

        private void SetTitles()
        {
            var obj = (Franchisee_Technician_TechnicianMaster)Master;

            obj.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";
            if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"] == "Existing")
            {
                obj.settitle("Existing Customer");
                dvTitle.InnerText = "Technician Existing Customer";
            }
            else
            {
                imgSymbol.Src = "../../Images/CCRep/page2symbol.gif";
                obj.settitle("Register New Customer");
                dvTitle.InnerText = "Technician Register Customer";
            }

            Page.Title = "Search Events";
        }

        private void SetIntialValues()
        {
            EventId = 0;
            if (CustomerId > 0)
            {
                txtState.Text = Customer.Address.State;
                txtCity.Text = Customer.Address.City;
                txtZip.Text = Customer.Address.ZipCode.Zip;
            }
            ViewState["SortExp"] = txtZip.Text == string.Empty ? "Name" : "Distance";
            ViewState["SortDir"] = SortDirection.Ascending;
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

                    packageAndTest = string.IsNullOrEmpty(packageAndTest) ? additinalTest : packageAndTest + (string.IsNullOrEmpty(additinalTest) ? string.Empty : ", " + additinalTest);

                    divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divErrorMsg.InnerHtml = Customer.NameAsString + " is already registered for this event (" + eventData.Name + " ) at " +
                                            eventData.EventDate.ToString("dddd dd MMMM yyyy") + " " + appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
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

        private bool ValidateInvitationCode
        {
            get
            {
                if (!EventRepository.ValidateInvitationCode(EventId, txtInvitationCode.Text.Trim()))
                {
                    divErrorMsg.InnerHtml = "You had enter the wrong invitation code.<br> Please enter correct invitation code and try again.";
                    divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                    return false;
                }
                return true;
            }
        }

        private string GetAddressVerifiedUser(long organizationRoleUserId)
        {
            string userName = string.Empty;
            if (organizationRoleUserId > 0)
            {
                IOrganizationRoleUserRepository organizationRoleUserRepository = new OrganizationRoleUserRepository();
                var organizationRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(organizationRoleUserId);
                if (organizationRoleUser != null)
                {
                    IUserRepository<Core.Users.Domain.Customer> userRepository = new UserRepository<Core.Users.Domain.Customer>();
                    var user = userRepository.GetUser(organizationRoleUser.UserId);
                    if (user != null)
                    {
                        userName = "Address Verified By " + user.Name.FullName;
                    }
                }
            }
            return userName;
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
                EventSearchTypeDropdownList.Visible = false;
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

        #endregion

    }
}