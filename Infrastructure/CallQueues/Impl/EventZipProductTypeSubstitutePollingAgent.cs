using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class EventZipProductTypeSubstitutePollingAgent : IEventZipProductTypeSubstitutePollingAgent
    {
       private readonly IEventZipProductTypeService _eventZipProductTypeService;
        private readonly ILogger _logger;

        public EventZipProductTypeSubstitutePollingAgent(IEventZipProductTypeService eventZipProductTypeService, ILogManager logManager)
        {
            _eventZipProductTypeService = eventZipProductTypeService;
            _logger = logManager.GetLogger("EventZipProductTypeSubstitutePollingAgent");
        }

        public void PollEventZipProductType() 
        {
            try
            {
                _logger.Info("Starting Event Zip Product Type Substitute Polling Agent");

                _eventZipProductTypeService.EventZipProductTypeSubstitute(_logger);

                _logger.Info("Stop Event Zip Product Type Substitute Polling Agent");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error While Saving Event Zip Product Type Substitute Polling Agent. Message {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}