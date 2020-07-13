using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class BioCheckJsonGeneratorPollingAgent : IBioCheckJsonGeneratorPollingAgent
    {
        private readonly ILogManager _logManager;
        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private readonly IMyBioCheckAssessmentJsonHelper _myBioCheckAssessmentForFailCustomer;
        private readonly IEventRepository _eventRepository;
        private readonly bool _stopTrailService;

        public BioCheckJsonGeneratorPollingAgent(ILogManager logManager, IMyBioCheckAssessmentJsonHelper imyBioCheckAssessmentForFailCustomer, IEventRepository eventRepository, ISettings settings)
        {

            _logManager = logManager;
            _logger = logManager.GetLogger("GenerateBIoCheckJsonPollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
            _myBioCheckAssessmentForFailCustomer = imyBioCheckAssessmentForFailCustomer;
            _eventRepository = eventRepository;
            _stopTrailService = settings.StopTrailService;
        }

        public void PollForBiomassEvents()
        {
            try
            {
                if (_stopTrailService)
                {
                    _logger.Info("Trail service has been stopped");
                    return;
                }

                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(3, 0, 0))
                {
                    _logger.Info("Initialising xml generation.....");

                    var eventsReadyToMyBioMass = _eventRepository.GetEventsForGenerateMyBioCheckAssessment();

                    if (eventsReadyToMyBioMass == null || !eventsReadyToMyBioMass.Any()) return;

                    foreach (var eventdetail in eventsReadyToMyBioMass)
                    {
                        try
                        {
                            var eventlogger = _logManager.GetLogger("BioCheckJson" + eventdetail.Id);

                            _eventRepository.UpateGenerateMyBioCheckStatusField(eventdetail.Id, GenerateKynXmlStatus.InProcess);

                            _myBioCheckAssessmentForFailCustomer.GenerateJsonforEventCustomers(eventdetail, eventlogger);

                            _eventRepository.UpateGenerateMyBioCheckStatusField(eventdetail.Id, GenerateKynXmlStatus.Generated);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("Error while generating MyBioCheck for EventId {0} Message: {1} , StackTrace {2}", eventdetail.Id, exception.Message, exception.StackTrace));
                        }

                    }
                }
                else
                {
                    _logger.Info(string.Format("Generate MyBioCheck Polling can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some Error Occurred. Message: {0} , StackTrace {1}", exception.Message, exception.StackTrace));
            }

        }
    }
}