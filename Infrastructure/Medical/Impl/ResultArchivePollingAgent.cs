using System;
using System.IO;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using NLog;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IResultArchivePollingAgent))]
    public class ResultArchivePollingAgent : IResultArchivePollingAgent
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private readonly IResultArchiveUploadLogRepository _resultArchiveUploadLogRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ILogManager _logManager;
        private readonly IZipHelper _zipHelper;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ISettings _settings;
        private readonly ICustomerRepository _customerRepository;

        private IResultParser _resultParser;

        private readonly IRepository<BasicBiometric> _basicBiometricRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ILipidParserHelper _lipidParserHelper;
        private readonly IEventEndofDayService _endofDayService;
        private readonly ICustomerService _customerService;
        private readonly IEventRepository _eventRepository;

        public ResultArchivePollingAgent(IResultArchiveUploadRepository resultArchiveUploadRepository, ICorporateAccountRepository corporateAccountRepository, IResultArchiveUploadLogRepository resultArchiveUploadLogRepository,
                                        IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, IEventCustomerResultRepository eventCustomerResultRepository, IZipHelper zipHelper,
                                        ILogManager logManager, ISettings settings, ICustomerRepository customerRepository, IRepository<BasicBiometric> basicBiometricRepository, IEventCustomerRepository eventCustomerRepository,
                                        ILipidParserHelper lipidParserHelper, IEventEndofDayService endofDayService,ICustomerService customerService, IEventRepository eventRepository)
        {
            _resultArchiveUploadLogRepository = resultArchiveUploadLogRepository;
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _logManager = logManager;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _zipHelper = zipHelper;
            _settings = settings;
            _customerRepository = customerRepository;
            _basicBiometricRepository = basicBiometricRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _lipidParserHelper = lipidParserHelper;
            _endofDayService = endofDayService;
            _customerService = customerService;
            _eventRepository = eventRepository;
        }

        public void PollforUploadCompleteResultArchives()
        {
            var tempLogger = _logManager.GetLogger("jobs");
            var resultArchives = _resultArchiveUploadRepository.Get(ResultArchiveUploadStatus.Uploaded);
            resultArchives = resultArchives.Where(r => r.FileId.HasValue).OrderBy(r => r.UploadEndTime);
            if (resultArchives.Count() > 0)
                tempLogger.Info("Got the uploaded files list.");

            foreach (var resultArchive in resultArchives)
            {
                var logFileName = "File_" + resultArchive.Id;
                ILogger logger = new NLogLogManager().GetLogger(logFileName);

                var theEvent = new LogEventInfo(LogLevel.Off, "", logFileName);
                theEvent.Properties["LogFileName"] = logFileName;

                string extractedFilePath = "";
                string zipFilePath = "";
                logger.Info(
                    "\n\n****************************************************************************************************************** ");
                try
                {
                    // ReSharper disable PossibleInvalidOperationException
                    var file = _fileRepository.GetById(resultArchive.FileId.Value);
                    // ReSharper restore PossibleInvalidOperationException

                    if (file == null)
                    {
                        logger.Info(String.Format("\nFile Information not found for Result Archive Id: {0}, uploaded on {1}, for the Event Id: {2} ", resultArchive.Id, resultArchive.UploadEndTime.Value, resultArchive.EventId));
                        resultArchive.Status = ResultArchiveUploadStatus.FileNotFound;
                        _resultArchiveUploadRepository.Save(resultArchive);
                        continue;
                    }

                    var mediaLocation = _mediaRepository.GetResultArchiveMediaFileLocation(resultArchive.EventId);
                    if (!System.IO.File.Exists(mediaLocation.PhysicalPath + file.Path))
                    {
                        logger.Info(String.Format("\nInvalid File Path for Result Archive Id: {0}, uploaded on {1}, for the Event Id: {2} ", resultArchive.Id, resultArchive.UploadEndTime.Value, resultArchive.EventId));
                        resultArchive.Status = ResultArchiveUploadStatus.FileNotFound;
                        _resultArchiveUploadRepository.Save(resultArchive);
                        continue;
                    }

                    zipFilePath = mediaLocation.PhysicalPath + file.Path;
                }
                catch (Exception ex)
                {
                    logger.Info(String.Format("\nSystem Failure, while fetching File Info for Result Archive Id: {0}, uploaded on {1}, for the Event Id: {2}. \nMessage:{3} \n\t {4}", resultArchive.Id, resultArchive.UploadEndTime.Value, resultArchive.EventId, ex.Message, ex.StackTrace));
                    resultArchive.Status = ResultArchiveUploadStatus.FileNotFound;
                    _resultArchiveUploadRepository.Save(resultArchive);
                    continue;
                }

                try
                {
                    resultArchive.ParseStartTime = DateTime.Now;
                    resultArchive.Status = ResultArchiveUploadStatus.Parsing;
                    _resultArchiveUploadRepository.Save(resultArchive);
                }
                catch (Exception ex)
                {
                    logger.Info("\nSystem Failure, while saving 'Parsing Start Time'! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                    continue;
                }

                try
                {
                    extractedFilePath = _zipHelper.ExtractZipFiles(zipFilePath);
                }
                catch (Exception ex)
                {
                    logger.Info(String.Format("\nSystem Failure, Invalid File Format for Result Archive Id: {0}, uploaded on {1}, for the Event Id: {2}. \nMessage:{3} \n\t {4}", resultArchive.Id, resultArchive.UploadEndTime.Value, resultArchive.EventId, ex.Message, ex.StackTrace));
                    resultArchive.Status = ResultArchiveUploadStatus.InvalidFileFormat;
                    _resultArchiveUploadRepository.Save(resultArchive);
                    continue;
                }

                try
                {
                    logger.Info(String.Format("\nParsing Started for Result Archive Id: {0}, uploaded on {1}, for the Event Id: {2} ", resultArchive.Id, resultArchive.UploadEndTime.Value, resultArchive.EventId));

                    _resultParser = new ResultParser(resultArchive.Id, extractedFilePath, _corporateAccountRepository, _mediaRepository, _resultArchiveUploadRepository, _resultArchiveUploadLogRepository, logger, _settings, _customerRepository, _zipHelper,
                        _basicBiometricRepository, _eventCustomerRepository, _lipidParserHelper, _endofDayService, _customerService, _eventRepository);
                    _resultParser.Parse();
                    logger.Info("\nParsing completed without any system Failure.");
                    resultArchive.ParseEndTime = DateTime.Now;
                    //Directory.Delete(extractedFilePath, true);
                }
                catch (IOException ex)
                {
                    logger.Info("\nParsing Failed! Message: " + ex.Message + "\n\t" + ex.StackTrace);

                    resultArchive.ParseEndTime = DateTime.Now;
                    resultArchive.Status = ResultArchiveUploadStatus.ParseFailed;
                    _resultArchiveUploadRepository.Save(resultArchive);
                }
                catch (Exception ex)
                {
                    logger.Info("\nParsing Failed! Message: " + ex.Message + "\n\t" + ex.StackTrace);

                    resultArchive.ParseEndTime = DateTime.Now;
                    resultArchive.Status = ResultArchiveUploadStatus.ParseFailed;
                    _resultArchiveUploadRepository.Save(resultArchive);
                    Directory.Delete(extractedFilePath, true);
                }
                finally
                {
                    var ecs = _eventCustomerResultRepository.GetByEventId(resultArchive.EventId);

                    if (ecs != null && ecs.Count() > 0)
                    {
                        foreach (var eventCustomerResult in ecs)
                        {
                            _eventCustomerResultRepository.SetEventCustomerResultState(eventCustomerResult.EventId, eventCustomerResult.CustomerId);
                        }
                    }

                   // GC.Collect();
                    //logger.Info("Calling gc collect");
                    Thread.Sleep(2000);
                }

                try
                {
                    var resultArchiveLogs = _resultArchiveUploadLogRepository.GetbyResultArchiveId(resultArchive.Id);
                    var succesFulRecords = resultArchiveLogs != null ? resultArchiveLogs.Where(rl => rl.IsSuccessful).Count() : 0;

                    if (succesFulRecords > 0) resultArchive.Status = ResultArchiveUploadStatus.Parsed;
                    else resultArchive.Status = ResultArchiveUploadStatus.ParseFailed;

                    var customerCount = resultArchiveLogs != null ? resultArchiveLogs.Select(rl => rl.CustomerId).Distinct().Count() : 0;

                    resultArchive.CustomerRecordsFound = customerCount;
                    _resultArchiveUploadRepository.Save(resultArchive);
                }
                catch (Exception ex)
                {
                    logger.Info("/Saving Parse End Data Failed! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                }
            }
        }

    }
}