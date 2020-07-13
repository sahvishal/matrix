using System;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.Core.Extensions;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Customer
{
    public partial class UpdateEventCustomerProfile : BasePage
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
            set { Session[GuId] = value; }
        }

        private long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }

        private long CustomerId
        {
            set
            {
                RegistrationFlow.CustomerId = value;
            }
        }

        protected long UserId
        {
            get
            {
                return IoC.Resolve<ISessionContext>().UserSession.UserId;
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
        protected bool IsOtpBySmsEnabled
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumSms));
            }
        }
        protected bool IsOtpByEmailEnabled
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.OtpNotificationMediumEmail));
            }
        }
        protected bool IsOtpByAppEnabled
        {
            get
            {
                var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
                return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.OtpByGoogleAuthenticator));
            }
        }

        protected bool IsPinRequiredForRole { get; set; }
        protected bool IsAuthenticationForUserEnabled { get; set; }

        protected long? AuthenticationModeId { get; set; }

        private const string DDL_VALUE_ID = "Id";
        private const string DDL_TEXT_NAME = "Name";

        protected string ZipCode = "";

        protected bool IsUpdateProfile
        {
            get
            {
                if (Request.QueryString["Ref"] == "DashBoard")
                    return true;
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUpdateProfile)
            {
                var roles = IoC.Resolve<ISessionContext>().UserSession.AvailableOrganizationRoles;
                var defaultRole = roles.Where(x => x.IsDefault).FirstOrDefault();
                if (defaultRole != null)
                {
                    var roleRepository = IoC.Resolve<IRoleRepository>();
                    var role = roleRepository.GetByRoleId(defaultRole.RoleId);
                    IsPinRequiredForRole = role.IsPinRequired;
                    IsAuthenticationForUserEnabled = role.IsTwoFactorAuthrequired;
                }
                else
                {
                    IsPinRequiredForRole = false;
                }
                var userLogin = IoC.Resolve<IUserLoginRepository>().GetByUserId(UserId);
                if (userLogin.IsTwoFactorAuthrequired != null)
                {
                    IsAuthenticationForUserEnabled = userLogin.IsTwoFactorAuthrequired.Value;
                }

                if ((IsOtpBySmsEnabled || IsOtpByEmailEnabled || IsOtpByAppEnabled) && IsAuthenticationForUserEnabled)
                {
                    var loginSettings = IoC.Resolve<ILoginSettingRepository>().Get(UserId);
                    AuthenticationModeId = loginSettings == null ? (long?)null : loginSettings.AuthenticationModeId;
                }
                else
                {
                    AuthenticationModeId = null;
                }
            }

            if (!IsPostBack)
            {
                Title = "Update Personal Information";
                var objmaster = (Customer_CustomerMaster)this.Master;
                if (IsUpdateProfile)
                    objmaster.SetPageView("DashBoard");
                else
                    objmaster.SetPageView("EventRegistration");

                SetZipCode();
                // bind from database and display state info
                GetDropDownInfo();
                // bind from database and display customers info
                DisplayCustomer();
            }
            // bind marketing source from database
            if (IsUpdateProfile)
            {
                StepDiv.Style.Add(HtmlTextWriterStyle.Display, "none");
                ibtnNext.ImageUrl = "~/App/Images/save-button.gif";
            }

        }

        public void SetName(object sender, EventArgs e)
        {
            //spFullName.InnerHtml = uc1.CustName;
        }

        /// <summary>
        /// Display customer information
        /// </summary>
        private void DisplayCustomer()
        {
            long customerId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            ICustomerRepository customerRepository = new CustomerRepository();
            var customer = customerRepository.GetCustomer(customerId);
            var commonCode = new CommonCode();
            dynamic displayCustomerModel = new ExpandoObject();
            displayCustomerModel.CustomerId = customerId;
            if (customer != null)
            {
                _txtFirstName.Text = customer.Name.FirstName;
                _txtMiddleName.Text = customer.Name.MiddleName;
                _txtLastName.Text = customer.Name.LastName;

                NameLabel.InnerText = displayCustomerModel.Name = customer.Name.FullName;

                if (customer.Height != null)
                {
                    _ddlFeet.SelectedValue = displayCustomerModel.Feet = customer.Height.Feet.ToString();
                    _ddlInch.SelectedValue = displayCustomerModel.Inches = customer.Height.Inches.ToString();
                }

                if (customer.Weight != null)
                    displayCustomerModel.Weight = _txtWeight.Text = customer.Weight.Pounds.ToString();

                if (customer.Waist.HasValue && customer.Waist.Value > 0)
                    displayCustomerModel.Waist = _txtWaist.Text = customer.Waist.Value.ToString("0.0");

                ListItem lstRace = _ddlRace.Items.FindByText(customer.Race.ToString());
                if (lstRace != null)
                {
                    lstRace.Selected = true;
                    displayCustomerModel.Race = lstRace.Text;
                }



                displayCustomerModel.AddressLine = _txtAddress.Text = customer.Address.StreetAddressLine1;
                displayCustomerModel.Suit = _txtSuit.Text = customer.Address.StreetAddressLine2;
                displayCustomerModel.City = _txtCity.Text = customer.Address.City;
                displayCustomerModel.State = hfstate.Value = customer.Address.State;
                ddlCountry.SelectedValue = customer.Address.CountryId.ToString();
                displayCustomerModel.AddressLine = ddlCountry.SelectedItem.Text;
                displayCustomerModel.Zip = _txtZip.Text = customer.Address.ZipCode.Zip;

                displayCustomerModel.PhoneHome = _txtPhoneHome.Text = commonCode.FormatPhoneNumberGet(customer.HomePhoneNumber.ToString());
                displayCustomerModel.PhoneCell = _txtPhoneCell.Text = commonCode.FormatPhoneNumberGet(customer.MobilePhoneNumber.ToString());
                displayCustomerModel.PhoneOffice = _txtPhoneOffice.Text = commonCode.FormatPhoneNumberGet(customer.OfficePhoneNumber.ToString());
                displayCustomerModel.EnableTexting = customer.EnableTexting;
                rbtnEnableTexting.Checked = customer.EnableTexting;
                rbtnDisableTexting.Checked = !customer.EnableTexting;
                displayCustomerModel.EnableVoiceMail = customer.EnableVoiceMail;
                rbtnEnableVoiceMail.Checked = customer.EnableVoiceMail;
                rbtnDisableVoiceMail.Checked = !customer.EnableVoiceMail;
                

                if (customer.DateOfBirth.HasValue)
                {
                    displayCustomerModel.DateOfBrith = _txtDateOfBrith.Text = customer.DateOfBirth.Value.ToString("MM/dd/yyyy");
                    DobLabel.InnerText = customer.DateOfBirth.Value.ToString("MM/dd/yyyy");
                    DobLabelSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                    DobTextboxSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    DobLabelSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
                    DobTextboxSpan.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
                _ddlGender.SelectedValue = displayCustomerModel.Gender = customer.Gender.ToString();
                displayCustomerModel.Email = _txtEmail.Text = customer.Email.ToString();
                displayCustomerModel.PhoneOfficeExtension = PhoneOfficeExtension.Text = customer.PhoneOfficeExtension;
                displayCustomerModel.Ssn = _txtSsnNumber.Text = customer.Ssn;
                if (IsUpdateProfile)
                    MarketingSourceDropDown.SelectedValue = displayCustomerModel.MarketingSource = customer.MarketingSource;

                LogAudit(ModelType.View, displayCustomerModel, customerId);
            }

        }

        private bool UpdateCustomerInfo()
        {
            long customerId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            dynamic displayCustomerModel = new ExpandoObject();
            ICustomerRepository customerRepository = new CustomerRepository();
            displayCustomerModel.CustomerId = customerId;

            if (!customerRepository.UniqueEmail(customerId, _txtEmail.Text))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_UniqueEmail", "alert('This email address is already registered! Please use different email address.');", true);
                return false;
            }


            var address = new Address(_txtAddress.Text, _txtSuit.Text, _txtCity.Text, hfstate.Value,
                                      _txtZip.Text, ddlCountry.SelectedItem.Text);
            var customer = customerRepository.GetCustomer(customerId);

            customer.Name = new Name
            {
                FirstName = _txtFirstName.Text,
                MiddleName = _txtMiddleName.Text,
                LastName = _txtLastName.Text
            };
            displayCustomerModel.Name = customer.Name;
            address.Id = customer.Address.Id;
            displayCustomerModel.Address = customer.Address = address;

            var commonCode = new CommonCode();
            customer.HomePhoneNumber = new PhoneNumber
            {
                PhoneNumberType = PhoneNumberType.Home,
                Number = commonCode.FormatPhoneNumber(_txtPhoneHome.Text)
            };
            displayCustomerModel.HomePhone = _txtPhoneHome.Text;
            customer.OfficePhoneNumber = new PhoneNumber
            {
                PhoneNumberType = PhoneNumberType.Office,
                Number = commonCode.FormatPhoneNumber(_txtPhoneOffice.Text)
            };
            displayCustomerModel.PhoneOffice = _txtPhoneOffice.Text;
            customer.PhoneOfficeExtension = PhoneOfficeExtension.Text;
            displayCustomerModel.PhoneOfficeExtension = PhoneOfficeExtension.Text;

            customer.MobilePhoneNumber = new PhoneNumber
            {
                PhoneNumberType = PhoneNumberType.Mobile,
                Number = commonCode.FormatPhoneNumber(_txtPhoneCell.Text)
            };
            displayCustomerModel.MobilePhoneNumber = _txtPhoneCell.Text;
            displayCustomerModel.Email = _txtEmail.Text;
            string[] emailSplitUp = _txtEmail.Text.Split(new[] { '@' });
            customer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };

            displayCustomerModel.Feet = _ddlFeet.SelectedValue;
            displayCustomerModel.Inch = _ddlInch.SelectedValue;

            customer.Height = new Height(Convert.ToInt64(_ddlFeet.SelectedValue), Convert.ToInt64(_ddlInch.SelectedValue));
            customer.Race = (Race)Enum.Parse(typeof(Race), _ddlRace.SelectedValue);
            displayCustomerModel.Race = _ddlRace.SelectedValue;

            if (_txtDateOfBrith.Text.Trim().Length > 0)
                displayCustomerModel.DateOfBirth = customer.DateOfBirth = Convert.ToDateTime(_txtDateOfBrith.Text);

            double weight;
            if (_txtWeight.Text.Trim().Length > 0 && Double.TryParse(_txtWeight.Text.Trim(), out weight))
            {
                customer.Weight = new Weight(weight);
                displayCustomerModel.Weight = weight;
            }
            else
            {
                customer.Weight = null;
            }

            customer.EnableTexting = rbtnEnableTexting.Checked;
            customer.EnableVoiceMail = rbtnEnableVoiceMail.Checked;
            displayCustomerModel.EnableVoiceMail = customer.EnableVoiceMail;
            displayCustomerModel.EnableTexting = customer.EnableTexting;
            decimal waist;
            if (_txtWaist.Text.Trim().Length > 0 && decimal.TryParse(_txtWaist.Text.Trim(), out waist))
            {
                customer.Waist = waist;
                displayCustomerModel.Waist = waist;
            }
            else
            {
                customer.Waist = null;
            }

            if (_ddlGender.SelectedItem.Text == Gender.Male.ToString())
                customer.Gender = Gender.Male;
            else if (_ddlGender.SelectedItem.Text == Gender.Female.ToString())
                customer.Gender = Gender.Female;
            else
                customer.Gender = Gender.Unspecified;
            displayCustomerModel.Gender = customer.Gender.GetDescription();

            displayCustomerModel.Ssn = customer.Ssn = _txtSsnNumber.Text.Replace("-", "").Trim();

            var customerService = IoC.Resolve<ICustomerService>();
            try
            {
                customerService.SaveCustomer(customer, customerId);
                if (IsUpdateProfile)
                {
                    var loginSettingRepository = IoC.Resolve<ILoginSettingRepository>();

                    var loginSettings = loginSettingRepository.Get(customer.UserLogin.Id);
                    if (loginSettings != null && (IsPinRequiredForRole || ((IsOtpByAppEnabled || IsOtpByEmailEnabled || IsOtpBySmsEnabled) && IsAuthenticationForUserEnabled)))
                    {
                        if (IsPinRequiredForRole)
                            loginSettings.DownloadFilePin = IsPinRequiredForRole ? (string.IsNullOrEmpty(txtDownloadFilePin.Value) ? loginSettings.DownloadFilePin : txtDownloadFilePin.Value) : null;

                        if ((IsOtpByAppEnabled || IsOtpByEmailEnabled || IsOtpBySmsEnabled) && IsAuthenticationForUserEnabled)
                        {

                            if (useApp.Checked)
                            {
                                loginSettings.AuthenticationModeId = (long)AuthenticationMode.AuthenticatorApp;
                                loginSettings.GoogleAuthenticatorSecretKey = (string)Session["EncodedSecret"];
                            }
                            else
                            {
                                loginSettings.GoogleAuthenticatorSecretKey = null;
                                loginSettings.AuthenticationModeId = UseEmail.Checked && UseSms.Checked ? (long)AuthenticationMode.BothSmsEmail : (UseSms.Checked ? (long)AuthenticationMode.Sms : (long)AuthenticationMode.Email);
                            }
                            Session["EncodedSecret"] = null;
                        }

                        loginSettingRepository.Save(loginSettings);
                    }
                }

                LogAudit(ModelType.Edit, displayCustomerModel, customerId);
            }
            catch (InvalidAddressException ex)
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscodecityvalidate", "alert('" + ex.Message + "');", true);
                return false;
            }
            if (!IsUpdateProfile)
            {
                CustomerId = customer.CustomerId;

                RegistrationFlow.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;
            }
            return true;
        }

        /// <summary>
        /// Getting all dropdown info from database, like city, state, country.
        /// </summary>
        private void GetDropDownInfo()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlCountry.DataSource = countries;
            ddlCountry.DataTextField = DDL_TEXT_NAME;
            ddlCountry.DataValueField = DDL_VALUE_ID;
            ddlCountry.DataBind();

            _ddlRace.Items.Clear();
            var races = Race.Other.GetNameValuePairs();
            _ddlRace.DataSource = races;
            _ddlRace.DataTextField = "SecondValue";
            _ddlRace.DataValueField = "FirstValue";
            _ddlRace.DataBind();

            var marketingSourceService = IoC.Resolve<IMarketingSourceService>();
            var marketingSources = marketingSourceService.FetchMarketingSourceByZip(ZipCode);
            MarketingSourceDropDown.DataSource = marketingSources;
            MarketingSourceDropDown.DataBind();
            MarketingSourceDropDown.Items.Insert(0, new ListItem("", ""));
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }

        private void SetZipCode()
        {
            if (EventId > 0)
            {
                var hostRepository = IoC.Resolve<IHostRepository>();
                var host = hostRepository.GetHostForEvent(EventId);

                if (host != null)
                {
                    ZipCode = host.Address.ZipCode.Zip;
                }
            }
        }

        protected void ibtnNext_Click(object sender, ImageClickEventArgs e)
        {
            // save and redirect to event details page.
            if (UpdateCustomerInfo())
            {
                if (IsUpdateProfile)
                    Response.RedirectUser("HomePage.aspx");
                else
                    Response.RedirectUser("SelectPackage.aspx?guid=" + GuId);
            }
        }

        protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
        {
            RegistrationFlow = null;
            Response.RedirectUser("HomePage.aspx");
        }
    }

}
