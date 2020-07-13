using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSound2ImtParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;
        private readonly IMediaHelper _mediaHelper;
        private readonly IStandardFindingRepository _standardFindingRepository;

        private const string StringQimt = "qimt";
        private const string StringLeft = "left";
        private const string StringRight = "right";
        private const string StringNodeNameExpectedQimt = "ExpectedQIMT";

        public BioSound2ImtParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaLocation = mediaLocation;
            _logger = logger;
            _mediaHelper = new MediaHelper(logger);
            _standardFindingRepository = new StandardFindingRepository();
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public TestResult Parse()
        {
            bool isExceptionCaused;
            var resultImages = _mediaHelper.GetMediaSortedByDecimalValue(Directory.GetParent(_pathToReportXmlFile).FullName, _mediaLocation, TestType.IMT.ToString(), out isExceptionCaused);
            var testResult = new ImtTestResult();

            var xDoc = XDocument.Load(_pathToReportXmlFile);
            var svgImages = _mediaHelper.GetSvgImages(Path.GetDirectoryName(_pathToReportXmlFile), TestType.IMT.ToString(), _mediaLocation);

            if (resultImages == null) resultImages = svgImages;
            else if (svgImages != null && svgImages.Any()) resultImages = resultImages.Concat(svgImages);

            var leftQimt = GetValuefromXmlDoc(xDoc, StringLeft);
            var rightQimt = GetValuefromXmlDoc(xDoc, StringRight);
            var expectedQimt = GetValuefromXmlDocforSpecificNode(xDoc);

            if (leftQimt != null) testResult.QimtLeft = new ResultReading<int> { Reading = leftQimt.Value, ReadingSource = ReadingSource.Automatic, Label = ReadingLabels.QimtLeft };
            if (rightQimt != null) testResult.QimtRight = new ResultReading<int> { Reading = rightQimt.Value, ReadingSource = ReadingSource.Automatic, Label = ReadingLabels.QimtRight };
            if (expectedQimt != null) testResult.ExpectedQimt = new ResultReading<int> { Reading = expectedQimt.Value, ReadingSource = ReadingSource.Automatic, Label = ReadingLabels.ExpectedQimt };

            SetFinding(testResult);

            if (resultImages != null && resultImages.Count() > 0)
            {
                testResult.ResultMedia = resultImages;
            }
            else if (leftQimt == null && rightQimt == null && expectedQimt == null)
                testResult = null;

            if (isExceptionCaused)
            {
                _errorSummary += "Media Extraction Failed. ";
            }

            return testResult;
        }

        private static int? GetValuefromXmlDoc(XDocument xDoc, string sideString)
        {
            var query = from f in xDoc.Descendants("MacroMeasure") select f;

            var b = (from q in query
                where q.Attribute("Description") != null && q.Attribute("Description").Value.ToLower().Contains(StringQimt) && q.Attribute("Description").Value.ToLower().Contains(sideString)
                select q.Descendants("MeanValue").FirstOrDefault()).FirstOrDefault();

            if (b != null && b.Attribute("Value") != null)
            {
                int d = 0;
                if (!string.IsNullOrWhiteSpace(b.Attribute("Value").Value))
                    int.TryParse(b.Attribute("Value").Value.Trim(), out d);

                if (d > 0) return d;
            }
            return null;
        }

        private static int? GetValuefromXmlDocforSpecificNode(XDocument xDoc)
        {
            var node = (from f in xDoc.Descendants(StringNodeNameExpectedQimt) select f).SingleOrDefault();

            if (node != null && node.Attribute("Value") != null)
            {
                int d = 0;
                if (!string.IsNullOrWhiteSpace(node.Attribute("Value").Value))
                    int.TryParse(node.Attribute("Value").Value.Trim(), out d);

                if (d > 0) return d;
            }
            return null;
        }

        private void SetFinding(ImtTestResult testResult)
        {
            if (testResult == null || (testResult.QimtLeft == null && testResult.QimtRight == null) || testResult.ExpectedQimt == null)
                return;

            int qimtData = 0;
            if (testResult.QimtRight != null && testResult.QimtLeft != null)
            {
                qimtData = testResult.QimtLeft.Reading > testResult.QimtRight.Reading ? testResult.QimtLeft.Reading : testResult.QimtRight.Reading;
            }
            else
            {
                qimtData = testResult.QimtRight == null ? testResult.QimtLeft.Reading : testResult.QimtRight.Reading;
            }

            var expectedQimt = testResult.ExpectedQimt.Reading;

            var standardFindingList = _standardFindingRepository.GetAllStandardFindings<int>((int)TestType.IMT);
            if (standardFindingList == null) return;

            var normalFinding = standardFindingList.Where(sfl => sfl.Label.ToLower().Trim().Equals("normal")).FirstOrDefault();
            var abnormalFinding = standardFindingList.Where(sfl => sfl.Label.ToLower().Trim().Equals("abnormal")).FirstOrDefault();

            testResult.Finding = qimtData <= expectedQimt ? normalFinding : abnormalFinding;
        }

    }
}