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
    public class KynXmlPollingAgent : IKynXmlPollingAgent
    {
        private readonly ILogger _logger;

        private readonly IEventRepository _eventRepository;
        private readonly IEventEndofDayService _endofDayService;
        private readonly bool _isDevEnvironment;

        public KynXmlPollingAgent(ILogManager logManager, IEventRepository eventRepository, IEventEndofDayService endofDayService, ISettings settings)
        {
            _logger = logManager.GetLogger("KynXmlPollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
            _eventRepository = eventRepository;
            _endofDayService = endofDayService;
        }

        public void PollForEventsForKynXml()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var events = _eventRepository.GetEventForKynXml();

                    if (events == null || !events.Any())
                    {
                        _logger.Info("No events found for KYN XML");
                        return;
                    }

                    foreach (var @event in events)
                    {
                        try
                        {
                            var eventEndofDayListModel = _endofDayService.GetforEvent(@event.Id);

                            if (eventEndofDayListModel != null && eventEndofDayListModel.IsKynComplete)
                            {
                                _eventRepository.UpateGenerateXMLStatusField(@event.Id, GenerateKynXmlStatus.Generate);

                                _logger.Info(string.Format("Generate KYN xml status set for Event (Id: {0})", @event.Id));
                            }
                            else
                            {
                                _logger.Info(string.Format("Generate KYN xml status is not set for Event (Id: {0})",
                                    @event.Id));
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(
                                string.Format(
                                    "Error while Setting KYN xml status for Event (Id: {0}). Message: {1} \n Stack Trace {2}",
                                    @event.Id, ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("kyn xml polling agent can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error Message: {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
