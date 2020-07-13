using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class UnlockCorporateEventsPollingAgent : IUnlockCorporateEventsPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly ILogger _logger;
        public UnlockCorporateEventsPollingAgent(IEventRepository eventRepository, ILogManager logManager)
        {
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger("UnlockCorporateEventsPollingAgent");
        }

        public void PollForUnlockCorporateEvents()
        {
            try
            {
                _eventRepository.UnlockLockedCorporateEvents();
                _logger.Info("Unlocked Corporate Events Successfully");
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Message: " + ex.Message + " Stack Trace: " + ex.StackTrace));
            }

        }
    }
}