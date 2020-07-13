namespace Falcon.UnitTests.Core.Communication
{
    // TODO: fix.
    //public class NotificationMapperTester
    //{
    //    private NotificationMapper _notificationMapper;

    //    [Test]
    //    public void ReturnsEmailNotificationWhenNotificationMediumIsEmail()
    //    {
    //        var mockRepository = new MockRepository();

    //        var notificationPopulatorMock = mockRepository.DynamicMock<IPopulator<NotificationEntity, Notification>>();
    //        var phoneNumberMapperMock = mockRepository.DynamicMock<IPhoneNumberFactory>();

    //        _notificationMapper = new NotificationMapper(notificationPopulatorMock, phoneNumberMapperMock);

    //        var objectToMap = new NotificationEntity
    //        {
    //            NotificationType = new NotificationTypeEntity { NotificationTypeNameAlias = "Some type of notification" },
    //            NotificationMedium = new NotificationMediumEntity { NotificationMedium = "email" },
    //        };
    //        objectToMap.NotificationEmail.Add(new NotificationEmailEntity { ToEmail = "test@example.com", FromEmail = "test@example.com"});
            
    //        var notification = _notificationMapper.Map(objectToMap);

    //        Assert.AreEqual(typeof(NotificationEmail), notification.GetType());
    //    }

    //    [Test]
    //    public void ReturnsNotificationWhenNotificationMediumIsNotEmailOrPhone()
    //    {
    //        var mockRepository = new MockRepository();

    //        var notificationPopulatorMock = mockRepository.DynamicMock<IPopulator<NotificationEntity, Notification>>();
    //        var phoneNumberMapperMock = mockRepository.DynamicMock<IPhoneNumberFactory>();

    //        _notificationMapper = new NotificationMapper(notificationPopulatorMock, phoneNumberMapperMock);

    //        var objectToMap = new NotificationEntity
    //        {
    //            NotificationType = new NotificationTypeEntity { NotificationTypeNameAlias = "Some type of notification" },
    //            NotificationMedium = new NotificationMediumEntity { NotificationMedium = "not-email" },
    //        };

    //        var notification = _notificationMapper.Map(objectToMap);

    //        Assert.AreEqual(typeof(Notification), notification.GetType());
    //    }
    //}
}