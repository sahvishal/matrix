using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Marketing;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    [DefaultImplementation]
    public class DirectMailActivityReminderPollingAgent : IDirectMailActivityReminderPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;
        private readonly ICampaignActivityAssignmentRepository _campaignActivityAssignmentRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        private readonly IUserRepository<User> _userRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public DirectMailActivityReminderPollingAgent(ILogManager logManager, IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier,
            ICampaignRepository campaignRepository, ICampaignActivityRepository campaignActivityRepository, ICampaignActivityAssignmentRepository campaignActivityAssignmentRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IUserRepository<User> userRepository, IOrganizationRepository organizationRepository)
        {
            _logger = logManager.GetLogger("DirectMailActivityReminder");
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _campaignRepository = campaignRepository;
            _campaignActivityRepository = campaignActivityRepository;
            _campaignActivityAssignmentRepository = campaignActivityAssignmentRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
        }

        public void PollforDirectMailNotification()
        {
            try
            {
                var activityDate = DateTime.Now;

                var campaignActivities = _campaignActivityRepository.GetActivitiesByDateTypeId(activityDate.Date, (long)CampaignActivityType.DirectMail);

                if (campaignActivities != null && campaignActivities.Any())
                {

                    _logger.Info(string.Format("Activities Count  {0} Found for Today  {1}: ", campaignActivities.Count(), activityDate.Date));

                    foreach (var campaignActivity in campaignActivities)
                    {
                        var campaignActivityAssignments = _campaignActivityAssignmentRepository.GetByCampaignActivityId(campaignActivity.Id);
                        if (campaignActivityAssignments != null && campaignActivities.Any())
                        {
                            var orgRolesUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(campaignActivityAssignments.Select(x => x.AssignedToOrgRoleUserId));

                            var users = _userRepository.GetUsers(orgRolesUsers.Select(x => x.UserId).Distinct().ToList());
                            var campaign = _campaignRepository.GetById(campaignActivity.CampaignId);

                            var healthPlan = _organizationRepository.GetOrganizationbyId(campaign.AccountId);

                            foreach (var user in users)
                            {
                                if (user.Email == null || string.IsNullOrEmpty(user.Email.ToString()))
                                {
                                    _logger.Info("No Email Found For User " + user.NameAsString);
                                    continue;
                                }

                                _logger.Info("Sending Direct Mail to Email Id : " + user.Email);

                                var createdByOrgRoleUser = orgRolesUsers.First(x => x.UserId == user.Id);
                                var model = _emailNotificationModelsFactory.GetDirectMailActivityNotificationViewModel(user.NameAsString, campaign.Name, healthPlan.Name, campaign.CustomTags);

                                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.DirectMailActivityNotification, EmailTemplateAlias.DirectMailActivityEmailReminder, model, new string[] { user.Email.ToString() }, user.Id, createdByOrgRoleUser.Id, "Direct Mail Activity Reminder");
                            }
                        }
                        else
                        {
                            _logger.Info("No Assignment Found for Activity " + campaignActivity.Id);
                        }
                    }
                }
                else
                {
                    _logger.Info("No Activity scheduled for Today Date: " + activityDate.ToShortDateString());
                }
            }
            catch (Exception ex) { _logger.Error("Exception Message: " + ex.Message + " Stack Trace" + ex.StackTrace); }
        }
    }

}

