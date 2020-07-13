using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using Falcon.App.Core.CallCenter.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    class CustomerCallQueueCallAttemptService : ICustomerCallQueueCallAttemptService
    {
        private readonly ICustomerCallQueueCallAttemptRepository _customerCallQueueCallAttemptRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCriteriaRepository _callQueueCriteriaRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IHealthPlanCriteriaAssignmentRepository _healthPlanCriteriaAssignmentRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;
        private readonly IHealthPlanCriteriaTeamAssignmentRepository _healthPlanCriteriaTeamAssignmentRepository;
        private readonly IHealthPlanCriteriaDirectMailService _healthPlanCriteriaDirectMailService;
        private readonly ISettings _settings;
        //ctor
        public CustomerCallQueueCallAttemptService(ICustomerCallQueueCallAttemptRepository customerCallQueueCallAttemptRepository,
                                                   ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository,
                                                   ICallQueueCriteriaRepository callQueueCriteriaRepository, ICampaignRepository campaignRepository,
                                                   IHealthPlanCriteriaAssignmentRepository healthPlanCriteriaAssignmentRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
                                                   IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService, IHealthPlanCriteriaTeamAssignmentRepository healthPlanCriteriaTeamAssignmentRepository, ISettings settings, IHealthPlanCriteriaDirectMailService healthPlanCriteriaDirectMailService)
        {
            _customerCallQueueCallAttemptRepository = customerCallQueueCallAttemptRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueCriteriaRepository = callQueueCriteriaRepository;
            _campaignRepository = campaignRepository;
            _healthPlanCriteriaAssignmentRepository = healthPlanCriteriaAssignmentRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
            _callQueueRepository = callQueueRepository;
            _healthPlanCriteriaTeamAssignmentRepository = healthPlanCriteriaTeamAssignmentRepository;
            _settings = settings;
            _healthPlanCriteriaDirectMailService = healthPlanCriteriaDirectMailService;
        }

        public void SetReadAndUnderstoodNotes(long callAttemptId)
        {
            var callAttemptRecord = _customerCallQueueCallAttemptRepository.GetById(callAttemptId);
            callAttemptRecord.IsNotesReadAndUnderstood = true;
            _customerCallQueueCallAttemptRepository.Save(callAttemptRecord);
        }

        public IEnumerable<CallCentreAgentQueueListViewModel> CallCenterAgentDashboardData(CallCentreAgentQueueFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var criteriaCollection = _callQueueCriteriaRepository.GetAgentAssignedCallQueueCriteria(filter);

            if (criteriaCollection.IsNullOrEmpty())
            {
                totalRecords = 0;
                return null;
            }

            //to find distinct list of healthplanIds just group them and select first of each such group
            var healthPlanIds = criteriaCollection.Select(x => x.HealthPlanId).Distinct();

            var healthPlanNameIdPairList = _corporateAccountRepository.HealthPlanNamesCorrepondingToHealthPlanIds(healthPlanIds);

            var callQueues = _callQueueRepository.GetByIds(criteriaCollection.Select(x => x.CallQueueId).Distinct(), false, true);

            var campaignIds = criteriaCollection.Where(x => x.CampaignId.HasValue).Select(x => x.CampaignId.Value).ToList();
            var campaigns = _campaignRepository.GetByIds(campaignIds);

            var criteriaIds = criteriaCollection.Select(x => x.Id).ToArray();

            //Eliminating those criterias for which Number of Customers are ZERO
            var criteriasToExclude = new List<long>();
            foreach (var criteria in criteriaCollection)
            {
                var count = CustomerCountForHealthPlanCriteria(criteria, callQueues, true);
                if (!(count > 0))
                {
                    criteriasToExclude.Add(criteria.Id);
                }
            }
            criteriaCollection = criteriaCollection.Where(x => !criteriasToExclude.Contains(x.Id)).Select(x => x);    //uncomment this to make this work(except fillevent)

            //Take criterias according to our paging
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            totalRecords = criteriaCollection.Count();
            criteriaCollection = criteriaCollection.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            var assignments = _healthPlanCriteriaAssignmentRepository.GetByCriteriaIds(criteriaIds);
            var teamAssignments = _healthPlanCriteriaTeamAssignmentRepository.GetByCriteriaIds(criteriaIds);

            var criteriaDirectMailDates = _healthPlanCriteriaDirectMailService.GetDirectMailDatesByCriteriaIds(criteriaCollection.Select(x => x.Id));

            //putting data into our View model to be returned
            var listModel = new List<CallCentreAgentQueueListViewModel>();
            foreach (var item in criteriaCollection)
            {
                var model = new CallCentreAgentQueueListViewModel();

                var healthPlan = healthPlanNameIdPairList.First(x => x.FirstValue == item.HealthPlanId);
                var callQueue = callQueues.First(x => x.Id == item.CallQueueId);
                var campaign = item.CampaignId.HasValue ? campaigns.First(x => x.Id == item.CampaignId.Value) : null;
                var assignmentDate = assignments != null ? assignments.FirstOrDefault(x => x.HealthPlanCriteriaId == item.Id && x.AssignedToOrgRoleUserId == filter.AgentOrganizationRoleUserId) : null;
                var teamAssignmentDate = teamAssignments != null ? teamAssignments.FirstOrDefault(x => x.HealthPlanCriteriaId == item.Id) : null;

                var directMailDates = criteriaDirectMailDates.Where(x => x.FirstValue == item.Id).Select(x => x.SecondValue);

                model.CriteriaName = callQueue.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan || callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation ? item.CriteriaName
                    : (callQueue.Category == HealthPlanCallQueueCategory.MailRound ? campaign.Name : healthPlan.SecondValue + " " + callQueue.Name);
                model.CriteriaId = item.Id;
                model.HealthPlanName = healthPlan.SecondValue;
                model.HealthPlanId = healthPlan.FirstValue;
                model.CallQueueName = callQueue.Name;
                model.CallQueueId = callQueue.Id;
                model.CapmaignId = item.CampaignId;
                model.CampaignName = campaign != null ? campaign.Name : string.Empty;
                if (assignmentDate != null)
                {
                    model.StartDate = assignmentDate.StartDate;
                    model.EndDate = assignmentDate.EndDate;
                }
                else if (teamAssignmentDate != null)
                {
                    model.StartDate = teamAssignmentDate.StartDate;
                    model.EndDate = teamAssignmentDate.EndDate;
                }

                model.DirectMailDates = directMailDates;

                listModel.Add(model);
            }

            return listModel;
        }

        public void SetCallIdCallAttempt(long attemptId, long callId)
        {
            var domain = _customerCallQueueCallAttemptRepository.GetById(attemptId);
            domain.CallId = callId;
            _customerCallQueueCallAttemptRepository.Save(domain);
        }

        public long CustomerCountForHealthPlanCriteria(HealthPlanCallQueueCriteria criteria, IEnumerable<CallQueue> callQueues, bool isForDashboard = false)
        {
            var callQueueCategory = callQueues.FirstOrDefault(x => x.Id == criteria.CallQueueId).Category;
            long totalCustomersForCriteria = 0;
            var filter = new OutboundCallQueueFilter
            {
                CallQueueId = criteria.CallQueueId,
                CriteriaId = criteria.Id,
                HealthPlanId = criteria.HealthPlanId ?? 0,
                GmsAccountIds = _settings.GmsAccountIds
                //Radius = 25,
                //ZipCode = criteria.ZipCode
            };

            if (callQueueCategory == HealthPlanCallQueueCategory.FillEventsHealthPlan)
            {
                _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
                totalCustomersForCriteria = _callQueueCustomerRepository.GetCallQueueCustomerCountForHealthPlanFillEvents(filter, isForDashboard);
            }
            else if (callQueueCategory == HealthPlanCallQueueCategory.MailRound)
            {
                filter.CampaignId = criteria.CampaignId;

                _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
                totalCustomersForCriteria = _callQueueCustomerRepository.GetMailRoundCallqueueCustomerCount(filter, isForDashboard);
            }
            else if (callQueueCategory == HealthPlanCallQueueCategory.LanguageBarrier)
            {
                _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
                totalCustomersForCriteria = _callQueueCustomerRepository.GetLanguageBarrierCallQueueCustomerCount(filter, isForDashboard);
            }
            else if (callQueueCategory == HealthPlanCallQueueCategory.AppointmentConfirmation)
            {
                _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);
                totalCustomersForCriteria = _callQueueCustomerRepository.GetConfirmationCallQueueCustomerCount(filter);
            }
            return totalCustomersForCriteria;
        }
    }
}
