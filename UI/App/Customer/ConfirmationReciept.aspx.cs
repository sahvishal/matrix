using System;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Customer
{
    public partial class ConfirmationReciept : Page
    {
        private string _eventDate;
        private string _eventVenue;

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
            get { return RegistrationFlow != null ? RegistrationFlow.EventId : 0; }
        }

        private long CustomerId
        {
            get { return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Confirmation Reciept ";
            var objmaster = (Customer_CustomerMaster)Master;
            objmaster.SetBreadcrumb = "<a href=\"/App/Customer/HomePage.aspx\">Home</a>";
            if (!IsPostBack)
            {
                var customer = GetCustomerDetail();
                var appointmentRepository = IoC.Resolve<IAppointmentRepository>();
                var appointment = appointmentRepository.GetEventCustomerAppointment(EventId, CustomerId);
                string appointmentSlot = appointment != null ? appointment.StartTime.ToShortTimeString() : string.Empty;

                IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService = new EventCustomerPackageTestDetailService();
                var eventCustomerPackageTestDetailViewData =
                    eventCustomerPackageTestDetailService.GetEventPackageDetails(EventId, customer.CustomerId);

                var orderRepository = IoC.Resolve<IOrderRepository>();
                var order = orderRepository.GetOrder(customer.CustomerId, EventId);
                _orderPackageTest.SetOrderPackageTest(order, eventCustomerPackageTestDetailViewData);

                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(EventId);

                var settings = IoC.Resolve<ISettings>();

                try
                {
                    FillEventDetails();

                    //For static pages
                    lblFullName.Text = HttpUtility.HtmlEncode(IoC.Resolve<ISessionContext>().UserSession.FirstName + " " + IoC.Resolve<ISessionContext>().UserSession.LastName);
                    lblWhen.Text = HttpUtility.HtmlEncode(_eventDate + " at " + appointmentSlot);
                    lblVenue.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(_eventVenue, true);

                    //for small reciept
                    aSmallReciept.HRef = "javascript:popupmenu2('/Config/Content/Controls/SmallPrintReciept.aspx?CustomerID=" + CustomerId + "&EventID=" + EventId + "',310,505)";
                    imgBtnPrint.HRef = "javascript:popupmenu2('/Communication/AppointmentConfirmation?eventId=" + EventId + "&customerId=" + customer.CustomerId + "',680,700)";
                    var notifier = IoC.Resolve<INotifier>();
                    var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                    var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                    if (account == null || account.SendWelcomeEmail)
                    {
                        var welcomeEmailViewModel = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(customer.UserLogin.UserName, customer.Name.FullName, customer.DateCreated);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

                        //var welcomePasswordViewModel = emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel(customer.Name.FullName, customer.UserLogin.Password);
                        //notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithPassword, EmailTemplateAlias.CustomerWelcomeEmailWithPassword, welcomePasswordViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                    }

                    var eventRepository = IoC.Resolve<IEventRepository>();
                    var eventData = eventRepository.GetById(EventId);

                    var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
                    customerRegistrationService.SendAppointmentConfirmationMail(customer, eventData, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath,account);

                    //If somebody registered within 24 hours of the event Date then send notification.
                    if (eventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
                    {
                        var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(EventId, customer.CustomerId);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void FillEventDetails()
        {
            var eventService = IoC.Resolve<IEventService>();
            var eventData = eventService.GetById(EventId);
            if (eventData != null)
            {
                _eventDate = eventData.EventDate.ToLongDateString();
                _eventVenue = eventData.OrganizationName + "<br/>" + CommonCode.AddressMultiLine(eventData.StreetAddressLine1, eventData.StreetAddressLine2, eventData.City, eventData.State, eventData.Zip);
                googleMapUrl.HRef = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" +
                                            eventData.StreetAddressLine1 + "," +
                                            eventData.City + "," +
                                            eventData.State + "," +
                                            eventData.Zip +
                                            "&ie=UTF8&z=16";
            }
        }

        protected string GetTestName(int packageId)
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestNamesByPackageId(Convert.ToInt64(packageId));
        }

        public void SetName(object sender, EventArgs e)
        {
            //spFullName.InnerHtml = uc1.CustName;

        }

        private Core.Users.Domain.Customer GetCustomerDetail()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetCustomer(CustomerId);
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            RegistrationFlow = null;
            Response.RedirectUser("HomePage.aspx");
        }

        protected void BtnFillMedicalHistory_Click(object sender, EventArgs e)
        {
            RegistrationFlow = null;
            Response.RedirectUser("MedicalHistory.aspx?Edit=true");
        }
    }
}