using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface INotifier
    {
        IEnumerable<Notification> NotifySubscribersViaEmail<T>(string notificationTypeAlias, string emailTemplateAlias, T model, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null, bool useAlternateEmail = false);
        IEnumerable<Notification> NotifySubscribersViaEmail<T>(string notificationTypeAlias, string emailTemplateAlias, T model, string[] subscriberEmails, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null);
        Notification NotifyCannedEmail(string notificationTypeAlias, Email fromEmail, string toEmail, string subjectText, string bodyText, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null);

        Notification NotifyViaSms<T>(string notificationTypeAlias, string smsTemplateAlias, T model, long userId, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null);

        Notification NotifyViaFax<T>(string notificationTypeAlias, T model, PhoneNumber faxPhoneNumber, byte[] message, long requestedBy, string source, string notes = null, int priority = 0, DateTime? notificationDate = null);

        Notification NotifyViaSmsImmediate<T>(string notificationTypeAlias, string smsTemplateAlias, T model, long userId, long requestedBy, string source, string notes = null, int priority = 0,
            DateTime? notificationDate = null, bool sendBeforeSavingToDb = false);
    }
}