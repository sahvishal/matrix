using System;
using System.Configuration;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.Web.IntegrationTests.Fakes;
using NUnit.Framework;
using IoFile = System.IO.File;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication
{
    [TestFixture]
    public class NotifierTester
    {
        private INotifier _notifier;
        private IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        [SetUp]
        public void SetUp()
        {
            IoC.Register<ISettings, FakeSettings>();
            DependencyRegistrar.RegisterDependencies();
            _notifier = IoC.Resolve<INotifier>();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        }

        [Test]
        public void WelcomeWithUserNameNotificationTester()
        {
            //var validUserId = 1;

            //where areyou invoking it?
            var welcomeEmailViewModel = _emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel("admin", "Bidhan", DateTime.Today.AddDays(-10));
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, "CustomerWelcomeEmailWithUsername", welcomeEmailViewModel, 4, 1, "integration test");
        }

        [Test]
        public void ResultReadyNotificationTester()
        {
            //var validUserId = 1;

            //where areyou invoking it?
            var resultReadyViewModel = _emailNotificationModelsFactory.GetResultReadyModel("Bidhan", "BidhanB", true, 3500);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ResultsReady, "ResultsReady", resultReadyViewModel, 4, 1, "integration test");
        }

        [Test]
        public void WelcomeWithPasswordNotificationTester()
        {
            //var validUserId = 1;

            //where areyou invoking it?
            var welcomeEmailViewModel = _emailNotificationModelsFactory.GetWelcomeWithPasswordNotificationModel("x9m+HqDPZ/izaYrMqL6Sqg==", "Bidhan","");
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithResetMail, "CustomerWelcomeEmailWithPassword", welcomeEmailViewModel, 1, 1, "integration test");
        }
        [Test]
        public void ResetNotificationTester()
        {
            //var validUserId = 1;

            //where areyou invoking it?
            var resetPasswordViewModel = _emailNotificationModelsFactory.GetResetNotificationModel(1, "Bidhan", "qa-App.PreventionHealth.com");
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ResetMail, "ResetPassword", resetPasswordViewModel, 1, 1, "integration test");
        }
        [Test]
        public void AppointmentConfirmationTester()
        {
            //var validUserId = 1;

            //where areyou invoking it?
            var appointmentConfirmationViewModel = _emailNotificationModelsFactory.GetAppointmentConfirmationModel(2, 7);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentConfirmationWithEventDetails, "AppointmentConfirmationWithEventDetails", appointmentConfirmationViewModel, 1, 1, "integration test",useAlternateEmail:true);
        }

        [Test]
        public void AppointmentBookedInTwentyFourHoursTester()
        {
            var appointmentBookedInTwentyFourHoursNotificationModel = _emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(2, 7);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, "AppointmentBookedInTwentyFourHours", appointmentBookedInTwentyFourHoursNotificationModel, 0, 1, "integration test");
        }
        [Test]
        public void PollForAppointmentReminderViaSms()
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var smsNotificationFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();

            var theevent = eventRepository.GetById(33062);
            var customer = customerRepository.GetCustomer(645103);
            var notificationModel = smsNotificationFactory.GetScreeningReminderSmsNotificationModel(customer, theevent);

            _notifier.NotifyViaSms(NotificationTypeAlias.AppointmentReminder, NotificationTypeAlias.AppointmentReminder, notificationModel, customer.UserLogin.Id, 1, "integration test");

        }

        [Test]
        public void PollForAppointmentReminderViaFax()
        {
            var eventRepository = IoC.Resolve<IEventRepository>();
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var smsNotificationFactory = IoC.Resolve<IPhoneNotificationModelsFactory>();
            var customerRessultRepository = IoC.Resolve<IEventCustomerResultRepository>();
            var pcpc = IoC.Resolve<IPrimaryCarePhysicianRepository>();
            var settings = IoC.Resolve<ISettings>();
            var theevent = eventRepository.GetById(33062);
            var customer = customerRepository.GetCustomer(645103);
            var notificationModel = smsNotificationFactory.GetScreeningReminderSmsNotificationModel(customer, theevent);
            var media = settings.MediaLocation + "//temp//" + ConfigurationManager.AppSettings.Get("FaxTestPDF");
            if (!IoFile.Exists(media)) return;

            var bytes = IoFile.ReadAllBytes(media);
            _notifier.NotifyViaFax(NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification, NotificationTypeAlias.PhysicianPartnerCustomerResultFaxNotification, new PhoneNumber(CountryCode.UnitedStatesAndCanada, "111", "1111111", PhoneNumberType.Unknown), bytes, customer.UserLogin.Id, "integration test");
        }

    }
}