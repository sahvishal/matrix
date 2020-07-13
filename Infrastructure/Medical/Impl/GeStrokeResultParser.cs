using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public class GeStrokeResultParser : IGeTestParser
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<string> _pathToMediaFolder;
        private readonly string _mediaLocation; 
        private readonly IMovieMaker _movieMaker;

        private const string ColumnForValue = "ResultValue";
        private const string ColumnForFieldName = "ParameterName";
        private const string ColumnForFieldNameSupport = "ResultIdentifier";
        private const string ColumnForBodySide = "Qualifier";
        private const string ColumnForDisplayUnit = "DisplayUnit";

        private const string FieldValueForMeasurement = "Measurement";
        private const string FieldValueforBodySideLeft = "Side=Lt";
        private const string FieldValueforBodySideRight = "Side=Rt";
        private const string FieldValueforPsv = "ICA PS";
        private const string FieldValueforEdv = "ICA ED";
        private const string FieldValueforDisplayUnit = "cm/s";

        private string _errorSummary;
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public GeStrokeResultParser(IEnumerable<string> pathToMediaFolder, string mediaLocation, ILogger logger)
        {
            _errorSummary = string.Empty;
            _logger = logger;
            _pathToMediaFolder = pathToMediaFolder;
            _mediaLocation = mediaLocation;
            _movieMaker = new MovieMaker(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, _logger);
        }

        public bool CheckifDatatableisValidfortheTestType(DataTable dtSourceFromExcel)
        {
            if (!(dtSourceFromExcel.Columns.Contains(ColumnForValue) && dtSourceFromExcel.Columns.Contains(ColumnForFieldName) && dtSourceFromExcel.Columns.Contains(ColumnForFieldNameSupport)
                 && dtSourceFromExcel.Columns.Contains(ColumnForBodySide) && dtSourceFromExcel.Columns.Contains(ColumnForDisplayUnit)))
            {
                _logger.Info(string.Format("\n\tOne or more, among the requried columns [{0}, {1}, {2}, {3}, {4}] is missing.", ColumnForValue, ColumnForFieldName, ColumnForFieldNameSupport, ColumnForBodySide, ColumnForDisplayUnit));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForValue + " is not null and LEN(" + ColumnForValue + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1)
            {
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

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForBodySide + " is not null and LEN(" + ColumnForBodySide + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1)
            {
                _logger.Info(string.Format("\n\tNo valid value found in column [{0}].", ColumnForBodySide));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = ColumnForDisplayUnit + " is not null and LEN(" + ColumnForDisplayUnit + ") > 0";
            if (dtSourceFromExcel.DefaultView.Count < 1)
            {
                _logger.Info(string.Format("\n\tNo valid value found in column [{0}].", ColumnForDisplayUnit));
                return false;
            }

            dtSourceFromExcel.DefaultView.RowFilter = string.Format("({0} like '%{1}%' Or {0} like '%{2}%') and {3} like '%{4}%' and ({5} like '%{6}%' Or {5} like '%{7}%')", ColumnForFieldName, FieldValueforPsv, FieldValueforEdv, ColumnForDisplayUnit, FieldValueforDisplayUnit, ColumnForBodySide, FieldValueforBodySideLeft, FieldValueforBodySideRight);
            if (dtSourceFromExcel.DefaultView.Count < 1) return false;

            return true;
        }

        public TestResult Parse(DataTable dtSourceFromExcel)
        {
            var testResult = new StrokeTestResult();

            if (dtSourceFromExcel != null)
            {
                if (CheckifDatatableisValidfortheTestType(dtSourceFromExcel))
                {
                    testResult.LeftResultReadings = GetStrokeResultReadings(dtSourceFromExcel, FieldValueforBodySideLeft);
                    testResult.RightResultReadings = GetStrokeResultReadings(dtSourceFromExcel,
                                                                             FieldValueforBodySideRight);

                    if (testResult.LeftResultReadings != null)
                    {
                        if (testResult.LeftResultReadings.ICAEDV != null)
                            testResult.LeftResultReadings.ICAEDV.Label = ReadingLabels.LICAEDV;

                        if (testResult.LeftResultReadings.ICAPSV != null)
                            testResult.LeftResultReadings.ICAPSV.Label = ReadingLabels.LICAPSV;
                    }

                    if (testResult.RightResultReadings != null)
                    {
                        if (testResult.RightResultReadings.ICAEDV != null)
                            testResult.RightResultReadings.ICAEDV.Label = ReadingLabels.RICAEDV;

                        if (testResult.RightResultReadings.ICAPSV != null)
                            testResult.RightResultReadings.ICAPSV.Label = ReadingLabels.RICAPSV;
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

            if (testResult.LeftResultReadings == null && testResult.RightResultReadings == null && testResult.ResultImages.Count() < 1)
                return null;

            return testResult;
        }

        public IEnumerable<ResultMedia> GetMediaforTest(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            _logger.Info("\nMedia Path: " + path);
            var media = new List<ResultMedia>();
            var fileName = "Stroke_" + Guid.NewGuid() + "(1)";
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

        private StrokeTestReadings GetStrokeResultReadings(DataTable dtSourceFromExcel, string sideValue)
        {
            var strokeResultReadings = new StrokeTestReadings();

            var value = GetFieldValue(dtSourceFromExcel, sideValue, FieldValueforPsv);
            if (value != null) strokeResultReadings.ICAPSV = value;

            value = GetFieldValue(dtSourceFromExcel, sideValue, FieldValueforEdv);
            if (value != null) strokeResultReadings.ICAEDV = value;

            if (strokeResultReadings.ICAEDV == null && strokeResultReadings.ICAPSV == null) return null;
            return strokeResultReadings;
        }

        private ResultReading<decimal?> GetFieldValue(DataTable dtSourceFromExcel, string sideValue, string valueForVelType)
        {
            try
            {
                dtSourceFromExcel.DefaultView.RowFilter = string.Format("{0} like '%{1}%' and {2} like '%{3}%' and {4} like '%{5}%' and {6} is not null and {7} like '%{8}%'", ColumnForFieldName, valueForVelType, ColumnForDisplayUnit, FieldValueforDisplayUnit, ColumnForBodySide, sideValue, ColumnForValue, ColumnForFieldNameSupport, FieldValueForMeasurement);
                
                dtSourceFromExcel.DefaultView.Sort = ColumnForFieldNameSupport + " desc";

                if (dtSourceFromExcel.DefaultView.Count > 0)
                {
                    decimal s;
                    string value = dtSourceFromExcel.DefaultView[0][ColumnForValue].ToString();
                    if (decimal.TryParse(value, out s))
                    {
                        return new ResultReading<decimal?>
                        {
                            ReadingSource = ReadingSource.Automatic,
                            Reading = Decimal.Round(s, 2)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data Extraction failed for " + sideValue == FieldValueforBodySideLeft ? "Left" : "Right" + " ICA " + valueForVelType == FieldValueforPsv ? "PSV" : "EDV" + ". ";
                _logger.Error("\n Data Extraction failed for " + sideValue == FieldValueforBodySideLeft ? "Left" : "Right" + " ICA " + valueForVelType == FieldValueforEdv ? "PSV" : "EDV" + "! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return null;
        }
    }
}