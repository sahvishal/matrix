using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSoundAaaParser2 : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly Service.TestResultService _testResultService;
        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;
        private readonly IMediaHelper _mediaHelper;

        private const string ViewtypeAnt = "ant/post";
        private const string ViewtypeTran = "transverse";


        private const string StringForAorta = "aorta";

        public BioSoundAaaParser2(string pathToReportXmlFile, string mediaLocation, ILogger logger)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaLocation = mediaLocation;
            _testResultService = new Service.TestResultService();
            _logger = logger;
            _mediaHelper = new MediaHelper(logger);
        }

        public TestResult Parse()
        {
            _errorSummary = string.Empty;

            var testResult = new AAATestResult();
            var xDoc = XDocument.Load(_pathToReportXmlFile);

            testResult.AortaSize = GetAaaAortaValues(xDoc);

            var aortaValue = testResult.AortaSize != null ? testResult.AortaSize.Reading : null;
            if (aortaValue != null)
                testResult.Finding =
                    new StandardFinding<decimal?>(_testResultService.GetCalculatedStandardFinding(aortaValue.Value, (int)TestType.AAA, (int)ReadingLabels.AortaSize));

            bool isExceptionCaused;
            testResult.ResultImages = _mediaHelper.GetMediaforTest(Directory.GetParent(_pathToReportXmlFile).Parent.FullName, _mediaLocation, TestType.AAA.ToString(), out isExceptionCaused).ToList();

            if (isExceptionCaused) { _errorSummary += "Media Extraction Failed. "; }

            if (testResult.AortaSize == null && (testResult.ResultImages.Count() < 1))
                return null;

            return testResult;
        }

        private ResultReading<decimal?> GetAaaAortaValues(XDocument xDoc)
        {
            try
            {
                var aoTrans = GetValuefromXmlDoc(xDoc, ViewtypeTran);
                var aoAnt = GetValuefromXmlDoc(xDoc, ViewtypeAnt);

                if (aoTrans == null && aoAnt == null) return null;

                decimal aorta = aoTrans == null ? aoAnt.Value : (aoAnt == null ? aoTrans.Value : (aoTrans.Value > aoAnt.Value ? aoTrans.Value : aoAnt.Value));

                return new ResultReading<decimal?>(ReadingLabels.AortaSize)
                           {
                               Reading = Decimal.Round(aorta, 2),
                               ReadingSource = ReadingSource.Automatic
                           };
            }
            catch (Exception ex)
            {
                _errorSummary += "Measurement for Aorta could not be extracted. ";
                _logger.Error("\n Measurement for Aorta could not be extracted. Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return null;
        }

        private static decimal? GetValuefromXmlDoc(XDocument xDoc, string viewAortaType)
        {
            var query = from f in xDoc.Descendants("MacroMeasure") select f;

            var b = (from q in query
                     where
                         q.Attribute("Description") != null && q.Attribute("Description").Value.ToLower().Contains(StringForAorta) && q.Attribute("Description").Value.ToLower().Contains(viewAortaType)
                     select q.Descendants("MeanValue").FirstOrDefault()).FirstOrDefault();

            if (b != null && b.Attribute("Value") != null)
            {
                decimal d = 0;
                if (!string.IsNullOrWhiteSpace(b.Attribute("Value").Value))
                    decimal.TryParse(b.Attribute("Value").Value.Trim(), out d);

                if (d > 0) return d;
            }
            return null;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}
