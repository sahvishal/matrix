using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class GeAaaResultParser : IGeTestParser
    {
        private readonly Service.TestResultService _testResultService;
        private readonly ILogger _logger;
        private readonly IEnumerable<string> _pathToMediaFolder;
        private readonly string _mediaLocation;
        private readonly IMovieMaker _movieMaker;

        private const string ColumnForValue = "ResultValue";
        private const string ColumnForFieldName = "ParameterName";
        private const string ColumnForFieldNameSupport = "ResultIdentifier";

        private const string FieldValueForMeasurement = "Measurement";
        private const string ConstForAo = "AO";
        private const string ConstForDist = "DIS";
        private const string ConstForMid = "MID";
        private const string ConstForProx = "PROX";
        private const string ConstForTrans = "TRANS";
        
        private const string ViewLocProx = "prox";
        private const string ViewLocMid = "mid";
        private const string ViewLocDist = "dist";

        private string _errorSummary;
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public GeAaaResultParser(IEnumerable<string> pathToMediaFolder, string mediaLocation, ILogger logger)
        {
            _errorSummary = string.Empty;
            _logger = logger;
            _testResultService = new Service.TestResultService();
            _pathToMediaFolder = pathToMediaFolder;
            _mediaLocation = mediaLocation;
            _movieMaker = new MovieMaker(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, _logger);
        }

        public bool CheckifDatatableisValidfortheTestType(DataTable dtSourceFromExcel)
        {
            if (!(dtSourceFromExcel.Columns.Contains(ColumnForValue) && dtSourceFromExcel.Columns.Contains(ColumnForFieldName) && dtSourceFromExcel.Columns.Contains(ColumnForFieldNameSupport)))
            {
                _logger.Info(string.Format("\n\tOne of the required columns, [{0} | {1} | {2}], are missing.", ColumnForValue, ColumnForFieldName, ColumnForFieldNameSupport));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForValue + " is not null and LEN(" + ColumnForValue + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1){
                _logger.Info(string.Format("\n\tNo valid value found in column [{0}].", ColumnForValue));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForFieldName + " is not null and LEN(" + ColumnForFieldName + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1)
            {
                _logger.Info(string.Format("\n\tNo valid value found in column [{0}].", ColumnForFieldName));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForFieldNameSupport + " is not null and LEN(" + ColumnForFieldNameSupport + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1)
            {
                _logger.Info(string.Format("\n\tNo valid value found in column [{0}].", ColumnForFieldNameSupport));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = string.Format("{0} like '%{1}%' And ({0} like '%{2}%' Or {0} like '%{3}%' Or {0} like '%{4}%' Or {0} like '%{5}%')", ColumnForFieldName, ConstForAo, ConstForDist, ConstForMid, ConstForProx, ConstForTrans);
            if (dtSourceFromExcel.DefaultView.Count < 1) return false;

            return true;
        }

        public TestResult Parse(DataTable dtSourceFromExcel)
        {
            var testResult = new AAATestResult();

            if (dtSourceFromExcel != null)
            {
                var isContainAllColNeededForReadings = CheckifDatatableisValidfortheTestType(dtSourceFromExcel);

                if (isContainAllColNeededForReadings)
                {
                    GetSaggitalView(testResult, dtSourceFromExcel);
                    GetTransverseView(testResult, dtSourceFromExcel);

                    if (testResult.AortaSize != null || testResult.TransverseView != null)
                    {
                        var aortaValue = GetMaxofthreeAortaValues(testResult);
                        if (aortaValue != null)
                            testResult.Finding =
                                new StandardFinding<decimal?>(
                                    _testResultService.GetCalculatedStandardFinding(aortaValue.Value, (int) TestType.AAA,
                                                                                    (int) ReadingLabels.AortaSize));
                    }
                }
            }

            testResult.ResultImages = new List<ResultMedia>();
            foreach (var path in _pathToMediaFolder)
            {
                var media = GetMediaforTest(path);
                if (media != null)
                    testResult.ResultImages.AddRange(media);
            }

            if (testResult.AortaSize == null && testResult.TransverseView == null && testResult.ResultImages.Count < 1)
                return null;

            return testResult;
        }

        private void GetSaggitalView(AAATestResult testResult, DataTable dtSourceFromExcel)
        {
            try
            {
                decimal? aoDistal = GetAortaValueforSaggital(dtSourceFromExcel, ConstForDist);
                decimal? aoProx = GetAortaValueforSaggital(dtSourceFromExcel, ConstForProx);
                decimal? aoMid = GetAortaValueforSaggital(dtSourceFromExcel, ConstForMid);

                if (aoDistal == null && aoMid == null && aoProx == null)
                {
                    _logger.Info("\n\tData for Saggital view not found.");
                    return;
                }

                IEnumerable<string> viewLocs = null;
                var value = GetMaximumOfThree(aoProx ?? 0, aoMid ?? 0, aoDistal ?? 0, out viewLocs);

                if (value == null || viewLocs == null || viewLocs.Count() < 1) return;

                testResult.AortaSize = new ResultReading<decimal?>(ReadingLabels.AortaSize)
                {
                    Reading = Decimal.Round(value.Value, 2),
                    ReadingSource = ReadingSource.Automatic
                };

                var sagViewFindings = _testResultService.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeSaggitalView);
                testResult.AortaRangeSaggitalView = new List<StandardFinding<int>>();
                foreach (string viewLoc in viewLocs)
                {
                    var finding =
                        sagViewFindings.Where(s => s.Label.ToLower().Contains(viewLoc)).SingleOrDefault();
                    if (finding != null)
                        testResult.AortaRangeSaggitalView.Add(finding);
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Measurement for Saggital View could not be extracted. ";
                _logger.Error("\n Measurement for Saggital View could not be extracted. Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
        }

        private void GetTransverseView(AAATestResult testResult, DataTable dtSourceFromExcel)
        {
            try
            {
                var aoDistalOp = GetAortaValueforTransverse(dtSourceFromExcel, ConstForDist);
                var aoProxOp = GetAortaValueforTransverse(dtSourceFromExcel, ConstForProx);
                var aoMidOp = GetAortaValueforTransverse(dtSourceFromExcel, ConstForMid);

                var aoDisDp1 = aoDistalOp != null ? aoDistalOp.FirstValue : null;
                var aoMidDp1 = aoMidOp != null ? aoMidOp.FirstValue : null;
                var aoProxDp1 = aoProxOp != null ? aoProxOp.FirstValue : null;

                var aoDisDp2 = aoDistalOp != null ? aoDistalOp.SecondValue : null;
                var aoMidDp2 = aoMidOp != null ? aoMidOp.SecondValue : null;
                var aoProxDp2 = aoProxOp != null ? aoProxOp.SecondValue : null;

                decimal? valueDp1, valueDp2;
                IEnumerable<string> viewLocsDp1 = null;
                IEnumerable<string> viewLocsDp2 = null;
                valueDp2 = valueDp1 = null;

                IEnumerable<string> viewLocs;

                if (!(aoDisDp1 == null && aoMidDp1 == null && aoProxDp1 == null))
                {
                    valueDp1 = GetMaximumOfThree(aoProxDp1 ?? 0, aoMidDp1 ?? 0, aoDisDp1 ?? 0, out viewLocsDp1);
                }

                if (!(aoDisDp2 == null && aoMidDp2 == null && aoProxDp2 == null))
                {
                    valueDp2 = GetMaximumOfThree(aoProxDp2 ?? 0, aoMidDp2 ?? 0, aoDisDp2 ?? 0, out viewLocsDp2);
                }

                if (valueDp1 == null && valueDp2 == null)
                {
                    _logger.Info("\n\tData for Transverse view not found.");
                    return;
                }

                viewLocs = (valueDp1 ?? 0) > (valueDp2 ?? 0) ? viewLocsDp1 : viewLocsDp2;

                testResult.TransverseView = new OrderedPair<ResultReading<decimal?>, ResultReading<decimal?>>
                                                {
                                                    FirstValue =
                                                        new ResultReading<decimal?>(ReadingLabels.TransverseViewDataPointOne)
                                                            {
                                                                ReadingSource = ReadingSource.Automatic
                                                            },
                                                    SecondValue =
                                                        new ResultReading<decimal?>(ReadingLabels.TransverseViewDataPointTwo)
                                                            {
                                                                ReadingSource = ReadingSource.Automatic
                                                            }
                                                };

                if (viewLocs.ElementAt(0) == ViewLocProx)
                {
                    if (aoProxDp1 != null) testResult.TransverseView.FirstValue.Reading = Decimal.Round(aoProxDp1.Value, 2);
                    else testResult.TransverseView.FirstValue = null;

                    if (aoProxDp2 != null) testResult.TransverseView.SecondValue.Reading = Decimal.Round(aoProxDp2.Value, 2);
                    else testResult.TransverseView.SecondValue = null;
                }
                else if (viewLocs.ElementAt(0) == ViewLocDist)
                {
                    if (aoDisDp1 != null) testResult.TransverseView.FirstValue.Reading = Decimal.Round(aoDisDp1.Value, 2);
                    else testResult.TransverseView.FirstValue = null;

                    if (aoDisDp2 != null) testResult.TransverseView.SecondValue.Reading = Decimal.Round(aoDisDp2.Value, 2);
                    else testResult.TransverseView.SecondValue = null;
                }
                else if (viewLocs.ElementAt(0) == ViewLocMid)
                {
                    if (aoMidDp1 != null) testResult.TransverseView.FirstValue.Reading = Decimal.Round(aoMidDp1.Value, 2);
                    else testResult.TransverseView.FirstValue = null;

                    if (aoMidDp2 != null) testResult.TransverseView.SecondValue.Reading = Decimal.Round(aoMidDp2.Value, 2);
                    else testResult.TransverseView.SecondValue = null;
                }

                var transViewFindings = _testResultService.GetAllStandardFindings<int>((int)TestType.AAA, (int)ReadingLabels.AortaRangeTransverseView);
                testResult.AortaRangeTransverseView = new List<StandardFinding<int>>();

                foreach (string viewLoc in viewLocs)
                {
                    var finding =
                        transViewFindings.Where(s => s.Label.ToLower().Contains(viewLoc)).SingleOrDefault();
                    if (finding != null)
                        testResult.AortaRangeTransverseView.Add(finding);
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Datapoints for Transverse View could not be extracted. ";
                _logger.Error("\n Datapoints for Transverse View could not be extracted. Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
        }

        public IEnumerable<ResultMedia> GetMediaforTest(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            _logger.Info("\nMedia Path: " + path);
            var media = new List<ResultMedia>();
            var fileName = "Aaa_" + Guid.NewGuid() + "(1)";
            var counter = Directory.GetFiles(path).Select(Path.GetExtension).Where(ext => !string.IsNullOrEmpty(ext)).LongCount(ext => ext.Contains(".jpg") || ext.Contains(".jpeg") || ext.Contains(".bmp") || ext.Contains(".png"));

            try
            {
                if (counter > 1)
                {
                    string fileNameWithoutExtension = fileName;
                    fileName = fileName + ".flv";
                    var returnResult = _movieMaker.GenerateMoviefromImageGroup(path, _mediaLocation, fileName);
                    if (string.IsNullOrEmpty(returnResult)) return null;

                    var mp4File = _movieMaker.GenerateMPEG(_mediaLocation + "\\" + returnResult, _mediaLocation, fileNameWithoutExtension);
                    
                    var file = new FileInfo(_mediaLocation + fileName);

                    var resultMedia = new ResultMedia
                    {
                        File =
                            new File
                            {
                                FileSize = file.Length,
                                Path = mp4File,//fileName,
                                UploadedOn = DateTime.Now,
                                Type = FileType.Video
                            }
                    };
                    media.Add(resultMedia);
                }
                else if (counter > 0)
                {
                    var imgFilePath = "";
                    foreach (string filePath in Directory.GetFiles(path))
                    {
                        string ext = Path.GetExtension(filePath);
                        if (!string.IsNullOrEmpty(ext) && (ext.Contains(".jpg") || ext.Contains(".jpeg") || ext.Contains(".bmp") || ext.Contains(".png")))
                        {
                            imgFilePath = filePath;
                            break;
                        }
                    }

                    var imageName = fileName + Path.GetExtension(imgFilePath);
                    var file = new FileInfo(imgFilePath);
                    file.MoveTo(_mediaLocation + imageName);

                    decimal fileSize;
                    var thumbnailImageName = CreateThumbnailImage(_mediaLocation + imageName, out fileSize);
                    var resultMedia = new ResultMedia
                    {
                        File =
                            new File
                            {
                                FileSize = file.Length,
                                Path = imageName,
                                UploadedOn = DateTime.Now,
                                Type = FileType.Image
                            },
                        Thumbnail =
                            new File
                            {
                                FileSize = fileSize,
                                Path = thumbnailImageName,
                                UploadedOn = DateTime.Now,
                                Type = FileType.Image
                            }
                    };
                    media.Add(resultMedia);
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Media Extraction Failed. ";
                _logger.Error("\n Media Extraction Failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return media;
        }

        private string CreateThumbnailImage(string filePath, out decimal fileSize)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
            //System.Drawing.Image thumbnailImage = image.GetThumbnailImage(64, 64, ThumbnailCallback, IntPtr.Zero);

            //string filesavefolder = filePath.Substring(0, filePath.LastIndexOf("\\"));
            //string thumbNailFileName = "Thumb_" + filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.Length - (filePath.LastIndexOf("\\") + 1));
            //string thumbnailimagefilepath = filesavefolder + "\\" + thumbNailFileName;
            //if (!System.IO.File.Exists(thumbnailimagefilepath))
            //    thumbnailImage.Save(thumbnailimagefilepath);

            //fileSize = new FileInfo(thumbnailimagefilepath).Length;
            //return thumbNailFileName;

            using (var image = System.Drawing.Image.FromFile(filePath))
            {
                using (var thumbnailImage = image.GetThumbnailImage(64, 64, ThumbnailCallback, IntPtr.Zero))
                {
                    string filesavefolder = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    string thumbNailFileName = "Thumb_" + filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.Length - (filePath.LastIndexOf("\\") + 1));
                    string thumbnailimagefilepath = filesavefolder + "\\" + thumbNailFileName;
                    if (!System.IO.File.Exists(thumbnailimagefilepath))
                        thumbnailImage.Save(thumbnailimagefilepath);

                    fileSize = new FileInfo(thumbnailimagefilepath).Length;
                    return thumbNailFileName;
                }
            }
        }

        /// Required, but not used
        /// 
        /// <returns>true</returns>
        public bool ThumbnailCallback()
        {
            return true;
        }

        private static decimal? GetAortaValueforSaggital(DataTable dtSourceFromExcel, string fieldValue)
        {
            dtSourceFromExcel.DefaultView.RowFilter = string.Format("{0} like '%{1}%' and {0} like '%{5}%' and {0} not like '%{6}%' and {2} like '%{3}%' and {4} is not null", ColumnForFieldName,
                              fieldValue, ColumnForFieldNameSupport, FieldValueForMeasurement, ColumnForValue, ConstForAo, ConstForTrans);

            dtSourceFromExcel.DefaultView.Sort = ColumnForFieldNameSupport + " desc";

            if (dtSourceFromExcel.DefaultView.Count > 0)
            {
                string value = dtSourceFromExcel.DefaultView[0][ColumnForValue].ToString();
                decimal s;
                if (decimal.TryParse(value, out s))
                {
                    return s;
                }
            }
            return null;
        }

        private static OrderedPair<decimal?, decimal?> GetAortaValueforTransverse(DataTable dtSourceFromExcel, string fieldValue)
        {
            dtSourceFromExcel.DefaultView.RowFilter = "";
            dtSourceFromExcel.DefaultView.RowFilter = string.Format("{0} like '%{1}%' and {0} like '%{5}%' and {0} like '%{6}%' and {2} like '%{3}%' and {4} is not null", ColumnForFieldName,
                              fieldValue, ColumnForFieldNameSupport, FieldValueForMeasurement, ColumnForValue, ConstForAo, ConstForTrans);

            if (dtSourceFromExcel.DefaultView.Count < 1) return null;

            decimal? dp1, dp2;
            dp1 = dp2 = null;

            DataRowView selectedViewforDp1 = null;
            DataRowView selectedViewforDp2 = null;

            dtSourceFromExcel.DefaultView.Sort = ColumnForFieldNameSupport + " desc";

            var containsSequence = dtSourceFromExcel.DefaultView.Cast<DataRowView>().Any(v => v[ColumnForFieldName].ToString().IndexOf("1") > 0 || v[ColumnForFieldName].ToString().IndexOf("2") > 0);

            foreach (DataRowView v in dtSourceFromExcel.DefaultView)
            {
                if (selectedViewforDp1 == null && ((containsSequence && v[ColumnForFieldName].ToString().IndexOf("1") > 0) || !containsSequence))
                {
                    selectedViewforDp1 = v;
                    continue;
                }

                if (selectedViewforDp2 == null && ((containsSequence && v[ColumnForFieldName].ToString().IndexOf("2") > 0) || !containsSequence))
                {
                    selectedViewforDp2 = v;
                }
            }

            if (selectedViewforDp1 != null)
            {
                string value = selectedViewforDp1[ColumnForValue].ToString();
                decimal s;
                if (decimal.TryParse(value, out s))
                {
                    dp1 = s;
                }
            }

            if (selectedViewforDp2 != null)
            {
                string value = selectedViewforDp2[ColumnForValue].ToString();
                decimal s;
                if (decimal.TryParse(value, out s))
                {
                    dp2 = s;
                }
            }

            return new OrderedPair<decimal?, decimal?>(dp1, dp2);
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

        private static decimal? GetMaxofthreeAortaValues(AAATestResult testResult)
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

    }
}