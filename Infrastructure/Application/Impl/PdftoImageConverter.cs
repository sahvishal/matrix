using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using WebSupergoo.ABCpdf10;


namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation(Interface = typeof(IPdftoImageConverter))]
    public class PdftoImageConverter : IPdftoImageConverter
    {
        private Settings _settings;
        public PdftoImageConverter()
        {
            _settings = new Settings();
        }
        public bool ConvertToImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection)
        {
            if (pdfPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;
            if (toSaveImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;


            if (File.Exists(pdfPath))
            {
                var doc = new Doc();
                string tempSavePath = hideSection ? Directory.GetParent(toSaveImagePath).FullName + "\\temp.jpg" : toSaveImagePath;

                try
                {
                    doc.Read(pdfPath);
                    doc.PageNumber = 1;
                    doc.Rendering.Save(tempSavePath);

                }
                catch (Exception ex)
                {
                    logger.Error("System Failure! File could not be generated. Message: " + ex.Message + " \n\t " + ex.StackTrace);
                    return false;
                }
                finally
                {
                    doc.ClearCachedDecompressedStreams();
                    doc.Clear();
                    doc.Dispose();
                }

                List<RectangleDimesion> higeQualityrectangles = null;
                //if (hideSection)
                //{
                    
                //    HideEcgFinding(tempSavePath, toSaveImagePath, logger, rectangles); // normal

                //    higeQualityrectangles = new List<RectangleDimesion>
                //                         {
                //                             new RectangleDimesion(390, 15, 325, 100),
                //                             new RectangleDimesion(10, 15, 175, 100)
                //                         };

                //}

                var imageName = _settings.HighImageQuality + Path.GetFileName(toSaveImagePath);

                var directoryToSave = Directory.GetParent(toSaveImagePath).FullName;
                var highQualityImage = Path.Combine(directoryToSave, imageName);

                ConvertToHighQualityImage(pdfPath, highQualityImage, logger, hideSection, higeQualityrectangles);

                return true;
            }

            return false;
        }

        public bool ConvertToImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles, List<RectangleDimesion> highQualityRectangles = null)
        {

            if (pdfPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;
            if (toSaveImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;

            if (File.Exists(pdfPath))
            {
                var doc = new Doc();
                string tempSavePath = hideSection ? Directory.GetParent(toSaveImagePath).FullName + "\\temp.jpg" : toSaveImagePath;

                try
                {
                    doc.Read(pdfPath);
                    doc.PageNumber = 1;
                    doc.Rendering.Save(tempSavePath);

                }
                catch (Exception ex)
                {
                    logger.Error("System Failure! File could not be generated. Message: " + ex.Message + " \n\t " +
                                 ex.StackTrace);
                    return false;
                }
                finally
                {
                    doc.ClearCachedDecompressedStreams();
                    doc.Clear();
                    doc.Dispose();
                }

                if (hideSection)
                {
                    HideEcgFinding(tempSavePath, toSaveImagePath, logger, rectangles);
                }

                var imageName = _settings.HighImageQuality + Path.GetFileName(toSaveImagePath);

                var directoryToSave = Directory.GetParent(toSaveImagePath).FullName;
                var highQualityImage = Path.Combine(directoryToSave, imageName);

                ConvertToHighQualityImage(pdfPath, highQualityImage, logger, hideSection, highQualityRectangles);

                return true;
            }
            return false;
        }

        public void HideEcgFinding(string fromImagePath, string toSaveImagePath, ILogger logger, IEnumerable<RectangleDimesion> rectangles)
        {
            if (fromImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (toSaveImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            var image = new Bitmap(fromImagePath);
            Graphics graphics = Graphics.FromImage(image);

            try
            {
                if (rectangles != null && rectangles.Count() > 0)
                {
                    foreach (var rectangleDimesion in rectangles)
                    {
                        graphics.FillRectangle(Brushes.White, rectangleDimesion.PositionX, rectangleDimesion.PositionY, rectangleDimesion.Width, rectangleDimesion.Heigth);
                    }
                }
               
                image.Save(toSaveImagePath);

            }
            catch (Exception ex)
            {
                logger.Error("System Failure! Unable to hide ECG findings. Message: " + ex.Message + " \n\t " +
                             ex.StackTrace);
            }
            finally
            {
                image.Dispose();
                graphics.Dispose();
                DirectoryOperationsHelper.Delete(fromImagePath);
            }
        }

        private string ConvertJpgAsPdf(string imageFile, string testNamePrefix, string folderLocationToSaveFile)
        {
            using (var doc = new WebSupergoo.ABCpdf10.Doc())
            {
                var pdfName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                var filePath = folderLocationToSaveFile + pdfName;
                doc.AddImageFile(imageFile);
                doc.Save(filePath);

                return pdfName;
            }
        }

        //public string HideSectionFromPdf(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles, string testNamePrefix)
        //{
        //    if (pdfPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
        //        return string.Empty;
        //    if (toSaveImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
        //        return string.Empty;


        //    if (File.Exists(pdfPath))
        //    {
        //        var doc = new Doc();
        //        string tempSavePath = hideSection ? Directory.GetParent(toSaveImagePath).FullName + "\\temp.jpg" : toSaveImagePath;

        //        try
        //        {
        //            doc.Read(pdfPath);
        //            doc.PageNumber = 1;
        //            doc.Rendering.Save(tempSavePath);

        //        }
        //        catch (Exception ex)
        //        {
        //            logger.Error("System Failure! File could not be generated. Message: " + ex.Message + " \n\t " +
        //                         ex.StackTrace);
        //            return string.Empty;
        //        }
        //        finally
        //        {
        //            doc.ClearCachedDecompressedStreams();
        //            doc.Clear();
        //            doc.Dispose();
        //        }

        //        if (hideSection)
        //        {
        //            HideEcgFinding(tempSavePath, toSaveImagePath, logger, rectangles);
        //        }

        //        return ConvertJpgAsPdf(toSaveImagePath, testNamePrefix, Directory.GetParent(toSaveImagePath).FullName + "\\");

        //    }
        //    return string.Empty;
        //}

        public bool ConvertToHighQualityImage(string pdfPath, string toSaveImagePath, ILogger logger, bool hideSection, List<RectangleDimesion> rectangles)
        {

            if (pdfPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;
            if (toSaveImagePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;

            if (File.Exists(pdfPath))
            {
                var doc = new Doc();
                string tempSavePath = hideSection ? Directory.GetParent(toSaveImagePath).FullName + "\\temp.jpg" : toSaveImagePath;

                try
                {
                    doc.Read(pdfPath);
                    doc.PageNumber = 1;
                    doc.Rendering.SaveQuality = 100;
                    doc.Rendering.DotsPerInch = 400;

                    doc.Rendering.Save(tempSavePath);

                }
                catch (Exception ex)
                {
                    logger.Error("System Failure! File could not be generated. Message: " + ex.Message + " \n\t " +
                                 ex.StackTrace);
                    return false;
                }
                finally
                {
                    doc.ClearCachedDecompressedStreams();
                    doc.Clear();
                    doc.Dispose();
                }

                if (hideSection)
                {
                    HideEcgFinding(tempSavePath, toSaveImagePath, logger, rectangles);
                }

                return true;
            }
            return false;
        }
    }

}

