using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class QuantaFloABIParser : IResultArchiveParser
    {
        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly Service.TestResultService _testResultService;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly IMediaHelper _mediaHelper;

        public QuantaFloABIParser(string resultOutputPath, long eventId, ILogger logger, IMediaRepository mediaRepository)
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

            var directoryPath = GetFolderPathfor(_resultOutputPath);
            if (string.IsNullOrEmpty(directoryPath)) return null;

            var testType = TestType.QuantaFloABI;

            foreach (var filePath in Directory.GetFiles(directoryPath))
            {
                long customerId = 0;

                if (string.IsNullOrEmpty(filePath) || !Path.GetExtension(filePath).ToLower().Contains("pdf"))
                {
                    _logger.Info("file path empty or not contain pdf");
                    continue;
                }

                var fileName = Path.GetFileName(filePath);

                try
                {
                    if (fileName.Split('_').Length > 2)
                    {
                        long.TryParse(fileName.Split('_')[2], out customerId);
                    }
                }
                catch (Exception exception)
                {
                    _logger.Error(string.Format("some Error occured while extracting customerId from file Path  {0} exception : {1} \n stacktrace: {2}", filePath, exception.Message, exception.StackTrace));
                    continue;

                }
                if (customerId <= 0)
                {
                    _logger.Error(string.Format("customerId not found in file Path  {0}", filePath));
                    continue;
                }

                try
                {
                    bool isQuantaFloAbiPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)testType);

                    if (!isQuantaFloAbiPurchased)
                    {
                        _logger.Info("QuantaFlo ABI is not availed by CustomerId[" + customerId + "].\n");
                        continue;
                    }

                    var foldertoSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

                    var resultMedia = GetMediaFromPdfFile(filePath, foldertoSaveImage, testType.ToString());

                    if (resultMedia != null)
                    {
                        var mediaFilePath = foldertoSaveImage + Path.GetFileNameWithoutExtension(resultMedia.File.Path) + ".pdf";
                        File.Copy(filePath, mediaFilePath);
                    }

                    var testResult = new QuantaFloABITestResult { ResultImage = resultMedia };

                    _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                    _resultParserHelper.AddResultArchiveLog(string.Empty, testType, customerId, MedicalEquipmentTag.QuantaFlo);

                    _logger.Info(string.Concat("\nParsing succeeded for QuantaFlo-ABI  for Customer Id: ", customerId, "\n"));
                }
                catch (Exception ex)
                {
                    _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                    _resultParserHelper.AddResultArchiveLog(ex.Message, testType, customerId, MedicalEquipmentTag.QuantaFlo, false);
                }
            }

            return eventCustomerAggregates;
        }

        private ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testName)
        {

            var highQualityRectangles  = new List<RectangleDimesion>
                                         {
                                              new RectangleDimesion(2200, 630, 870, 88)
                                         };

            var rectangles = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(350, 116, 210, 15)
                                         };


            return _mediaHelper.GetMediaFromPdfFile(pdfFilePath, folderLocationToSaveFile, testName, true, rectangles, highQualityRectangles);
        }

        private static string GetFolderPathfor(string toFindinFolder)
        {
            if (Directory.GetFiles(toFindinFolder).Any(file => Path.GetExtension(file).ToLower().IndexOf("pdf") > 0))
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