using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HkynXmlPollingAgent : IHkynXmlPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventEndofDayService _endofDayService;
        private readonly bool _isDevEnvironment;
        private readonly IEventRepository _eventRepository;

        public HkynXmlPollingAgent(IEventRepository eventRepository, ILogManager logManager, IEventEndofDayService endofDayService, ISettings settings)
        {
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger("HkynXmlPollingAgent");
            _endofDayService = endofDayService;
            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void PollForEventsforHkynXml()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var events = _eventRepository.GetEventForHkynXml();

                    if (events == null || !events.Any())
                    {
                        _logger.Info("No events found for HKYN XML");
                        return;
                    }

                    foreach (var @event in events)
                    {
                        try
                        {
                            var eventEndofDayListModel = _endofDayService.GetforEvent(@event.Id);

                            if (eventEndofDayListModel != null && eventEndofDayListModel.IsHkynComplete)
                            {
                                _eventRepository.UpateGeneratehkynXmlStatusField(@event.Id, GenerateKynXmlStatus.Generate);

                                _logger.Info(string.Format("Generate Hkyn xml status set for Event (Id: {0})", @event.Id));
                            }
                            else
                            {
                                _logger.Info(string.Format("Generate Hkyn xml status is not set for Event (Id: {0})", @event.Id));
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error while Setting Hkyn xml status for Event (Id: {0}). Message: {1} \n Stack Trace {2}",
                                @event.Id, ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("Hkyn xml polling agent can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error Message: {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}