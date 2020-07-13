using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class ParseHkynPdfPollingAgent : IParseHkynPdfPollingAgent
    {
        private readonly string _hkynParsePdfPath;
        private readonly MediaRepository _mediaRepository;
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly bool _isDevEnvironment;
        private readonly ILogManager _logManager;
        private const long DeleteEmptyFolderAfter = 90;
        public ParseHkynPdfPollingAgent(ISettings settings, IEventRepository eventRepository, IEventCustomerResultRepository eventCustomerResultRepository, ILogManager logManager)
        {
            _logger = logManager.GetLogger("ParseHkynPdfPollingAgent");
            _logManager = logManager;
            _eventRepository = eventRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            

            _isDevEnvironment = settings.IsDevEnvironment;
            _hkynParsePdfPath = settings.HkynParsePdfPath;
            _mediaRepository = new MediaRepository(settings);
        }

        public void PollForParsing()
        {
            try
            {
                var timeOfDay = DateTime.Now;

                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    _logger.Info("Service started...");
                    var directoryInfo = DirectoryOperationsHelper.GetDirectories(_hkynParsePdfPath);

                    if (directoryInfo.IsNullOrEmpty())
                    {
                        _logger.Info("No Directory found for Parsing");
                        return;
                    }

                    foreach (var dirPath in directoryInfo)
                    {
                        try
                        {
                            var dirInfo = DirectoryOperationsHelper.GetDirectoryInfo(dirPath);
                            if (dirInfo != null)
                            {
                                var files = DirectoryOperationsHelper.GetFiles(dirPath, "*.Pdf");


                                long eventid = 0;
                                long.TryParse(dirInfo.Name, out eventid);

                                if (eventid > 0)
                                {
                                    var eventData = _eventRepository.GetById(eventid);

                                    if (files.IsNullOrEmpty())
                                    {

                                        _logger.Info("No file found inside " + dirInfo.Name);
                                        if (eventData.EventDate > DateTime.Today.AddDays(-DeleteEmptyFolderAfter))
                                        {
                                            DirectoryOperationsHelper.DeleteDirectory(dirPath, true);
                                        }
                                        continue;
                                    }

                                    ParseFilesForCustomer(dirPath, eventid);
                                }
                                else
                                {
                                    _logger.Info("folder does not contain valid Name: " + dirInfo.Name);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Some error occurred for Dir Path: " + dirPath);
                            _logger.Error("Message: " + ex.Message);
                            _logger.Error("Stack Trace: " + ex.StackTrace);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.Error("Some error occurred while parsing");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

        }

        private void ParseFilesForCustomer(string dirPath, long eventId)
        {
            var eventlogger = _logManager.GetLogger("HkynParsing_" + eventId);

            eventlogger.Info("started Parsing for EventId: " + eventId);

            var evnentCustomers = _eventCustomerResultRepository.GetByEventId(eventId);

            foreach (var eventCustomer in evnentCustomers)
            {
                try
                {
                    var files = DirectoryOperationsHelper.GetFiles(dirPath, eventCustomer.CustomerId + "*.pdf");

                    if (files.IsNullOrEmpty())
                    {
                        eventlogger.Info("No file found for CustomerId: " + eventCustomer.CustomerId);
                        continue;
                    }

                    var mediaLocation = _mediaRepository.GetKynIntegrationOutputDataLocation(eventId, eventCustomer.CustomerId);

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(mediaLocation.PhysicalPath);

                    var fileName = KynFileTypes.GetFileName(TestType.HKYN, KynFileTypes.ParticipantSummaryReport);

                    var destinationFilePath = Path.Combine(mediaLocation.PhysicalPath, fileName);
                    var sourceFile = files.First();

                    eventlogger.Info("Source File: " + sourceFile);
                    eventlogger.Info("destinationFilePath: " + destinationFilePath);

                    DirectoryOperationsHelper.DeleteFileIfExist(destinationFilePath);

                    DirectoryOperationsHelper.Move(sourceFile, destinationFilePath);
                }
                catch (Exception ex)
                {
                    _logger.Error("Some error occurred while parsing for Event id " + eventId + " CustomerId: " + eventCustomer.CustomerId);
                    _logger.Error("Message: " + ex.Message);
                    _logger.Error("Stack Trace: " + ex.StackTrace);
                }
            }

            eventlogger.Info("completed Parsing  for EventId: " + eventId);
        }
    }
}