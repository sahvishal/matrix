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
    public class BioSound2LeadParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;
        private readonly IMediaHelper _mediaHelper;

        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;

        private const string SideToCheckLeft = "lt";
        private const string SideToCheckRight = "rt";


        private const string ConstforCfa = "cfa";
        private const string ConstforPsfa = "sfa";

        public BioSound2LeadParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaLocation = mediaLocation;
            _mediaHelper = new MediaHelper(logger);
            _logger = logger;
        }

        public TestResult Parse()
        {
            _errorSummary = string.Empty;
            return MapXmlToDomainObject(_pathToReportXmlFile);
        }

        public LeadTestResult MapXmlToDomainObject(string filePathtoXml)
        {
            var testResult = new LeadTestResult();
            var xDoc = XDocument.Load(filePathtoXml);

            testResult.LeftResultReadings = GetLeadTestReadings(xDoc, SideToCheckLeft);
            testResult.RightResultReadings = GetLeadTestReadings(xDoc, SideToCheckRight);

            if (testResult.LeftResultReadings != null)
            {
                if (testResult.LeftResultReadings.CFAPSV != null)
                {
                    testResult.LeftResultReadings.CFAPSV.Label = ReadingLabels.LeftCFAPSV;
                }

                if (testResult.LeftResultReadings.PSFAPSV != null)
                {
                    testResult.LeftResultReadings.PSFAPSV.Label = ReadingLabels.LeftPSFAPSV;
                }
            }

            if (testResult.RightResultReadings != null)
            {
                if (testResult.RightResultReadings.CFAPSV != null)
                {
                    testResult.RightResultReadings.CFAPSV.Label = ReadingLabels.RightCFAPSV;
                }

                if (testResult.RightResultReadings.PSFAPSV != null)
                {
                    testResult.RightResultReadings.PSFAPSV.Label = ReadingLabels.RightPSFAPSV;
                }
            }

            bool isExceptionCaused;
            testResult.ResultImages = _mediaHelper.GetMediaSortedByDecimalValue(Directory.GetParent(filePathtoXml).FullName, _mediaLocation, TestType.Lead.ToString(), out isExceptionCaused).ToList();

            if (isExceptionCaused) { _errorSummary += "Media Extraction Failed. "; }

            return testResult;
        }

        public LeadTestReadings GetLeadTestReadings(XDocument xDoc, string sideToCheck)
        {
            var cfaPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforCfa);
            var psfaPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforPsfa);

            if (cfaPsvValue != null || psfaPsvValue != null)
            {
                var readings = new LeadTestReadings
                {
                    CFAPSV = cfaPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(cfaPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    PSFAPSV = psfaPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(psfaPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null
                };
                return readings;
            }
            return null;
        }

        private decimal? GetValuefromXmlDoc(XDocument xDoc, string sideToCheck, string constForVelocityType)
        {
          //  const string PageId = "ids_lower_extr";
            try
            {
                var query = from f in xDoc.Descendants("MacroMeasure") select f;

                var subMeasures = (from q in query
                                   where q.Attribute("Description") != null
                                         && q.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " + constForVelocityType)
                                   select q.Descendants("SubMeasure")).SelectMany(q => q);

                var meanValue = (from m in subMeasures
                                 where
                                     m.Attribute("Description") != null &&
                                     m.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " + constForVelocityType)
                                     && m.Attribute("Description").Value.ToLower().Contains(constForVelocityType)
                                 select m.Descendants("MeanValue").FirstOrDefault()).FirstOrDefault();

                if (meanValue != null && meanValue.Attribute("Value") != null)
                {
                    decimal d = 0;
                    if (!string.IsNullOrWhiteSpace(meanValue.Attribute("Value").Value))
                        decimal.TryParse(meanValue.Attribute("Value").Value, out d);

                    if (d != 0) return d;
                }

            }
            catch (Exception ex)
            {

                _errorSummary += "Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + constForVelocityType == ConstforCfa ? "CFA" : "PSFA" + ". ";
                _logger.Error("\n Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + constForVelocityType == ConstforCfa ? "CFA" : "PSFA" + "! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
            return null;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}