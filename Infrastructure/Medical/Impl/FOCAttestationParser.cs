using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class FOCAttestationParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private readonly ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;


        public FOCAttestationParser(string resultOutputPath, long eventId, ILogger logger, IMediaRepository mediaRepository)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _logger = logger;
            _mediaRepository = mediaRepository;
            _testResultService = new Service.TestResultService();
            _resultParserHelper = new ResultParserHelper();
            _mediaHelper = new MediaHelper(logger);
        }

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            var eventCustomerAggregates = new List<EventCustomerScreeningAggregate>();
            var testType = TestType.FocAttestation;
            var directoryPath = GetFolderPathfor(_resultOutputPath);
            if (string.IsNullOrEmpty(directoryPath)) return null;

            var pdfFiles = Directory.GetFiles(directoryPath, "*.pdf");

            if (pdfFiles.IsNullOrEmpty())
            {
                _logger.Info("file path empty or not contain pdf");

                return eventCustomerAggregates;
            }

            foreach (var filePath in pdfFiles)
            {
                long customerId = 0;

                try
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                    long.TryParse(fileNameWithoutExtension, out customerId);

                    if (customerId <= 0)
                    {
                        _logger.Error(string.Format("customerId not found in file Path  {0}", filePath));
                        continue;
                    }
                }
                catch (Exception exception)
                {
                    _logger.Error(string.Format("some Error occured while extracting customerId from file Path  {0} exception : {1} \n stacktrace: {2}", filePath, exception.Message, exception.StackTrace));
                    continue;
                }

                try
                {
                    bool isFOCAttestationPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)testType);

                    if (!isFOCAttestationPurchased)
                    {
                        _logger.Info("FOC Attestation is not availed by CustomerId[" + customerId + "].\n");
                        continue;
                    }

                    var foldertoSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                    var resultMedia = GetMediaFromPdfFile(filePath, foldertoSaveImage, testType.ToString());

                    if (resultMedia != null)
                    {
                        resultMedia.ReadingSource = ReadingSource.Automatic;

                        var testResult = new FocAttestationTestResult { ResultImage = resultMedia };

                        _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                        _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.FocAttestation);

                        _logger.Info(string.Concat("\nParsing succeeded for FOC Attestation  for Customer Id: ", customerId, "\n"));
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                    _resultParserHelper.AddResultArchiveLog(ex.Message, testType, customerId, MedicalEquipmentTag.FocAttestation, false);
                }

            }

            return eventCustomerAggregates;
        }
        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testName)
        {
            return _mediaHelper.GetResultMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testName);
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            var pdfFiles = Directory.GetFiles(toFindinFolder, "*.pdf");

            if (pdfFiles.Any())
            {
                return toFindinFolder;
            }

            foreach (string directory in Directory.GetDirectories(toFindinFolder))
            {
                var path = GetFolderPathfor(directory);
                if (!string.IsNullOrEmpty(path)) return path;
            }

            return string.Empty;
        }
    }
}