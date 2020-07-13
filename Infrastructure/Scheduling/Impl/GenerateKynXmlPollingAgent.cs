using System;
using System.IO;
using System.Linq;
using System.Xml;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class GenerateKynXmlPollingAgent : IGenerateKynXmlPollingAgent
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IGenerateKynLipidService _kynLipidService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private string _kynRawDataRepositoryPath;
        private readonly MediaRepository _mediaRepository;
        private readonly ILogger _logger;

        private readonly bool _isDevEnvironment;
        public GenerateKynXmlPollingAgent(ISettings settings, IEventRepository eventRepository, IEventCustomerRepository eventCustomerRepository, IGenerateKynLipidService kynLipidService,
            ICorporateAccountRepository corporateAccountRepository, ILogManager logManager)
        {
            _logger = logManager.GetLogger("GenerateKynXmlPollingAgent");
            _eventRepository = eventRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _kynLipidService = kynLipidService;
            _corporateAccountRepository = corporateAccountRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
            _mediaRepository = new MediaRepository(settings);
        }

        public void Polling()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var eventsReadyToKynXMl = _eventRepository.GetEventsForGenerateKynXml();

                    if (eventsReadyToKynXMl == null || !eventsReadyToKynXMl.Any()) return;

                    foreach (var eventdetail in eventsReadyToKynXMl)
                    {
                        try
                        {
                            _eventRepository.UpateGenerateXMLStatusField(eventdetail.Id, GenerateKynXmlStatus.InProcess);

                            _logger.Info("Initialising xml generation.....");

                            InitializeGlobalPathVariables(eventdetail.Id, eventdetail.EventDate);

                            GeneratexmlforEventCustomers(eventdetail.Id, eventdetail.EventDate, eventdetail);

                            _eventRepository.UpateGenerateXMLStatusField(eventdetail.Id, GenerateKynXmlStatus.Generated);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("Error while generating kyn xml for EventId {0} Message: {1} , StackTrace {2}", eventdetail.Id, exception.Message, exception.StackTrace));
                        }

                    }
                }
                else
                {
                    _logger.Info(string.Format("Generate Kyn Xml Polling can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception exception)
            {
                _logger.Error(string.Format("Some Error Occured. Message: {0} , StackTrace {1}", exception.Message, exception.StackTrace));
            }

        }

        private void InitializeGlobalPathVariables(long eventId, DateTime eventDate)
        {
            var location = _mediaRepository.GetKynRawDataRepositoryLocation();
            _kynRawDataRepositoryPath = location.PhysicalPath;

            _kynRawDataRepositoryPath = string.Format("{0}{1}_{2}", _kynRawDataRepositoryPath, eventId, eventDate.ToString("yyyyMMdd"));

            if (Directory.Exists(_kynRawDataRepositoryPath))
            {
                Directory.Delete(_kynRawDataRepositoryPath, true);
            }

            if (File.Exists(_kynRawDataRepositoryPath + ".xml"))
                File.Delete(_kynRawDataRepositoryPath + ".xml");
        }

        private void GenerateMetadataXmlForEvent(Event eventDetail)
        {
            var location = _mediaRepository.GetKynIntegrationOutputDataLocation(eventDetail.Id);
            var kynIntegrationOutputDataPath = location.PhysicalPath;

            var xmlText = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <KynIntegrationMetaData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">";
            xmlText += "<ArchiveId>" + 0 + "</ArchiveId><EventId>" + eventDetail.Id + "</EventId><Status />";
            xmlText += "<DestinationFolderPath>" + kynIntegrationOutputDataPath + "</DestinationFolderPath>";
            xmlText += "<ProcessStartTime>" + DateTime.Now.ToString("yyyy-MM-dd") + "</ProcessStartTime><ProcessEndTime>" + DateTime.Now.ToString("yyyy-MM-dd") + "</ProcessEndTime><CustomersDone/></KynIntegrationMetaData>";

            var doc = new XmlDocument();
            doc.LoadXml(xmlText);

            doc.Save(_kynRawDataRepositoryPath + ".xml");

        }

        private void GeneratexmlforEventCustomers(long eventId, DateTime eventDate, Event eventDetail)
        {
            int totalrecords;

            _logger.Info("Getting event customers......");

            var eventCusomters = _eventCustomerRepository.GetKynEventCustomers(1, 400, new KynCustomerModelFilter { EventId = eventId }, out totalrecords);

            var corporateAccount = _corporateAccountRepository.GetbyEventId(eventId);
            if (eventCusomters == null || !eventCusomters.Any()) return;

            _logger.Info(string.Format("{0} event customers found.", eventCusomters.Count()));

            foreach (var ec in eventCusomters)
            {
                try
                {
                    var corpAccountcode = corporateAccount != null ? corporateAccount.AccountCode.Trim() : string.Empty;
                    _kynLipidService.GenerateKynXMlforCustomer(ec, eventId, eventDate, corpAccountcode);
                }
                catch (Exception exception)
                {
                    _logger.Error(string.Format("Error while generating kyn xml for customer Id: {0} and EventId {1} Message: {2}, StackTrace {3}", ec.CustomerId, ec.EventId, exception.Message, exception.StackTrace));
                }

            }

            GenerateMetadataXmlForEvent(eventDetail);
        }
    }
}
