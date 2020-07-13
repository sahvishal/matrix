using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IEvaluationReminderNotificationPollingAgent))]
    public class EvaluationReminderNotificationPollingAgent : IEvaluationReminderNotificationPollingAgent
    {
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly ILogger _logger;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        public EvaluationReminderNotificationPollingAgent(IOrganizationRoleUserRepository organizationRoleUserRepository, IPhysicianRepository physicianRepository, ILogManager logManager,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, IConfigurationSettingRepository configurationSettingRepository)
        {
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _physicianRepository = physicianRepository;
            _logger = logManager.GetLogger<EvaluationReminderNotificationPollingAgent>();
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _configurationSettingRepository = configurationSettingRepository;
        }
        public void PollForEvaluationReminderNotification()
        {
            _logger.Info("Starting the Polling Agent for Evaluation Reminder Notification.");

            var value = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.SendEmptyQueueEvaluationReminder);

            var physicians = _organizationRoleUserRepository.GetIdNamePairofUsersByRole(Roles.MedicalVendorUser);
            foreach (var orderedPair in physicians)
            {
                var overReadEvaluationPair = _physicianRepository.GetEventCustomerIdForOverReadPhysicianEvaluation(orderedPair.FirstValue);
                var evaluationPair = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(orderedPair.FirstValue);
                if ((value.ToLower() == bool.TrueString.ToLower()) || (evaluationPair.ItemsAvailable > 0 || overReadEvaluationPair.ItemsAvailable > 0))
                {
                    try
                    {
                        var createdByOrgRoleUserId =
                            _organizationRoleUserRepository.GetOrganizationRoleUserIdsForRole((long)Roles.FranchisorAdmin).First();

                        var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(orderedPair.FirstValue);

                        var evaluationReminderNotificationModel = _emailNotificationModelsFactory.GetEvaluationReminderNotificationModel(orderedPair.FirstValue);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.EvaluationReminder, EmailTemplateAlias.EvaluationReminder, evaluationReminderNotificationModel, orgRoleUser.UserId, createdByOrgRoleUserId, "Evaluation Reminder Notification");
                    }
                    catch (Exception ex)
                    {
                        _logger.Info(
                            String.Format("\n System failure: For Physician:{0} \n Message{1}", orderedPair.SecondValue,
                                          ex.Message));
                    }
                }
                else
                {
                    _logger.Info(String.Format("\n No Evaluation Pending For Physician:{0}", orderedPair.SecondValue));
                }
            }
        }
    }
}
