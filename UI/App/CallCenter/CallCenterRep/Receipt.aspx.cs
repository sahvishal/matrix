using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.DependencyResolution;
using Falcon.App.UI;

public partial class App_CallCenter_CallCenterRep_Receipt : System.Web.UI.Page
{
    public string strEventDate;
    public string strEventVenue;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";

        if (!IsPostBack)
        {

            Mail();
        }
        Response.End();
    }

    private void Mail()
    {
        var eventId = Session["EventID"] != null && !string.IsNullOrEmpty(Session["EventID"].ToString())
                          ? Convert.ToInt64(Session["EventID"])
                          : 0;
        var customerId = Session["CustomerId"] != null && !string.IsNullOrEmpty(Session["CustomerId"].ToString())
                          ? Convert.ToInt64(Session["CustomerId"])
                          : 0;
        var customerRepository = IoC.Resolve<ICustomerRepository>();
        var customer = customerRepository.GetCustomer(customerId);

        var notifier = IoC.Resolve<INotifier>();
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        var smsNotificaionModelFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();
        var eventCustomerNotificationRepository = IoC.Resolve<IEventCustomerNotificationRepository>();
        var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
        var emailTemplateRepository = IoC.Resolve<IEmailTemplateRepository>();
        var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
        var eventCustomer = eventCustomerRepository.Get(eventId, customerId);
        var appointmentConfirmationViewModel = emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventId, customerId);

        var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
        var account = corporateAccountRepository.GetbyEventId(eventId);
        
        string emailTemplateAlias = EmailTemplateAlias.AppointmentConfirmationWithEventDetails;
        if (account != null && account.AppointmentConfirmationMailTemplateId > 0)
        {

            var emailTemplate = emailTemplateRepository.GetById(account.AppointmentConfirmationMailTemplateId);
            emailTemplateAlias = emailTemplate.Alias;
        }

        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentConfirmationWithEventDetails, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath, useAlternateEmail: true);

        //If somebody registered within 24 hours of the event Date then send notification.
        if (appointmentConfirmationViewModel.EventDate.AddDays(-1).Date == DateTime.Now.Date)
        {
            var appointmentBookedInTwentyFourHoursNotificationModel = emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(eventId, customerId);
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
        }

        if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
        {
            logger.Info("customer has not Subscribed for SMS customerId " + customer.CustomerId);

            return;
        }
        if (!eventCustomer.EnableTexting) return;

        if (account != null && !account.EnableSms)
        {
            logger.Info("account has disabled SMS, Account Tag: " + account.Tag);
            return;
        }

        var eventRepository = IoC.Resolve<IEventRepository>();
        var eventData = eventRepository.GetById(eventId);


        var messageAlreadySentList = eventCustomerNotificationRepository.GetAllByEventCustomerId(eventCustomer.Id, NotificationTypeAlias.AppointmentConfirmation);
        var messageCount = (messageAlreadySentList != null && messageAlreadySentList.Any()) ? messageAlreadySentList.Count() : 0;

        var smsNotificaionModel = smsNotificaionModelFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);

        if (account != null && messageCount >= account.MaximumSms)
        {
            logger.Info("Maximum SMS has Been Sent ");
            logger.Info(string.Format("Allowed SMS {0}, SMS Already Sent {0} " + account.MaximumSms, messageCount));
            return;
        }

        var smsTemplateAlias = EmailTemplateAlias.AppointmentConfirmation;
        if (account != null && account.ConfirmationSmsTemplateId.HasValue && account.ConfirmationSmsTemplateId.Value > 0)
        {
            var smsTemplate = emailTemplateRepository.GetById(account.ConfirmationSmsTemplateId.Value);
            smsTemplateAlias = smsTemplate.Alias;
        }
        var notification = notifier.NotifyViaSms(NotificationTypeAlias.AppointmentConfirmation, smsTemplateAlias, smsNotificaionModel, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

        if (notification != null)
        {
            var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomer.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
            eventCustomerNotificationRepository.Save(eventCustomerNotification);
        }

    }

    protected string GetTestName(long packageId)
    {
        ITestRepository testRepository = new TestRepository();
        return testRepository.GetTestNamesByPackageId(packageId);
    }
}
