using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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
    public class UltrasoundTransducerResultParser : IResultArchiveParser
    {
        private readonly ILogger _logger;
        private readonly long _eventId;
        private readonly string _ultrasoundFolderPath;
        private readonly IResultParserHelper _resultParserHelper;
        private readonly Service.TestResultService _testResultService;
        private readonly IMediaHelper _mediaHelper;
        private readonly IMediaRepository _mediaRepository;
        private List<EventCustomerScreeningAggregate> _eventCustomerScreeningAggregates;

        private const string PatientInfoFileName = "pt_pps.xml";
        private const string CustomerIdNodeName = "PatientID";
        private const string ImageIdentifierNodeName = "ScanheadName";

        private const string AaaImageIdentifier = "c60";
        private const string StrokeImageIdentifier = "l38";

        public IEnumerable<ResultArchiveLog> ResultArchiveLogs
        {
            get { return _resultParserHelper.ResultArchiveLogs; }
        }

        public UltrasoundTransducerResultParser(string ultrasoundFolderPath, long eventId, ILogger logger, ISettings settings)
        {
            _ultrasoundFolderPath = ultrasoundFolderPath;
            _eventId = eventId;
            _logger = logger;

            _resultParserHelper = new ResultParserHelper();
            _testResultService = new Service.TestResultService();
            _mediaRepository = new MediaRepository(settings);
            _mediaHelper = new MediaHelper(logger);
            _eventCustomerScreeningAggregates = new List<EventCustomerScreeningAggregate>();
        }

        public IEnumerable<EventCustomerScreeningAggregate> Parse()
        {
            if (!Directory.Exists(_ultrasoundFolderPath))
            {
                _logger.Info(string.Format("Ultrasound Directory [{0}] not found.", _ultrasoundFolderPath));
                return null;
            }

            foreach (var customerDir in Directory.GetDirectories(_ultrasoundFolderPath))
            {
                long customerId = GetCustomerIdfromDirectoryName(customerDir);

                _logger.Info(string.Format("Starting for Dir [{0}]", customerDir));
                var directoryPath = GetFileContainingDirectoryPath(customerDir);

                if (string.IsNullOrEmpty(directoryPath)) continue;

                var allImageFiles = new List<string>();
                var allXmlFiles = new List<string>();

                var allFiles = Directory.GetFiles(directoryPath);

                foreach (var file in allFiles)
                {
                    var extension = Path.GetExtension(file).ToLower();

                    if (extension.Contains("xml"))
                        allXmlFiles.Add(file);
                    else if (extension.Contains("jpeg") || extension.Contains("jpg") || extension.Contains("png") || extension.Contains("gif") || extension.Contains("bmp"))
                        allImageFiles.Add(file);
                }

                if (allImageFiles.Count() < 1)
                {
                    _logger.Info("No Image Files found in the directory!");
                    continue;
                }

                try
                {
                    long customerIdFromFile = GetCustomerIdfromthefile(allXmlFiles);

                    if (customerIdFromFile > 0) customerId = customerIdFromFile;
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Getting Customer Id from the file. Message {0}. \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                }

                if (customerId < 1) continue;

                try
                {
                    GetDataImportedtoSystem(customerId, allImageFiles, allXmlFiles);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Some Exception occured. Message {0}. \n Stack Trace: {1}", ex.Message, ex.StackTrace));
                }
            }

            return _eventCustomerScreeningAggregates;
        }

        private string GetFileContainingDirectoryPath(string customerDirPath)
        {
            var directories = Directory.GetDirectories(customerDirPath);

            if (directories.Count() < 1)
            {
                _logger.Info("No directory found.");
                return string.Empty;
            }

            if (directories.Count() > 1)
            {
                _logger.Info("Contains more than one directory.");
            }

            return directories.First();
        }

        private long GetCustomerIdfromthefile(IEnumerable<string> allXmlFiles)
        {
            var file = allXmlFiles.Where(f => Path.GetFileName(f).ToLower().Contains(PatientInfoFileName)).SingleOrDefault();

            if (file == null)
            {
                _logger.Info("Patient Info file not found in the list!");
                return 0;
            }

            var xdoc = XDocument.Load(file);
            var node = (from e in xdoc.Descendants(CustomerIdNodeName) select e).SingleOrDefault();

            if (node == null)
            {
                _logger.Info("PatientID node not found in the Xml!");
                return 0;
            }

            var customerIdString = node.Value;

            long customerId;

            if (!long.TryParse(customerIdString, out customerId))
            {
                _logger.Info("Not a valid PatientID string found!");
                return 0;
            }

            return customerId;
        }

        private static long GetCustomerIdfromDirectoryName(string directoryPath)
        {
            var directoryName = Path.GetFileName(directoryPath);
            string customerIdString = "";
            long customerId;

            if (directoryName.IndexOf("__") > 0)
            {
                customerIdString = directoryName.Substring(directoryName.LastIndexOf("_") + 1);
            }
            else if (directoryName.IndexOf(".") > 0)
            {
                customerIdString = directoryName.Substring(directoryName.LastIndexOf(".") + 1);
            }

            long.TryParse(customerIdString, out customerId);

            return customerId;
        }

        private void GetDataImportedtoSystem(long customerId, IEnumerable<string> allImageFiles, IEnumerable<string> allXmlFiles)
        {
            bool strokeFound = false;
            bool aaaFound = false;

            var aaaPurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.AAA);
            var strokePurchased = _testResultService.IsTestPurchasedByCustomer(_eventId, customerId, (long)TestType.Stroke);

            var mediaLocation = _mediaRepository.GetResultMediaFileLocation(customerId, _eventId).PhysicalPath;

            var aaaTestResult = new AAATestResult
                                    {
                                        ResultImages = new List<ResultMedia>()
                                    };

            var strokeTestResult = new StrokeTestResult
                                       {
                                           ResultImages = new List<ResultMedia>()
                                       };

            foreach (var imageFile in allImageFiles)
            {
                var fileName = Path.GetFileNameWithoutExtension(imageFile);
                string imageType = string.Empty;
                string xmlFile = "";

                if (allXmlFiles.Count() == 0)
                {
                    if (strokePurchased) imageType = StrokeImageIdentifier;
                    else if (aaaPurchased) imageType = AaaImageIdentifier;
                }
                else
                {
                    var startIndex = fileName.IndexOf("[");
                    var endIndex = fileName.IndexOf("]");

                    if (startIndex < 0 || endIndex < 0) continue;

                    var identifier = fileName.Substring(startIndex + 1, endIndex - (startIndex + 1)).ToLower();
                    xmlFile = allXmlFiles.Where(f => Path.GetFileNameWithoutExtension(f).ToLower().Contains(identifier)).SingleOrDefault();
                    if (string.IsNullOrEmpty(xmlFile)) continue;

                    imageType = GetImageTypefromXmlFile(xmlFile);
                }

                if (string.IsNullOrEmpty(imageType)) continue;

                imageType = imageType.ToLower();

                if (imageType == AaaImageIdentifier)
                {
                    aaaFound = true;
                    if (!aaaPurchased) continue;

                    var resultMedia = _mediaHelper.GetfromImageFile(new FileInfo(imageFile), "Aaa", mediaLocation);
                    aaaTestResult.ResultImages.Add(resultMedia);
                }
                else if (imageType == StrokeImageIdentifier)
                {
                    strokeFound = true;
                    if (!strokePurchased) continue;

                    var resultMedia = _mediaHelper.GetfromImageFile(new FileInfo(imageFile), "Stroke", mediaLocation);
                    strokeTestResult.ResultImages.Add(resultMedia);
                }
                else
                {
                    _logger.Info(string.Format("Invalid Image Identifier = [{0}] from XML = [{1}].", imageType, xmlFile));
                }
            }

            if (!aaaPurchased && aaaFound)
            {
                _logger.Info(string.Format("AAA not purchased by Customer [{0}], but files are found.", customerId));
            }
            else if (aaaPurchased && aaaFound)
            {
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, aaaTestResult);
                _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.AAA, customerId, MedicalEquipmentTag.UltrasoundTransducer);
            }
            else if (aaaPurchased)
            {
                _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.AAA, customerId, MedicalEquipmentTag.UltrasoundTransducer, false);
            }

            if (!strokePurchased && strokeFound)
            {
                _logger.Info(string.Format("Stroke not purchased by Customer [{0}], but files are found.", customerId));
            }
            else if (strokePurchased && strokeFound)
            {
                _resultParserHelper.AddTestResulttoEventCustomerAggregate(_eventCustomerScreeningAggregates, _eventId, customerId, strokeTestResult);
                _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.Stroke, customerId, MedicalEquipmentTag.UltrasoundTransducer);
            }
            else if (strokePurchased)
            {
                _resultParserHelper.AddResultArchiveLog(string.Empty, TestType.Stroke, customerId, MedicalEquipmentTag.UltrasoundTransducer, false);
            }
        }

        private string GetImageTypefromXmlFile(string xmlFile)
        {
            var xDoc = XDocument.Load(xmlFile);

            var node = (from e in xDoc.Descendants(ImageIdentifierNodeName) select e).SingleOrDefault();

            if (node == null)
            {
                _logger.Info(string.Format("Image Identifier missing from XML = [{0}].", xmlFile));
                return string.Empty;
            }

            return node.Value.Trim();
        }
    }
}
