using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using System;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Scheduling.Interfaces;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SendNotiificationToNursePractitionerPollingAgent : ISendNotiificationToNursePractitionerPollingAgent
    {
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ITestResultService _testResultService;
        private readonly INewResultFlowStateService _newResultFlowStateService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private const long _RequestedByOrgRoleUserId = 1;

        public SendNotiificationToNursePractitionerPollingAgent(IEmailNotificationModelsFactory emailNotificationModelsFactory,
            IEventCustomerResultRepository eventCustomerResultRepository, ILogManager logManager, INotifier notifier,
            ISettings settings, ITestResultService testResultService, INewResultFlowStateService newResultFlowStateService,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IEventCustomerRepository eventCustomerRepository)
        {
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _testResultService = testResultService;
            _newResultFlowStateService = newResultFlowStateService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _notifier = notifier;
            _settings = settings;
            _logger = logManager.GetLogger("SendNotiificationToNursePractitionerPollingAgent");
        }

        public void PollForSendNotification()
        {
            try
            {
                _logger.Info("Starting the Polling Agent to Send Notification to Nurse Practitioner after evaluation.");

                var eventCustomerResults = _eventCustomerResultRepository.GetEventCustomerResultByResultState((int)NewTestResultStateNumber.Evaluated, false, _settings.ResultFlowChangeDate);
                if (eventCustomerResults.IsNullOrEmpty())
                {
                    _logger.Info("No record found to send notification."); return;
                }

                var cryptographyService = new DigitalDeliveryCryptographyService();
                _logger.Info("Total Customer: " + eventCustomerResults.Count());

                var appUrl = _settings.AppUrl;
                var medicareAppUrl = _settings.MedicareAppUrl;

                foreach (var eventCustomerResult in eventCustomerResults)
                {
                    try
                    {
                        _logger.Info("sending Notification to Np customer Id: " + eventCustomerResult.CustomerId + "event Id: " + eventCustomerResult.EventId);

                        var eventCustomer = _eventCustomerRepository.GetRegisteredEventForUser(eventCustomerResult.CustomerId, eventCustomerResult.EventId);
                        if (eventCustomer.AwvVisitId.HasValue)
                        {
                            var model = new EhrReadyForReEvaluation
                            {
                                EventId = eventCustomerResult.EventId,
                                HfCustomerId = eventCustomerResult.CustomerId,
                                Message = "",
                                ReadyForReEvaluation = true
                            };

                            _logger.Info(string.Format("Sending for Sync ready for Reevaluation to HRA for NursePractitionerId: {0} for CustomerId: {1} and EventId: {2}", eventCustomerResult.SignedOffBy.Value, eventCustomerResult.CustomerId, eventCustomerResult.EventId));

                            var isSynced = _newResultFlowStateService.SyncReadyForEvaluation(model, eventCustomerResult.DataRecorderMetaData.DataRecorderModifier.Id, "Calling from polling agent PollForSendNotification");
                            
                            if (isSynced)
                            {
                                _logger.Info(string.Format(" Synced Notification send To NP and HRA has been updated NursePractitionerId: {0} for CustomerId: {1} and EventId: {2}", eventCustomerResult.SignedOffBy.Value, eventCustomerResult.CustomerId, eventCustomerResult.EventId));

                                var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(eventCustomerResult.SignedOffBy.Value);

                                var urlTestDocumentation = appUrl + string.Format("/App/Common/Results.aspx?key={0}", cryptographyService.Encrypt(eventCustomerResult.EventId + "~" + eventCustomerResult.CustomerId));
                                var urlUnlockAssessment = medicareAppUrl + string.Format("/mailauth/{0}", eventCustomer.AwvVisitId);
                                var urlTriggersReadyForCodingStatus = ""; // need to write code for this url variables

                                var notificationModel = _emailNotificationModelsFactory.GetNPfordiagnosingwithlinkNotificationViewModel(eventCustomerResult.CustomerId, eventCustomerResult.EventId, urlTestDocumentation, urlUnlockAssessment, urlTriggersReadyForCodingStatus);

                                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.NPfordiagnosingwithlinkNotification, EmailTemplateAlias.NPfordiagnosingwithlinkNotification, notificationModel, orgRoleUser.UserId, _RequestedByOrgRoleUserId, "SendNotiificationToNursePractitionerPollingAgent");

                                _logger.Info(string.Format("Notification sent to NursePractitionerId: {0} for CustomerId: {1} and EventId: {2}", eventCustomerResult.SignedOffBy.Value, eventCustomerResult.CustomerId, eventCustomerResult.EventId));
                                
                                _testResultService.SetResultstoState(eventCustomerResult.EventId, eventCustomerResult.CustomerId, (int)NewTestResultStateNumber.NpNotificationSent, false, eventCustomerResult.DataRecorderMetaData.DataRecorderModifier.Id);
                                _logger.Info(string.Format(" Result State has been update for CustomerId: {0} and EventId: {1}", eventCustomerResult.CustomerId, eventCustomerResult.EventId));
                            }

                            _logger.Info(string.Format("Synced To NP and HRA NursePractitionerId: {0} for CustomerId: {1} and EventId: {2} and hra Result {3}", eventCustomerResult.SignedOffBy.Value, eventCustomerResult.CustomerId, eventCustomerResult.EventId , isSynced));
                        }
                        else
                        {
                            _logger.Error(string.Format("AwvVisitId is null for CustomerId: {0} and EventId: {1}", eventCustomerResult.CustomerId, eventCustomerResult.EventId));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("System failure: For NursePractitionerId: {0}, CustomerId: {1} and EventId: {2}", eventCustomerResult.SignedOffBy.Value, eventCustomerResult.CustomerId, eventCustomerResult.EventId));
                        _logger.Error("Error Message: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occurred on execution of SendNotiificationToNursePractitionerPollingAgent.");
                _logger.Error("Error Message: " + ex.Message);
            }
        }
    }
}
