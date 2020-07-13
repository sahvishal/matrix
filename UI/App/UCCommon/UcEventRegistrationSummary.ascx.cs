using System;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Util;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Finance.Impl;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Service;
using Falcon.App.UI.App.BasePageClass;
using Falcon.DataAccess.Master;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Users.Enum;


namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcEventRegistrationSummary : BaseUserControl
    {
        private dynamic customerLogEditModel = new ExpandoObject();
        protected string VersionNumber { get; set; }
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

        public long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected string HraQuestionerAppUrl { get; set; }
        protected string OrganizationNameForHraQuestioner { get; set; }
        protected string HraToken { get; set; }
        protected string CorporateAccountTag { get; set; }
        protected bool IsEawvPurchased { get; set; }

        protected long AwvVisitId
        {
            get
            {
                return RegistrationFlow != null && RegistrationFlow.AwvVisitId.HasValue
                    ? RegistrationFlow.AwvVisitId.Value
                    : 0;
            }
        }

        public long EventId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
            }
        }
        private string _strEventDate;
        private string _strEventVenue;
        private Core.Finance.Domain.Order _order;
        private OrderDetail GetCurrentOrder(long customerId, long eventId)
        {
            IOrderRepository orderRepository = new OrderRepository();
            try
            {
                _order = orderRepository.GetOrder(customerId, eventId);
                IOrderController orderController = new OrderController();
                return orderController.GetActiveOrderDetail(_order);
            }
            catch
            {
                return null;
            }
        }

        protected string ChatQuestionerAppUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetEventDetail();

            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            if (!Page.IsPostBack)
            { LogAudit(ModelType.View, customerLogEditModel, CustomerId); }
        }

        private void GetEventDetail()
        {
            if (EventId > 0 && CustomerId > 0)
            {
                _spCustomerId.InnerText = customerLogEditModel.CustomerId = CustomerId.ToString();
                _spEventId.InnerText = customerLogEditModel.EventId = EventId.ToString();

                var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                var appointment = appointmentRepository.GetEventCustomerAppointment(EventId, CustomerId);

                if (appointment == null) return;

                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customer = customerRepository.GetCustomer(CustomerId);

                var eventService = IoC.Resolve<IEventService>();
                var eventHost = eventService.GetById(EventId);

                var strCustomerName = customerLogEditModel.Name = customer.NameAsString;

                _spAcesId.InnerText = string.IsNullOrWhiteSpace(customer.AcesId) ? "N/A" : customer.AcesId;

                _strEventDate = eventHost.EventDate.ToLongDateString();
                var strHostAddress = new Address(eventHost.StreetAddressLine1, eventHost.StreetAddressLine2,
                                                 eventHost.City, eventHost.State, eventHost.Zip, "");
                customerLogEditModel.EventVenue = _strEventVenue = eventHost.Name + "  " + strHostAddress;

                _spFullName.InnerText = strCustomerName;
                customerLogEditModel.EventDate = _strEventDate + " at " + appointment.StartTime.ToShortTimeString();
                _spWhen.InnerText = HttpUtility.HtmlEncode(customerLogEditModel.EventDate);
                _spVenue.InnerText = _strEventVenue;

                var orderDetail = GetCurrentOrder(CustomerId, EventId);
                //decimal shippingPrice = orderDetail.ShippingDetailOrderDetails.Sum(shippingDetailOrderDetail => shippingDetailOrderDetail.Amount);

                decimal totalAmount = _order.DiscountedTotal;

                IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService = new EventCustomerPackageTestDetailService();
                var eventCustomerPackageTestDetailViewData =
                    eventCustomerPackageTestDetailService.GetEventPackageDetails(EventId, CustomerId);
                if (eventCustomerPackageTestDetailViewData.Package != null)
                {
                    _spPackageName.InnerText = customerLogEditModel.PackageName = eventCustomerPackageTestDetailViewData.Package.Name;

                    var packageTest = string.Empty; var packageTestAudit = string.Empty;
                    foreach (var test in eventCustomerPackageTestDetailViewData.Package.Tests)
                    {
                        packageTest += "<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>";
                        packageTestAudit += test.Name + ", ";
                    }
                    _spTestNames.InnerHtml = packageTest;
                    customerLogEditModel.PackageTest = packageTestAudit.Length > 2 ? packageTestAudit.Substring(0, packageTestAudit.Length - 2) : ""; ;
                }
                else
                {
                    _dvPackageMain.Visible = false;
                    _dvAdditionalTest.InnerHtml = "Test(s):";
                }

                var additionalTest = string.Empty; var additionalTestAudit = string.Empty;
                foreach (var test in eventCustomerPackageTestDetailViewData.Tests)
                {
                    additionalTest += "<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>";
                    additionalTestAudit += test.Name + ", ";
                }

                _spAdditionalTestNames.InnerHtml = additionalTest;
                customerLogEditModel.AdditionalTestAudit = additionalTestAudit.Length > 2 ? additionalTestAudit.Substring(0, additionalTestAudit.Length - 2) : "";
                if (eventCustomerPackageTestDetailViewData.Tests.Count < 1) _dvAdditionalTestMain.Visible = false;

                _spPrice.InnerHtml = customerLogEditModel.OrderValue = totalAmount.ToString("C2");

                //_spPaymentStatus.InnerHtml = (_order.TotalAmountPaid - _order.DiscountedTotal) >= 0 ? "<i>The payment captured sucessfully.</i>" : "<i>Not Paid</i>";

                if (_order.DiscountedTotal > 0)
                    customerLogEditModel.PaymentStatus = _spPaymentStatus.InnerHtml = _order.TotalAmountPaid > 0
                                                      ? "<i>The payment captured sucessfully.</i>"
                                                      : "<i>Not Paid</i>";
                else
                    customerLogEditModel.PaymentStatus = _spPaymentStatus.InnerHtml = "<i>Not charged.</i>";

                customerLogEditModel.PaymentStatus = ((string)customerLogEditModel.PaymentStatus).Replace("<i>", "").Replace("</i>", "");

                if (eventCustomerPackageTestDetailViewData.ElectronicProduct != null)
                {
                    ProductDiv.Visible = true;
                    ProductSpan.InnerHtml = eventCustomerPackageTestDetailViewData.ElectronicProduct.Name + "<a  class='jtip'  title='Description|" + eventCustomerPackageTestDetailViewData.ElectronicProduct.ShortDescription + "'> <span class='smalltxtblu'>[More Info]</span></a>";
                    customerLogEditModel.ElectronicProduct = eventCustomerPackageTestDetailViewData.ElectronicProduct.Name;
                }
                else
                    ProductDiv.Visible = false;

                //TODO:For Spike release it is kept here. it should be in db and need to have one more field in DB to identify Digital delivery shipping option
                var shippingOption = new ShippingOption { Id = 0, Name = "Unlimited Online Results (Free)", Price = 0.00m, Description = IoC.Resolve<ISettings>().CompanyName + "  securely stores your screening results, including all medical device output and ultrasound images, online permanently and provides unlimited access, printing & emailing 24-hours a day, free of charge!  Online results typically available in less than 2 business days however, guaranteed in 4 business days.", Disclaimer = "" };

                long shippingDetailId = 0;
                if (orderDetail != null && orderDetail.ShippingDetailOrderDetails != null && orderDetail.ShippingDetailOrderDetails.Count() > 0)
                    shippingDetailId = orderDetail.ShippingDetailOrderDetails.Where(sdod => sdod.IsActive).Select(sdod => sdod.ShippingDetailId).FirstOrDefault();

                if (shippingDetailId > 0)
                {
                    var shippingRepository = IoC.Resolve<IShippingDetailRepository>();
                    var shippingDetail = shippingRepository.GetById(shippingDetailId);

                    IShippingOptionRepository shippingOptionRepository = new ShippingOptionRepository();
                    shippingOption = shippingOptionRepository.GetById(shippingDetail.ShippingOption.Id);

                }

                _spShippingOption.InnerHtml = shippingOption.Name + "<a  class='jtip'  title='Description/Disclaimer!|" + shippingOption.Description + "|<br /><strong>" + shippingOption.Disclaimer + "</strong><br /> '> <span class='smalltxtblu'>[More Info]</span></a>";

                if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep))
                {
                    GetCcRepInstruction(EventId);
                }
                else
                {
                    _spCCRepNotes.Visible = false;
                }

                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(EventId);

                _spUserName.InnerText = customerLogEditModel.UserName = customer.UserLogin.UserName;
                //_spPassword.InnerHtml = customer.UserLogin.Password;
                hfUserID.Value = customer.UserLogin.Id.ToString();

                SetPcpInfo(CustomerId);

                SetHafInfo(account);
                SetHraInfo(EventId, CustomerId, eventHost.EventDate, account);
                HideUserLoginDetails(account);

            }
        }


        private void SetHafInfo(CorporateAccount account)
        {
            if (account != null && account.CaptureHaf == false)
            {
                customerHaf.Visible = false;
                return;
            }

            if (CustomerId <= 0 || EventId <= 0)
            {
                customerHaf.Visible = false;
                return;
            }
            var isHafFilled = IoC.Resolve<IKynHealthAssessmentHelper>().CheckHafPrefilled(EventId, CustomerId);
            if (customerHaf != null && customerHaf.Visible)
            {
                if (isHafFilled)
                {
                    hafStatusText.InnerHtml = customerLogEditModel.HafStatus = "Completed";
                    hafStatubtn.InnerText = "Update";
                }
                else
                {
                    hafStatusText.InnerHtml = customerLogEditModel.HafStatus = "Not Filled";
                    hafStatubtn.InnerText = "Fill";
                }
            }

        }
        private void GetCcRepInstruction(long eventId)
        {
            var masterDal = new MasterDAL();
            var strCcRepInstruction = masterDal.getCCRepInstructionForEvent(eventId);
            _txtCallCenterNotes.Text = strCcRepInstruction;
        }

        protected void UpdateUserNameButton_Click(object sender, EventArgs e)
        {
            var userLoginId = Convert.ToInt64(hfUserID.Value);
            if (UniqueUserNameValidation(userLoginId))
            {
                var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                try
                {
                    var userNameUpdated = userLoginRepository.UpdateUserName(userLoginId, UserNameTextBox.Text.Trim());
                    if (userNameUpdated)
                    {
                        var notifier = IoC.Resolve<INotifier>();
                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                        var customerRepository = IoC.Resolve<ICustomerRepository>();
                        var customer = customerRepository.GetCustomer(CustomerId);

                        var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(UserNameTextBox.Text.Trim(), customer.Name.FullName, customer.DateCreated);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, "CustomerWelcomeEmailWithUsername", welcomeEmailViewModel, userLoginId, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                        _spUserName.InnerText = UserNameTextBox.Text.Trim();
                        LogAudit(ModelType.Edit, new { CustomerId, Action = "User name updated", UserName = UserNameTextBox.Text.Trim() }, CustomerId);
                        Page.ClientScript.RegisterStartupScript(typeof(string), "js_usernameupdated", "alert('User name updated successfully.');", true);
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "js_error", "alert('" + ex.Message + "');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "js_usernameexists", "alert('User name already exist. Please try another user name.');", true);
            }
        }

        private bool UniqueUserNameValidation(long userLoginId)
        {
            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            return userLoginRepository.UniqueUserName(userLoginId, UserNameTextBox.Text.Trim());
        }

        private void SetPcpInfo(long customerId)
        {
            var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();
            var pcp = primaryCarePhysicianRepository.Get(customerId);
            if (pcp != null)
            {
                PcpNameDiv.InnerText = customerLogEditModel.PcpName = pcp.Name.FullName;
                if (pcp.Address != null)
                {
                    PcpAddressDiv.InnerHtml = customerLogEditModel.PcpAddress = pcp.Address.ToString();
                }
                PcpEmailDiv.InnerText = customerLogEditModel.PcpEmail = pcp.Email != null ? pcp.Email.ToString() : "N/A";
                PcpPhoneDiv.InnerText = customerLogEditModel.PcpPhone = pcp.Primary != null && !string.IsNullOrEmpty(pcp.Primary.ToString()) ? pcp.Primary.ToString() : "N/A";
                PcpFaxDiv.InnerText = customerLogEditModel.PcpFax = pcp.Fax != null && !string.IsNullOrEmpty(pcp.Fax.ToString()) ? pcp.Fax.ToString() : "N/A";
                PcpDetailDiv.Visible = true;
            }
            else
            {
                PcpDetailDiv.Visible = false;
            }
        }

        private void SetHraInfo(long eventId, long customerId, DateTime eventDate, CorporateAccount account)
        {
            
            var settings = IoC.Resolve<ISettings>();

            QuestionnaireType questionnaireType = QuestionnaireType.None;

            if (account != null && account.IsHealthPlan)
            {
                var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                questionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, eventDate);
            }

            if (account != null && account.IsHealthPlan && (questionnaireType == QuestionnaireType.HraQuestionnaire))
            {
                var testResultService = new TestResultService();
                IsEawvPurchased = testResultService.IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.eAWV);

                CorporateAccountTag = account.Tag;
                var sessionContext = IoC.Resolve<ISessionContext>();

                HraQuestionerAppUrl = settings.HraQuestionerAppUrl;
                OrganizationNameForHraQuestioner = settings.OrganizationNameForHraQuestioner;
                HraToken = (Session.SessionID + "_" + sessionContext.UserSession.UserId + "_" +
                               sessionContext.UserSession.CurrentOrganizationRole.RoleId + "_" +
                               sessionContext.UserSession.CurrentOrganizationRole.OrganizationId).Encrypt();

                ChatQuestionerAppUrl = string.Empty;
            }
            else if (account != null && (questionnaireType == QuestionnaireType.ChatQuestionnaire))
            {
                ChatQuestionerAppUrl = settings.ChatQuestionerAppUrl;
                HraQuestionerAppUrl = string.Empty;
            }
        }

        private void HideUserLoginDetails(CorporateAccount account)
        {
            if (account != null && !account.AllowCustomerPortalLogin)
            {
                dvLoginDetails.Style.Add(System.Web.UI.HtmlTextWriterStyle.Display, "none");
            }
        }
    }
}