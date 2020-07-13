using System;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.UCPublic
{
    public partial class ucUserLoginInfo : UserControl
    {
        public delegate void ErrorOnClick(string message);
        public event ErrorOnClick ErrorGeneratedOnClick;

        public bool IsGiftCertificate
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["gc"]) && Request.QueryString["gc"] == "gc";
            }
        }

        protected string MarketingSource
        {
            get
            {
                if (Request.QueryString["MarketingSource"] != null)
                    return Request.QueryString["MarketingSource"];
                return string.Empty;
            }
        }

        protected string MiddleName
        {
            get
            {
                if (Request.QueryString["MiddleName"] != null)
                    return Request.QueryString["MiddleName"].ToUppercaseInitalLetter();
                return string.Empty;
            }
        }

        private GiftCertificate _giftCertificate;
        private GiftCertificate GiftCertificate
        {
            get
            {
                if (IsGiftCertificate && _giftCertificate == null && Session["GiftCertificateId"] != null)
                {
                    long id = 0;
                    long.TryParse(Session["GiftCertificateId"].ToString(), out id);
                    _giftCertificate = IoC.Resolve<IGiftCertificateRepository>().GetById(id);
                }
                return _giftCertificate;
            }
        }

        private ProspectCustomer _propsectCustomer;
        private ProspectCustomer ProspectCustomer
        {
            get
            {
                if (_propsectCustomer == null && Session["ProspectCustomerId"] != null)
                {
                    _propsectCustomer = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>().GetById(Convert.ToInt64(Session["ProspectCustomerId"]));
                }
                return _propsectCustomer;
            }
        }

        private long CountryId
        {
            get { return Convert.ToInt64(Session["CountryId"]); }
        }

        private Core.Users.Domain.Customer _customer;
        private Core.Users.Domain.Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    if (Request.QueryString["UserType"] != null && Request.QueryString["UserType"] == "Existing")
                    {
                        var customerRepository = IoC.Resolve<ICustomerRepository>();
                        _customer =
                            customerRepository.GetCustomerByUserId(IoC.Resolve<ISessionContext>().UserSession.UserId);
                    }
                    else
                    {
                        _customer = new Core.Users.Domain.Customer
                                        {
                                            Name = new Name
                                                       {
                                                           FirstName = ProspectCustomer.FirstName.ToUppercaseInitalLetter(),
                                                           MiddleName = MiddleName,
                                                           LastName = ProspectCustomer.LastName
                                                       },
                                            HomePhoneNumber = ProspectCustomer.CallBackPhoneNumber,
                                            Address = ProspectCustomer.Address,
                                            MarketingSource = MarketingSource,
                                            DateOfBirth = Convert.ToDateTime("01/01/1902 00:00:00"),
                                            DateCreated = DateTime.Now
                                        };
                        if (_customer.Address != null)
                            _customer.Address.CountryId = CountryId;
                    }
                }
                return _customer;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtRegUserName.Attributes.Add("onKeyDown", "return keypress_userName(event);");
                txtRegUserName.Attributes.Add("onKeyUp", "return keyUp_userName(event);");
                if (Request.QueryString["UserType"] != null && Request.QueryString["UserType"] == "Existing")
                {
                    FillCustomerDetails();
                }
                if (IsGiftCertificate)
                {
                    var giftCertificate = GiftCertificate;
                    if (giftCertificate != null)
                    {
                        GiftCertificateSummary.Visible = true;
                        IGiftCertificateTypeRepository giftCertificateTypeRepository =
                            new GiftCertificateTypeRepository();

                        AmountSpan.InnerText += giftCertificate.Price.ToString();
                        ForNameSpan.InnerText = giftCertificate.ToName;
                        ForEmailSpan.InnerText = giftCertificate.ToEmail;
                        MessageSpan.InnerText = giftCertificate.Message;
                        OccasionSpan.InnerText =
                            giftCertificateTypeRepository.GetById(giftCertificate.GiftCertificateTypeId).Name;
                    }
                }
                else
                {
                    GiftCertificateSummary.Visible = false;
                }
            }
        }

        protected void ibtnSaveCustomer_Click(object sender, ImageClickEventArgs e)
        {
            //server side validation
            txtNewPassword.Attributes.Add("value", txtNewPassword.Text); //instead of txtPassword.Text = "abcd"
            txtCrfmPassword.Attributes.Add("value", txtCrfmPassword.Text);

            if (txtEmail.Text.Trim().Length == 0)
            {
                ErrorGeneratedOnClick("Email can not be left blank.");
                return;
            }

            bool isValidEmail1 = false;
            bool isValidEmail2 = false;
            foreach (char singleChar in txtEmail.Text)
            {
                UInt32 singleCharAsciiCode = Convert.ToUInt32(singleChar);
                if (singleCharAsciiCode == 64)//for @
                    isValidEmail1 = true;
                if (singleCharAsciiCode == 46)//for .
                    isValidEmail2 = true;
            }
            if ((!isValidEmail1) || (!isValidEmail2))
            {
                ErrorGeneratedOnClick("Please enter valid email.");
                return;
            }
            if (txtRegUserName.Text.Trim().Length == 0)
            {
                ErrorGeneratedOnClick("User name can not be left blank.");
                return;
            }
            if (txtRegUserName.Text.Trim().Length < 6)
            {
                ErrorGeneratedOnClick("Username length can not be less than 6 characters.");
                return;
            }
            if (txtNewPassword.Text.Trim().Length == 0)
            {
                ErrorGeneratedOnClick("New Password is mandatory.");
                return;
            }
            if (txtNewPassword.Text.Trim().Length < 8)
            {
                ErrorGeneratedOnClick("Password length can not be less than 8 characters.");
                return;
            }

            bool isContainNumeric = false;
            bool isContainAlphanumeric = false;
            foreach (char singleChar in txtNewPassword.Text)
            {
                UInt32 singleCharAsciiCode = Convert.ToUInt32(singleChar);
                if (singleCharAsciiCode > 47 && singleCharAsciiCode < 58)
                    isContainNumeric = true;
                if ((singleCharAsciiCode > 64 && singleCharAsciiCode < 91) || (singleCharAsciiCode > 96 && singleCharAsciiCode < 123))
                    isContainAlphanumeric = true;
            }
            if ((!isContainNumeric) || (!isContainAlphanumeric))
            {
                ErrorGeneratedOnClick("New Password should contain at least one alphabet and one numeric.");
                return;
            }
            if (txtCrfmPassword.Text != txtNewPassword.Text)
            {
                ErrorGeneratedOnClick("Verify Password should be same as New Password.");
                return;
            }
            if (txtQuestion.Text.Trim().Length == 0)
            {
                ErrorGeneratedOnClick("Hint Question can not be left blank.");
                return;
            }
            if (txtAnswer1.Text.Trim().Length == 0)
            {
                ErrorGeneratedOnClick("Hint Answer can not be left blank.");
                return;
            }

            //IUserRepository<Core.Users.Domain.Customer> userRepository = new UserRepository<Core.Users.Domain.Customer>();
            var userRepository = IoC.Resolve<ICustomerRepository>();
            if (!userRepository.UniqueEmail(Customer.CustomerId, txtEmail.Text))
            {
                const string duplicateEmailError = "Email Address already registered! Please use different Email.";
                ErrorGeneratedOnClick(duplicateEmailError);
                spErrorMsg.InnerText = duplicateEmailError;
                return;
            }

            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            if (!userLoginRepository.UniqueUserName(Convert.ToInt64(hfUserID.Value), txtRegUserName.Text))
            {
                const string usernameAlreadyExists = "UserName already exists. Please use different UserName.";
                ErrorGeneratedOnClick(usernameAlreadyExists);
                spErrorMsg.InnerText = usernameAlreadyExists;
                return;
            }

            if (Customer == null) return;

            _customer.UserLogin = new UserLogin()
                                      {
                                          UserName = txtRegUserName.Text.ToLower(),
                                          Password = txtNewPassword.Text,
                                          HintQuestion = txtQuestion.Text,
                                          HintAnswer = txtAnswer1.Text,
                                          IsSecurityQuestionVerified = true,
                                          UserVerified = true,
                                          Id =
                                              (Customer.UserLogin == null || Customer.UserLogin.Id < 1)
                                                  ? 0
                                                  : Customer.UserLogin.Id
                                      };

            if (ProspectCustomer != null)
                _customer.MarketingSource = ProspectCustomer.MarketingSource;
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text)) _customer.Email = new Email(txtEmail.Text);
                var customerService = IoC.Resolve<ICustomerService>();
                IoC.Resolve<ISessionContext>().UserSession = IoC.Resolve<IUserLoginService>().GetUserSessionModel(txtRegUserName.Text);
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                customerService.SaveCustomer(Customer, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);



                var notifier = IoC.Resolve<INotifier>();
                var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();


                var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(Customer.UserLogin.UserName, Customer.Name.FullName, Customer.DateCreated);
                notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, currentSession.UserId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                //var welcomePasswordViewModel = emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(Customer.Name.FullName, Customer.UserLogin.Password);
                //notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithPassword, EmailTemplateAlias.CustomerWelcomeEmailWithPassword, welcomePasswordViewModel, currentSession.UserId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                if (IsGiftCertificate)
                {
                    Response.RedirectUser("/Public/Customer/Payment.aspx?gc=gc");
                }
                else if (Request.QueryString["UserType"] != null && Request.QueryString["UserType"] == "Existing")
                {

                    Response.RedirectUser("~/Public/Customer/RegisterCustomer.aspx?User=" + txtRegUserName.Text + "&EventId=" +
                                      Request.QueryString["EventId"]);
                }
                else
                {
                    if (Customer.Id >= 0)
                    {
                        SaveProspectCustomer(Customer.CustomerId);
                        // this is where the new user is created.

                        var ccr = IoC.Resolve<IClickConversionRepository>();
                        ccr.SaveCustomerConversion(ProspectCustomer.Id, Customer.CustomerId);

                        Response.RedirectUser("/Public/Account/RegisterUserStep3.aspx?EventId=" + Request.QueryString["EventId"]);
                    }
                }
            }
            catch (InvalidAddressException ex)
            {

                ErrorGeneratedOnClick(ex.Message);
                spErrorMsg.InnerHtml = ex.Message;
                if (
                    !(IsGiftCertificate ||
                      Request.QueryString["UserType"] != null && Request.QueryString["UserType"] == "Existing"))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_CheckTempPassword",
                                                            "checkTempPassword();", true);
                }
            }
            catch (Exception)
            {
                string error =
                    "There appears to be an issue with the data you are tryng to save. Please try again or contact us at " + IoC.Resolve<ISettings>().PhoneTollFree + " (Toll Free).";

                ErrorGeneratedOnClick(error);
                spErrorMsg.InnerHtml = error;
                if (!(IsGiftCertificate || Request.QueryString["UserType"] != null && Request.QueryString["UserType"] == "Existing"))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_CheckTempPassword", "checkTempPassword();", true);
                }
            }
        }

        private void SaveProspectCustomer(long customerId)
        {
            var uniqueItemRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();

            if (ProspectCustomer == null) return;
            if (!string.IsNullOrEmpty(txtEmail.Text))
                ProspectCustomer.Email = new Email(txtEmail.Text);

            ProspectCustomer.CustomerId = customerId;
            ProspectCustomer.IsConverted = false;
            uniqueItemRepository.Save(ProspectCustomer);
        }

        private void FillCustomerDetails()
        {
            if (IoC.Resolve<ISessionContext>().UserSession == null) return;

            if (Customer == null) return;
            txtEmail.Text = Customer.Email.ToString();
            txtRegUserName.Text = Customer.UserLogin.UserName;
            txtQuestion.Text = Customer.UserLogin.HintQuestion;
            txtAnswer1.Text = Customer.UserLogin.HintAnswer;
            hfUserID.Value = Customer.Id.ToString();
            txtNewPassword.Attributes.Add("value", HttpUtility.HtmlEncode(Customer.UserLogin.Password));
            txtCrfmPassword.Attributes.Add("value", HttpUtility.HtmlEncode(Customer.UserLogin.Password));
        }

        protected void ChangeAmount_ServerClick(object sender, EventArgs e)
        {
            if (IsGiftCertificate)
            {
                Response.RedirectUser("../GiftCertificates/Catalog.aspx?gc=gc");
            }
        }

        protected void ChangeDetails_ServerClick(object sender, EventArgs e)
        {
            if (IsGiftCertificate)
            {
                Response.RedirectUser("../GiftCertificates/Details.aspx?Amount=" + GiftCertificate.Price);
            }
        }

    }
}