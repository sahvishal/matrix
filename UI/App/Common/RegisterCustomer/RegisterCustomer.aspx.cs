using System;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
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
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Lib;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Lib;
using Falcon.DataAccess.CallCenter;
using Falcon.App.Core.Extensions;
using Falcon.DataAccess.Master;
using Falcon.App.UI.HtmlHelpers;

namespace Falcon.App.UI.App.Common.RegisterCustomer
{
    public partial class RegisterCustomer : BasePage
    {

        private dynamic customerLogEditModel = new ExpandoObject();
        private dynamic prospectCustomerLogEditModel = new ExpandoObject();
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

        protected bool EnableSmsNotification
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
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
            set { RegistrationFlow.CustomerId = value; }
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

        private Event _eventData;
        private Event EventData
        {
            get { return _eventData ?? (_eventData = EventId > 0 ? EventRepository.GetEventOnlyById(EventId) : null); }
        }

        private IEventCustomerPackageTestDetailService _packageTestDetailService;
        private IEventCustomerPackageTestDetailService PackageTestDetailService
        {
            get
            {
                return _packageTestDetailService ?? (_packageTestDetailService = IoC.Resolve<IEventCustomerPackageTestDetailService>());
            }
        }

        private CorporateAccount _accountByEventId;
        private CorporateAccount AccountByEventId
        {
            get
            {
                if (_accountByEventId == null && EventId > 0)
                {
                    _accountByEventId = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId);
                }

                return _accountByEventId;
            }
        }

        public string FirstName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FirstName"]))
                {
                    return Request.QueryString["FirstName"];
                }
                return string.Empty;
            }
        }
        public string LastName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LastName"]))
                {
                    return Request.QueryString["LastName"];
                }
                return string.Empty;
            }
        }
        public string ZipCode
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ZipCode"]))
                {
                    return Request.QueryString["ZipCode"];
                }
                return string.Empty;
            }
        }
        public long State
        {
            get
            {
                long stateId = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["State"]))
                {
                    long.TryParse(Request.QueryString["State"], out stateId);
                }
                return stateId;
            }
        }

        private ProspectCustomer CurrentProspectCustomer
        {
            get
            {
                return new ProspectCustomer()
                           {
                               FirstName = this.FirstName,
                               LastName = this.LastName,
                               Address = new Address()
                                             {
                                                 StateId = this.State,
                                                 ZipCode = new ZipCode() { Zip = this.ZipCode }
                                             }
                           };

            }
        }

        private long EventId
        {
            get
            {
                return RegistrationFlow != null && RegistrationFlow.EventId > 0
                           ? RegistrationFlow.EventId
                           : (Request.QueryString["EventId"] != null
                                  ? Convert.ToInt64(Request.QueryString["EventId"])
                                  : 0);
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

        protected bool PasswordNotTobeValidate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDisplayControls();

            if (!IsPostBack)
            {
                if (RegistrationFlow != null)
                {
                    RegistrationFlow.SourceCodeId = 0;
                    RegistrationFlow.SourceCode = string.Empty;
                    RegistrationFlow.SourceCodeAmount = 0;
                    RegistrationFlow.TestIds = null;
                    RegistrationFlow.PackageId = 0;
                    RegistrationFlow.AppointmentSlotIds = null;
                    RegistrationFlow.ShippingDetailId = 0;
                    RegistrationFlow.ShippingOptionId = 0;
                    RegistrationFlow.ShippingAddressId = 0;
                    RegistrationFlow.ProductId = 0;
                }

                FillSecurityQuestions();
                BindDropDownControls();
                if (CustomerType == CustomerType.New && CurrentAction != null && CurrentAction.Equals("Back"))
                {
                    isPageOpenedByBackClick.Value = "true";
                    MarketingSourceDropDown.SelectedValue = CurrentCustomer.MarketingSource;
                }

                if (CurrentAction != null || CurrentProspectCustomer == null)
                {
                    SetCustomerDataToControls();
                    LogAudit(ModelType.View, customerLogEditModel, CustomerId);
                }
                else
                {
                    SetProspectCustomerDataToControls();
                    LogAudit(ModelType.View, prospectCustomerLogEditModel, CustomerId);
                }
                SetJavaScriptEvents();

                var callCenterDal = new CallCenterDAL();
                var listScriptType = callCenterDal.GetScriptType("Above 40", 2);
                var objAbove40Script = callCenterDal.GetScript(listScriptType[0].ScriptTypeID.ToString(), 4);
                if (objAbove40Script.Count > 0)
                {
                    bubbleContent.InnerText = objAbove40Script[0].ScriptText;
                }

                ViewState["RefferedUrl"] = Request.UrlReferrer.PathAndQuery;


                InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                InsuranceIdRequiredHiddenField.Value = Boolean.FalseString;
                var settings = IoC.Resolve<ISettings>();
                if (settings.CaptureInsuranceId)
                {
                    if (EventData != null && EventData.CaptureInsuranceId)
                    {
                        InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
                        if (EventData.InsuranceIdRequired)
                            InsuranceIdRequiredHiddenField.Value = Boolean.TrueString;
                    }
                }
                SsnContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
                if (EventId > 0)
                {
                    var captureSsn = EventRepository.CaptureSsn(EventId);
                    if (captureSsn)
                        SsnContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
            }
            HideUserCredentialPanel();

            var toolTipRepository = IoC.Resolve<IToolTipRepository>();
            var insuranceIdLabel = toolTipRepository.GetToolTipContentByTag(ToolTipType.InsuranceIdLabel);
            insuranceIdLabel = string.IsNullOrEmpty(insuranceIdLabel) ? "Insurance Id" : (insuranceIdLabel);

            if (AccountByEventId != null && !string.IsNullOrEmpty(AccountByEventId.MemberIdLabel))
            {
                insuranceIdLabel = AccountByEventId.MemberIdLabel;
            }

            InsuranceIdLabel.InnerText = insuranceIdLabel;

            MedicareIdRequiredHiddenField.Value = Boolean.FalseString;

            if (EventId <= 0) return;

            var eventTestRepository = IoC.Resolve<EventTestRepository>();

            var eventTestList = eventTestRepository.GetTestsForEvent(EventId);
            MedicareIdRequiredHiddenField.Value = eventTestList != null && eventTestList.Any(x => x.TestId == (long)TestType.AWV) ? Boolean.TrueString : Boolean.FalseString;
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            if (!EmailValidation()) return;
            if (!UniqueUserNameValidation()) return;
            try
            {
                CustomerId = SaveCustomer();
                CreateProspectCustomer();
            }
            catch (InvalidAddressException ex)
            {
                DisplayErrorMessage(ex.Message);
                return;
            }

            if (CustomerId > 0)
            {
                if (CurrentCustomer.EnableTexting && CurrentCustomer.IsSubscribed == null)
                {
                    var smsNotificaionModelFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();
                    var notifier = IoC.Resolve<INotifier>();
                    var smsNotificaionModel = smsNotificaionModelFactory.GetWellcomeSmsNotificationViewModel();
                    notifier.NotifyViaSms(NotificationTypeAlias.WellcomeSmsMessage, EmailTemplateAlias.WellcomeSmsMessage, smsNotificaionModel, CurrentCustomer.Id, CurrentCustomer.CustomerId, Request.Url.AbsolutePath);
                }
            }

            if (CurrentAction == null || !CurrentAction.Equals("Back"))
            {
                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                if (AccountByEventId == null || AccountByEventId.SendWelcomeEmail)
                {
                    var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(CurrentCustomer.UserLogin.UserName, CurrentCustomer.Name.FullName, CurrentCustomer.DateCreated);
                    notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, CurrentCustomer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                    if (CurrentCustomer.UserLogin != null && !CurrentCustomer.UserLogin.UserVerified)
                    {
                        var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
                        customerRegistrationService.SendResetPasswordMail(CurrentCustomer.Id, CurrentCustomer.Name.FullName, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                    }
                }

            }
            long eventid = Convert.ToInt64(Request.QueryString["Eventid"]);

            //check for existing or new customer
            if (Request.QueryString["Eventid"] != null)
            {
                if (Request.QueryString["Customer"] != null)
                {
                    if (CustomerType == CustomerType.New)
                    {
                        RegistrationFlow.ProspectCustomerId = 0;
                        Response.RedirectUser("/App/Common/RegisterCustomer/SelectPackage.aspx?EventID=" + eventid + "&From=ECL&Customer=" + Request.QueryString["Customer"] + "&guid=" + GuId);
                    }
                    else if (CustomerType == CustomerType.Existing)
                    {
                        if (!EventValidation()) return;
                        Response.RedirectUser("/App/Common/RegisterCustomer/SelectPackage.aspx?Customer=Existing&EventID=" + eventid + "&guid=" + GuId);
                    }

                }
            }
            else if (Request.QueryString["Customer"] != null && CustomerType == CustomerType.Existing && Request.QueryString["Eventid"] == null)
            {
                Response.RedirectUser("RegCustomerSearchEvent.aspx?Customer=Existing" + "&guid=" + GuId);
            }
            else
            {
                RegistrationFlow.ProspectCustomerId = 0;
                Response.RedirectUser("RegCustomerSearchEvent.aspx?guid=" + GuId);
            }

        }

        protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (CustomerType == CustomerType.Existing)
            {
                Response.RedirectUser(ViewState["RefferedUrl"].ToString());
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

            MarketingSourceDropDown.Items.Clear();
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
            var ini = securityQuestions[initialValue];
            ddlQues1.Items.Insert(0, new ListItem(ini.Name, ini.SecurityQuestionID.ToString()));
            var mid = securityQuestions[middleValue];
            ddlQues1.Items.Insert(1, new ListItem(mid.Name, mid.SecurityQuestionID.ToString()));
            var last = securityQuestions[finalValue];
            ddlQues1.Items.Insert(2, new ListItem(last.Name, last.SecurityQuestionID.ToString()));
            ddlQues1.SelectedIndex = 0;
        }

        private static int GetRandomNumber(int min, int max)
        {
            return RandomNumberHelper.Between(min, max);
        }

        private void SetJavaScriptEvents()
        {
            txtDOB.Attributes["onChange"] = "ShowScript();";
            txtDOB.Attributes["onblur"] = "setFocusGender();";
            txtPassword.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtUserName.Attributes.Add("onKeyDown", "return keypress_userName(event);");
            txtUserName.Attributes.Add("onKeyUp", "return keyUp_userName(event);");
        }

        private void SetProspectCustomerDataToControls()
        {

            if (CurrentProspectCustomer != null)
            {
                prospectCustomerLogEditModel.FirstName = txtFName.Text = CurrentProspectCustomer.FirstName;
                prospectCustomerLogEditModel.LastName = txtLName.Text = CurrentProspectCustomer.LastName;
                prospectCustomerLogEditModel.City = txtCity.Text = CurrentProspectCustomer.Address.City;
                prospectCustomerLogEditModel.State = hfstate.Value = CurrentProspectCustomer.Address.State;


                if (CurrentProspectCustomer.Address != null && CurrentProspectCustomer.Address.ZipCode != null)
                    prospectCustomerLogEditModel.Zip = txtZip.Text = CurrentProspectCustomer.Address.ZipCode.Zip;


                if (!string.IsNullOrEmpty(txtZip.Text.Trim()) && string.IsNullOrEmpty(txtCity.Text.Trim()) && string.IsNullOrEmpty(hfstate.Value))
                {
                    try
                    {
                        IAddressService addressService = new AddressService();
                        var addressByZipCode = addressService.GetSanitizeAddress(txtZip.Text.Trim());

                        if (addressByZipCode != null)
                        {
                            prospectCustomerLogEditModel.City = txtCity.Text = addressByZipCode.City;
                            prospectCustomerLogEditModel.State = hfstate.Value = addressByZipCode.State;
                        }
                    }
                    catch {/* TODO: We have to more elegantly handle this exception.*/}
                }

                ddlPatientConsentPrimary.SelectedValue = ddlPatientConsentCell.SelectedValue = ddlPatientConsentOffice.SelectedValue = ((long)PatientConsent.Unknown).ToString();
            }
        }

        private void SetCustomerDataToControls()
        {
            if (CurrentCustomer != null)
            {

                customerLogEditModel.FirstName = txtFName.Text = CurrentCustomer.Name.FirstName;
                customerLogEditModel.MiddleName = txtMName.Text = CurrentCustomer.Name.MiddleName;
                customerLogEditModel.LastName = txtLName.Text = CurrentCustomer.Name.LastName;

                if (CurrentCustomer.Address != null)
                {
                    customerLogEditModel.AddressLine1 = txtAddress1.Text = CurrentCustomer.Address.StreetAddressLine1;
                    customerLogEditModel.AddressLine2 = txtAddress2.Text = CurrentCustomer.Address.StreetAddressLine2;
                    customerLogEditModel.Zip = txtZip.Text = CurrentCustomer.Address.ZipCode.Zip;
                    customerLogEditModel.State = hfstate.Value = CurrentCustomer.Address.State;
                    customerLogEditModel.City = txtCity.Text = CurrentCustomer.Address.City;
                    ddlCountry.ClearSelection();
                    ddlCountry.SelectedValue = CurrentCustomer.Address.CountryId.ToString();
                    customerLogEditModel.Country = ddlCountry.SelectedItem.Text;
                }

                var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                var userLogin = userLoginRepository.GetByUserId(CurrentCustomer.Id);
                if (string.IsNullOrEmpty(userLogin.HintQuestion))
                    pHintQues.Style.Add(HtmlTextWriterStyle.Display, "block");
                else
                {
                    var item = ddlQues1.Items.FindByText(userLogin.HintQuestion);
                    if (item != null)
                    {
                        ddlQues1.ClearSelection();
                        item.Selected = true;
                        customerLogEditModel.HintQuestion = item.Text;
                    }
                }

                if (string.IsNullOrEmpty(userLogin.HintAnswer))
                    pHintAns.Style.Add(HtmlTextWriterStyle.Display, "block");
                else
                    txtAnswer.Text = userLogin.HintAnswer;

                customerLogEditModel.Username = txtUserName.Text = userLogin.UserName;
                //txtPassword.Attributes.Add("value", userLogin.Password);

                var commonCode = new CommonCode();

                customerLogEditModel.MobilePhoneNumber = txtCPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.MobilePhoneNumber.ToString());
                customerLogEditModel.HomePhoneNumber = txtHPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.HomePhoneNumber.ToString());
                customerLogEditModel.OfficePhoneNumber = txtOPhone.Text = commonCode.FormatPhoneNumber(CurrentCustomer.OfficePhoneNumber.ToString());
                customerLogEditModel.OfficePhoneExtension = PhoneOfficeExtension.Text = CurrentCustomer.PhoneOfficeExtension;

                customerLogEditModel.Email = txtEmail.Text = CurrentCustomer.Email.ToString();
                customerLogEditModel.EmailSecondary = txtEmail2.Text = CurrentCustomer.AlternateEmail.ToString();
                if (CurrentCustomer.DateOfBirth.HasValue)
                    customerLogEditModel.DateOfBirth = txtDOB.Text = Convert.ToDateTime(CurrentCustomer.DateOfBirth).ToString("MM/dd/yyyy");

                if (CurrentCustomer.Height != null)
                {
                    customerLogEditModel.Feet = ddlFeet.SelectedValue = CurrentCustomer.Height.Feet.ToString();
                    customerLogEditModel.Inches = ddlInch.SelectedValue = CurrentCustomer.Height.Inches.ToString();
                }

                if (CurrentCustomer.Weight != null)
                    customerLogEditModel.Weight = txtweight.Text = CurrentCustomer.Weight.Pounds.ToString();



                switch (CurrentCustomer.Gender)
                {
                    case Gender.Male:
                        rbtnGender.Items[0].Selected = true;
                        rbtnGender.Items[1].Selected = false;
                        customerLogEditModel.Gender = "Male";
                        break;
                    case Gender.Female:
                        rbtnGender.Items[1].Selected = true;
                        rbtnGender.Items[0].Selected = false;
                        customerLogEditModel.Gender = "Female";
                        break;
                    default:
                        rbtnGender.Items[0].Selected = false;
                        rbtnGender.Items[1].Selected = false;
                        break;
                }

                txtUserName.ReadOnly = true;
                customerLogEditModel.Race = CurrentCustomer.Race;
                ListItem selectedRace = ddlrace.Items.FindByText(CurrentCustomer.Race.ToString());
                if (selectedRace != null)
                    selectedRace.Selected = true;

                if (CurrentCustomer.CustomerId > 0 && !CurrentCustomer.EnableTexting)
                {
                    rbtnEnableTexting.Items[1].Selected = true;
                    customerLogEditModel.EnableTexting = "false";
                }
                else if (CurrentCustomer.EnableTexting)
                {
                    rbtnEnableTexting.Items[0].Selected = true;
                    customerLogEditModel.EnableTexting = "true";
                }
                if (CurrentCustomer.CustomerId > 0 && !CurrentCustomer.EnableVoiceMail)
                {
                    rbtnEnableVoiceMail.Items[1].Selected = true;
                    customerLogEditModel.EnableVoiceMail = "false";
                }
                else if (CurrentCustomer.EnableVoiceMail)
                {
                    rbtnEnableVoiceMail.Items[0].Selected = true;
                    customerLogEditModel.EnableVoiceMail = "true";
                }

                if (CurrentCustomer.CustomerId > 0 && CurrentCustomer.EnableEmail)
                {
                    rbtnEnableEmail.Items[0].Selected = true;
                    customerLogEditModel.EnableEmail = true;
                }
                else
                {
                    rbtnEnableEmail.Items[1].Selected = true;
                    customerLogEditModel.EnableEmail = false;
                }

                customerLogEditModel.InsuranceId = InsuranceIdTextbox.Text = CurrentCustomer.InsuranceId.Trim();

                if (CurrentCustomer.LanguageId.HasValue)
                {
                    var languageRepository = IoC.Resolve<ILanguageRepository>();
                    var language = languageRepository.GetById(CurrentCustomer.LanguageId.Value);

                    if (language != null)
                    {
                        //    customerLogEditModel.LanguageName = PreferredLanguageTextbox.Text = language.Name;
                        customerLogEditModel.LanguageName = language.Name;
                        PreferredLanguageDropDown.SelectedValue = language.Id.ToString();
                    }
                }
                PreferredLanguageDropDown.SelectedValue = CurrentCustomer.LanguageId.ToString();
                if (CurrentCustomer.BestTimeToCall.HasValue && CurrentCustomer.BestTimeToCall.Value > 0)
                    customerLogEditModel.BestTimeToCall = BestTimeToCallDropdown.SelectedValue = CurrentCustomer.BestTimeToCall.Value.ToString();

                SsnTextbox.Text = CurrentCustomer.Ssn.Trim();
                customerLogEditModel.MedicareId = MedicareIdTextbox.Text = CurrentCustomer.Hicn.Trim();
                customerLogEditModel.MBINumber = MBINumberTextbox.Text = CurrentCustomer.Mbi.Trim();
                customerLogEditModel.MedicareAdvantageNumber = MedicareAdvantageNumber.Text = CurrentCustomer.MedicareAdvantageNumber.Trim();
                customerLogEditModel.MedicareAdvantagePlanName = MedicareAdvantagePlanName.Text = CurrentCustomer.MedicareAdvantagePlanName.Trim();
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

        private void SetDisplayControls()
        {
            Page.Title = "Customer Personal Information";
            var technicianMaster = Master as Franchisee_Technician_TechnicianMaster;
            if (technicianMaster != null)
            {
                technicianMaster.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";

                if (CustomerType == CustomerType.Existing)
                {
                    technicianMaster.settitle("Existing Customer");
                    dvTitle.InnerText = "Technician Register Customer";
                    ppageinnertitle.InnerText = "Existing Customer";
                    spbtnBack.Visible = true;
                    imgReset.Visible = false;
                    pHintQues.Style.Add(HtmlTextWriterStyle.Display, "none");
                    pHintAns.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "none");
                    hfCustomer.Value = "Existing";
                }
                else
                {
                    imgSymbol.Src = "/App/Images/CCRep/page1symbol.gif";
                    technicianMaster.settitle("Register New Customer");
                    dvTitle.InnerText = "Technician Register Customer";
                    ppageinnertitle.InnerText = "New Customer";
                    spbtnBack.Visible = false;
                    pHintQues.Style.Add(HtmlTextWriterStyle.Display, "block");
                    pHintAns.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "block");
                    hfCustomer.Value = "New";
                }
            }
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

        private bool EventValidation()
        {
            if (EventCustomer != null && EventCustomer.AppointmentId.HasValue)
            {
                var packageTestDetail = PackageTestDetailService.GetEventPackageDetails(EventCustomer.Id);
                var appointment = IoC.Resolve<IAppointmentRepository>().GetById(EventCustomer.AppointmentId.Value);
                if (packageTestDetail != null)
                {
                    var packageAndTest = packageTestDetail.Package != null ? packageTestDetail.Package.Name : string.Empty;
                    var additinalTest = packageTestDetail.Tests.IsNullOrEmpty() ? string.Empty : string.Join(",", packageTestDetail.Tests.Select(x => x.Name).ToArray());

                    packageAndTest = string.IsNullOrEmpty(packageAndTest) ? additinalTest : packageAndTest + (string.IsNullOrEmpty(additinalTest) ? string.Empty : ", " + additinalTest);

                    divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divErrorMsg.InnerHtml = CurrentCustomer.NameAsString + " is already registered for this event (" + EventData.Name + " ) at " +
                                            EventData.EventDate.ToString("dddd dd MMMM yyyy") + " " + appointment.StartTime.ToString("hh:mm tt") + " for the " + packageAndTest +
                                            ". Duplicate registrations for the same customer are not allowed.";
                }

                return false;
            }

            return true;
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
                CurrentCustomer.UserLogin = new UserLogin
                                                {
                                                    UserName = txtUserName.Text,
                                                    Password = txtPassword.Text,
                                                    HintQuestion = ddlQues1.SelectedItem.Text,
                                                    HintAnswer = txtAnswer.Text,
                                                    IsSecurityQuestionVerified = false,
                                                    UserVerified = false
                                                };
            else
            {
                CurrentCustomer.UserLogin.UserName = txtUserName.Text;
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    CurrentCustomer.UserLogin.Password = txtPassword.Text;
                    CurrentCustomer.UserLogin.Salt = null;
                }
                CurrentCustomer.UserLogin.HintQuestion = string.IsNullOrEmpty(CurrentCustomer.UserLogin.HintQuestion) ? ddlQues1.SelectedItem.Text : CurrentCustomer.UserLogin.HintQuestion;
                CurrentCustomer.UserLogin.HintAnswer = string.IsNullOrEmpty(CurrentCustomer.UserLogin.HintAnswer) ? txtAnswer.Text : CurrentCustomer.UserLogin.HintAnswer;
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
                CurrentCustomer.AddedByRoleId = Convert.ToInt64(Roles.Technician);
            }
            else if (CustomerId <= 0)
            {
                CurrentCustomer.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
                CurrentCustomer.AddedByRoleId = Convert.ToInt64(Roles.Technician);
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
            CurrentCustomer.PreferredLanguage = PreferredLanguageDropDown.SelectedItem.Text;
            CurrentCustomer.BestTimeToCall = Convert.ToInt64(BestTimeToCallDropdown.SelectedValue);

            CurrentCustomer.Ssn = SsnTextbox.Text.Replace("-", "").Trim();
            CurrentCustomer.Hicn = MedicareIdTextbox.Text.Trim();
            CurrentCustomer.Mbi = MBINumberTextbox.Text.Trim();

            CurrentCustomer.MedicareAdvantageNumber = MedicareAdvantageNumber.Text.Trim();
            CurrentCustomer.MedicareAdvantagePlanName = MedicareAdvantagePlanName.Text.Trim();
            CurrentCustomer.EnableTexting = rbtnEnableTexting.SelectedValue == "true";
            CurrentCustomer.EnableVoiceMail = rbtnEnableVoiceMail.SelectedValue == "true";

            CurrentCustomer.EnableEmail = rbtnEnableEmail.SelectedValue == "true";

            CurrentCustomer.PreferredContactType = ddlPreferredContactType.SelectedIndex > 0 ? (long?)long.Parse(ddlPreferredContactType.SelectedValue) : null;

            CurrentCustomer.PhoneHomeConsentId = long.Parse(ddlPatientConsentPrimary.SelectedValue);
            CurrentCustomer.PhoneCellConsentId = long.Parse(ddlPatientConsentCell.SelectedValue);
            CurrentCustomer.PhoneOfficeConsentId = long.Parse(ddlPatientConsentOffice.SelectedValue);

            var customerService = IoC.Resolve<ICustomerService>();
            customerService.SaveCustomer(CurrentCustomer, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);
            LogAudit(ModelType.Edit, CurrentCustomer, CustomerId);
            return CurrentCustomer.CustomerId;
        }

        private void CreateProspectCustomer()
        {
            var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
            var prospectCustomer = ((IProspectCustomerRepository)prospectCustomerRepository).GetProspectCustomerByCustomerId(CustomerId);

            var customer = CurrentCustomer;
            if (prospectCustomer == null)
            {
                prospectCustomer = new ProspectCustomer
                                       {
                                           FirstName = customer.Name.FirstName,
                                           LastName = customer.Name.LastName,
                                           Gender = customer.Gender,
                                           Address = customer.Address,
                                           CallBackPhoneNumber = customer.HomePhoneNumber,
                                           Email = customer.Email,
                                           BirthDate = customer.DateOfBirth,
                                           MarketingSource = customer.MarketingSource,
                                           CustomerId = CustomerId,
                                           Source = ProspectCustomerSource.CallCenter,
                                           Tag = ProspectCustomerTag.Unspecified,
                                           CreatedOn = DateTime.Now,
                                           IsConverted = false,
                                           Status = (long)ProspectCustomerConversionStatus.NotConverted,
                                           TagUpdateDate = DateTime.Now

                                       };
                prospectCustomerRepository.Save(prospectCustomer);
            }
        }

        protected void HideUserCredentialPanel()
        {
            if (EventId > 0)
            {
                var account = IoC.Resolve<ICorporateAccountRepository>().GetbyEventId(EventId);
                if (account != null && !account.AllowCustomerPortalLogin)
                {
                    if (CustomerId <= 0)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "JSCode", "GenerateUserName();GeneratePassword();", true);
                    }

                    pHintQues.Style.Add(HtmlTextWriterStyle.Display, "none");
                    pHintAns.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divExistinggCust.Style.Add(HtmlTextWriterStyle.Display, "none");

                    if (isPageOpenedByBackClick.Value == "true")
                    {
                        PasswordNotTobeValidate = true;
                    }
                }
            }
        }
    }
}