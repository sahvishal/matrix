using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class BioCheckJsonForFailedCustomersPollingAgent : IBioCheckJsonForFailedCustomersPollingAgent
    {
        private readonly ILogManager _logManager;
        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private readonly IMyBioCheckAssessmentJsonHelper _myBioCheckAssessmentJsonHelper;
        private readonly IEventRepository _eventRepository;
        private readonly string _bioCheckAssessmentFailedListPath;
        private readonly IXmlSerializer<BioCheckAssessmentFailedList> _bioCheckAssessmentFailedListXmlSerializer;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly bool _stopTrailService;
        public BioCheckJsonForFailedCustomersPollingAgent(ILogManager logManager, IMyBioCheckAssessmentJsonHelper myBioCheckAssessmentJsonHelper,
            IEventRepository eventRepository, ISettings settings, IXmlSerializer<BioCheckAssessmentFailedList> bioCheckAssessmentFailedListXmlSerializer,
            IEventCustomerRepository eventCustomerRepository)
        {

            _logManager = logManager;
            _logger = logManager.GetLogger("BioCheckJsonForFailedCustomerPollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
            _stopTrailService = settings.StopTrailService;
            _myBioCheckAssessmentJsonHelper = myBioCheckAssessmentJsonHelper;
            _eventRepository = eventRepository;
            _bioCheckAssessmentFailedListXmlSerializer = bioCheckAssessmentFailedListXmlSerializer;
            _eventCustomerRepository = eventCustomerRepository;
            _bioCheckAssessmentFailedListPath = settings.BioCheckAssessmentFailedListPath;
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
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(_bioCheckAssessmentFailedListPath);
                    var files = DirectoryOperationsHelper.GetFiles(_bioCheckAssessmentFailedListPath, "failedCustomerRecord*.xml");
                    if (files.IsNullOrEmpty())
                    {
                        _logger.Info("No Failed Customer XML found");
                        return;
                    }

                    foreach (var file in files)
                    {
                        try
                        {
                            var failedCustomerRecords = _bioCheckAssessmentFailedListXmlSerializer.Deserialize(file);

                            if (failedCustomerRecords == null || failedCustomerRecords.EventCustomers.IsNullOrEmpty())
                            {
                                _logger.Info("no record found in failedRecord XML in File: " + file);
                                continue;
                            }

                            var customerIds = failedCustomerRecords.EventCustomers.Select(x => x.CustomerId);
                            var eventid = failedCustomerRecords.EventCustomers.First().EventId;
                            var eventData = _eventRepository.GetById(eventid);

                            DirectoryOperationsHelper.DeleteFileIfExist(file);

                            int totalrecords;
                            var logger = _logManager.GetLogger("FailedBioCheckJson" + eventData.Id);
                            var eventCustomers = _eventCustomerRepository.GetMyBioCheckEventCustomers(1, 400, new MyBioCheckCustomerModelFilter { EventId = eventData.Id }, out totalrecords);

                            if (eventCustomers == null || !eventCustomers.Any())
                            {
                                logger.Info(string.Format("No event customers found for Event Id {0} EventDate {1}", eventData.Id, eventData.EventDate));
                                return;
                            }

                            eventCustomers = eventCustomers.Where(x => customerIds.Contains(x.CustomerId));
                            _myBioCheckAssessmentJsonHelper.GenerateJsonforEventCustomers(eventData, eventCustomers, logger);
                        }
                        catch (Exception ex)
                        {
                            _logger.Info("Some Error Occurred While generating Failed Customer BioCheck Assessment Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
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