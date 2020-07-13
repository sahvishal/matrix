using System.Collections.Generic;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Application
{
    public interface IPdftoImageConverter
    {
        bool ConvertToImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection);

        bool ConvertToImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles, List<RectangleDimesion> highQualityRectangles = null);

        void HideEcgFinding(string fromImagePath, string toSaveImagePath, ILogger logger, IEnumerable<RectangleDimesion> rectangles);

        //string HideSectionFromPdf(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles, string testNamePrefix);
        bool ConvertToHighQualityImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles);
    }
}