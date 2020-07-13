using System.IO;
using System.Xml;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class KynAppLipidParser : IKynAppLipidParser
    {
        private string _errorSummary;
        private string _tagNameforBiomarker;
        private string _attrName;
        private string _attrValue;
        private readonly ILipidParserHelper _lipidParserHelper;
        private readonly ILogger _logger;


        private const string TotalCholName = "CHOLESTEROL_TOTAL";
        private const string HdlCholName = "CHOLESTEROL_HDL";
        private const string LdlCholName = "CHOLESTEROL_LDL";
        private const string GlucoseName = "FASTING_GLUCOSE";
        private const string TriglyceridesName = "TRIGLYCERIDES";

        public KynAppLipidParser(ILogger logger, string tagNameforBiomarker, string attrName, string attrValue, ILipidParserHelper lipidParserHelper)
        {
            _tagNameforBiomarker = tagNameforBiomarker;
            _logger = logger;
            _attrValue = attrValue;
            _lipidParserHelper = lipidParserHelper;
            _attrName = attrName;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public TestResult Parse(long customerId, string xmlFilePath, TestType testType)
        {
            _lipidParserHelper.SetLogger(_logger);
            _errorSummary = string.Empty;
            _logger.Info(string.Format("------------------------------- {0} Parsing for file [{1}]", testType.ToString(), xmlFilePath));

            if (!File.Exists(xmlFilePath))
            {
                _errorSummary += "File doesn't exist.";
                _logger.Error("File doesn't exist.");
                return null;
            }

            var doc = new XmlDocument();
            doc.Load(xmlFilePath);
            var elements = doc.GetElementsByTagName(_tagNameforBiomarker);

            if (elements.Count < 1)
            {
                _errorSummary += "Data not found in file.";
                _logger.Error("Data not found in file.");
                return null;
            }

            var ldlValue = GetLipidValue(LdlCholName, elements);
            var hdlValue = GetLipidValue(HdlCholName, elements);
            var tCholValue = GetLipidValue(TotalCholName, elements);
            var glucoseValue = GetLipidValue(GlucoseName, elements);
            var tglValue = GetLipidValue(TriglyceridesName, elements);

            decimal? tchol = null;
            decimal? hdl = null;
            //not in use
            decimal? tGlycerides = null;


            if (testType == TestType.Lipid)
            {
                var testResult = new LipidTestResult
                {
                    Glucose = _lipidParserHelper.GetReading(glucoseValue, ReadingLabels.Glucose, testType, ref _errorSummary),
                    LDL = _lipidParserHelper.GetReading(ldlValue, ReadingLabels.LDL, testType, ref _errorSummary),
                    TotalCholestrol = _lipidParserHelper.GetReading(tCholValue, ReadingLabels.TotalCholestrol, ref tchol, testType, ref _errorSummary),
                    TriGlycerides = _lipidParserHelper.GetReading(tglValue, ReadingLabels.TriGlycerides, ref tGlycerides, testType, ref _errorSummary),
                    HDL = _lipidParserHelper.GetHdlReading(hdlValue, customerId, ref hdl, testType, ref _errorSummary),
                    TCHDLRatio = _lipidParserHelper.GetHdlTclRatio(hdl, tchol, testType, ref _errorSummary)
                };

                return GetLipidTestResult(testResult);
            }

            if (testType == TestType.Cholesterol)
            {
                var testResult = new CholesterolTestResult
                {
                    LDL = _lipidParserHelper.GetReading(ldlValue, ReadingLabels.LDL, testType, ref _errorSummary),
                    TotalCholesterol = _lipidParserHelper.GetReading(tCholValue, ReadingLabels.TotalCholestrol, ref tchol, testType, ref _errorSummary),
                    TriGlycerides = _lipidParserHelper.GetReading(tglValue, ReadingLabels.TriGlycerides, ref tGlycerides, testType, ref _errorSummary),
                    HDL = _lipidParserHelper.GetHdlReading(hdlValue, customerId, ref hdl, testType, ref _errorSummary),
                    TCHDLRatio = _lipidParserHelper.GetHdlTclRatio(hdl, tchol, testType, ref _errorSummary)
                };

                return GetCholesterolTestResult(testResult);
            }

            if (testType == TestType.Diabetes)
            {
                var testResult = new DiabetesTestResult
                {
                    Glucose = _lipidParserHelper.GetReading(glucoseValue, ReadingLabels.Glucose, testType, ref _errorSummary)
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
        private string GetLipidValue(string name, XmlNodeList elements)
        {
            name = name.ToLower();

            foreach (XmlNode e in elements)
            {
                if (e.Attributes != null && e.Attributes[_attrName] != null && e.Attributes[_attrName].Value.ToLower() == name && e.Attributes[_attrValue] != null)
                {
                    return e.Attributes[_attrValue].Value;
                }
            }

            return string.Empty;
        }

    }
}
