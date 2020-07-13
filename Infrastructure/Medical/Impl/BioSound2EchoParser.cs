using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSound2EchoParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly IMediaHelper _mediaHelper;
        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;

        private readonly TestType _testType;

        public BioSound2EchoParser(string pathToReportXmlFile, string mediaLocation, ILogger logger, TestType testType)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaHelper = new MediaHelper(logger);
            _mediaLocation = mediaLocation;
            _logger = logger;
            _testType = testType;
        }

        public TestResult Parse()
        {
            _errorSummary = string.Empty;

            MediaTestResult testResult = new EchocardiogramTestResult(); ;

            switch (_testType)
            {
                case TestType.PPEcho:
                    testResult = new PpEchocardiogramTestResult();
                    break;
                case TestType.HCPEcho:
                    testResult = new HcpEchocardiogramTestResult();
                    break;
                case TestType.AwvEcho:
                    testResult = new AwvEchocardiogramTestResult();
                    break;
            }

            bool isExceptionCaused;
            testResult.Media = _mediaHelper.GetMediaSortedByDecimalValue(Directory.GetParent(_pathToReportXmlFile).FullName, _mediaLocation, "Echo", out isExceptionCaused).ToList();

            if (isExceptionCaused)
            {
                _errorSummary += "Media Extraction Failed. ";
            }

            if (testResult.Media.Count < 1) return null;

            return testResult;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}