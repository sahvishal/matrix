using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class DeletePastEventSystemGeneratedCallQueuePollingAgent : IDeletePastEventSystemGeneratedCallQueuePollingAgent
    {
        private readonly IDeletePastEventCallQueueService _deletePastEventCallQueueService;
        private readonly ILogger _logger;

        public DeletePastEventSystemGeneratedCallQueuePollingAgent(ILogManager logManager,IDeletePastEventCallQueueService deletePastEventCallQueueService)
        {
            _deletePastEventCallQueueService = deletePastEventCallQueueService;
            _logger = logManager.GetLogger<SystemGeneratedCallQueuePollingAgent>();
        }

        public void PollForCallQueueDeletion()
        {
            if(DateTime.Today.DayOfWeek != DayOfWeek.Sunday)  
                return;
            try
            {
                _deletePastEventCallQueueService.DeletePastEventCallQueue();

                _logger.Info("No System generated call queue exist.");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while pulling System generated call queue. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
