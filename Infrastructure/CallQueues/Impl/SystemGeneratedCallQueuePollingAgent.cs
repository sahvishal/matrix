using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class SystemGeneratedCallQueuePollingAgent : ISystemGeneratedCallQueuePollingAgent
    {
        private readonly ILogger _logger;
        private readonly ISettings _settings;

        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallQueueCustomerHelper _callQueueCustomerHelper;

        private readonly IEasiestToConvertCallQueueService _easiestToConvertCallQueueService;
        private readonly IAnnualCallQueueService _annualCallQueueService;
        private readonly IConfirmationCallQueueService _confirmationCallQueueService;
        private readonly IUpsellCallQueueService _upsellCallQueueService;
        private readonly IFillEventsCallQueueService _fillEventsCallQueueService;
        private readonly ICallBackCallQueueService _callBackCallQueueService;
        private readonly ISystemGeneratedCallQueueCriteriaService _systemGeneratedCallQueueCriteriaService;
        private readonly ISystemGeneratedCallQueueAssignmentRepository _systemGeneratedCallQueueAssignmentRepository;


        public SystemGeneratedCallQueuePollingAgent(ILogManager logManager, ISettings settings, ICallQueueRepository callQueueRepository, ICallQueueCustomerHelper callQueueCustomerHelper,
            IEasiestToConvertCallQueueService easiestToConvertCallQueueService, IAnnualCallQueueService annualCallQueueService, IConfirmationCallQueueService confirmationCallQueueService,
            IUpsellCallQueueService upsellCallQueueService, IFillEventsCallQueueService fillEventsCallQueueService, ICallBackCallQueueService callBackCallQueueService,
            ISystemGeneratedCallQueueCriteriaService systemGeneratedCallQueueCriteriaService, ISystemGeneratedCallQueueAssignmentRepository systemGeneratedCallQueueAssignmentRepository)
        {
            _logger = logManager.GetLogger<SystemGeneratedCallQueuePollingAgent>();
            _settings = settings;

            _callQueueRepository = callQueueRepository;
            _callQueueCustomerHelper = callQueueCustomerHelper;

            _easiestToConvertCallQueueService = easiestToConvertCallQueueService;
            _annualCallQueueService = annualCallQueueService;
            _confirmationCallQueueService = confirmationCallQueueService;
            _upsellCallQueueService = upsellCallQueueService;
            _fillEventsCallQueueService = fillEventsCallQueueService;
            _callBackCallQueueService = callBackCallQueueService;
            _systemGeneratedCallQueueCriteriaService = systemGeneratedCallQueueCriteriaService;
            _systemGeneratedCallQueueAssignmentRepository = systemGeneratedCallQueueAssignmentRepository;
        }

        public void PollForCallQueue()
        {
            try
            {
                var callQueues = _callQueueRepository.GetAll(false);
                if (callQueues != null && callQueues.Any())
                {

                    foreach (var callQueue in callQueues)
                    {
                        var criterias = _systemGeneratedCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(callQueue.Id);
                        criterias = criterias.Where(x => x.IsQueueGenerated);
                        try
                        {
                            IEnumerable<CallQueueCustomer> callQueueCustomers;
                            switch (callQueue.Category)
                            {
                                case CallQueueCategory.EasiestToConvertProspect:
                                    callQueueCustomers = _easiestToConvertCallQueueService.GetCallQueueCustomers(callQueue.Id, callQueue.LastQueueGeneratedDate);
                                    if (callQueueCustomers != null && callQueueCustomers.Any())
                                    {
                                        _logger.Info(string.Format("{0} call queue customer found for {1}", callQueueCustomers.Count(), callQueue.Category));
                                        _callQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomers);
                                        _logger.Info(string.Format("{0} call queue customer saved for {1}", callQueueCustomers.Count(), callQueue.Category));
                                    }
                                    else
                                        _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));
                                    break;
                                case CallQueueCategory.Annual:
                                    callQueueCustomers = _annualCallQueueService.GetCallQueueCustomers(callQueue.Id);
                                    if (callQueueCustomers != null && callQueueCustomers.Any())
                                    {
                                        _logger.Info(string.Format("{0} call queue customer found for {1}", callQueueCustomers.Count(), callQueue.Category));
                                        _callQueueCustomerHelper.SaveCallQueueCustomer(callQueueCustomers);
                                        _logger.Info(string.Format("{0} call queue customer saved for {1}", callQueueCustomers.Count(), callQueue.Category));
                                    }
                                    else
                                        _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));
                                    break;
                                case CallQueueCategory.CallBack:
                                    callQueueCustomers = _callBackCallQueueService.GetCallQueueCustomers(callQueue.Id, callQueue.LastQueueGeneratedDate);
                                    if (callQueueCustomers != null && callQueueCustomers.Any())
                                    {
                                        _logger.Info(string.Format("{0} call queue customer found for {1}", callQueueCustomers.Count(), callQueue.Category));
                                        _callQueueCustomerHelper.SaveCallQueueCustomerForCallBack(callQueueCustomers);
                                        _logger.Info(string.Format("{0} call queue customer saved for {1}", callQueueCustomers.Count(), callQueue.Category));
                                    }
                                    else
                                        _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));
                                    break;
                                case CallQueueCategory.FillEvents:
                                    foreach (var criteria in criterias)
                                    {
                                        _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                                        callQueueCustomers = _fillEventsCallQueueService.GetCallQueueCustomers(callQueue.Id, criteria);
                                        if (callQueueCustomers != null && callQueueCustomers.Any())
                                        {
                                            _logger.Info(string.Format("{0} call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                            _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);
                                            _logger.Info(string.Format("{0} call queue customer saved for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                        }
                                        else
                                            _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));

                                        criteria.IsQueueGenerated = true;
                                        criteria.LastQueueGeneratedDate = DateTime.Now;
                                        _systemGeneratedCallQueueCriteriaService.Save(criteria);
                                    }
                                    break;
                                case CallQueueCategory.Upsell:
                                    foreach (var criteria in criterias)
                                    {
                                        _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                                        callQueueCustomers = _upsellCallQueueService.GetCallQueueCustomers(callQueue.Id, criteria.Amount, criteria.NoOfDays);
                                        if (callQueueCustomers != null && callQueueCustomers.Any())
                                        {
                                            _logger.Info(string.Format("{0} call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                            _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);
                                            _logger.Info(string.Format("{0} call queue customer saved for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                        }
                                        else
                                            _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));

                                        criteria.IsQueueGenerated = true;
                                        criteria.LastQueueGeneratedDate = DateTime.Now;
                                        _systemGeneratedCallQueueCriteriaService.Save(criteria);
                                    }

                                    break;
                                case CallQueueCategory.Confirmation:
                                    foreach (var criteria in criterias)
                                    {
                                        _systemGeneratedCallQueueAssignmentRepository.DeleteByCriteriaId(criteria.Id);
                                        callQueueCustomers = _confirmationCallQueueService.GetCallQueueCustomers(callQueue.Id, criteria.NoOfDays);
                                        if (callQueueCustomers != null && callQueueCustomers.Any())
                                        {
                                            _logger.Info(string.Format("{0} call queue customer found for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                            _callQueueCustomerHelper.SaveCallQueueCustomerForFillEvent(callQueueCustomers, criteria.Id);
                                            _logger.Info(string.Format("{0} call queue customer saved for {1} for Agent Id : {2}", callQueueCustomers.Count(), callQueue.Category, criteria.AssignedToOrgRoleUserId));
                                        }
                                        else
                                            _logger.Info(string.Format("No call queue customer found for {0}", callQueue.Category));

                                        criteria.IsQueueGenerated = true;
                                        criteria.LastQueueGeneratedDate = DateTime.Now;
                                        _systemGeneratedCallQueueCriteriaService.Save(criteria);

                                    }
                                    break;
                            }

                            callQueue.IsQueueGenerated = true;
                            callQueue.LastQueueGeneratedDate = DateTime.Now;
                            _callQueueRepository.Save(callQueue);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error while creating {0} call queue. Message {1} \n Stack Trace {2}", callQueue.Category, ex.Message, ex.StackTrace));
                        }

                    }
                }
                else
                    _logger.Info("No System generated call queue exist.");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while pulling System generated call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
