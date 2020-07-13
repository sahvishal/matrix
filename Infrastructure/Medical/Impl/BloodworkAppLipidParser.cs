using System.IO;
using System.Xml;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodworkAppLipidParser : IBloodworkAppLipidParser
    {
        private string _errorSummary;
        private readonly ILogger _logger;
        private readonly ILipidParserHelper _lipidParserHelper;


        private const string TotalCholTagName = "total_cholesterol";
        private const string HdlCholTagName = "hdl_cholesterol";
        private const string LdlCholTagName = "ldl_cholesterol";
        private const string GlucoseTagName = "glucose";
        private const string TriglyceridesTagName = "triglycerides";
        private const string TcHdlTagName = "tchdl";

        public BloodworkAppLipidParser(ILogger logger, ILipidParserHelper lipidParserHelper)
        {
            _logger = logger;
            _lipidParserHelper = lipidParserHelper;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public TestResult Parse(long customerId, string xmlFilePath, TestType testType)
        {
            _lipidParserHelper.SetLogger(_logger);
            _errorSummary = string.Empty;
            _logger.Info(string.Format("------------------------------- Lipid Parsing for file [{0}]", xmlFilePath));

            if (!File.Exists(xmlFilePath))
            {
                _errorSummary += "File doesn't exist.";
                _logger.Error("File doesn't exist.");
                return null;
            }

            var doc = new XmlDocument();
            doc.Load(xmlFilePath);

            var elements = doc.GetElementsByTagName(LdlCholTagName);
            var ldlValue = GetLipidValue(elements);

            elements = doc.GetElementsByTagName(HdlCholTagName);
            var hdlValue = GetLipidValue(elements);

            elements = doc.GetElementsByTagName(TotalCholTagName);
            var tCholValue = GetLipidValue(elements);

            elements = doc.GetElementsByTagName(GlucoseTagName);
            var glucoseValue = GetLipidValue(elements);

            elements = doc.GetElementsByTagName(TriglyceridesTagName);
            var tglValue = GetLipidValue(elements);

            decimal? tchol = null;
            decimal? hdl = null;
            decimal? triGlycerides = null;

            if (testType == TestType.Lipid)
            {
                var testResult = new LipidTestResult
                {
                    Glucose = _lipidParserHelper.GetReading(glucoseValue, ReadingLabels.Glucose, TestType.Lipid, ref _errorSummary),
                    LDL = _lipidParserHelper.GetReading(ldlValue, ReadingLabels.LDL, TestType.Lipid, ref _errorSummary),
                    TotalCholestrol = _lipidParserHelper.GetReading(tCholValue, ReadingLabels.TotalCholestrol, ref tchol, TestType.Lipid, ref _errorSummary),
                    TriGlycerides = _lipidParserHelper.GetReading(tglValue, ReadingLabels.TriGlycerides, ref triGlycerides, TestType.Lipid, ref _errorSummary),
                    HDL = _lipidParserHelper.GetHdlReading(hdlValue, customerId, ref hdl, TestType.Lipid, ref _errorSummary),
                    TCHDLRatio = _lipidParserHelper.GetHdlTclRatio(hdl, tchol, TestType.Lipid, ref _errorSummary)
                };

                return GetLipidTestResult(testResult);
            }

            if (testType == TestType.Cholesterol)
            {
                var testResult = new CholesterolTestResult()
                {
                    LDL = _lipidParserHelper.GetReading(ldlValue, ReadingLabels.LDL, TestType.Cholesterol, ref _errorSummary),
                    TotalCholesterol = _lipidParserHelper.GetReading(tCholValue, ReadingLabels.TotalCholestrol, ref tchol, TestType.Cholesterol, ref _errorSummary),
                    TriGlycerides = _lipidParserHelper.GetReading(tglValue, ReadingLabels.TriGlycerides, ref triGlycerides, TestType.Cholesterol, ref _errorSummary),
                    HDL = _lipidParserHelper.GetHdlReading(hdlValue, customerId, ref hdl, TestType.Cholesterol, ref _errorSummary),
                    TCHDLRatio = _lipidParserHelper.GetHdlTclRatio(hdl, tchol, TestType.Cholesterol, ref _errorSummary)
                };
                return GetCholesterolTestResult(testResult);
            }

            if (testType == TestType.Diabetes)
            {
                var testResult = new DiabetesTestResult()
                {
                    Glucose = _lipidParserHelper.GetReading(glucoseValue, ReadingLabels.Glucose, TestType.Diabetes, ref _errorSummary),
                };

                return GetDiabetesTestResult(testResult);
            }

            return null;
        }

        private TestResult GetDiabetesTestResult(DiabetesTestResult testResult)
        {
            if (testResult.Glucose == null) return null;

            return testResult;
        }

        private LipidTestResult GetLipidTestResult(LipidTestResult testResult)
        {
            if (testResult.TotalCholestrol == null && testResult.HDL == null && testResult.TCHDLRatio == null && testResult.LDL == null &&
               testResult.Glucose == null && testResult.TriGlycerides == null) return null;

            return testResult;
        }

        private CholesterolTestResult GetCholesterolTestResult(CholesterolTestResult testResult)
        {
            if (testResult.TotalCholesterol == null && testResult.HDL == null && testResult.TCHDLRatio == null && testResult.LDL == null && testResult.TriGlycerides == null) return null;

            return testResult;
        }


        private string GetLipidValue(XmlNodeList elements)
        {
            if (elements.Count > 0)
                return elements[0].InnerXml;

            return string.Empty;
        }

    }
}
