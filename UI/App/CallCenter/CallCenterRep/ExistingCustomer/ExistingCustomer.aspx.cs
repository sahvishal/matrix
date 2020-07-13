using System;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.DataAccess.Master;
using Falcon.Entity.CallCenter;
using System.Text;
using Falcon.App.Core.Extensions;
using System.Collections.Generic;
using System.Web.Mvc;
using Falcon.DataAccess.Deprecated;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.UI.HtmlHelpers;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class CallCenterRepExistingCustomer : Page
    {
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();
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
                switch (CustomerId)
                {
                    case 0:
                        return CustomerType.New;
                    default:
                        return CustomerType.Existing;
                }
            }
        }

        private string CurrentAction
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Action"]))
                {
                    return Request.QueryString["Action"];
                }
                return null;
            }
        }

        private long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
            set
            {
                RegistrationFlow.CustomerId = value;
            }
        }

        protected string ZipCode = "";

        private long CurrentProspectCustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;
            }
            set
            {
                RegistrationFlow.ProspectCustomerId = value;
            }

        }

        private Core.Users.Domain.Customer _customer;

        protected Core.Users.Domain.Customer CurrentCustomer
        {
            get
            {
                if (_customer == null && CustomerId > 0)
                {
                    ICustomerRepository customerRepository = new CustomerRepository();
                    _customer = customerRepository.GetCustomer(CustomerId);
                }
                return _customer;
            }
            set { _customer = value; }
        }

        private bool IsGiftCertificatePurchase
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["gc"]);
            }
        }

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
            set { RegistrationFlow.CallId = value; }
        }

        protected bool IsInboundCall
        {
            get
            {
                if (CallId > 0)
                    return !IoC.Resolve<ICallCenterRepository>().IsCallTypeOutbound(CallId);
                return false;
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
            get { return Convert.ToString(Request.QueryString["CallBackNumber"]); }
        }

        protected String Zip
        {
            get { return Convert.ToString(Request.QueryString["Zip"]); }
        }

        protected bool IncomingPhoneLineRequired
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.IncomingPhoneLineRequired));
            }
        }

        protected bool EnableSmsNotification
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
            }
        }
        protected bool EnableVoiceMailNotification
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EnableVoiceMailNotification));
            }
        }

        private long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        private long CallQueueId { get; set; }

        protected bool PasswordNotTobeValidate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegistrationFlow.CanSaveConsentInfo = true;

            SetDisplayControls();
            if (!IsPostBack)
            {

                SetZipCode();
                if (Request.QueryString["CustomerID"] != null)
                {
                    CustomerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
                    var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
                    var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(CustomerId);
                    if (prospectCustomer == null)
                    {
                        var customerRepository = IoC.Resolve<ICustomerRepository>();

                        var customer = customerRepository.GetCustomer(CustomerId);
                        var prospectCustomerFactory = IoC.Resolve<IProspectCustomerFactory>();
                        prospectCustomer = prospectCustomerFactory.CreateProspectCustomerFromCustomer(customer, false);
                        prospectCustomer = ((IUniqueItemRepository<ProspectCustomer>)prospectCustomerRepository).Save(prospectCustomer);
                        if (CallId > 0)
                        {
                            var callWizardService = new CallCenterCallWizardService();
                            callWizardService.BindCurrentCallToProspectCustomer(CallId, prospectCustomer.Id, Convert.ToInt64(IoC.Resolve<ISessionContext>().UserSession.UserId));
                        }
                    }
                }

                FillSecurityQuestions();
                BindDropDownControls();

                if (CustomerType == CustomerType.New && CurrentAction == null)
                {
                    if (CustomerId > 0)
                    {
                        SetCustomerDataToControls();
                        MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;
                    }
                    else
                        SetProspectCustomerDataToControls();
                }
                else if (CustomerType == CustomerType.New && CurrentAction != null && CurrentAction.Equals("Back"))
                {
                    SetCustomerDataToControls();
                    MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;
                    isPageOpenedByBackClick.Value = "true";
                }
                else if (CustomerType == CustomerType.New && CurrentAction != null && CurrentAction.Equals("SameEvent"))
                {
                    SetCustomerDataToControls();
                    MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;
                    CurrentCustomer.Id = 0;
                    CurrentCustomer.CustomerId = 0;
                }
                else if (CustomerType == CustomerType.New && CurrentAction != null && CurrentAction.Equals("RegNewCustForSameEvent"))
                {
                    SetCustomerDataToControls();
                    txtFName.Text = "";
                    txtMName.Text = "";
                    txtLName.Text = "";
                    txtEmail.Text = "";
                    ddlFeet.SelectedIndex = 0;
                    ddlInch.SelectedIndex = 0;
                    txtweight.Text = "";

                    txtUserName.Text = "";
                    txtPassword.Attributes.Add("value", "");
                    txtAnswer1.Text = "";
                    rbtnGender.Items[0].Selected = false;
                    rbtnGender.Items[1].Selected = false;
                    txtDOB.Text = "";
                    ddlrace.SelectedIndex = 0;
                    MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;
                    //txtOPhone.Text = "";
                    //txtCPhone.Text = "";
                    txtEmail2.Text = "";
                    if (CurrentCustomer != null && CurrentCustomer.Address != null)
                        CurrentCustomer.Address.Id = 0;
                    if (CurrentCustomer != null)
                    {
                        CurrentCustomer.Id = 0;
                        CurrentCustomer.CustomerId = 0;
                    }
                    CustomerId = 0;

                }
                else if (CustomerType == CustomerType.Existing && CurrentAction != null && CurrentAction.Equals("Back"))
                {
                    SetCustomerDataToControls();
                    MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;

                }
                else if (CustomerType == CustomerType.Existing)
                    SetCustomerDataToControls();

                SetJavaScriptEvents();
                SetCallCenterScripts();

                if (IsGiftCertificatePurchase)
                {
                    StepTitleContainer.InnerText = "Step 3: Gift Certificate Check out - Create Account";
                    StepSymbolDiv.Style[HtmlTextWriterStyle.Display] = "none";
                }

                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else if (CallId > 0)
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId);
                    var call = repository.GetCallCenterEntity(CallId);
                    IncomingPhoneLineTextBox.Text = call.IncomingPhoneLine;
                    CallersPhoneNumberTextBox.Text = call.CallersPhoneNumber;
                }
            }

            HideUserCredentialPanel();

            if (rbtPhone.Checked)
            {
                RegisterContactMethodValidationOnPage();
            }

            var eventRepository = IoC.Resolve<IEventRepository>();
            InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
            InsuranceIdRequiredHiddenField.Value = Boolean.FalseString;
            var settings = IoC.Resolve<ISettings>();
            if (settings.CaptureInsuranceId && EventId > 0)
            {
                var eventData = eventRepository.GetById(EventId);
                if (eventData.CaptureInsuranceId)
                {
                    InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
                    if (eventData.InsuranceIdRequired)
                        InsuranceIdRequiredHiddenField.Value = Boolean.TrueString;
                }

            }

            SsnContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (EventId > 0)
            {
                var captureSsn = eventRepository.CaptureSsn(EventId);
                if (captureSsn)
                    SsnContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
            }


            var toolTipRepository = IoC.Resolve<IToolTipRepository>();
            var insuranceIdLabel = toolTipRepository.GetToolTipContentByTag(ToolTipType.InsuranceIdLabel);
            insuranceIdLabel = string.IsNullOrEmpty(insuranceIdLabel) ? "Insurance Id" : (insuranceIdLabel);

            var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = accountRepository.GetbyEventId(EventId);
            MedicareIdRequiredHiddenField.Value = Boolean.FalseString;


            if (account != null)
            {
                if (!string.IsNullOrEmpty(account.MemberIdLabel))
                {
                    insuranceIdLabel = account.MemberIdLabel;
                }

                MedicareIdRequiredHiddenField.Value = account.HicNumberRequired ? Boolean.TrueString : Boolean.FalseString;
            }
            InsuranceIdLabelHiddenField.Value = insuranceIdLabel;
            InsuranceIdLabel.InnerHtml = HttpUtility.HtmlEncode(insuranceIdLabel) + "<span id='InsuranceIdRequiredMark' class='reqiredmark'><sup>*</sup></span>";

        }

        private void RegisterContactMethodValidationOnPage()
        {
            var strJsCloseWindow = new StringBuilder();
            strJsCloseWindow.Append(" <script language = 'Javascript'>CheckContactMethod('" + rbtPhone.ClientID + "'); </script>");
            ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
        }

        private bool IsSystemGeneratedCallQueue()
        {
            if (RegistrationFlow != null && RegistrationFlow.CallQueueCustomerId > 0)
            {
                var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
                var callQueueCustomer = callQueueCustomerRepository.GetById(RegistrationFlow.CallQueueCustomerId);

                var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
                var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

                return (callQueue != null && !callQueue.IsManual && !callQueue.IsHealthPlan);
            }

            return false;
        }
        private bool IsHealthPlanCallQueue()
        {
            if (RegistrationFlow == null || RegistrationFlow.CallQueueCustomerId == 0) return false;
            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
            var callQueueCustomer = callQueueCustomerRepository.GetById(RegistrationFlow.CallQueueCustomerId);

            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);

            CallQueueId = callQueue != null ? callQueue.Id : 0;

            return (callQueue != null && !callQueue.IsManual && callQueue.IsHealthPlan);
        }

        protected void ibtnBack_Click(object sender, ImageClickEventArgs e)
        {
            //if (IsSystemGeneratedCallQueue())
            //{
            //    var setting = IoC.Resolve<ISettings>();
            //    var url = setting.AppUrl + "/CallCenter/CallQueue/Call#/contact/" + RegistrationFlow.CallQueueCustomerId + "/" + RegistrationFlow.CallId;

            //    if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
            //    {
            //        var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
            //        var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
            //        if (slots.Any(s => s.EventId != EventId))
            //        {
            //            eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
            //            RegistrationFlow.AppointmentSlotIds = null;
            //        }

            //    }
            //    Session[GuId] = null;
            //    Response.RedirectUser(url);
            //}
            //else 
            if (IsHealthPlanCallQueue())
            {
                var setting = IoC.Resolve<ISettings>();
                //CallCenter/CallCenterRepDashBoard#/healthplan/contact/30018445/34
                var url = setting.AppUrl + "/CallCenter/CallCenterRepDashBoard#/healthplan/contact/" + RegistrationFlow.CallQueueCustomerId + "/" + RegistrationFlow.AttempId;

                if (RegistrationFlow.IsGmsCall)
                {
                    url = setting.AppUrl + "/CallCenter/ContactCustomer/GetCustomerContactView?customerId=" + RegistrationFlow.CustomerId + "&callId=" + RegistrationFlow.CallId;
                }
                else if (RegistrationFlow.IsViciCall)
                {
                    url = setting.AppUrl + "/CallCenter/ContactCustomer/GetDialerPatient?customerId=" + RegistrationFlow.CustomerId + "&callQueueId=" + CallQueueId + "&callId=" + RegistrationFlow.CallId;
                }

                if (RegistrationFlow.AppointmentSlotIds != null && RegistrationFlow.AppointmentSlotIds.Count() > 0)
                {
                    var eventSchedulingSlotRepository = IoC.Resolve<IEventSchedulingSlotRepository>();
                    var slots = eventSchedulingSlotRepository.GetbyIds(RegistrationFlow.AppointmentSlotIds);
                    if (slots.Any(s => s.EventId != EventId))
                    {
                        eventSchedulingSlotRepository.ReleaseSlots(RegistrationFlow.AppointmentSlotIds);
                        RegistrationFlow.AppointmentSlotIds = null;
                    }

                }
                Session[GuId] = null;
                Response.Redirect(url);
            }
            else
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    if (CustomerType == CustomerType.Existing)
                        Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=Existing&CustomerID=" +
                            Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId));
                    else
                        Response.RedirectUser(
                            "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?RegCustomerSearchEvent=New&FirstName=" +
                            FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&Call=No" + "&guid=" + GuId);
                }
                else
                {
                    if (CustomerType == CustomerType.Existing)
                    {
                        if (RegistrationFlow.IsViciCall)
                        {
                            var setting = IoC.Resolve<ISettings>();
                            var url = setting.AppUrl + "/CallCenter/ContactCustomer/GetDialerPatient?customerId=" + RegistrationFlow.CustomerId + "&callQueueId=" + CallQueueId
                                + "&callId=" + RegistrationFlow.CallId;
                            Response.RedirectUser(url);
                        }
                        else
                        {
                            Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=Existing&CustomerID=" +
                                Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                        }
                    }
                    else
                        Response.RedirectUser(
                            "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?RegCustomerSearchEvent=New&FirstName=" +
                            FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);
                }
            }


        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            if (CurrentCustomer == null)
                CurrentCustomer = new Core.Users.Domain.Customer();

            if (!UniqueUserNameValidation()) return;
            if (!EmailValidation()) return;

            try
            {
                CustomerId = SaveCustomer();
            }
            catch (InvalidAddressException ex)
            {
                DisplayErrorMessage(ex.Message);
                return;
            }

            if (CustomerId > 0)
            {
                var customerRepository = IoC.Resolve<CustomerRepository>();
                var customer = customerRepository.GetCustomer(CustomerId);

                if (customer.EnableTexting && customer.IsSubscribed == null)
                {
                    var smsNotificaionModelFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();
                    var notifier = IoC.Resolve<INotifier>();
                    var smsNotificaionModel = smsNotificaionModelFactory.GetWellcomeSmsNotificationViewModel();
                    notifier.NotifyViaSms(NotificationTypeAlias.WellcomeSmsMessage, EmailTemplateAlias.WellcomeSmsMessage, smsNotificaionModel, customer.Id, customer.CustomerId, Request.Url.AbsolutePath);
                }
            }

            if (CustomerType == CustomerType.New)
            {
                if (!IsGiftCertificatePurchase)
                {
                    if (CurrentAction == "RegNewCustForSameEvent" ||
                        CurrentAction == "SameEvent" && Request.QueryString["Page"] == null)
                        CurrentProspectCustomerId = 0;
                    UpdateProspectCustomer();
                }
            }
            else if (CustomerType == CustomerType.Existing && !IsGiftCertificatePurchase)
                UpdateProspectCustomer();

            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
            var account = corporateAccountRepository.GetbyEventId(EventId);

            if ((account == null || account.SendWelcomeEmail) && (CurrentAction == null || !CurrentAction.Equals("Back")))
            {
                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(CurrentCustomer.UserLogin.UserName, CurrentCustomer.Name.FullName, CurrentCustomer.DateCreated);
                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, CurrentCustomer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                if (CurrentCustomer.UserLogin != null && !CurrentCustomer.UserLogin.UserVerified)
                {
                    string resetPasswordQueryString = _cryptographyService.Encrypt(DateTime.Now.ToLongDateString()).Replace("+", "X");
                    var welcomePasswordViewModel = emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(CurrentCustomer.Name.FullName, null, resetPasswordQueryString, CurrentCustomer.UserLogin.Id);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithResetMail, EmailTemplateAlias.CustomerWelcomeEmailWithPassword, welcomePasswordViewModel, CurrentCustomer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                    var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                    userLoginRepository.UpdateResetPasswordQueryString(CurrentCustomer.UserLogin.Id, resetPasswordQueryString);
                }
            }

            if (IsGiftCertificatePurchase)
            {
                Response.RedirectUser("BillingInformationExisting.aspx?gc=gc" + "&guid=" + GuId);
                return;
            }

            if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"))
            {
                UpdateCallStatus();
            }
            else if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"
                && (!string.IsNullOrEmpty(IncomingPhoneLineTextBox.Text.Trim()) || !string.IsNullOrEmpty(CallersPhoneNumberTextBox.Text.Trim())))
            {
                var oruId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                var outboundCallQueueService = IoC.Resolve<IOutboundCallQueueService>();
                outboundCallQueueService.SetCallDetail(oruId, CustomerId, IncomingPhoneLineTextBox.Text, CallersPhoneNumberTextBox.Text, Core.CallCenter.Enum.CallType.Existing_Customer.ToString().Replace("_", " "), null, account == null ? null : (long?)account.Id, ProductTypeId: CurrentCustomer.ProductTypeId);

            }

            if (CustomerId > 0 && Request.QueryString["Name"] != null)
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    Response.RedirectUser("SelectPackage.aspx?CustomerType=" + CustomerType + "&Call=No&CustomerID=" + CustomerId +
                                      "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
                else
                    Response.RedirectUser("SelectPackage.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId +
                                      "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
            }
            else if (CustomerId > 0)
            {
                Response.RedirectUser("SelectPackage.aspx?CustomerType=" + CustomerType + "&CustomerID=" + CustomerId + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("SelectPackage.aspx?CustomerType=" + CustomerType + "&guid=" + GuId);
            }
        }

        private void UpdateProspectCustomer()
        {

            var commonCode = new CommonCode();

            var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
            var prospectCustomer = (CurrentProspectCustomerId != 0 ? prospectCustomerRepository.GetProspectCustomer(CurrentProspectCustomerId) : prospectCustomerRepository.GetProspectCustomerByCustomerId(CustomerId)) ??
                                   new ProspectCustomer();

            prospectCustomer.FirstName = txtFName.Text;
            prospectCustomer.LastName = txtLName.Text;
            prospectCustomer.CallBackPhoneNumber = new PhoneNumber
                                                              {
                                                                  PhoneNumberType = PhoneNumberType.Home,
                                                                  Number = commonCode.FormatPhoneNumber(txtHPhone.Text)
                                                              };
            if (!string.IsNullOrEmpty(IncomingPhoneLineTextBox.Text))
            {
                prospectCustomer.PhoneNumber = new PhoneNumber
                                                   {
                                                       PhoneNumberType = PhoneNumberType.Unknown,
                                                       Number = commonCode.FormatPhoneNumber(IncomingPhoneLineTextBox.Text)
                                                   };
            }
            prospectCustomer.Address = new Address
                                                  {
                                                      City = txtCity.Text,
                                                      Country = ddlCountry.SelectedItem.Text,
                                                      State = hfstate.Value,
                                                      StreetAddressLine1 = txtAddress1.Text,
                                                      StreetAddressLine2 = txtAddress2.Text,
                                                      ZipCode = new ZipCode { Zip = txtZip.Text }
                                                  };
            if (!string.IsNullOrEmpty(txtDOB.Text))
                prospectCustomer.BirthDate = Convert.ToDateTime(txtDOB.Text);

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string[] emailSplitUp = txtEmail.Text.Split(new[] { '@' });

                prospectCustomer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }

            prospectCustomer.CustomerId = CustomerId;
            prospectCustomer.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
            if (rbtnGender.SelectedValue == Gender.Male.ToString() || rbtnGender.SelectedValue == Gender.Female.ToString())
                prospectCustomer.Gender = rbtnGender.SelectedValue == Gender.Male.ToString() ? Gender.Male : Gender.Female;

            prospectCustomer.Source = ProspectCustomerSource.CallCenter;
            prospectCustomer.Tag = ProspectCustomerTag.CallCenterSignup;
            prospectCustomer.TagUpdateDate = DateTime.Now;

            var eventRepository = IoC.Resolve<IEventRepository>();
            prospectCustomer.IsConverted = eventRepository.CheckCustomerRegisteredForFutureEvent(CustomerId);

            if (!prospectCustomer.IsConverted.Value)
            {
                prospectCustomer.ConvertedOnDate = null;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
                prospectCustomer.CreatedOn = DateTime.Now;
            }


            IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();

            CurrentProspectCustomerId = uniqueItemRepository.Save(prospectCustomer).Id;

            if (CallId > 0)
            {
                var callWizardService = new CallCenterCallWizardService();
                callWizardService.BindCurrentCallToProspectCustomer(CallId, CurrentProspectCustomerId, Convert.ToInt64(IoC.Resolve<ISessionContext>().UserSession.UserId));
            }
        }

        private bool UniqueUserNameValidation()
        {
            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            if (!userLoginRepository.UniqueUserName(CurrentCustomer == null ? 0 : CurrentCustomer.Id, txtUserName.Text.Trim()))
            {
                DisplayErrorMessage("This User name already registered! Please use different User name.");
                return false;
            }
            return true;
        }

        protected void imgEndCall_Click(object sender, ImageClickEventArgs e)
        {
            var commoncode = new CommonCode();
            commoncode.EndCCRepCall(Page);

        }

        private void SetDisplayControls()
        {
            Page.Title = "Customer Personal Information";
            var masterPage = Master as CallCenter_CallCenterMaster1;
            if (masterPage != null)
            {
                masterPage.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
                masterPage.hideucsearch();
                if (CustomerType == CustomerType.Existing)
                {
                    masterPage.SetTitle("Existing Customer");
                    divHintQA.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    hfCustomer.Value = "Existing";
                    StepTitleContainer.InnerText = "Existing Customer";
                    txtUserName.ReadOnly = true;
                }
                else
                {
                    masterPage.SetTitle("Customer Personal Information");
                    divHintQA.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                    hfCustomer.Value = "New";
                    StepTitleContainer.InnerText = "Register New Customer";

                }
            }
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }

        private void BindDropDownControls()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlCountry.DataSource = countries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "Id";
            ddlCountry.DataBind();
            ddlCountry.Items[0].Selected = true;
            //ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

            var races = Race.None.GetNameValuePairs();

            ddlrace.Items.Clear();
            ddlrace.DataSource = races;
            ddlrace.DataTextField = "SecondValue";
            ddlrace.DataValueField = "FirstValue";
            ddlrace.DataBind();

            var marketingSourceService = IoC.Resolve<IMarketingSourceService>();
            var marketingSources = marketingSourceService.FetchMarketingSourceByZip(ZipCode);
            MarketingSourceDropDown.DataSource = marketingSources;
            MarketingSourceDropDown.DataBind();
            MarketingSourceDropDown.Items.Insert(0, new ListItem("", ""));

            BestTimeToCallDropdown.Items.Clear();
            var bestTimeToCallTypes = BestTimeToCall.Morning.GetNameValuePairs();
            BestTimeToCallDropdown.DataSource = bestTimeToCallTypes;
            BestTimeToCallDropdown.DataTextField = "SecondValue";
            BestTimeToCallDropdown.DataValueField = "FirstValue";
            BestTimeToCallDropdown.DataBind();
            BestTimeToCallDropdown.Items.Insert(0, (new ListItem("--Select--", "0")));

            PreferredLanguageDropDown.Items.Clear();
            var languageRepository = IoC.Resolve<ILanguageRepository>();
            var languages = languageRepository.GetAll().OrderBy(x => x.Name);
            PreferredLanguageDropDown.DataSource = languages;
            PreferredLanguageDropDown.DataTextField = "Name";
            PreferredLanguageDropDown.DataValueField = "Id";
            PreferredLanguageDropDown.DataBind();
            PreferredLanguageDropDown.Items.Insert(0, (new ListItem("--Select--", "0")));
            PreferredLanguageDropDown.Items[0].Selected = true;

            ddlPreferredContactType.Items.Clear();
            var lookupReporsitory = IoC.Resolve<ILookupRepository>();
            var preferredContactTypes = lookupReporsitory.GetByLookupId((long)PreferredContactType.Email);
            ddlPreferredContactType.DataSource = preferredContactTypes.OrderBy(x => x.DisplayName);
            ddlPreferredContactType.DataTextField = "DisplayName";
            ddlPreferredContactType.DataValueField = "Id";
            ddlPreferredContactType.DataBind();

            ddlPreferredContactType.Items.Insert(0, new ListItem("--Select--", "0"));


            ddlPatientConsentPrimary.Items.Clear();
            var consentDropDown = DropDownHelper.GetPatientPhoneConsent();
            ddlPatientConsentPrimary.DataSource = consentDropDown;
            ddlPatientConsentPrimary.DataTextField = "Text";
            ddlPatientConsentPrimary.DataValueField = "Value";
            ddlPatientConsentPrimary.DataBind();

            ddlPatientConsentOffice.Items.Clear();
            ddlPatientConsentOffice.DataSource = consentDropDown;
            ddlPatientConsentOffice.DataTextField = "Text";
            ddlPatientConsentOffice.DataValueField = "Value";
            ddlPatientConsentOffice.DataBind();

            ddlPatientConsentCell.Items.Clear();
            ddlPatientConsentCell.DataSource = consentDropDown;
            ddlPatientConsentCell.DataTextField = "Text";
            ddlPatientConsentCell.DataValueField = "Value";
            ddlPatientConsentCell.DataBind();
        }

        private void SetJavaScriptEvents()
        {
            switch (CustomerType)
            {
                case CustomerType.New:
                    txtUserName.Attributes.Add("onKeyDown", "return keypress_userName(event);");
                    txtUserName.Attributes.Add("onChange", "return keyUp_userName(event);");
                    txtPassword.Attributes.Add("onKeyDown", "return txtkeypress(event);");
                    break;
                case CustomerType.Existing:
                    break;
            }
            txtDOB.Attributes["onChange"] = "ShowScript();";
            txtDOB.Attributes["onblur"] = "setFocusGender();";
            rbtEmail.Attributes["onClick"] = "CheckContactMethod('" + rbtEmail.ClientID + "'); ";
            rbtPhone.Attributes["onClick"] = "CheckContactMethod('" + rbtPhone.ClientID + "');";
        }

        private void SetCallCenterScripts()
        {
            var callCenterDal = new CallCenterDAL();
            List<EScript> objAbove40Script = callCenterDal.GetScript(callCenterDal.GetScriptType("Above 40", 2)[0].ScriptTypeID.ToString(), 4);
            if (objAbove40Script.Count > 0)
            {
                bubbleContent.InnerText = objAbove40Script[0].ScriptText;
            }


            objAbove40Script = callCenterDal.GetScript(callCenterDal.GetScriptType("New Customer Registration", 2)[0].ScriptTypeID.ToString(), 4);
            spRegisterScript.InnerText = objAbove40Script[0].ScriptText;
        }

        private void SetCustomerDataToControls()
        {
            if (CurrentCustomer != null)
            {
                var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                var userLogin = userLoginRepository.GetByUserId(CurrentCustomer.Id);
                if (CustomerType == CustomerType.Existing)
                {
                    if (string.IsNullOrEmpty(userLogin.HintQuestion))
                        divHintQA.Style.Add(HtmlTextWriterStyle.Display, "block");
                    else
                        divHintQA.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                txtUserName.Text = userLogin.UserName;
                //txtPassword.Attributes.Add("value", userLogin.Password);
                txtAnswer1.Text = userLogin.HintAnswer;

                txtFName.Text = CurrentCustomer.Name.FirstName;
                txtMName.Text = CurrentCustomer.Name.MiddleName;
                txtLName.Text = CurrentCustomer.Name.LastName;

                var commonCode = new CommonCode();

                if (CallId > 0)
                {
                    var repository = new CallCenterCallRepository();
                    var objCall = repository.GetCallCenterEntity(CallId);
                    txtHPhone.Text =
                        !string.IsNullOrEmpty(commonCode.FormatPhoneNumber(CurrentCustomer.HomePhoneNumber.ToString()))
                            ? commonCode.FormatPhoneNumber(CurrentCustomer.HomePhoneNumber.ToString())
                            : commonCode.FormatPhoneNumber(objCall.CallBackNumber);
                }
                else
                    txtHPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.HomePhoneNumber.ToString());

                txtCPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.MobilePhoneNumber.ToString());
                txtOPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.OfficePhoneNumber.ToString());
                PhoneOfficeExtension.Text = CurrentCustomer.PhoneOfficeExtension;

                if (CurrentCustomer.Email != null)
                    txtEmail.Text = CurrentCustomer.Email.ToString();
                if (CurrentCustomer.AlternateEmail != null)
                    txtEmail2.Text = CurrentCustomer.AlternateEmail.ToString();
                if (CurrentCustomer.DateOfBirth.HasValue)
                    txtDOB.Text = Convert.ToDateTime(CurrentCustomer.DateOfBirth).ToString("MM/dd/yyyy");

                if (CurrentCustomer.Height != null)
                {
                    ddlFeet.SelectedValue = CurrentCustomer.Height.Feet.ToString();
                    ddlInch.SelectedValue = CurrentCustomer.Height.Inches.ToString();
                }

                if (CurrentCustomer.Weight != null)
                    txtweight.Text = CurrentCustomer.Weight.Pounds.ToString();

                if (CurrentCustomer.Address != null)
                {
                    txtAddress1.Text = CurrentCustomer.Address.StreetAddressLine1;
                    txtAddress2.Text = CurrentCustomer.Address.StreetAddressLine2;
                    if (CurrentCustomer.Address.ZipCode != null)
                        txtZip.Text = CurrentCustomer.Address.ZipCode.Zip;
                    hfstate.Value = CurrentCustomer.Address.State;
                    ddlCountry.SelectedValue = CurrentCustomer.Address.CountryId.ToString();
                    txtCity.Text = CurrentCustomer.Address.City;
                }


                switch (CurrentCustomer.Gender)
                {
                    case Gender.Male:
                        rbtnGender.Items[0].Selected = true;
                        rbtnGender.Items[1].Selected = false;
                        break;
                    case Gender.Female:
                        rbtnGender.Items[1].Selected = true;
                        rbtnGender.Items[0].Selected = false;
                        break;
                    default:
                        rbtnGender.Items[0].Selected = false;
                        rbtnGender.Items[1].Selected = false;
                        break;
                }

                ListItem selectedRace = ddlrace.Items.FindByText(CurrentCustomer.Race.ToString());
                if (selectedRace != null)
                    selectedRace.Selected = true;

                if (CurrentCustomer.CustomerId > 0 && !CurrentCustomer.EnableTexting)
                {
                    rbtnEnableTexting.Items[1].Selected = true;
                }
                else if (CurrentCustomer.EnableTexting)
                {
                    rbtnEnableTexting.Items[0].Selected = true;
                }

                if (CurrentCustomer.CustomerId > 0 && !CurrentCustomer.EnableVoiceMail)
                {
                    rbtnEnableVoiceMail.Items[1].Selected = true;
                }
                else if (CurrentCustomer.EnableVoiceMail)
                {
                    rbtnEnableVoiceMail.Items[0].Selected = true;
                }

                if (CurrentCustomer.CustomerId > 0 && !CurrentCustomer.EnableEmail)
                {
                    rbtnEnableEmail.Items[1].Selected = true;
                }
                else if (CurrentCustomer.EnableEmail)
                {
                    rbtnEnableEmail.Items[0].Selected = true;
                }

                InsuranceIdTextbox.Text = CurrentCustomer.InsuranceId.Trim();

                if (CurrentCustomer.LanguageId.HasValue)
                {
                    var languageRepository = IoC.Resolve<ILanguageRepository>();
                    var language = languageRepository.GetById(CurrentCustomer.LanguageId.Value);
                    if (language != null)
                    {
                        //PreferredLanguageTextbox.Text = language.Name;
                        PreferredLanguageDropDown.SelectedValue = language.Id.ToString();
                    }
                }

                //PreferredLanguageTextbox.Text = CurrentCustomer.PreferredLanguage.Trim();
                if (CurrentCustomer.BestTimeToCall.HasValue && CurrentCustomer.BestTimeToCall.Value > 0)
                    BestTimeToCallDropdown.SelectedValue = CurrentCustomer.BestTimeToCall.Value.ToString();

                SsnTextbox.Text = CurrentCustomer.Ssn.Trim();
                MedicareIdTextbox.Text = CurrentCustomer.Hicn.Trim();
                MbiNumberTextbox.Text = CurrentCustomer.Mbi.Trim();
                MedicareAdvantageNumber.Text = CurrentCustomer.MedicareAdvantageNumber.Trim();
                MedicareAdvantagePlanName.Text = CurrentCustomer.MedicareAdvantagePlanName.Trim();
                if (CurrentCustomer.PreferredContactType.HasValue && CurrentCustomer.PreferredContactType.Value > 0)
                {
                    ddlPreferredContactType.SelectedValue = CurrentCustomer.PreferredContactType.Value.ToString();
                }

                if (CurrentCustomer.PhoneHomeConsentId > 0)
                {
                    ddlPatientConsentPrimary.SelectedValue = CurrentCustomer.PhoneHomeConsentId.ToString();
                }
                if (CurrentCustomer.PhoneCellConsentId > 0)
                {
                    ddlPatientConsentCell.SelectedValue = CurrentCustomer.PhoneCellConsentId.ToString();
                }
                if (CurrentCustomer.PhoneOfficeConsentId > 0)
                {
                    ddlPatientConsentOffice.SelectedValue = CurrentCustomer.PhoneOfficeConsentId.ToString();
                }
            }

        }

        private void UpdateCallStatus()
        {
            if (CallId <= 0) return;
            var repository = new CallCenterCallRepository();
            var objCall = repository.GetCallCenterEntity(CallId);

            objCall.TimeEnd = DateTime.Now.ToString();
            objCall.CalledCustomerID = CustomerId;
            objCall.IncomingPhoneLine = IncomingPhoneLineTextBox.Text;
            objCall.CallersPhoneNumber = CallersPhoneNumberTextBox.Text;
            var callcenterDal = new CallCenterDAL();
            callcenterDal.UpdateCall(objCall);
        }

        private void FillSecurityQuestions()
        {
            var masterDal = new MasterDAL();
            var securityQuestions = masterDal.GetSecurityQuestion(string.Empty, 3);

            int initialValue = GetRandomNumber(0, securityQuestions.Count - 1);
            int middleValue;
            int finalValue;

            if (initialValue == 0)
            {
                middleValue = initialValue + 1;
                finalValue = initialValue + 2;
            }
            else if (initialValue == securityQuestions.Count - 1)
            {
                middleValue = initialValue - 1;
                finalValue = initialValue - 2;
            }
            else
            {
                middleValue = initialValue + 1;
                finalValue = initialValue - 1;
            }

            ddlQues1.Items.Clear();
            ddlQues1.Items.Insert(0, new ListItem("-- Select Security Question --", ""));
            var ini = securityQuestions[initialValue];
            ddlQues1.Items.Insert(1, new ListItem(ini.Name, ini.SecurityQuestionID.ToString()));
            var mid = securityQuestions[middleValue];
            ddlQues1.Items.Insert(2, new ListItem(mid.Name, mid.SecurityQuestionID.ToString()));
            var last = securityQuestions[finalValue];
            ddlQues1.Items.Insert(3, new ListItem(last.Name, last.SecurityQuestionID.ToString()));
            ddlQues1.SelectedIndex = 0;
        }

        private static int GetRandomNumber(int min, int max)
        {
            return RandomNumberHelper.Between(min, max);
        }

        private void DisplayErrorMessage(string message)
        {
            errordiv.InnerText = message;
            errordiv.Visible = true;
            errordiv.Style["display"] = string.Empty;
        }

        private bool EmailValidation()
        {
            ICustomerRepository customerRepository = new CustomerRepository();

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!customerRepository.UniqueEmail(CurrentCustomer != null ? CurrentCustomer.CustomerId : 0, txtEmail.Text.Trim()))
                {
                    DisplayErrorMessage("This Email address already registered! Please use different Email.");
                    return false;
                }
            }
            return true;
        }

        private void SetZipCode()
        {
            if (RegistrationFlow != null && RegistrationFlow.EventId > 0)
            {
                var hostRepository = IoC.Resolve<IHostRepository>();
                var host = hostRepository.GetHostForEvent(RegistrationFlow.EventId);

                if (host != null)
                {
                    ZipCode = host.Address.ZipCode.Zip;
                }
            }
        }

        private long SaveCustomer()
        {
            var commonCode = new CommonCode();
            if (CurrentCustomer == null)
                CurrentCustomer = new Core.Users.Domain.Customer();
            CurrentCustomer.Name = new Name
                                     {
                                         FirstName = txtFName.Text,
                                         LastName = txtLName.Text,
                                         MiddleName = txtMName.Text
                                     };
            CurrentCustomer.MobilePhoneNumber = new PhoneNumber
                                                    {
                                                        PhoneNumberType = PhoneNumberType.Mobile,
                                                        Number = commonCode.FormatPhoneNumber(txtCPhone.Text)
                                                    };
            CurrentCustomer.HomePhoneNumber = new PhoneNumber
                                                  {
                                                      PhoneNumberType = PhoneNumberType.Home,
                                                      Number = commonCode.FormatPhoneNumber(txtHPhone.Text)
                                                  };
            CurrentCustomer.OfficePhoneNumber = new PhoneNumber
                                                    {
                                                        PhoneNumberType = PhoneNumberType.Office,
                                                        Number = commonCode.FormatPhoneNumber(txtOPhone.Text)
                                                    };
            CurrentCustomer.PhoneOfficeExtension = PhoneOfficeExtension.Text;
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string[] emailSplitUp = txtEmail.Text.Split(new[] { '@' });

                CurrentCustomer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            else
                CurrentCustomer.Email = null;

            if (!string.IsNullOrEmpty(txtDOB.Text))
                CurrentCustomer.DateOfBirth = Convert.ToDateTime(txtDOB.Text);
            if (CurrentCustomer.Address == null)
                CurrentCustomer.Address = new Address();
            else
                CurrentCustomer.Address = new Address(CurrentCustomer.Address.Id);
            CurrentCustomer.Address.StreetAddressLine1 = txtAddress1.Text;
            CurrentCustomer.Address.StreetAddressLine2 = txtAddress2.Text;
            CurrentCustomer.Address.ZipCode = new ZipCode { Zip = txtZip.Text };
            CurrentCustomer.Address.Country = ddlCountry.SelectedItem.Text;
            CurrentCustomer.Address.State = hfstate.Value;
            CurrentCustomer.Address.City = txtCity.Text;
            if (CurrentCustomer.UserLogin == null)
            {
                CurrentCustomer.UserLogin = new UserLogin
                                              {
                                                  UserName = txtUserName.Text,
                                                  Password = txtPassword.Text,
                                                  HintQuestion = string.IsNullOrWhiteSpace(ddlQues1.SelectedValue) ? "" : ddlQues1.SelectedItem.Text,
                                                  HintAnswer = String.IsNullOrWhiteSpace(txtAnswer1.Text) ? "" : txtAnswer1.Text,
                                                  IsSecurityQuestionVerified = false,
                                                  UserVerified = false
                                              };
            }
            else if (string.IsNullOrEmpty(CurrentCustomer.UserLogin.HintQuestion))
            {
                CurrentCustomer.UserLogin.UserName = txtUserName.Text;
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    CurrentCustomer.UserLogin.Password = txtPassword.Text;
                    CurrentCustomer.UserLogin.Salt = null;
                }
                CurrentCustomer.UserLogin.HintQuestion = string.IsNullOrWhiteSpace(ddlQues1.SelectedValue)
                                                             ? ""
                                                             : ddlQues1.SelectedItem.Text;
                CurrentCustomer.UserLogin.HintAnswer = String.IsNullOrWhiteSpace(txtAnswer1.Text) ? "" : txtAnswer1.Text;

            }
            if (!string.IsNullOrEmpty(txtEmail2.Text))
            {
                string[] emailSplitUp = txtEmail2.Text.Split(new[] { '@' });

                CurrentCustomer.AlternateEmail = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            else
                CurrentCustomer.AlternateEmail = null;

            if (rbtnGender.SelectedValue == Gender.Male.ToString() || rbtnGender.SelectedValue == Gender.Female.ToString())
                CurrentCustomer.Gender = rbtnGender.SelectedValue == Gender.Male.ToString() ? Gender.Male : Gender.Female;

            if (CustomerType == CustomerType.New)
            {
                CurrentCustomer.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
                CurrentCustomer.AddedByRoleId = Convert.ToInt64(Roles.CallCenterRep);
            }
            else if (CustomerId <= 0)
            {
                CurrentCustomer.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
                CurrentCustomer.AddedByRoleId = Convert.ToInt64(Roles.CallCenterRep);
            }
            RegistrationFlow.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
            if (Convert.ToInt64(ddlFeet.SelectedValue) > 0 || Convert.ToInt64(ddlInch.SelectedValue) > 0)
                CurrentCustomer.Height = new Height(Convert.ToInt64(ddlFeet.SelectedValue),
                                                    Convert.ToInt64(ddlInch.SelectedValue));
            double weight;
            if (txtweight.Text.Trim().Length > 0 && Double.TryParse(txtweight.Text.Trim(), out weight))
            {
                CurrentCustomer.Weight = new Weight(weight);
            }
            if (ddlrace.SelectedItem.Text != "Select Race")
                CurrentCustomer.Race = (Race)Enum.Parse(typeof(Race), ddlrace.SelectedValue);


            CurrentCustomer.InsuranceId = InsuranceIdTextbox.Text.Trim();

            var prefferedLanguage = PreferredLanguageDropDown.SelectedItem.Text;
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            if (!string.IsNullOrEmpty(prefferedLanguage))
            {
                var languageRepository = IoC.Resolve<ILanguageRepository>();

                var languageService = IoC.Resolve<ILanguageService>();
                var language = languageRepository.GetByName(prefferedLanguage) ??
                               languageService.AddLanguage(prefferedLanguage, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);


                CurrentCustomer.LanguageId = language.Id;
            }
            else
            {
                CurrentCustomer.LanguageId = null;
            }

            CurrentCustomer.BestTimeToCall = Convert.ToInt64(BestTimeToCallDropdown.SelectedValue);

            CurrentCustomer.Ssn = SsnTextbox.Text.Replace("-", "").Trim();
            CurrentCustomer.EnableTexting = rbtnEnableTexting.SelectedValue == "true";
            CurrentCustomer.EnableVoiceMail = rbtnEnableVoiceMail.SelectedValue == "true";
            CurrentCustomer.EnableEmail = rbtnEnableEmail.SelectedValue == "true";
            CurrentCustomer.Hicn = MedicareIdTextbox.Text.Trim();
            CurrentCustomer.Mbi = MbiNumberTextbox.Text.Trim();
            CurrentCustomer.MedicareAdvantageNumber = MedicareAdvantageNumber.Text.Trim();
            CurrentCustomer.MedicareAdvantagePlanName = MedicareAdvantagePlanName.Text.Trim();
            CurrentCustomer.PreferredContactType = ddlPreferredContactType.SelectedIndex > 0 ? (long?)long.Parse(ddlPreferredContactType.SelectedValue) : null;

            CurrentCustomer.PhoneHomeConsentId = long.Parse(ddlPatientConsentPrimary.SelectedValue);
            CurrentCustomer.PhoneCellConsentId = long.Parse(ddlPatientConsentCell.SelectedValue);
            CurrentCustomer.PhoneOfficeConsentId = long.Parse(ddlPatientConsentOffice.SelectedValue);

            var customerService = IoC.Resolve<ICustomerService>();
            customerService.SaveCustomer(CurrentCustomer, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

            return CurrentCustomer.CustomerId;
        }

        private void SetProspectCustomerDataToControls()
        {

            if (CurrentProspectCustomerId != 0)
            {
                var currentProspectCustomer = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>().GetById(CurrentProspectCustomerId);

                txtFName.Text = currentProspectCustomer.FirstName;
                txtLName.Text = currentProspectCustomer.LastName;
                txtCity.Text = currentProspectCustomer.Address.City;
                hfstate.Value = currentProspectCustomer.Address.State;
                var commonCode = new CommonCode();
                txtHPhone.Text = currentProspectCustomer.CallBackPhoneNumber != null
                                     ? commonCode.FormatPhoneNumber(
                                           currentProspectCustomer.CallBackPhoneNumber.ToString())
                                     : null;
                if (currentProspectCustomer.Address != null && currentProspectCustomer.Address.ZipCode != null)
                    txtZip.Text = currentProspectCustomer.Address.ZipCode.Zip;


                if (!string.IsNullOrEmpty(txtZip.Text.Trim()) && string.IsNullOrEmpty(txtCity.Text.Trim()) && string.IsNullOrEmpty(hfstate.Value))
                {
                    try
                    {
                        IAddressService addressService = new AddressService();
                        var addressByZipCode = addressService.GetSanitizeAddress(txtZip.Text.Trim());

                        if (addressByZipCode != null)
                        {
                            txtCity.Text = addressByZipCode.City;
                            hfstate.Value = addressByZipCode.State;
                        }
                    }
                    catch {/* TODO: We have to more elegantly handle this exception.*/}
                }
            }
            else
            {
                txtFName.Text = FirstName;
                txtLName.Text = LastName;
                txtZip.Text = Zip;
            }

            ddlPatientConsentPrimary.SelectedValue = ddlPatientConsentCell.SelectedValue = ddlPatientConsentOffice.SelectedValue = ((long)PatientConsent.Unknown).ToString();
        }

        private void HideUserCredentialPanel()
        {
            var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(RegistrationFlow.EventId);
            if (account != null && !account.AllowCustomerPortalLogin)
            {
                if (CustomerId <= 0)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode", "GenerateUserName();GeneratePassword();", true);
                }

                divHintQA.Style.Add(HtmlTextWriterStyle.Display, "none");
                divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                
                PasswordNotTobeValidate = true;
            }
        }

    }
}
