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
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.Customer
{
    public partial class RegisterCustomerSubmit : Page
    {
        private string _eventDate;
        private string _eventVenue;
        private string _eventName;
        private string _hostName;
        private string _address1;
        private string _cityStateZip;

        private long EventId
        {
            get
            {
                if (Session["EventID"] != null && !string.IsNullOrEmpty(Session["EventID"].ToString()))
                {
                    long eventId;
                    if (Int64.TryParse(Session["EventID"].ToString(), out eventId))
                        return eventId;
                }
                return 0;
            }
        }

        private long UserId
        {
            get
            {
                if (IoC.Resolve<ISessionContext>().UserSession != null)
                {
                    return IoC.Resolve<ISessionContext>().UserSession.UserId;
                }
                return 0;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Confirmation";

            headingtxt.InnerHtml = "<img src=\"/Content/Images/step6_public.gif\">";

            var eventRepository = IoC.Resolve<IEventRepository>();
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["status"].Equals("2") || Request.QueryString["status"].Equals("4"))
                    {
                        var customer = GetCustomerDetail();
                        var logger = IoC.Resolve<ILogManager>().GetLogger("RegisterCustomersubmitt.aspx");
                        
                        var notifier = IoC.Resolve<INotifier>();

                        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();

                        var appointmentConfirmationViewModel =emailNotificationModelsFactory.GetAppointmentConfirmationModel(EventId, customer.CustomerId);
                        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentConfirmationWithEventDetails,EmailTemplateAlias.AppointmentConfirmationWithEventDetails, appointmentConfirmationViewModel, UserId,customer.CustomerId, Request.Url.AbsolutePath,useAlternateEmail:true);

                        if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
                        {
                            logger.Info("customer has not Subscribed for SMS customerId " + customer.CustomerId);

                        }
                        else
                        {
                            if (customer.EnableTexting)
                            {
                                var smsNotificaionModelFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();

                                var eventData = eventRepository.GetById(EventId);
                                var smsNotificaionModel = smsNotificaionModelFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);
                                notifier.NotifyViaSms(NotificationTypeAlias.AppointmentConfirmation, NotificationTypeAlias.AppointmentConfirmation, smsNotificaionModel, customer.Id, customer.CustomerId, Request.Url.AbsolutePath);
                            }
                        }


                        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

                        //If somebody registered within 24 hours of the event Date then send notification.
                        if (appointmentConfirmationViewModel.EventDate.AddDays(-1).Date == DateTime.Now.Date)
                        {
                            var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(EventId, customer.CustomerId);
                            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
                        }


                        IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService =
                            new EventCustomerPackageTestDetailService();
                        var eventCustomerPackageTestDetailViewData =
                            eventCustomerPackageTestDetailService.GetEventPackageDetails(EventId, customer.CustomerId);

                        var orderRepository = IoC.Resolve<IOrderRepository>();
                        var order = orderRepository.GetOrder(customer.CustomerId, EventId);
                        _orderPackageTest.SetOrderPackageTest(order, eventCustomerPackageTestDetailViewData);


                        string appointmentSlot = Session["TimeSlot"].ToString();
                        // Needed for Physician Search Page
                        Session["PCPSearchCustomerState"] = customer.Address.State;

                        //DataSet dsEmail;
                        //var objEmail = new SendEmail();
                        //*** Notification Service
                        string strEmail = customer.Email.ToString();
                        if (strEmail == "")
                        {
                            divEmail.Visible = false;
                        }

                        try
                        {
                            FillEventDetails();

                            //For static pages
                            lblFullName.Text = HttpUtility.HtmlEncode(customer.Name.FirstName + " " + customer.Name.LastName);
                            lblWhen.Text = HttpUtility.HtmlEncode(_eventDate + " at " + appointmentSlot);
                            lblVenue.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(_eventVenue,true);


                            imgPrintReciept.HRef =
                                "javascript:popupmenu2('/Communication/AppointmentConfirmation?eventId=" + EventId +
                                "&customerId=" + customer.CustomerId + "',680,700)";
                            //for small reciept
                            aSmallReciept.HRef =
                                "javascript:popupmenu2('/Config/Content/Controls/SmallPrintReciept.aspx?CustomerName=" +
                                customer.Name.FirstName.Replace("'", "@") + " " +
                                customer.Name.LastName.Replace("'", "@") + "&CustomerID=" + customer.CustomerId +
                                "&EventID=" + EventId + "&EventName=" + _eventName.Replace("'", "*") + "&Amount=" +
                                Math.Round(order.OrderValue, 2).ToString("C2") + "&hostName=" +
                                _hostName.Replace("'", "*") + "&hostAddress=" +
                                _address1.Replace("'", "*").Replace("#", "@") + "&hostCitystatezip=" + _cityStateZip +
                                "&eventDate=" + _eventDate + "&appointmentTime=" + appointmentSlot + "&username=" +
                                IoC.Resolve<ISessionContext>().UserSession.UserName + "&password=" + "Pass" +
                                "',310,705)";



                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                
                var eventType = eventRepository.GetById(EventId).EventType;
                var setting = IoC.Resolve<ISettings>();
                if (!setting.CapturePrimaryCarePhysician && eventType == EventType.Corporate)
                {
                    NextButton.Text = "Finish";
                }
            }

        }
        private void FillEventDetails()
        {
            IEventService eventService = IoC.Resolve<IEventService>();
            var eventData = eventService.GetById(EventId);
            if (eventData != null)
            {
                _eventDate = eventData.EventDate.ToLongDateString();
                _eventName = eventData.Name;
                _eventVenue = HttpUtility.HtmlEncode(eventData.OrganizationName) + "<br/>" + CommonCode.AddressMultiLine(eventData.StreetAddressLine1, eventData.StreetAddressLine2, eventData.City, eventData.State, eventData.Zip);
                _hostName = eventData.OrganizationName;
                _address1 = eventData.StreetAddressLine1;
                _cityStateZip = eventData.City + ", " + eventData.State + "  " + eventData.Zip;
                Session["PCPSearchEventState"] = eventData.State;
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

        private static string GetPackageName(int packageId)
        {
            var packageRepository = new PackageRepository();
            return packageRepository.GetById(packageId).Name;
        }

        private Core.Users.Domain.Customer GetCustomerDetail()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetCustomerByUserId(UserId);
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var eventType = eventRepository.GetById(EventId).EventType;
            var setting = IoC.Resolve<ISettings>();
            if (setting.CapturePrimaryCarePhysician)
                Response.RedirectUser("CustomerPCPInformation.aspx?UserID=" + UserId);
            else
            {
                if (eventType == EventType.Corporate)
                    Response.RedirectUser("/Home/ThankYou");
                else
                    Response.RedirectUser("MedicalHistory.aspx?UserID=" + UserId);
            }
        }


    }
}