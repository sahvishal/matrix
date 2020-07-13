using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSound2ThyroidParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;
        private readonly IMediaHelper _mediaHelper;

        public BioSound2ThyroidParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaLocation = mediaLocation;
            _logger = logger;
            _mediaHelper = new MediaHelper(logger);
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public TestResult Parse()
        {
            bool isExceptionCaused;
            var resultImages = _mediaHelper.GetMediaSortedByDecimalValue(Directory.GetParent(_pathToReportXmlFile).FullName, _mediaLocation, TestType.Thyroid.ToString(), out isExceptionCaused);
            var testResult = new ThyroidTestResult();

            if (resultImages != null && resultImages.Count() > 0)
            {
                testResult.ResultMedia = resultImages;
            }
            else
            {
                testResult = null;
            }

            if (isExceptionCaused)
            {
                _errorSummary += "Media Extraction Failed. ";
            }

            return testResult;
        }
    }
}