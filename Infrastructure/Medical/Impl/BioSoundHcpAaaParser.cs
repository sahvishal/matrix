using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BioSoundHcpAaaParser : ITestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private readonly Service.TestResultService _testResultService;
        private List<ResultReading<int>> _aaaReadings;
        private readonly string _pathToReportXmlFile;
        private readonly string _mediaLocation;
        private readonly IMediaHelper _mediaHelper;

        private const string ViewtypeSag = "sag";
        private const string ViewtypeTran = "tran";


        private const string ViewLocProx = "prox";
        private const string ViewLocMid = "mid";
        private const string ViewLocDist = "dis";

        public BioSoundHcpAaaParser(string pathToReportXmlFile, string mediaLocation, ILogger logger)
        {
            _pathToReportXmlFile = pathToReportXmlFile;
            _mediaLocation = mediaLocation;
            _testResultService = new Service.TestResultService();
            _aaaReadings = new TestResultRepository().GetAllReadings((int)TestType.HCPAAA);
            _logger = logger;
            _mediaHelper = new MediaHelper(logger);
        }

        public TestResult Parse()
        {
            _errorSummary = string.Empty;
            return MapXmlToDomainObject(_pathToReportXmlFile);
        }

        public HcpAaaTestResult MapXmlToDomainObject(string filePathtoXml)
        {
            var testResult = new HcpAaaTestResult();
            var xDoc = XDocument.Load(filePathtoXml);

            GetAaaSaggitalView(testResult, xDoc);

            GetAaaTransverseViewValues(testResult, xDoc);

            var aortaValue = GetMaxofthreeAortaValues(testResult);
            if (aortaValue != null)
                testResult.Finding =
                    new StandardFinding<decimal?>(_testResultService.GetCalculatedStandardFinding(aortaValue.Value, (int)TestType.HCPAAA, (int)ReadingLabels.AortaSize));

            bool isExceptionCaused;
            testResult.ResultImages = _mediaHelper.GetMediaforTest(Directory.GetParent(filePathtoXml).Parent.FullName, _mediaLocation, TestType.HCPAAA.ToString(), out isExceptionCaused).ToList();

            if (isExceptionCaused) { _errorSummary += "Media Extraction Failed. "; }

            return testResult;
        }

        private static decimal? GetMaxofthreeAortaValues(HcpAaaTestResult testResult)
        {
            var aortaValues = new decimal[3];
            int index = 0;

            if (testResult.AortaSize != null && testResult.AortaSize.Reading != null)
                aortaValues[index++] = testResult.AortaSize.Reading.Value;

            if (testResult.TransverseView != null)
            {
                if (testResult.TransverseView.FirstValue != null && testResult.TransverseView.FirstValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.FirstValue.Reading.Value;

                if (testResult.TransverseView.SecondValue != null && testResult.TransverseView.SecondValue.Reading != null)
                    aortaValues[index++] = testResult.TransverseView.SecondValue.Reading.Value;
            }

            var aortaValue = aortaValues.Max();
            if (aortaValue > 0) return aortaValue;

            return null;
        }

        private void GetAaaSaggitalView(HcpAaaTestResult testResult, XDocument xDoc)
        {
            try
            {

                var aoProxSag = GetValuefromXmlDoc(xDoc, ViewLocProx, ViewtypeSag);
                var aoMidSag = GetValuefromXmlDoc(xDoc, ViewLocMid, ViewtypeSag);
                var aoDistSag = GetValuefromXmlDoc(xDoc, ViewLocDist, ViewtypeSag);

                if (aoProxSag != null || aoMidSag != null || aoDistSag != null)
                {
                    IEnumerable<string> viewLocs;
                    var aortaValue = GetMaximumOfThree(aoProxSag ?? 0, aoMidSag ?? 0, aoDistSag ?? 0, out viewLocs);

                    if (aortaValue != null)
                    {
                        if (_aaaReadings.Any(r => r.Label == ReadingLabels.AortaSize))
                        {
                            testResult.AortaSize = new ResultReading<decimal?>(ReadingLabels.AortaSize)
                                                   {
                                                       Reading = Decimal.Round(aortaValue.Value, 2),
                                                       ReadingSource = ReadingSource.Automatic
                                                   };

                        }

                        if (viewLocs != null && viewLocs.Any() && _aaaReadings.Any(r => r.Label == ReadingLabels.AortaRangeSaggitalView))
                        {
                            var sagViewFindings = _testResultService.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeSaggitalView);

                            testResult.AortaRangeSaggitalView = new List<StandardFinding<int>>();
                            foreach (string viewLoc in viewLocs)
                            {
                                var finding = sagViewFindings.SingleOrDefault(s => s.Label.ToLower().Contains(viewLoc));
                                if (finding != null)
                                    testResult.AortaRangeSaggitalView.Add(finding);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Measurement for Saggital View could not be extracted. ";
                _logger.Error("\n Measurement for Saggital View could not be extracted. Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
        }

        private void GetAaaTransverseViewValues(HcpAaaTestResult testResult, XDocument xDoc)
        {
            try
            {
                var aoProxTran1 = GetValuefromXmlDoc(xDoc, ViewLocProx, ViewtypeTran, "1");
                var aoMidTran1 = GetValuefromXmlDoc(xDoc, ViewLocMid, ViewtypeTran, "1");
                var aoDistTran1 = GetValuefromXmlDoc(xDoc, ViewLocDist, ViewtypeTran, "1");

                var aoProxTran2 = GetValuefromXmlDoc(xDoc, ViewLocProx, ViewtypeTran, "2");
                var aoMidTran2 = GetValuefromXmlDoc(xDoc, ViewLocMid, ViewtypeTran, "2");
                var aoDistTran2 = GetValuefromXmlDoc(xDoc, ViewLocDist, ViewtypeTran, "2");

                IEnumerable<string> viewLocs1, viewLocs2, viewLocs;
                decimal? aortaValue1, aortaValue2, aortaValue;
                aortaValue1 = aortaValue2 = null;
                viewLocs1 = viewLocs2 = null;

                if (aoProxTran1 != null || aoMidTran1 != null || aoDistTran1 != null)
                {
                    aortaValue1 = GetMaximumOfThree(aoProxTran1 ?? 0, aoMidTran1 ?? 0, aoDistTran1 ?? 0, out viewLocs1);
                }

                if (aoProxTran2 != null || aoMidTran2 != null || aoDistTran2 != null)
                {
                    aortaValue2 = GetMaximumOfThree(aoProxTran2 ?? 0, aoMidTran2 ?? 0, aoDistTran2 ?? 0, out viewLocs2);
                }

                if (aortaValue1 != null || aortaValue2 != null)
                {
                    if ((aortaValue1 ?? 0) > (aortaValue2 ?? 0))
                    {
                        aortaValue = aortaValue1;
                        viewLocs = viewLocs1;
                    }
                    else
                    {
                        aortaValue = aortaValue2;
                        viewLocs = viewLocs2;
                    }

                    if (aortaValue != null)
                    {

                        testResult.TransverseView = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>();

                        if (_aaaReadings.Any(r => r.Label == ReadingLabels.TransverseViewDataPointOne))
                        {
                            testResult.TransverseView.FirstValue =
                                new ResultReading<decimal?>(ReadingLabels.TransverseViewDataPointOne)
                                    {
                                        ReadingSource = ReadingSource.Automatic
                                    };
                        }

                        if (_aaaReadings.Any(r => r.Label == ReadingLabels.TransverseViewDataPointTwo))
                        {
                            testResult.TransverseView.SecondValue =
                                new ResultReading<decimal?>(ReadingLabels.TransverseViewDataPointTwo)
                                    {
                                        ReadingSource = ReadingSource.Automatic
                                    };
                        }
                    }

                    if (viewLocs != null && viewLocs.Any())
                    {
                        if (viewLocs.ElementAt(0) == ViewLocProx)
                        {
                            testResult.TransverseView.FirstValue.Reading = aoProxTran1.HasValue ? (decimal?)decimal.Round(aoProxTran1.Value, 2) : null;
                            testResult.TransverseView.SecondValue.Reading = aoProxTran2.HasValue ? (decimal?)decimal.Round(aoProxTran2.Value, 2) : null;
                        }
                        else if (viewLocs.ElementAt(0) == ViewLocDist)
                        {
                            testResult.TransverseView.FirstValue.Reading = aoDistTran1.HasValue ? (decimal?)decimal.Round(aoDistTran1.Value, 2) : null;
                            testResult.TransverseView.SecondValue.Reading = aoDistTran2.HasValue ? (decimal?)decimal.Round(aoDistTran2.Value, 2) : null;
                        }
                        else if (viewLocs.ElementAt(0) == ViewLocMid)
                        {
                            testResult.TransverseView.FirstValue.Reading = aoMidTran1.HasValue ? (decimal?)decimal.Round(aoMidTran1.Value, 2) : null;
                            testResult.TransverseView.SecondValue.Reading = aoMidTran2.HasValue ? (decimal?)decimal.Round(aoMidTran2.Value, 2) : null;
                        }

                        if (_aaaReadings.Any(r => r.Label == ReadingLabels.AortaRangeTransverseView))
                        {
                            var transViewFindings = _testResultService.GetAllStandardFindings<int>((int)TestType.HCPAAA, (int)ReadingLabels.AortaRangeTransverseView);
                            testResult.AortaRangeTransverseView = new List<StandardFinding<int>>();

                            foreach (string viewLoc in viewLocs)
                            {
                                var finding =
                                    transViewFindings.SingleOrDefault(s => s.Label.ToLower().Contains(viewLoc));
                                if (finding != null)
                                    testResult.AortaRangeTransverseView.Add(finding);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Datapoints for Transverse View could not be extracted. ";
                _logger.Error("\n Datapoints for Transverse View could not be extracted." + ex.Message + "\n\t\t" + ex.StackTrace);
            }
        }

        private static decimal? GetValuefromXmlDoc(XDocument xDoc, string viewLocation, string viewType, string viewTypeCounter = "")
        {
            var query = from f in xDoc.Descendants("MacroMeasure") select f;

            var b = (from q in query
                     where
                         q.Attribute("Description") != null && q.Attribute("Description").Value.ToLower().Contains("ao") && q.Attribute("Description").Value.ToLower().Contains(viewLocation)
                         && q.Attribute("Description").Value.ToLower().Contains(viewType) && q.Attribute("Description").Value.ToLower().Contains(viewTypeCounter)
                     select q.Descendants("MeanValue").FirstOrDefault()).FirstOrDefault();

            if (b != null && b.Attribute("Value") != null)
            {
                decimal d = 0;
                if (!string.IsNullOrWhiteSpace(b.Attribute("Value").Value))
                    decimal.TryParse(b.Attribute("Value").Value, out d);

                if (d > 0) return d;
            }
            return null;
        }

        private static decimal? GetMaximumOfThree(decimal proximal, decimal mid, decimal distal, out IEnumerable<string> viewLoc)
        {
            viewLoc = new List<string>();

            if (proximal > mid && proximal > distal)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocProx });
                return proximal;
            }

            if (proximal > mid && proximal == distal)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocProx, ViewLocDist });
                return proximal;
            }

            if (proximal == mid && proximal > distal)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocProx, ViewLocMid });
                return proximal;
            }

            if (proximal == mid && proximal == distal)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocProx, ViewLocMid, ViewLocDist });
                return proximal;
            }

            if (mid > distal)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocMid });
                return mid;
            }

            if (distal > mid)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocDist });
                return distal;
            }

            if (distal == mid)
            {
                viewLoc = viewLoc.Concat(new[] { ViewLocMid, ViewLocDist });
                return distal;
            }

            return null;
        }
        
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}
