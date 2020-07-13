using System.Collections.Generic;
using System.IO;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Application
{
    public interface IMediaHelper
    {
        IEnumerable<ResultMedia> GetMediaforTest(string path, string mediaLocation, string testNamePrefix, out bool isExceptionCaused);
        ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNameString, bool hideSections = false, List<RectangleDimesion> rectangles = null, List<RectangleDimesion> highQualityRectangles = null, bool convertImageBackToPdf = false);
        //ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNameString, TestType test, bool hideSections = false);
        ResultMedia GetfromImageFile(FileInfo file, string testNamePrefix, string mediaLocation, bool hideSections = false);
        IEnumerable<ResultMedia> GetSvgImages(string directoryPath, string testNamePrefix, string mediaLocation);
        string ConvertBmptoJpeg(string imageFilePath);
        void CreateThumbnailImage(string imageFileName, string thumbnailImageFileName);
        bool ThumbnailCallback();
        ResultMedia GetResultMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, ILogger logger = null);

        IEnumerable<ResultMedia> GetMediaSortedByDecimalValue(string path, string mediaLocation, string testNamePrefix, out bool isExceptionCaused);
        bool ConvertPdfFromImage(string imageFilePath, string pdfPath);
        ResultMedia GetOnlyHighMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, bool hideSections = false, List<RectangleDimesion> rectangles = null, bool convertImageBackToPdf = false);
    }
}