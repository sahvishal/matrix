using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanMailRoundCallQueuePollingAgent : IHealthPlanMailRoundCallQueuePollingAgent
    {
        private readonly ILogger _logger;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICampaignActivityRepository _campaignActivityRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHealthPlanCallQueueCriteriaRepository _healthPlanCallQueueCriteriaRepository;
        private readonly IHealthPlanCallRoundService _healthPlanCallRoundService;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IHealthPlanCallQueueAssignmentRepository _healthPlanCallQueueAssignmentRepository;

        public HealthPlanMailRoundCallQueuePollingAgent(ILogManager logManager, ICampaignRepository campaignRepository, ICampaignActivityRepository campaignActivityRepository,
            ICorporateAccountRepository corporateAccountRepository, IHealthPlanCallQueueCriteriaRepository healthPlanCallQueueCriteriaRepository, IHealthPlanCallRoundService healthPlanCallRoundService,
            ICallQueueRepository callQueueRepository, IHealthPlanCallQueueAssignmentRepository healthPlanCallQueueAssignmentRepository)
        {
            _logger = logManager.GetLogger("HealthPlanMailRoundPollingAgent");
            _campaignRepository = campaignRepository;
            _campaignActivityRepository = campaignActivityRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _healthPlanCallQueueCriteriaRepository = healthPlanCallQueueCriteriaRepository;
            _healthPlanCallRoundService = healthPlanCallRoundService;
            _callQueueRepository = callQueueRepository;
            _healthPlanCallQueueAssignmentRepository = healthPlanCallQueueAssignmentRepository;
        }

        public void PollForHealthPlanMailRoundCallQueue()
        {
            try
            {
                var callDate = DateTime.Now;
                var campaigns = new List<Campaign>();
                var campaignByCallDate = _campaignRepository.GeCotporateCampaignForCallQueue(callDate);

                if (!campaignByCallDate.IsNullOrEmpty())
                {
                    campaigns.AddRange(campaignByCallDate);
                }

                var campaignsNotGenerated = _campaignRepository.GetCotporateCampaignForNotGenerated();

                if (!campaignsNotGenerated.IsNullOrEmpty())
                {
                    var campaigIds = campaigns.Select(x => x.Id).ToArray();
                    if (!campaigIds.IsNullOrEmpty())
                    {
                        campaignsNotGenerated = campaignsNotGenerated.Where(x => !campaigIds.Contains(x.Id)).ToArray();
                        if (!campaignsNotGenerated.IsNullOrEmpty())
                            campaigns.AddRange(campaignsNotGenerated);
                    }
                    else
                    {
                        campaigns.AddRange(campaignsNotGenerated);
                    }
                }

                if (campaigns.IsNullOrEmpty())
                {
                    _logger.Info("No Campaigns found for call queue generation.");
                    return;
                }

                var healthPlanIds = campaigns.Select(x => x.AccountId).ToArray();
                var healthPlans = _corporateAccountRepository.GetByIds(healthPlanIds);

                foreach (var campaign in campaigns)
                {
                    try
                    {
                        _logger.Info("Started creating Mail Round call queue for campaign: " + campaign.Name);

                        var campaignActivites = _campaignActivityRepository.GetByCampaignId(campaign.Id);

                        var outboundCallAcivity = campaignActivites.FirstOrDefault(ca => ca.TypeId == (long)CampaignActivityType.OutboundCall && ca.ActivityDate.Date == callDate.Date);

                        if (outboundCallAcivity == null)
                            outboundCallAcivity = campaignActivites.Where(ca => ca.TypeId == (long)CampaignActivityType.OutboundCall).OrderByDescending(x => x.ActivityDate).FirstOrDefault();

                        if (outboundCallAcivity == null)
                            continue;

                        var firstDirectMailActivity = campaignActivites.Where(ca => ca.TypeId == (long)CampaignActivityType.DirectMail && ca.ActivityDate <= outboundCallAcivity.ActivityDate).OrderBy(ca => ca.ActivityDate).FirstOrDefault();

                        if (firstDirectMailActivity == null)
                        {
                            _logger.Info("No Direct mail activity before outbound call.");
                            _logger.Info("Completed creating Mail Round call queue for campaign: " + campaign.Name);
                            continue;
                        }

                        var criterias = _healthPlanCallQueueCriteriaRepository.GetByCampaignId(campaign.Id);
                        if (criterias.IsNullOrEmpty())
                        {
                            _logger.Info("No Criteria has been created.");
                            _logger.Info("Completed creating Mail Round call queue for campaign: " + campaign.Name);
                            continue;
                        }

                        foreach (var campaingnCriteria in criterias)
                        {
                            try
                            {
                                if (campaingnCriteria.IsQueueGenerated && campaingnCriteria.LastQueueGeneratedDate.HasValue && campaingnCriteria.LastQueueGeneratedDate.Value.Date == callDate.Date)
                                {
                                    _logger.Info("Call queue has been already generated for the campaign.");
                                    _logger.Info("Completed creating Mail Round call queue for campaign: " + campaign.Name);
                                    continue;
                                }

                                _healthPlanCallQueueAssignmentRepository.DeleteByCriteriaId(campaingnCriteria.Id);

                                var healthPlan = healthPlans.Single(x => x.Id == campaign.AccountId);

                                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.MailRound);

                                _healthPlanCallRoundService.SaveMailRoundCallQueueCustomers(healthPlan, campaingnCriteria, callQueue, _logger, campaign);

                                campaingnCriteria.IsQueueGenerated = true;
                                campaingnCriteria.LastQueueGeneratedDate = DateTime.Now;
                                _healthPlanCallQueueCriteriaRepository.Save(campaingnCriteria);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("Some Error Occurred While Generating Campaign Criteria Data: " + campaign.Name);
                                _logger.Error("Message: " + ex.Message);
                                _logger.Error("Stack Trace: " + ex.StackTrace);
                            }

                        }

                        _logger.Info("Completed creating Mail Round call queue for campaign: " + campaign.Name);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Error while Creating Mail Round call queue for campaign: " + campaign.Name);
                        _logger.Error("Message : " + ex.Message);
                        _logger.Error("Stack Trace : " + ex.StackTrace);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error while Polling Mail Round call queue");
                _logger.Error("Message : " + ex.Message);
                _logger.Error("Stack Trace : " + ex.StackTrace);
            }

        }
    }
}
