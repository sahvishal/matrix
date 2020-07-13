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
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class PftFileParser : IResultArchiveParser
    {

        private readonly string _resultOutputPath;
        private readonly long _eventId;
        private ILogger _logger;
        private readonly IMediaRepository _mediaRepository;
        private readonly IMediaHelper _mediaHelper;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly Service.TestResultService _testResultService;

        public PftFileParser(string resultOutputPath, long eventId, ILogger logger)
        {
            _resultOutputPath = resultOutputPath;
            _eventId = eventId;
            _logger = logger;
            _mediaRepository = new MediaRepository(new Settings());
            _mediaHelper = new MediaHelper(logger);
            _resultParserHelper = new ResultParserHelper();
            _testResultService = new Service.TestResultService();
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

            foreach (var filePath in Directory.GetFiles(directoryPath))
            {
                if (Path.GetExtension(filePath).ToLower().Contains("pdf"))
                {
                    var fileName = Path.GetFileName(filePath);
                    var customerIdString = fileName.Substring(0, fileName.IndexOf("."));

                    long customerId = 0;
                    if (!long.TryParse(customerIdString, out customerId))
                    {
                        _logger.Info("CustomerId not found on Pdf file" + filePath);
                        continue;
                    }

                    try
                    {
                        bool isTestPurchasedByCustomer = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.PulmonaryFunction);
                        if (!isTestPurchasedByCustomer)
                        {
                            _logger.Info("Pulmonary is not availed by CustomerId[" + customerId + "].\n");
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Info("Pulmonary is not availed by CustomerId[" + customerId + "]. Exception Caused.\n Message: " + ex.Message + ".\t Stack Trace:" + ex.StackTrace);
                        continue;
                    }

                    try
                    {
                        string folderToSaveImage = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;
                        var resultMedia = _mediaHelper.GetMediaFromPdfFile(filePath, folderToSaveImage, TestType.PulmonaryFunction.ToString());

                        if (resultMedia != null)
                        {
                            var testResult = new PulmonaryFunctionTestResult
                            {
                                ResultImage = resultMedia
                            };

                            _resultParserHelper.AddTestResulttoEventCustomerAggregate(eventCustomerAggregates, _eventId, customerId, testResult);
                            _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.EKG, customerId, MedicalEquipmentTag.PulmonaryMachine);
                            _logger.Info(string.Concat("\nParsing succeeded for Customer Id: ", customerId, "\n"));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("System Failure! Message: " + ex.Message + "\n\t" + ex.StackTrace);
                        _resultParserHelper.AddResultArchiveLog(ex.Message, TestType.EKG, customerId, MedicalEquipmentTag.PulmonaryMachine, false);
                    }
                }
            }
            return eventCustomerAggregates;
        }

        //TODO: This is a repeated code, also in EKG Result Parser
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