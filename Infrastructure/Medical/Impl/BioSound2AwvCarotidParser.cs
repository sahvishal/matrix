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
    public class BioSound2AwvCarotidParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;
        private readonly IMediaHelper _mediaHelper;

        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;

        private const string SideToCheckLeft = "l";
        private const string SideToCheckRight = "r";

        private const string ConstforCca = "cca";
        private const string ConstforIca = "ica";

        private const string ConstforPorx = "prox";
        private const string ConstforDis = "dist";

        private const string ConstforBulb = "bulb";
        private const string ConstforExtCarotidArt = "ext carotid";

        private const string ConstforVertebralArt = "vertebral art";


        private const string ConstforEdv = "edvel";
        private const string ConstforPsv = "psvel";

        public BioSound2AwvCarotidParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
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

        public AwvCarotidTestResult MapXmlToDomainObject(string filePathtoXml)
        {
            var testResult = new AwvCarotidTestResult();
            var xDoc = XDocument.Load(filePathtoXml);

            testResult.LeftResultReadings = GetAwvCarotidTestReadings(xDoc, SideToCheckLeft);
            testResult.RightResultReadings = GetAwvCarotidTestReadings(xDoc, SideToCheckRight);

            if (testResult.LeftResultReadings != null)
            {
                if (testResult.LeftResultReadings.CCAProximalPSV != null)
                    testResult.LeftResultReadings.CCAProximalPSV.Label = ReadingLabels.LCCAProximalPSV;
                if (testResult.LeftResultReadings.CCAProximalEDV != null)
                    testResult.LeftResultReadings.CCAProximalEDV.Label = ReadingLabels.LCCAProximalEDV;

                if (testResult.LeftResultReadings.CCADistalPSV != null)
                    testResult.LeftResultReadings.CCADistalPSV.Label = ReadingLabels.LCCADistalPSV;
                if (testResult.LeftResultReadings.CCADistalEDV != null)
                    testResult.LeftResultReadings.CCADistalEDV.Label = ReadingLabels.LCCADistalEDV;

                if (testResult.LeftResultReadings.BulbPSV != null)
                    testResult.LeftResultReadings.BulbPSV.Label = ReadingLabels.LBulbPSV;
                if (testResult.LeftResultReadings.BulbEDV != null)
                    testResult.LeftResultReadings.BulbEDV.Label = ReadingLabels.LBulbEDV;

                if (testResult.LeftResultReadings.ExtCarotidArtPSV != null)
                    testResult.LeftResultReadings.ExtCarotidArtPSV.Label = ReadingLabels.LExtCarotidArtPSV;

                if (testResult.LeftResultReadings.ICAProximalPSV != null)
                    testResult.LeftResultReadings.ICAProximalPSV.Label = ReadingLabels.LICAPSV;
                if (testResult.LeftResultReadings.ICAProximalEDV != null)
                    testResult.LeftResultReadings.ICAProximalEDV.Label = ReadingLabels.LICAEDV;

                if (testResult.LeftResultReadings.ICADistalPSV != null)
                    testResult.LeftResultReadings.ICADistalPSV.Label = ReadingLabels.LICADistalPSV;
                if (testResult.LeftResultReadings.ICADistalEDV != null)
                    testResult.LeftResultReadings.ICADistalEDV.Label = ReadingLabels.LICADistalEDV;

                if (testResult.LeftResultReadings.VertebralArtPSV != null)
                    testResult.LeftResultReadings.VertebralArtPSV.Label = ReadingLabels.LVertebralArtPSV;
                if (testResult.LeftResultReadings.VertebralArtEDV != null)
                    testResult.LeftResultReadings.VertebralArtEDV.Label = ReadingLabels.LVertebralArtEDV;

            }

            if (testResult.RightResultReadings != null)
            {
                if (testResult.RightResultReadings.CCAProximalPSV != null)
                    testResult.RightResultReadings.CCAProximalPSV.Label = ReadingLabels.LCCAProximalPSV;
                if (testResult.RightResultReadings.CCAProximalEDV != null)
                    testResult.RightResultReadings.CCAProximalEDV.Label = ReadingLabels.LCCAProximalEDV;

                if (testResult.RightResultReadings.CCADistalPSV != null)
                    testResult.RightResultReadings.CCADistalPSV.Label = ReadingLabels.LCCADistalPSV;
                if (testResult.RightResultReadings.CCADistalEDV != null)
                    testResult.RightResultReadings.CCADistalEDV.Label = ReadingLabels.LCCADistalEDV;

                if (testResult.RightResultReadings.BulbPSV != null)
                    testResult.RightResultReadings.BulbPSV.Label = ReadingLabels.LBulbPSV;
                if (testResult.RightResultReadings.BulbEDV != null)
                    testResult.RightResultReadings.BulbEDV.Label = ReadingLabels.LBulbEDV;

                if (testResult.RightResultReadings.ExtCarotidArtPSV != null)
                    testResult.RightResultReadings.ExtCarotidArtPSV.Label = ReadingLabels.LExtCarotidArtPSV;

                if (testResult.RightResultReadings.ICAProximalPSV != null)
                    testResult.RightResultReadings.ICAProximalPSV.Label = ReadingLabels.RICAPSV;
                if (testResult.RightResultReadings.ICAProximalEDV != null)
                    testResult.RightResultReadings.ICAProximalEDV.Label = ReadingLabels.RICAEDV;

                if (testResult.RightResultReadings.ICADistalPSV != null)
                    testResult.RightResultReadings.ICADistalPSV.Label = ReadingLabels.LICADistalPSV;
                if (testResult.RightResultReadings.ICADistalEDV != null)
                    testResult.RightResultReadings.ICADistalEDV.Label = ReadingLabels.LICADistalEDV;

                if (testResult.RightResultReadings.VertebralArtPSV != null)
                    testResult.RightResultReadings.VertebralArtPSV.Label = ReadingLabels.LVertebralArtPSV;
                if (testResult.RightResultReadings.VertebralArtEDV != null)
                    testResult.RightResultReadings.VertebralArtEDV.Label = ReadingLabels.LVertebralArtEDV;
            }

            bool isExceptionCaused;
            testResult.ResultImages = _mediaHelper.GetMediaSortedByDecimalValue(Directory.GetParent(filePathtoXml).FullName, _mediaLocation, TestType.AwvCarotid.ToString(), out isExceptionCaused).ToList();

            if (isExceptionCaused) { _errorSummary += "Media Extraction Failed. "; }

            return testResult;
        }

        private AwvCarotidTestReadings GetAwvCarotidTestReadings(XDocument xDoc, string sideToCheck)
        {
            var ccaProximalPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforCca, ConstforPorx, ConstforPsv);
            var ccaProximalEdvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforCca, ConstforPorx, ConstforEdv);

            var ccaDistalPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforCca, ConstforDis, ConstforPsv);
            var ccaDistalEdvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforCca, ConstforDis, ConstforEdv);

            var icaProximalPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforIca, ConstforPorx, ConstforPsv);
            var icaProximalEdvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforIca, ConstforPorx, ConstforEdv);

            var icaDistalPsvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforIca, ConstforDis, ConstforPsv);
            var icaDistalEdvValue = GetValuefromXmlDoc(xDoc, sideToCheck, ConstforIca, ConstforDis, ConstforEdv);

            var bulbPsvValue = GetReadingValuefromXmlDoc(xDoc, sideToCheck, "bulb peak sys vel", ConstforBulb);
            var bulbEdvValue = GetReadingValuefromXmlDoc(xDoc, sideToCheck, "bulb enddiast vel", ConstforBulb);

            var vertebralArtPsvValue = GetReadingValuefromXmlDoc(xDoc, sideToCheck, "va peak sys vel",
                ConstforVertebralArt);
            var vertebralArtEdvValue = GetReadingValuefromXmlDoc(xDoc, sideToCheck, "va enddiast vel",
                ConstforVertebralArt);

            var extCarotidArtPsvValue = GetReadingValuefromXmlDoc(xDoc, sideToCheck, "eca peak sys vel",
                ConstforExtCarotidArt);

            if (ccaProximalPsvValue != null || ccaProximalEdvValue != null || ccaDistalPsvValue != null || ccaDistalEdvValue != null
                || icaProximalPsvValue != null || icaProximalEdvValue != null || icaDistalPsvValue != null || icaDistalEdvValue != null
                || bulbPsvValue != null || bulbEdvValue != null || vertebralArtPsvValue != null || vertebralArtEdvValue != null || extCarotidArtPsvValue != null)
            {
                var readings = new AwvCarotidTestReadings
                {
                    CCAProximalPSV = ccaProximalPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(ccaProximalPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    CCAProximalEDV = ccaProximalEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(ccaProximalEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    CCADistalPSV = ccaDistalPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(ccaDistalPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    CCADistalEDV = ccaDistalEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(ccaDistalEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    ICAProximalPSV = icaProximalPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(icaProximalPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    ICAProximalEDV = icaProximalEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(icaProximalEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    ICADistalPSV = icaDistalPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(icaDistalPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    ICADistalEDV = icaDistalEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(icaDistalEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    BulbPSV = bulbPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(bulbPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    BulbEDV = bulbEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(bulbEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    VertebralArtPSV = vertebralArtPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(vertebralArtPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                    VertebralArtEDV = vertebralArtEdvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(vertebralArtEdvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,

                    ExtCarotidArtPSV = extCarotidArtPsvValue != null ? new ResultReading<decimal?> { Reading = decimal.Round(extCarotidArtPsvValue.Value, 2), ReadingSource = ReadingSource.Automatic } : null,
                };
                return readings;
            }
            return null;
        }

        private  decimal? GetValuefromXmlDoc(XDocument xDoc, string sideToCheck, string constForVelocityType, string proxdis, string typeofVelSpeed)
        {
            try
            {
                var query = from f in xDoc.Descendants("MacroMeasure") select f;

                var subMeasures = (from q in query
                                   where q.Attribute("Description") != null
                                         && q.Attribute("Description").Value.ToLower().Replace(" ", "").Contains(sideToCheck + constForVelocityType + proxdis)
                                   select q.Descendants("SubMeasure")).SelectMany(q => q);

                var meanValue = (from m in subMeasures
                                 where
                                     m.Attribute("Description") != null &&
                                     m.Attribute("Description").Value.ToLower().Replace(" ", "").Contains(sideToCheck + constForVelocityType + proxdis + typeofVelSpeed)

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
                _errorSummary += "Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " " + constForVelocityType.ToUpper() + " " + proxdis + " " + typeofVelSpeed == ConstforPsv ? "PS VEL" : "ED VEL" + ". ";
                _logger.Error("\n Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " " + constForVelocityType.ToUpper() + " " + proxdis + " " + typeofVelSpeed == ConstforPsv ? "PS VEL" : "ED VEL" + "! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);

            }
            return null;
        }

        private  decimal? GetReadingValuefromXmlDoc(XDocument xDoc, string sideToCheck, string subMeasureDescription, string readingType)
        {
            try
            {
                var query = from f in xDoc.Descendants("MacroMeasure") select f;

                var subMeasures = (from q in query
                                   where q.Attribute("Description") != null
                                         && q.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " + readingType)
                                   select q.Descendants("SubMeasure")).SelectMany(q => q);

                var meanValue = (from m in subMeasures
                                 where
                                     m.Attribute("Description") != null
                                     && m.Attribute("Description").Value.ToLower().Contains(sideToCheck + " " + subMeasureDescription)
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

                _errorSummary += "Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " " + readingType.ToUpper() + " " + subMeasureDescription.ToUpper() + ". ";
                _logger.Error("\n Data Extraction failed for " + sideToCheck == SideToCheckLeft ? "Left" : "Right" + " " + readingType.ToUpper() + " " + subMeasureDescription.ToUpper() + "! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
            return null;
        }

        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}