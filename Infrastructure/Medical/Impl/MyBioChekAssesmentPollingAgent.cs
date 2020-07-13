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
    public class MyBioChekAssesmentPollingAgent : IMyBioChekAssesmentPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IEventEndofDayService _endofDayService;
        private readonly bool _isDevEnvironment;
        private readonly IEventRepository _eventRepository;

        public MyBioChekAssesmentPollingAgent(IEventRepository eventRepository, ILogManager logManager, IEventEndofDayService endofDayService, ISettings settings)
        {
            _eventRepository = eventRepository;
            _logger = logManager.GetLogger("MyBioChekAssesment");
            _endofDayService = endofDayService;
            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void PollForEventsforMyBioChekAssesmentJson()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(3, 0, 0))
                {
                    var events = _eventRepository.GetEventForMyBioCheckAssessment();

                    if (events == null || !events.Any())
                    {
                        _logger.Info("No events found for MyBio-Check");
                        return;
                    }

                    foreach (var @event in events)
                    {
                        try
                        {
                            var eventEndofDayListModel = _endofDayService.GetforEventMyBioCheckAssessment(@event.Id);

                            if (eventEndofDayListModel != null && eventEndofDayListModel.IsMyBioCheckAssessement)
                            {
                                _eventRepository.UpateGenerateMyBioCheckStatusField(@event.Id, GenerateKynXmlStatus.Generate);

                                _logger.Info(string.Format("Generate MyBio-Check Status set for Event (Id: {0})", @event.Id));
                            }
                            else
                            {
                                _logger.Info(string.Format("Generate MyBio-Check status is not set for Event (Id: {0})", @event.Id));
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error while Setting MyBio-Check status for Event (Id: {0}). Message: {1} \n Stack Trace {2}",
                                @event.Id, ex.Message, ex.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("MyBio-Check polling agent can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error Message: {0} \n Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }
    }
}