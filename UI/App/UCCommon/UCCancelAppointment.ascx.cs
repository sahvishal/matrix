using System;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Payment;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UCCancelAppointment : PaymentInstrumentChargerControl
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

        protected override long? CallId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.CallId > 0)
                    return RegistrationFlow.CallId;
                return null;
            }
            set { RegistrationFlow.CallId = value.HasValue ? value.Value : 0; }
        }

        protected override ViewType CurrentViewType
        {
            get
            {
                return (ViewType)Enum.Parse(typeof(ViewType), IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleAlias);
            }
        }

        protected override long? EventId
        {
            get
            {
                if (ViewState["EventId"] != null && !string.IsNullOrEmpty(ViewState["EventId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["EventId"]);
                }
                return null;
            }
            set
            {
                ViewState["EventId"] = value;
            }
        }

        protected override long? CustomerId
        {
            get
            {
                if (ViewState["CustomerId"] != null && !string.IsNullOrEmpty(ViewState["CustomerId"].ToString()))
                {
                    return Convert.ToInt64(ViewState["CustomerId"]);
                }
                return null;
            }
            set
            {
                ViewState["CustomerId"] = value;
            }
        }

        private EventAppointmentCancellationLog EventAppointmentCancellationLog { get; set; }
        protected override Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId.Value);
                }
                return _customer;
            }
        }

        protected override decimal? TotalAmountPayable
        {
            get
            {
                if (ViewState["TotalAmountPayable"] != null && !string.IsNullOrEmpty(ViewState["TotalAmountPayable"].ToString()))
                {
                    return Convert.ToDecimal(ViewState["TotalAmountPayable"]);
                }
                return null;
            }
            set
            {
                ViewState["TotalAmountPayable"] = value;
            }
        }

        protected override decimal? AppliedGiftCertificateBalanceAmount
        {
            get
            {
                return null;
            }
        }

        protected override long? AppliedGiftCertificateId
        {
            get
            {
                return null;
            }
        }

        protected override DropDownList CountryCombo
        {
            get
            {
                return ddlcountry;
            }
        }

        protected override DropDownList ECountryCombo
        {
            get
            {
                return null;
            }
        }

        protected override HiddenField StateHiddenField
        {
            get
            {
                return hfstate;
            }
        }

        protected override HiddenField EStateHiddenField
        {
            get
            {
                return null;
            }
        }

        protected override DropDownList CreditCardTypeCombo
        {
            get { return ddlcardtype; }
        }

        protected override DropDownList EChequeAccountTypeCombo
        {
            get { return null; }
        }

        protected override DropDownList ChequeAccountTypeCombo
        {
            get { return ddlaccounttype; }
        }

        protected override TextBox Address1TextBox
        {
            get
            {
                return txtAddress1;
            }
        }

        protected override TextBox Address2TextBox
        {
            get { return null; }
        }

        protected override TextBox CityTextBox
        {
            get
            {
                return txtCity;
            }
        }

        protected override TextBox ZipTextBox
        {
            get
            {
                return txtZip;
            }
        }

        protected override TextBox PhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox EAddress1TextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EAddress2TextBox
        {
            get { return null; }
        }

        protected override TextBox ECityTextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EZipTextBox
        {
            get
            {
                return null;
            }
        }

        protected override TextBox EPhoneTextBox
        {
            get { return null; }
        }

        protected override TextBox CreditCardHolderNameTextBox
        {
            get { return txtCardHolderName; }
        }

        protected override TextBox CreditCardExpiryDateTextBox
        {
            get { return txtExpirationDate; }
        }

        protected override TextBox CreditCardNumberTextBox
        {
            get { return txtCardNo; }
        }

        protected override TextBox CreditCardSecurityNumberTextBox
        {
            get { return txtSecurityNum; }
        }

        protected override TextBox EChequeRoutingNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeAccountNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeBankNameTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeAccountHolderNameTextBox
        {
            get { return null; }
        }

        protected override TextBox EChequeChequeNumberTextBox
        {
            get { return null; }
        }

        protected override TextBox ChequeRoutingNumberTextBox
        {
            get { return txtRoutingNum; }
        }

        protected override TextBox ChequeAccountNumberTextBox
        {
            get { return txtAccountNum; }
        }

        protected override TextBox ChequeBankNameTextBox
        {
            get { return txtBankName; }
        }

        protected override TextBox ChequeAccountHolderNameTextBox
        {
            get { return txtAccHolderName; }
        }

        protected override TextBox ChequeChequeNumberTextBox
        {
            get { return txtChequeNum; }
        }

        protected override ListControl PaymentMode
        {
            get { return ddlpaymentmode; }
        }

        public decimal TotalAmountRefundable
        {
            get
            {
                if (ViewState["TotalAmountRefundable"] != null)
                {
                    decimal totalAmountRefundable = 0.00m;
                    decimal.TryParse(ViewState["TotalAmountRefundable"].ToString(), out totalAmountRefundable);
                    return totalAmountRefundable;
                }
                return 0.00m;
            }

            set { ViewState["TotalAmountRefundable"] = value; }
        }

        private readonly Roles _currentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;

        private readonly OrganizationRoleUserModel _currentOrgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        protected override void SetAndDisplayErrorMessage(string errorMessage)
        {
            if (PaymentGatewayResponse != null)
            {
                if ((ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCard.PersistenceLayerId.ToString() || ddlpaymentmode.SelectedItem.Value == PaymentType.CreditCardOnFile_Value.ToString()) && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');MaintainAfterPostback();", true);
                else if (ddlpaymentmode.SelectedItem.Value == PaymentType.ElectronicCheck.PersistenceLayerId.ToString() && (PaymentGatewayResponse.ProcessorResult != ProcessorResponseResult.Accepted))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + PaymentGatewayResponse.Message + "');MaintainAfterPostback();", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('" + errorMessage + "');MaintainAfterPostback();", true);
        }

        protected override OrganizationRoleUser GetCreatorOrganizationRoleUser()
        {

            return IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        protected override string SourceCode { get; set; }

        protected override long SourceCodeId { get; set; }

        protected override decimal SourceCodeAmount { get; set; }

        protected override decimal AmountCoveredByInsurance
        {
            get
            {
                return 0;
            }
        }

        protected override long EligibilityId
        {
            get
            {
                return 0;
            }
            set { }
        }

        protected override long ChargeCardId
        {
            get
            {
                return 0;
            }
            set { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferredQuery"] = Request.UrlReferrer.PathAndQuery;
                }
                BindAllDropDowns();
                if (Request.QueryString["EventCustomerID"] != null)
                {
                    SetCustomerDetail(long.Parse(Request.QueryString["EventCustomerID"]));
                }
                SetJavaScriptEvents();
                bycreditcard.Style.Add(HtmlTextWriterStyle.Display, "none");

                BindReasonDropdown();
            }
        }

        private void HandleSaveforNormalFlow()
        {
            bool doEventRegistrationRedirect;
            try
            {
                using (var scope = new TransactionScope())
                {
                    doEventRegistrationRedirect = CancelAppointment();
                    if (CustomerId.HasValue && EventId.HasValue)
                    {
                        SaveCancellationNotes(CustomerId.Value, EventId.Value);

                        var testResultRepository = new TestResultRepository();
                        testResultRepository.DeleteTestDataByEventIdAndCustomerId(EventId.Value, CustomerId.Value);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger("Web").Error(" Message on Cancel appointment " + ex.Message);
                IoC.Resolve<ILogManager>().GetLogger("Web").Error(" Message on Stack Trace " + ex.StackTrace);

                SetAndDisplayErrorMessage("OOPS! Some error occured while saving details." + ex.Message);
                doEventRegistrationRedirect = false;
            }
            if (doEventRegistrationRedirect)
            {
                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(CustomerId.Value, EventId.Value);
                var customerService = IoC.Resolve<ICustomerService>();
                customerService.UnMarkProspectCustomerConverted(eventCustomer.Id, ProspectCustomerTag.Cancellation);

                try
                {
                    if (eventCustomer.AwvVisitId.HasValue)
                    {
                        var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId.Value);
                        var settings = IoC.Resolve<ISettings>();
                        if (account != null)
                        {
                            var medicare = IoC.Resolve<IMedicareApiService>();
                            var userSession = IoC.Resolve<ISessionContext>().UserSession;
                            
                            if (settings.SyncWithHra)
                            {
                                try
                                {
                                    medicare.Connect(userSession.UserLoginLogId);
                                }
                                catch (Exception)
                                {
                                    var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                                    var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                    medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                    medicare.Connect(userSession.UserLoginLogId);
                                }

                                medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Cancelled + "&unlock=true");
  
                            }
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    IoC.Resolve<ILogManager>().GetLogger<Global>().Error("Erroe on AWV Visit Cancellation Message " + ex.Message + " stack trace: " + ex.StackTrace);
                }


                SetPageRedirection();
            }
        }

        private void HandleSaveforRefundQueue()
        {
            bool doEventRegistrationRedirect;
            try
            {
                using (var scope = new TransactionScope())
                {
                    IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
                    var eventCustomer = itemRepository.GetById(EventCustomerId);
                    doEventRegistrationRedirect = false;

                    if (eventCustomer != null)
                    {
                        if (eventCustomer.AppointmentId.HasValue)
                        {
                            var eventCustomerRepository = new EventCustomerRepository();
                            eventCustomerRepository.UpdateAppointmentId(EventCustomerId);

                            var eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
                            eventAppointmentService.DeleteAppointment(eventCustomer.AppointmentId.Value);

                            var refundRequest = PrepareRefundRequestObject();
                            var refundRequestDomain = IoC.Resolve<IRefundRequestService>().SaveRequest(refundRequest);

                            doEventRegistrationRedirect = true;

                            if (CustomerId.HasValue && EventId.HasValue)
                            {
                                //SaveCancellationNotes(CustomerId.Value, EventId.Value);

                                var testResultRepository = new TestResultRepository();
                                testResultRepository.DeleteTestDataByEventIdAndCustomerId(EventId.Value, CustomerId.Value);
                            }

                            if (EventAppointmentCancellationLog != null)
                            {
                                var eventCancellationRepository = IoC.Resolve<IEventAppointmentCancellationLogRepository>();
                                EventAppointmentCancellationLog.RefundRequestId = refundRequestDomain.Id;
                                eventCancellationRepository.Save(EventAppointmentCancellationLog);
                                UpdateCallQueueAppointmentCancellationFlag();
                            }

                            scope.Complete();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(typeof(Page), "js_errorScript",
                                                                    "alert('It seems this appointment has already been cancelled.');",
                                                                    true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "js_errorScript", "alert('OOPS! Some error occured while saving details." + ex.Message.Replace("'", "\\'") + "');", true);
                doEventRegistrationRedirect = false;
            }

            if (doEventRegistrationRedirect)
            {
                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var eventCustomer = eventCustomerRepository.GetCancelledEventForUser(CustomerId.Value, EventId.Value);
                if (eventCustomer.AwvVisitId.HasValue)
                {
                    var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId.Value);
                    if (account != null)
                    {
                        var settings = IoC.Resolve<ISettings>();

                        var medicare = IoC.Resolve<IMedicareApiService>();
                        var userSession = IoC.Resolve<ISessionContext>().UserSession;
                        
                        if (settings.SyncWithHra)
                        {
                            try
                            {
                                medicare.Connect(userSession.UserLoginLogId);
                            }
                            catch (Exception)
                            {
                                var token = (Session.SessionID + "_" + userSession.UserId + "_" + userSession.CurrentOrganizationRole.RoleId + "_" + userSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                                var auth = new MedicareAuthenticationModel { UserToken = token, CustomerId = 0, OrgName = settings.OrganizationNameForHraQuestioner, Tag = settings.OrganizationNameForHraQuestioner, IsForAdmin = true, RoleAlias = "CallCenterRep" };
                                medicare.PostAnonymous<string>(settings.MedicareApiUrl + MedicareApiUrl.AuthenticateUser, auth);

                                medicare.Connect(userSession.UserLoginLogId);
                            }

                            medicare.Get<bool>(MedicareApiUrl.UpdateVisitStatus + "?visitId=" + eventCustomer.AwvVisitId.Value + "&status=" + (int)MedicareVisitStatus.Cancelled + "&unlock=true");
 
                        }
                        
                    }
                }
                SetPageRedirection();
            }
        }

        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            var totalAmount = Decimal.Parse(txtAmount.Text);

            TotalAmountPayable = totalAmount > 0 ? (-1) * totalAmount : totalAmount;

            SaveReasonForCancellation();

            if (TotalAmountPayable.Value < 0 && IoC.Resolve<ISettings>().IsRefundQueueEnabled)
            {
                HandleSaveforRefundQueue();
            }
            else
            {
                HandleSaveforNormalFlow();
            }
        }

        private void SetPageRedirection()
        {
            string redirectUrl = string.Empty;

            if (_currentOrgUser.CheckRole((long)Roles.FranchiseeAdmin))
            {
                redirectUrl = ResolveUrl("/App/Franchisee/FranchiseeCustomerList.aspx?Action=Deleted");
            }
            else if (_currentOrgUser.CheckRole((long)Roles.SalesRep))
            {
                redirectUrl = ResolveUrl("/App/Franchisee/SalesRep/SalesRepEventCustomerList.aspx?Action=Deleted");
            }
            else if (_currentOrgUser.CheckRole((long)Roles.FranchisorAdmin))
            {
                redirectUrl = ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + Customer.CustomerId);
            }
            else if (_currentOrgUser.CheckRole((long)Roles.CallCenterRep) || _currentOrgUser.CheckRole((long)Roles.CallCenterManager))
            {
                //Keep this before redirect for CCRep normal flow
                if (Request.QueryString["dialerType"] != null &&
                    (Request.QueryString["dialerType"] == ((long)DialerType.Gms).ToString()) || Request.QueryString["dialerType"] == ((long)DialerType.Vici).ToString())
                {
                    var setting = IoC.Resolve<ISettings>();
                    var url = "";
                    if (Request.QueryString["CallQueueId"] == "154")
                    {
                        url = setting.AppUrl + "/CallCenter/PreAssessmentCallQueue/PreAssessmentCall?customerId=" + Request.QueryString["CustomerID"] +
                           "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                    }
                    else
                    {
                         url = setting.AppUrl + "/CallCenter/ContactCustomer/AppointmentConfirmation?customerId=" + Request.QueryString["CustomerID"] +
                           "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                    }

                   
                    Response.Redirect(url);
                }

                else if (Request.QueryString["callQueueCustomerId"] != null && Request.QueryString["attemptId"] != null)
                {
                    var setting = IoC.Resolve<ISettings>();
                    redirectUrl = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + Request.QueryString["callQueueCustomerId"] + "/" + Request.QueryString["attemptId"];
                }

                else if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    redirectUrl = ResolveUrl(string.Format("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?Action=Deleted&CustomerID={0}&Call=No" + "&guid=" + GuId,
                                                   hfcustomerid.Value));
                }
                else
                {
                    if (CallId.HasValue)
                    {
                        var repository = new CallCenterCallRepository();
                        var call = repository.GetCallCenterEntity(CallId.Value);

                        EndCall();
                        StartCall(call.CalledCustomerID);
                    }

                    redirectUrl = ResolveUrl(string.Format("/App/CallCenter/CallCenterRep/CustomerOptions.aspx?Action=Deleted&CustomerID={0}&Name={1} {2}" + "&guid=" + GuId,
                                                   Customer.CustomerId, Customer.Name.FirstName, Customer.Name.LastName));
                }
            }
            else if (_currentOrgUser.CheckRole((long)Roles.Technician) || _currentOrgUser.CheckRole((long)Roles.NursePractitioner))
            {
                redirectUrl = ViewState["ReferredQuery"].ToString().IndexOf("EventCustomerList") >= 0 ?
                                                                                                      ViewState["ReferredQuery"].ToString() :
                                                                                                                                                ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerList.aspx?Action=Deleted");
            }

            try
            {
                var selectedItemValue = int.Parse(CancellationReasonddlList.SelectedItem.Value);
                var selectedSubReasonId = long.Parse(Request.Form[CancellationSubReasonddlList.UniqueID]);

                var cancelReason = (CancelAppointmentReason)selectedItemValue;
                var cancelSubReason = selectedSubReasonId > 0 ? ((CancelAppointmentSubReason)selectedSubReasonId).GetDescription() : "N/A";

                var cancelRescheduleService = IoC.Resolve<ICancellationRescheduleAppointmentNotificationService>();
                cancelRescheduleService.SendCancellationRescheduleAppointmentMail(true, CustomerId.Value, EventId.Value, 0, cancelReason.GetDescription(), _currentOrgUser.OrganizationRoleUserId, "System: Cancel Appointment", cancelSubReason);
            }
            catch (Exception ex)
            {
                IoC.Resolve<ILogManager>().GetLogger<Global>().Error(" Message " + ex.Message + " stack trace: " + ex.StackTrace);
            }

            Response.RedirectUser(redirectUrl);
        }

        protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
        {
            string url = string.Empty;
            var currentRole = (Roles)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId;
            if (!string.IsNullOrEmpty(hfcustomerid.Value))
            {
                if (_currentOrgUser.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    url = ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + hfcustomerid.Value);
                }
                else if (_currentOrgUser.CheckRole((long)Roles.SalesRep))
                {
                    url = ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + hfcustomerid.Value);
                }
                else if (_currentOrgUser.CheckRole((long)Roles.FranchisorAdmin))
                {
                    url = ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + hfcustomerid.Value);
                }
                else if (_currentOrgUser.CheckRole((long)Roles.CallCenterRep) || _currentOrgUser.CheckRole((long)Roles.CallCenterManager))
                {
                    if (Request.QueryString["dialerType"] != null &&
                                        (Request.QueryString["dialerType"] == ((long)DialerType.Gms).ToString()) || Request.QueryString["dialerType"] == ((long)DialerType.Vici).ToString())
                    {
                        var setting = IoC.Resolve<ISettings>();
                        if (Request.QueryString["CallQueueId"] == "154")
                        {
                            url = setting.AppUrl + "/CallCenter/PreAssessmentCallQueue/PreAssessmentCall?customerId=" + Request.QueryString["CustomerID"] +
                                "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                        }
                        else
                        {
                            url = setting.AppUrl + "/CallCenter/ContactCustomer/AppointmentConfirmation?customerId=" + Request.QueryString["CustomerID"] +
                                "&callId=" + Request.QueryString["CallID"] + "&callQueueId=" + Request.QueryString["CallQueueId"] + "&eventId=" + Request.QueryString["EventID"];
                        }
                        Response.Redirect(url);
                    }

                    else if (Request.QueryString["callQueueCustomerId"] != null && Request.QueryString["attemptId"] != null)
                    {
                        var setting = IoC.Resolve<ISettings>();
                        url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + Request.QueryString["callQueueCustomerId"] + "/" + Request.QueryString["attemptId"];
                    }

                    else if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    {
                        url = ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + hfcustomerid.Value + "&Call=No" + "&guid=" + GuId);
                    }
                    else
                    {
                        url = ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + hfcustomerid.Value + "&guid=" + GuId);
                    }
                }
                else if (_currentOrgUser.CheckRole((long)Roles.Technician) || _currentOrgUser.CheckRole((long)Roles.NursePractitioner))
                {
                    url = ViewState["ReferredQuery"].ToString();
                }
            }
            else
            {
                if (_currentOrgUser.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    url = ResolveUrl("/App/Franchisee/FranchiseeCustomerList.aspx");
                }
                else if (_currentOrgUser.CheckRole((long)Roles.SalesRep))
                {
                    url = ResolveUrl("/App/Franchisee/SalesRep/SalesRepEventCustomerList.aspx");
                }
                else if (_currentOrgUser.CheckRole((long)Roles.FranchisorAdmin))
                {
                    url = ResolveUrl("/App/Franchisor/FranchisorCustomerList.aspx");
                }
                else if (_currentOrgUser.CheckRole((long)Roles.CallCenterRep))
                {
                    url = ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerList.aspx");
                }
                else if (_currentOrgUser.CheckRole((long)Roles.Technician) || _currentOrgUser.CheckRole((long)Roles.NursePractitioner))
                {
                    url = ViewState["ReferredQuery"].ToString();
                }
            }
            Response.RedirectUser(url);
        }


        private void SetJavaScriptEvents()
        {
            txtCardNo.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAccountNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtChequeNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtSecurityNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");

            txtRoutingNum.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAmount.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            ddlpaymentmode.Attributes.Add("onChange", "OpenCloseDiv('" + ddlpaymentmode.ClientID + "')");
        }

        private void BindAllDropDowns()
        {
            BindCountryDropDown();
            BindPageDropDowns();
        }

        private void BindCountryDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlcountry.DataSource = countries;
            ddlcountry.DataTextField = "Name";
            ddlcountry.DataValueField = "Id";
            ddlcountry.DataBind();
            //ddlcountry.Items.Insert(0, new ListItem("Select Country", "0"));
            ddlcountry.Items[0].Selected = true;
        }

        protected override void BindPaymentModeDropDown()
        {
            ddlpaymentmode.Items.Clear();
            ddlpaymentmode.Items.Add(new ListItem(PaymentType.CreditCard.Name,
                                                      PaymentType.CreditCard.PersistenceLayerId.ToString()));
            ddlpaymentmode.Items.Add(new ListItem(PaymentType.Check.Name,
                                                  PaymentType.Check.PersistenceLayerId.ToString()));
            ddlpaymentmode.Items.Add(new ListItem(PaymentType.Cash.Name,
                                                  PaymentType.Cash.PersistenceLayerId.ToString()));
            if (_currentOrgUser.CheckRole((long)Roles.CallCenterRep))
            {
                ddlpaymentmode.Items.Remove(ddlpaymentmode.Items.FindByValue(PaymentType.Cash.PersistenceLayerId.ToString()));
                ddlpaymentmode.Items.Remove(ddlpaymentmode.Items.FindByValue(PaymentType.Check.PersistenceLayerId.ToString()));
            }

            ddlpaymentmode.Items.Insert(0, new ListItem("Pay By:", "0"));

        }

        private void SetPaymentDetails(Core.Finance.Domain.Order order)
        {
            decimal paidAmount = 0.00m;
            if (order.PaymentsApplied != null && !order.PaymentsApplied.IsEmpty())
            {
                TotalAmountPayable = order.TotalAmountPaid;

                //TODO:Currently it is removed as we don't have CC detail
                SetCreditCardOnFileDetails(order);

                foreach (var paymentApplied in order.PaymentsApplied)
                    paidAmount += paymentApplied.Amount;

                if (IoC.Resolve<ISettings>().IsRefundQueueEnabled)
                {
                    txtAmount.Text = paidAmount.ToString("0.00");
                }
                else
                {
                    var cancellationFeeString = IoC.Resolve<IConfigurationSettingRepository>().GetConfigurationValue(ConfigurationSettingName.CancellationFee);

                    decimal cancellationFee = 0;
                    if (!string.IsNullOrEmpty(cancellationFeeString))
                        decimal.TryParse(cancellationFeeString, out cancellationFee);

                    spAmountPaid.InnerText = paidAmount.ToString("0.00");
                    txtAmount.Text = (paidAmount - cancellationFee).ToString("0.00");

                    if (cancellationFee > 0)
                    {
                        CancellationFeeContainer.Visible = true;
                        CancellatinFeeSpan.InnerHtml = cancellationFee.ToString();
                    }
                }

            }
            else
            {
                spAmountPaid.InnerText = paidAmount.ToString("0.00");
                spdbpaymentmode.Visible = false;
            }
            if (paidAmount <= 0)
            {
                ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem("None", "-1"));
                ddlpaymentmode.Enabled = false;
                ddlpaymentmode.Items.FindByText("None").Selected = true;
                txtAmount.Text = "0.00";
                txtAmount.Enabled = false;
                byCreditCardOld.Style.Add(HtmlTextWriterStyle.Display, "none");
                bycreditcard.Style.Add(HtmlTextWriterStyle.Display, "none");
                bycheque.Style.Add(HtmlTextWriterStyle.Display, "none");
                byCash.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        private void SetCreditCardOnFileDetails(Core.Finance.Domain.Order order)
        {
            //var creditCardPaymentInstrument =
            //    order.PaymentsApplied.LastOrDefault(pa => pa.PaymentType == PaymentType.CreditCard) as
            //    ChargeCardPayment;

            var creditCardPaymentInstrument = order.PaymentsApplied.Where(pi => pi.PaymentType == PaymentType.CreditCard).OrderBy(
                pi => pi.DataRecorderMetaData.DateCreated).Select(pi => (ChargeCardPayment)pi).LastOrDefault();

            var isEccEnabled = IoC.Resolve<ISettings>().IsEccEnabled;
            if (creditCardPaymentInstrument != null && (isEccEnabled || (creditCardPaymentInstrument.Amount > 0 && creditCardPaymentInstrument.DataRecorderMetaData.DateCreated > DateTime.Now.Date.AddDays(-120) && ProcessorResponse.IsValidResponseString(creditCardPaymentInstrument.ProcessorResponse))))
            {
                //Removed cash and check peyment mode for refund if customer has made payment using credit card
                //ddlpaymentmode.Items.Remove(ddlpaymentmode.Items.FindByText(PaymentType.Cash.Name));
                //ddlpaymentmode.Items.Remove(ddlpaymentmode.Items.FindByText(PaymentType.Check.Name));

                IChargeCardRepository chargeCardRepository = new ChargeCardRepository();
                var existingChargeCard = chargeCardRepository.GetById(creditCardPaymentInstrument.ChargeCardId);
                spcardholder.InnerText = existingChargeCard.NameOnCard;
                string cardnumber = existingChargeCard.Number;
                if (cardnumber.Length > 0)
                {
                    string dispcardnumber = "";
                    for (int jcount = 0; jcount < cardnumber.Length - 4; jcount++)
                    {
                        dispcardnumber = dispcardnumber + "X";
                    }

                    dispcardnumber += cardnumber.Substring(cardnumber.Length - 4, 4);

                    spccnumber.InnerText = dispcardnumber;
                    spcctype.InnerText =
                        Enum.Parse(typeof(ChargeCardType), existingChargeCard.TypeId.ToString()).ToString();
                    spexpdate.InnerText = existingChargeCard.ExpirationDate.ToString("MM/yyyy");

                    ListItem itmCard = ddlpaymentmode.Items.FindByValue(PaymentType.CreditCard.PersistenceLayerId.ToString());
                    if (itmCard != null)
                    {
                        ddlpaymentmode.Items.Insert(ddlpaymentmode.Items.Count, new ListItem(PaymentType.CreditCardOnFile_Text, PaymentType.CreditCardOnFile_Value.ToString()));
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JSCODE",
                        "alert('The credit card number supplied is invalid.So you have to enter new credit card information if you wish to refund via credit card');",
                        true);
                }
            }
        }
        private void BindReasonDropdown()
        {
            var lookupRepository = IoC.Resolve<ILookupRepository>();
            var reasons = lookupRepository.GetByLookupId((long)CancelAppointmentReason.HealthFairReason)
                                          .OrderBy(x => x.RelativeOrder)
                                          .Select(x => new OrderedPair<long, string> { FirstValue = x.Id, SecondValue = x.DisplayName }).OrderBy(x => x.SecondValue)
                                          .ToArray(); //CancelAppointmentReason.NotEligible.GetNameValuePairs();

            CancellationReasonddlList.Items.Clear();
            CancellationReasonddlList.DataSource = reasons;
            CancellationReasonddlList.DataTextField = "SecondValue";
            CancellationReasonddlList.DataValueField = "FirstValue";
            CancellationReasonddlList.DataBind();
            CancellationReasonddlList.Items.Insert(0, (new ListItem("--Select--", "0")));
        }

        private void SaveReasonForCancellation()
        {
            if (EventCustomerId > 0 && EventId.HasValue)
            {
                var eventCancellationRepository = IoC.Resolve<IEventAppointmentCancellationLogRepository>();
                var organizationRoleUserId = GetCreatorOrganizationRoleUser().Id;
                var selectedItemValue = int.Parse(CancellationReasonddlList.SelectedItem.Value);
                var selectedSubReasonId = long.Parse(Request.Form[CancellationSubReasonddlList.UniqueID]);
                var cancellationLog = new EventAppointmentCancellationLog
                {
                    CreatedBy = organizationRoleUserId,
                    DateCreated = DateTime.Now,
                    EventCustomerId = EventCustomerId,
                    EventId = EventId.Value,
                    NoteId = null,
                    ReasonId = selectedItemValue,
                    SubReasonId = selectedSubReasonId > 0 ? selectedSubReasonId : (long?)null
                };

                EventAppointmentCancellationLog = eventCancellationRepository.Save(cancellationLog);
            }
        }


        private void SetCustomerDetail(long eventcustomerid)
        {
            EventCustomerId = eventcustomerid;
            IUniqueItemRepository<EventCustomer> eventCustomerRepository = new EventCustomerRepository();
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);
            if (eventCustomer != null)
            {
                CustomerId = eventCustomer.CustomerId;
                EventId = eventCustomer.EventId;
                spEventID.InnerHtml = EventId.ToString();
                hfEventCustomerID.Value = EventCustomerId.ToString();
                if (Customer != null && Customer.Address != null)
                {
                    spCustomerName.InnerText = Customer.Name + "(ID:" + CustomerId + ")";
                    hfcustomerid.Value = CustomerId.ToString();
                }

                var eventService = IoC.Resolve<IEventService>();
                var eventBasicInfoViewModel = eventService.GetEventBasicInfoFor(eventCustomer.EventId);

                spHost.InnerText = eventBasicInfoViewModel.HostName;
                spAddress.InnerText =
                    CommonCode.AddressSingleLine(eventBasicInfoViewModel.HostAddress.StreetAddressLine1,
                                                 eventBasicInfoViewModel.HostAddress.StreetAddressLine2,
                                                 eventBasicInfoViewModel.HostAddress.City,
                                                 eventBasicInfoViewModel.HostAddress.State,
                                                 eventBasicInfoViewModel.HostAddress.ZipCode);


                spEventDate.InnerText = eventBasicInfoViewModel.EventDate.ToShortDateString();
                ViewState["EventDate"] = eventBasicInfoViewModel.EventDate.ToShortDateString();

                if (eventCustomer.AppointmentId.HasValue)
                {
                    var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                    var appointment = appointmentRepository.GetById(eventCustomer.AppointmentId.Value);
                    spAppointment.InnerText = appointment.StartTime.ToShortTimeString();
                }

                IOrderRepository orderRepository = new OrderRepository();
                var order = orderRepository.GetOrder(CustomerId.Value, EventId.Value);
                if (order != null && !order.OrderDetails.IsEmpty())
                {
                    spPackageCost.InnerText = order.OrderDetails.Where(od =>
                                (od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted) ||
                                (od.DetailType == OrderItemType.EventTestItem && od.IsCompleted))
                            .Sum(od => od.Price).ToString("C2");

                    OrderId = order.Id;
                    TotalAmountRefundable = order.TotalAmountPaid;
                    SetPaymentDetails(order);

                    IOrderController orderController = new OrderController();
                    var orderDetail = orderController.GetActiveOrderDetail(order);
                    IOrderItemRepository orderItemRepository = new OrderItemRepository();
                    var orderItem = orderItemRepository.GetOrderItem(orderDetail.OrderItemId);
                    if (orderItem is EventPackageItem)
                    {
                        var eventPackageItem = orderItem as EventPackageItem;

                        var itemRepository = IoC.Resolve<IEventPackageRepository>();
                        var eventPackage = itemRepository.GetById(eventPackageItem.ItemId);
                        PackageId = eventPackage.PackageId;
                    }
                    if (orderDetail.SourceCodeOrderDetail != null)
                    {
                        ISourceCodeRepository sourceCodeRepository = new SourceCodeRepository();
                        var sourceCode =
                            sourceCodeRepository.GetSourceCodeById(orderDetail.SourceCodeOrderDetail.SourceCodeId);
                        spCouponDetails.InnerText = sourceCode.CouponCode;
                    }
                    else
                        spCouponDetails.InnerText = "-N/A-";

                    if (Customer != null)
                    {
                        var functionToCall = "javascript:return ShowOrderDetailPopUp(" +

                                            HttpUtility.HtmlEncode(order.Id) + "," + HttpUtility.HtmlEncode(order.DiscountedTotal) + "," + HttpUtility.HtmlEncode(order.TotalAmountPaid) + "," +
                                             HttpUtility.HtmlEncode(order.DiscountedTotal - order.TotalAmountPaid) + ",'" + HttpUtility.HtmlEncode(Customer.Name) + "'," +
                                             CustomerId.Value + ");";
                        _paymentLinkAnchor.Attributes.Add("onClick", functionToCall);
                        _orderLinkAnchor.Attributes.Add("onClick", functionToCall);

                    }
                    _paymentLinkAnchor.HRef = "javascript:void(0);";
                    _orderLinkAnchor.HRef = "javascript:void(0);";
                }
            }

        }

        private void StartCall(long calledCustomerid)
        {
            // We are not setting time here as this is a new call only for system.
            var newCall = new Call();
            var repository = new CallCenterCallRepository();

            if (CallId.HasValue)
            {
                var call = repository.GetById(CallId.Value);

                newCall.CalledInNumber = call.CalledInNumber;
                newCall.CallerNumber = call.CallerNumber;
                newCall.IsIncoming = call.IsIncoming;
            }

            newCall.CreatedByOrgRoleUserId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            newCall.StartTime = DateTime.Now;
            newCall.CallDateTime = DateTime.Now;
            newCall.DateCreated = DateTime.Now;
            newCall.DateModified = DateTime.Now;
            newCall.CalledCustomerId = calledCustomerid;

            if (!string.IsNullOrEmpty(Customer.Tag))
            {
                var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = accountRepository.GetByTag(Customer.Tag);
                newCall.HealthPlanId = account.Id;
            }

            newCall = repository.Save(newCall);
            CallId = newCall.Id;
        }

        private void EndCall()
        {
            var repository = new CallCenterCallRepository();
            if (CallId.HasValue) repository.UpdateCallEnd(DateTime.Now, CallId.Value);
        }

        private void SaveCancellationNotes(long customerId, long eventId)
        {
            var currentUser = IoC.Resolve<ISessionContext>().UserSession;
            var customerRegistrationNotes = new CustomerCallNotes
                                                {
                                                    CustomerId = customerId,
                                                    EventId =
                                                        eventId > 0 ? eventId : (long?)null,
                                                    Notes = txtReason.Text,
                                                    NotesType = CustomerRegistrationNotesType.CancellationNote,
                                                    DataRecorderMetaData = new DataRecorderMetaData
                                                                               {
                                                                                   DateCreated = DateTime.Now,
                                                                                   DataRecorderCreator = new OrganizationRoleUser(currentUser.CurrentOrganizationRole.OrganizationRoleUserId)
                                                                               }
                                                };

            var customerRegistrationNotesRepository = IoC.Resolve<IUniqueItemRepository<CustomerCallNotes>>();
            customerRegistrationNotes = customerRegistrationNotesRepository.Save(customerRegistrationNotes);

            if (EventAppointmentCancellationLog != null)
            {
                var eventCancellationRepository = IoC.Resolve<IEventAppointmentCancellationLogRepository>();
                EventAppointmentCancellationLog.NoteId = customerRegistrationNotes.Id;
                eventCancellationRepository.Save(EventAppointmentCancellationLog);
                UpdateCallQueueAppointmentCancellationFlag();
            }


            LogAudit(ModelType.Edit, customerRegistrationNotes, customerId);
        }

        private void UpdateCallQueueAppointmentCancellationFlag()
        {
            try
            {
                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var appointmentDate = eventCustomerRepository.GetFutureMostAppointmentDateForEventCustomerByCustomerId(CustomerId.Value);
                bool hasNextFutureAppointment = appointmentDate != null;

                var futureAppointment = new CancelAppointmentFlagViewModel
                {
                    HasFutureAppointment = hasNextFutureAppointment,
                    NextFutureAppointmentDate = appointmentDate,
                    CustomerId = CustomerId.Value,
                    CancelAppoinemtDate = DateTime.Now
                };

                IoC.Resolve<ICallQueueCustomerPublisher>().UpdateAppointmentCancellationFlag(futureAppointment);
            }
            catch (Exception ex)
            {

                var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
                logger.Error("some Error Occurred While Updating future Customers");
                logger.Error("Message: " + ex.Message);
                logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        public string GetSubReason()
        {
            var rescheduleCancelDispositionRepository = IoC.Resolve<IRescheduleCancelDispositionRepository>();
            var lookupIds = CancelAppointmentReason.HealthFairReason.GetNameValuePairs().Select(x => (long)x.FirstValue).ToArray();
            var subReasons = rescheduleCancelDispositionRepository.GetByLookupIds(lookupIds);

            return new System.Web.Script.Serialization.JavaScriptSerializer()
                .Serialize(subReasons.Select(x => new { Id = x.Id, DisplayName = x.DisplayName, LookupId = x.LookupId, RelativeOrder = x.RelativeOrder }).OrderBy(x => x.DisplayName));
        }
    }
}