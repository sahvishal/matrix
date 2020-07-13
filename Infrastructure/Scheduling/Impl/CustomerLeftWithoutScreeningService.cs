using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CustomerLeftWithoutScreeningService : ICustomerLeftWithoutScreeningService
    {
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;

        public CustomerLeftWithoutScreeningService(IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier)
        {
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
        }

        public void SendPatientLeftNotification(long eventCustomerId, long? leftWithoutScreeningReasonId, string notes, UserSessionModel currentUser, string source)
        {
            var patientLeftNotificationModel = _emailNotificationModelsFactory.GetPatientLeftNotificationViewModel(eventCustomerId, leftWithoutScreeningReasonId, notes, currentUser.UserId);

            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.PatientLeftNotification, EmailTemplateAlias.PatientLeftNotification, patientLeftNotificationModel, new string[0], 0, currentUser.CurrentOrganizationRole.OrganizationRoleUserId, source);
        }
    }
}
