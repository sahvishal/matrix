using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SyncResultsReadyForCodingPollingAgent : ISyncResultsReadyForCodingPollingAgent
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly INewResultFlowStateService _newResultFlowStateService;
        private readonly ILogger _logger;
        private readonly ISettings _settings;

        public SyncResultsReadyForCodingPollingAgent(ILogManager logManager, IEventCustomerResultRepository eventCustomerResultRepository, INewResultFlowStateService newResultFlowStateService, ISettings settings) //, ITestResultService testResultService
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _settings = settings;
            
            _newResultFlowStateService = newResultFlowStateService;
            _logger = logManager.GetLogger("SyncResultsReadyForCoding");
        }

        public void PollForSync()
        {
            try
            {
                _logger.Info("Syncing results ready for coding......");

                var results = _eventCustomerResultRepository.GetResultsNpVerified((int)NewTestResultStateNumber.NpSigned, true, _settings.ResultFlowChangeDate);

                if (results.IsNullOrEmpty())
                {
                    _logger.Info("No results found for sync.");
                    return;
                }

                _logger.Info("Total records : " + results.Count());

                foreach (var result in results)
                {
                    try
                    {
                        _logger.Info(string.Format("EventID : {0} and CustomerID : {1}", result.EventId, result.CustomerId));

                        var syncModel = new EhrReadyforCodingViewModel
                        {
                            EventId = result.EventId,
                            HfCustomerId = result.CustomerId,
                            ReadyForCoding = true,
                            Message = string.Empty
                        };

                        _newResultFlowStateService.SyncReadyForCodingForVisit(syncModel, result.DataRecorderMetaData.DataRecorderModifier.Id, "SaveCustomerResultAfterEvaluation");
                        
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error syncing to HRA for EventID : {0} and CustomerID : {1}", result.EventId, result.CustomerId));
                        _logger.Error(ex);
                    }
                }

                _logger.Info("Result sync completed.");
            }
            catch (Exception ex)
            {
                _logger.Error("Error getting data for sync.", ex);
            }
        }
    }
}
