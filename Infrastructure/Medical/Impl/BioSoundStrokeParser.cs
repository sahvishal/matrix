using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSoundStrokeParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;
        private readonly IMediaHelper _mediaHelper;

        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;

        private const string SideToCheckLeft = "l";
        private const string SideToCheckRight = "r";

        private const string ConstforIca = "ica";
        private const string ConstforEdv = "ed";
        private const string ConstforPsv = "ps";

        public BioSoundStrokeParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
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

        public StrokeTestResult MapXmlToDomainObject(string filePathtoXml)
        {
            var testResult = new StrokeTestResult();
            var xDoc = XDocument.Load(filePathtoXml);

            testResult.LeftResultReadings = GetStrokeTestReadings(xDoc, SideToCheckLeft);
            testResult.RightResultReadings = GetStrokeTestReadings(xDoc, SideToCheckRight);

            if (testResult.LeftResultReadings != null)
            {
                if (testResult.LeftResultReadings.ICAEDV != null)
                {
                    testResult.LeftResultReadings.ICAEDV.Label = ReadingLabels.LICAEDV;
                }

                if (testResult.LeftResultReadings.ICAPSV != null)
                {
                    testResult.LeftResultReadings.ICAPSV.Label = ReadingLabels.LICAPSV;
                }
            }

            if (testResult.RightResultReadings != null)
            {
                if (testResult.RightResultReadings.ICAEDV != null)
                {
                    testResult.RightResultReadings.ICAEDV.Label = ReadingLabels.RICAEDV;
                }

                if (testResult.RightResultReadings.ICAPSV != null)
                {
                    testResult.RightResultReadings.ICAPSV.Label = ReadingLabels.RICAPSV;
                }
            }

            bool isExceptionCaused;
            testResult.ResultImages = _mediaHelper.GetMediaforTest(Directory.GetParent(filePathtoXml).Parent.FullName, _mediaLocation, TestType.Stroke.ToString(), out isExceptionCaused).ToList();

            if (isExceptionCaused) { _errorSummary += "Media Extraction Failed. "; }

            return testResult;
        }

        public StrokeTestReadings GetStrokeTestReadings(XDocument xDoc, string sideToCheck)
        {
            var psvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforPsv);
            var edvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforEdv);

            if (psvValue != null || edvValue != null)
            {
                var readings = new StrokeTestReadings
                                  {
                                      ICAEDV = edvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(edvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                                      ICAPSV = psvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(psvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null
                                  };
                return readings;
            }
            return null;
        }

        private decimal? GetValuefromXmlDoc(XDocument xDoc, string sideToCheck, string constForVelocityType)
        {
            try
            {
                var query = from f in xDoc.Descendants("MacroMeasure") select f;

                var subMeasures = (from q in query
                                   where
                                       q.Attribute("Description") != null &&
                                       q.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " +
                                                                                           ConstforIca)
                                   select q.Descendants("SubMeasure")).SelectMany(q => q);

                var meanValue = (from m in subMeasures
                                 where
                                     m.Attribute("Description") != null &&
                                     m.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " + ConstforIca)
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

                _errorSummary += "Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " ICA " + constForVelocityType == ConstforPsv ? "PSV" : "EDV" + ". ";
                _logger.Error("\n Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " ICA " + constForVelocityType == ConstforPsv ? "PSV" : "EDV" + "! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
            return null;
        }
        
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}