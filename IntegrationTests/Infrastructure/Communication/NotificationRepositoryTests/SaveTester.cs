using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Communication.NotificationRepositoryTests
{
    [Ignore("Can only run one at a time - need to find out why.")]
    public class SaveTester
    {
        protected INotificationRepository _notificationRepository;
        protected INotificationTypeRepository _notificationTypeRepository;
        protected INotificationMediumRepository _notificationMediumRepository;
        private IEnumerable<NotificationType> _notificationTypes;
        private IEnumerable<NotificationMedium> _notificationMedia;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();

            _notificationRepository = IoC.Resolve<INotificationRepository>();
            _notificationTypeRepository = IoC.Resolve<INotificationTypeRepository>();
            _notificationMediumRepository = IoC.Resolve<INotificationMediumRepository>();

            _notificationTypes = _notificationTypeRepository.GetAll().ToList();
            _notificationMedia = _notificationMediumRepository.GetAll().ToList();
        }

        [Test]
        public void CanSaveNewBasicNotification()
        {
            Notification domainObject = GetNotificationToSave(_notificationTypes.First(), _notificationMedia.First());

            var savedNotification = _notificationRepository.Save(domainObject);

            Assert.AreNotEqual(0, savedNotification.Id);
        }

        [Test]
        [Ignore("May not be a real usage case.")]
        public void CanSaveExistingBasicNotification()
        {
            NotificationMedium notificationMedium = _notificationMedia.First(nt => !nt.Medium.ToLower().Contains("email") && !nt.Medium.ToLower().Contains("phone"));
            Notification domainObject = GetNotificationToSave(_notificationTypes.First(), notificationMedium);

            var savedNotification = _notificationRepository.Save(domainObject);
            var updatedNotification = _notificationRepository.Save(savedNotification);

            Assert.AreNotEqual(0, savedNotification.Id);
            Assert.AreEqual(savedNotification.Id, updatedNotification.Id);
        }

        [Test]
        public void CanSaveNewEmailNotification()
        {
            NotificationEmail domainObject = GetNewNotificationEmail();

            Notification savedNotification = _notificationRepository.Save(domainObject);

            Assert.AreNotEqual(0, savedNotification.Id);
        }

        private NotificationEmail GetNewNotificationEmail()
        {
            return new NotificationEmail
            {
                NotificationDate = DateTime.Now,
                NotificationType = _notificationTypes.First(),
                NotificationMedium = _notificationMedia.First(nm => nm.Medium == "Email"),
                UserId = 1,
                DateCreated = DateTime.Now,
                Source = "integration test",
                Body = "test message",
                Subject = "integration test",
                ToEmail = new Email("integration@test.com"),
                FromEmail = new Email("integration@test.com"),
                FromName = "Integration J. Test",
                RequestedBy = 1,
            };
        }

        [Test]
        public void CanSaveExistingEmailNotification()
        {
            NotificationEmail domainObject = GetNewNotificationEmail();

            Notification savedNotification = _notificationRepository.Save(domainObject);
            Notification updatedNotification = _notificationRepository.Save(savedNotification);

            Assert.AreEqual(savedNotification.Id, updatedNotification.Id);
        }

        private Notification GetNotificationToSave(NotificationType notificationType, NotificationMedium notificationMedium)
        {
            return new Notification
            {
                NotificationDate = DateTime.Now,
                NotificationType = notificationType,
                NotificationMedium = notificationMedium,
                UserId = 1,
                DateCreated = DateTime.Now,
                Source = "Notification occurred",
                RequestedBy = 1
            };
        }
    }
}