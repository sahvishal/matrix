using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncSuspectConditionPollingAgent : ISyncSuspectConditionPollingAgent
    {
        private readonly ILogger _logger;
        private readonly ISuspectConditionRepository _suspectConditionRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ISettings _setting;
        private readonly bool _isDevEnvironment;


        public SyncSuspectConditionPollingAgent(ILogManager logManager, ISettings settings, IMedicareApiService medicareApiService, ISuspectConditionRepository suspectConditionRepository)
        {
            _logger = logManager.GetLogger("SyncSuspectConditionPollingAgent");
            _setting = settings;
            _medicareApiService = medicareApiService;
            _suspectConditionRepository = suspectConditionRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void Sync()
        {
            try
            {
                if (!_setting.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }
                var loopCount = 1;
                var recordsToSkip = 0;
                if (_isDevEnvironment || !(DateTime.Now.TimeOfDay > new TimeSpan(1, 0, 0) && DateTime.Now.TimeOfDay < new TimeSpan(4, 0, 0)))
                {
                    _logger.Info(string.Format("Suspect Condition sync Started"));
                    var suspectConditions = _suspectConditionRepository.GetSuspectConditionForSync(recordsToSkip).ToArray();
                    var orgName = _setting.OrganizationNameForHraQuestioner;

                    do
                    {
                        if (suspectConditions.Any())
                        {
                            _logger.Info("Beginning Sync , Loop count : " + loopCount + " pulled " + suspectConditions.Count() + " records");
                            try
                            {
                                var listModel = new MedicareSuspectConditionListModel
                                {
                                    SuspectConditions = Mapper.Map<IEnumerable<SuspectCondition>, IEnumerable<MedicareSuspectConditionViewModel>>(suspectConditions).ToArray(),
                                    OrganizationName = orgName,
                                    Token = DateTime.UtcNow.ToLongTimeString().Encrypt()
                                };
                                
                                    
                                    var success = _medicareApiService.PostAnonymous<List<long>>(_setting.MedicareApiUrl + MedicareApiUrl.SyncSuspectCondition, listModel, escapeAscii: true);
                                    if (success.Any())
                                    {
                                        var suspectConditionSuccessList = suspectConditions.Where(x => success.Contains(x.CustomerId));
                                        foreach (var medicareSuspectCondition in suspectConditionSuccessList)
                                        {
                                            medicareSuspectCondition.IsSynced = true;
                                            _suspectConditionRepository.SaveSuspectCondition(medicareSuspectCondition);
                                        }
                                    }
                                    else
                                    {
                                        recordsToSkip += suspectConditions.Count();             //On HRA, either all records are saved , or none is saved
                                    }
                                    _logger.Info("Sync done for LoopCount: " + loopCount + " ,Successfully synced :" + success.Count + " records");
                                    _logger.Info("Skip count is : " + recordsToSkip);   
                                 
                                
                            }
                            catch (Exception exception)
                            {
                                _logger.Error("Error Message: " + exception.Message + "\n Stack Trace: " + exception.StackTrace);
                                recordsToSkip += suspectConditions.Count();
                            }
                            suspectConditions = _suspectConditionRepository.GetSuspectConditionForSync(recordsToSkip).ToArray();
                            loopCount++;
                        }
                        else
                        {
                            _logger.Info("No Suspect data found, loop count: " + loopCount);
                        }
                    } while (suspectConditions.Any());
                    _logger.Info("Exiting suspect condition sync");
                }
                else
                {
                    _logger.Info(string.Format("SyncSuspectConditionPollingAgent can not be called as time of day is {0}", DateTime.Now.TimeOfDay));
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Error occurred in SyncSuspectConditionPollingAgent, Message: " + exception.Message + "\n Stack Trace: " + exception.StackTrace);
            }
        }
    }
}
