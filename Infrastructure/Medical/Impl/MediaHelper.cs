using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using WebSupergoo.ABCpdf10;
using File = System.IO.File;
using System.Drawing;
using System.Drawing.Imaging;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MediaHelper : IMediaHelper
    {
        private readonly IPdftoImageConverter _pdfToImageConverter;
        private readonly ISvgToImageConverter _svgToImageConverter;
        private readonly ILogger _logger;
        private readonly ISettings _settings;
        public MediaHelper(ILogger logger)
        {
            _pdfToImageConverter = new PdftoImageConverter();
            _svgToImageConverter = new SvgToImageConverter();
            _logger = logger;
            _settings = new Settings();
        }

        public MediaHelper(IPdftoImageConverter pdftoImageConverter, ISvgToImageConverter svgToImageConverter, ILogManager logManager, ISettings settings)
        {
            _pdfToImageConverter = pdftoImageConverter;
            _svgToImageConverter = svgToImageConverter;
            _logger = logManager.GetLogger("Media Helper");
            _settings = settings;
        }

        private string ConvertJpgAsPdf(string imageFile, string testNamePrefix, string folderLocationToSaveFile)
        {
            using (var doc = new Doc())
            {
                var pdfName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
                var filePath = folderLocationToSaveFile + pdfName;
                doc.AddImageFile(imageFile);
                doc.Save(filePath);

                return pdfName;
            }
        }

        public ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, bool hideSections = false, List<RectangleDimesion> rectangles = null, List<RectangleDimesion> highQualityRectangles = null, bool convertImageBackToPdf = false)
        {

            var imageName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".jpg";
            var thumbnailImageName = "Thumb_" + imageName;
            var filePath = folderLocationToSaveFile + imageName;

            var imageConverted = !rectangles.IsNullOrEmpty() ? _pdfToImageConverter.ConvertToImage(pdfFilePath, filePath, _logger, hideSections, rectangles, highQualityRectangles) : _pdfToImageConverter.ConvertToImage(pdfFilePath, filePath, _logger, hideSections);

            if (!imageConverted) return null;
            _logger.Info("Convert back to pdf : " + convertImageBackToPdf);
            if (convertImageBackToPdf)
            {

                var pdfName = ConvertJpgAsPdf(filePath, testNamePrefix, Directory.GetParent(folderLocationToSaveFile).FullName);

                _logger.Info("pdf file name : " + pdfName);
                return new ResultMedia
                {
                    File = new Core.Application.Domain.File
                    {
                        Path = pdfName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Pdf,
                        FileSize = new FileInfo(filePath).Length
                    }
                };
            }
            CreateThumbnailImage(filePath, folderLocationToSaveFile + thumbnailImageName);
            return new ResultMedia
                       {
                           File =
                               new Core.Application.Domain.File
                                   {
                                       Path = imageName,
                                       UploadedOn = DateTime.Now,
                                       Type = FileType.Image,
                                       FileSize = new FileInfo(filePath).Length
                                   },
                           Thumbnail =
                               new Core.Application.Domain.File
                                   {
                                       Path = thumbnailImageName,
                                       UploadedOn = DateTime.Now,
                                       Type = FileType.Image,
                                       FileSize = new FileInfo(folderLocationToSaveFile + thumbnailImageName).Length
                                   }
                       };

        }

        public ResultMedia GetMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, TestType test, bool hideSections = false)
        {
            var imageName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".jpg";
            var thumbnailImageName = "Thumb_" + imageName;
            var filePath = folderLocationToSaveFile + imageName;
            bool imageConverted = false;

            if (hideSections && test == TestType.QuantaFloABI)
            {
                var rectangles = new List<RectangleDimesion>
                                         {
                                              new RectangleDimesion(2200, 630, 870, 88)
                                         };
                imageConverted = _pdfToImageConverter.ConvertToImage(pdfFilePath, filePath, _logger, hideSections, rectangles);
            }
            else
            {
                imageConverted = _pdfToImageConverter.ConvertToImage(pdfFilePath, filePath, _logger, hideSections);
            }



            if (!imageConverted) return null;

            CreateThumbnailImage(filePath, folderLocationToSaveFile + thumbnailImageName);

            return new ResultMedia
            {
                File =
                    new Core.Application.Domain.File
                    {
                        Path = imageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Image,
                        FileSize = new FileInfo(filePath).Length
                    },
                Thumbnail =
                    new Core.Application.Domain.File
                    {
                        Path = thumbnailImageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Image,
                        FileSize = new FileInfo(folderLocationToSaveFile + thumbnailImageName).Length
                    }
            };

        }

        public IEnumerable<ResultMedia> GetMediaforTest(string path, string mediaLocation, string testNamePrefix, out bool isExceptionCaused)
        {
            var media = new List<ResultMedia>();
            isExceptionCaused = false;

            int index = 1;
            foreach (var filePath in Directory.GetFiles(path))
            {
                try
                {
                    var file = GetforImagefilePath(filePath);

                    if (file.Extension.ToLower().Contains(".jpg") || file.Extension.ToLower().Contains(".jpeg") ||
                        file.Extension.ToLower().Contains(".bmp") || file.Extension.ToLower().Contains(".png"))
                    {
                        media.Add(GetfromImageFile(file, testNamePrefix, mediaLocation));
                    }
                    else if (file.Extension.ToLower().Contains(".avi") || file.Extension.ToLower().Contains(".flv"))
                    {
                        //var videoName = testNamePrefix + "_" + Guid.NewGuid() + "(" + index + ").flv";
                        var videoName = testNamePrefix + "_" + Guid.NewGuid() + "(" + index + ").mp4";

                        var result = SaveVideo(filePath, videoName, mediaLocation);
                        if (!result) continue;

                        index++;
                        if (file.Extension.ToLower().Contains(".flv"))
                            file.MoveTo(mediaLocation + videoName);

                        var resultMedia = new ResultMedia
                                              {
                                                  File =
                                                      new Core.Application.Domain.File
                                                          {
                                                              FileSize = file.Length,
                                                              Path = videoName,
                                                              UploadedOn = DateTime.Now,
                                                              Type = FileType.Video
                                                          },
                                                  Thumbnail = null
                                              };

                        media.Add(resultMedia);
                    }
                }
                catch (Exception ex)
                {
                    isExceptionCaused = true;
                    _logger.Error("\n Media Extraction Failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
                }
            }
            return media;
        }

        public IEnumerable<ResultMedia> GetSvgImages(string directoryPath, string testNamePrefix, string mediaLocation)
        {
            var svgFiles = Directory.GetFiles(directoryPath, "*.svg");
            if (svgFiles.Length < 1) return null;

            var mediaCollection = new List<ResultMedia>();
            foreach (var svgFile in svgFiles)
            {
                var imageFile = _svgToImageConverter.GenerateImage(svgFile);

                if (string.IsNullOrEmpty(imageFile) || !File.Exists(imageFile))
                {
                    _logger.Info(string.Format("Image File not generated for svg {0}", svgFile));
                    continue;
                }

                mediaCollection.Add(GetfromImageFile(new FileInfo(imageFile), testNamePrefix, mediaLocation));
            }

            return mediaCollection;
        }

        public ResultMedia GetfromImageFile(FileInfo file, string testNamePrefix, string mediaLocation, bool hideSections = false)
        {
            var imageName = testNamePrefix + "_" + Guid.NewGuid() + file.Extension;
            var fileLength = file.Length;

            if (hideSections)
            {
                var rectangles = new List<RectangleDimesion>
                                     {
                                         new RectangleDimesion(60, 110, 1100, 240)
                                     };
                _pdfToImageConverter.HideEcgFinding(file.FullName, (mediaLocation + imageName), _logger, rectangles);
            }
            else
            {
                file.MoveTo(mediaLocation + imageName);
            }

            var thumbnailImageName = "Thumb_" + imageName;
            CreateThumbnailImage(mediaLocation + imageName, mediaLocation + thumbnailImageName);
            decimal thumbnailFileLength = new FileInfo(mediaLocation + thumbnailImageName).Length;

            return new ResultMedia
            {
                File = new Core.Application.Domain.File
                {
                    FileSize = fileLength,
                    Path = imageName,
                    UploadedOn = DateTime.Now,
                    Type = FileType.Image
                },
                Thumbnail =
                    new Core.Application.Domain.File
                    {
                        FileSize = thumbnailFileLength,
                        Path = thumbnailImageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Image
                    }
            };
        }

        public void CreateThumbnailImage(string imageFileName, string thumbnailImageFileName)
        {
            using (var image = Image.FromFile(imageFileName))
            {
                //Image thumbnailImage = image.GetThumbnailImage(64, 64, ThumbnailCallback, IntPtr.Zero);

                //if (!File.Exists(thumbnailImageFileName))
                //    thumbnailImage.Save(thumbnailImageFileName);

                using (var thumbnailImage = image.GetThumbnailImage(64, 64, ThumbnailCallback, IntPtr.Zero))
                {
                    if (!File.Exists(thumbnailImageFileName))
                        thumbnailImage.Save(thumbnailImageFileName);
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        private bool SaveVideo(string filePath, string toSaveFileName, string mediaLocation)
        {
            IMovieMaker moviewMaker = new MovieMaker(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, _logger);
            var movieFile = new FileInfo(filePath);
            if (movieFile.Extension.ToLower().Contains(".flv"))
            {
                moviewMaker.GenerateMPEGWithoutRedis(filePath, mediaLocation + "\\", Path.GetFileNameWithoutExtension(filePath));
                return true;
            }

            try
            {
                var videoFilePath = moviewMaker.GenerateMoviefromAviWithoutRedis(filePath, mediaLocation + "\\", Path.GetFileNameWithoutExtension(toSaveFileName));
                moviewMaker.GenerateMPEGWithoutRedis(mediaLocation + "\\" + videoFilePath, mediaLocation + "\\", Path.GetFileNameWithoutExtension(toSaveFileName));
                return true;
            }
            catch (Exception ex)
            {
                _logger.Info("Video File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                return false;
            }
        }

        private FileInfo GetforImagefilePath(string imageFilePath)
        {
            if (Path.GetExtension(imageFilePath).ToLower().Contains(".bmp"))
            {
                return new FileInfo(this.ConvertBmptoJpeg(imageFilePath));
            }

            return new FileInfo(imageFilePath);
        }

        public string ConvertBmptoJpeg(string imageFilePath)
        {
            using (var imageFileBmp = Image.FromFile(imageFilePath))
            {
                var imageFileJpeg = Path.GetDirectoryName(imageFilePath) + "\\" + Path.GetFileNameWithoutExtension(imageFilePath) + ".jpeg";
                imageFileBmp.Save(imageFileJpeg, ImageFormat.Jpeg);
                return imageFileJpeg;
            }
        }

        public ResultMedia GetResultMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, ILogger logger = null)
        {
            var imageName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
            var filePath = folderLocationToSaveFile + imageName;

            if (logger != null)
            {
                logger.Info("Inside Media Helper Destination : " + filePath);
                logger.Info("Inside Media Helper Source: " + pdfFilePath);
            }
            File.Copy(pdfFilePath, filePath);
            return new ResultMedia
            {
                File =
                    new Core.Application.Domain.File
                    {
                        Path = imageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Pdf,
                        FileSize = new FileInfo(filePath).Length
                    }
            };
        }

        public IEnumerable<ResultMedia> GetMediaSortedByDecimalValue(string path, string mediaLocation, string testNamePrefix, out bool isExceptionCaused)
        {
            var media = new List<ResultMedia>();
            isExceptionCaused = false;
            try
            {
                var orderedFileInfo = GetMediaPathInSortedOrder(path);
                if (orderedFileInfo == null || !orderedFileInfo.Any()) return media;

                var index = 0;

                foreach (var fileInfoPair in orderedFileInfo)
                {
                    var filePath = fileInfoPair.SecondValue.FullName;
                    try
                    {
                        var file = GetforImagefilePath(filePath);

                        if (file.Extension.ToLower().Contains(".jpg") || file.Extension.ToLower().Contains(".jpeg") ||
                            file.Extension.ToLower().Contains(".bmp") || file.Extension.ToLower().Contains(".png"))
                        {
                            media.Add(GetfromImageFile(file, testNamePrefix, mediaLocation));
                        }
                        else if (file.Extension.ToLower().Contains(".avi") || file.Extension.ToLower().Contains(".flv"))
                        {
                            //var videoName = testNamePrefix + "_" + Guid.NewGuid() + "(" + index + ").flv";
                            var videoName = testNamePrefix + "_" + Guid.NewGuid() + "(" + index + ").mp4";

                            var result = SaveVideo(filePath, videoName, mediaLocation);
                            if (!result) continue;

                            index++;
                            if (file.Extension.ToLower().Contains(".flv"))
                                file.MoveTo(mediaLocation + videoName);

                            var resultMedia = new ResultMedia
                            {
                                File =
                                    new Core.Application.Domain.File
                                    {
                                        FileSize = file.Length,
                                        Path = videoName,
                                        UploadedOn = DateTime.Now,
                                        Type = FileType.Video
                                    },
                                Thumbnail = null
                            };

                            media.Add(resultMedia);
                        }
                    }
                    catch (Exception ex)
                    {
                        isExceptionCaused = true;
                        _logger.Error("\n Media Extraction Failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                isExceptionCaused = true;
                _logger.Error("\n Media Extraction Failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return media;
        }

        private IEnumerable<OrderedPair<long, FileInfo>> GetMediaPathInSortedOrder(string path)
        {
            if (!Directory.Exists(path)) return null;

            var directoryInfo = new DirectoryInfo(path);
            string[] exclusdefiles = { "measure.xml", "report.pdf" };

            var fileNameWithExtions = directoryInfo.GetFiles().Where(x => !exclusdefiles.Contains(x.Name.ToLower()));

            var orderedFile = new List<OrderedPair<long, FileInfo>>();

            foreach (var filePath in fileNameWithExtions)
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath.FullName);

                var namePartAferDecimalPart = fileNameWithoutExtension.Split('.').Last();
                long fileNumer = 0;
                long.TryParse(namePartAferDecimalPart, out fileNumer);

                orderedFile.Add(new OrderedPair<long, FileInfo>(fileNumer, filePath));
            }
            orderedFile = orderedFile.OrderBy(x => x.FirstValue).ToList();
            return orderedFile;
        }

        public bool ConvertPdfFromImage(string imageFilePath, string pdfPath)
        {

            using (var doc = new Doc())
            {
                doc.AddImageFile(imageFilePath);
                doc.Save(pdfPath);
                return true;
            }

        }

        public ResultMedia GetOnlyHighMediaFromPdfFile(string pdfFilePath, string folderLocationToSaveFile, string testNamePrefix, bool hideSections = false, List<RectangleDimesion> rectangles = null, bool convertImageBackToPdf = false)
        {

            var imageName = testNamePrefix + "_" + DateTime.Now.ToFileTimeUtc() + ".jpg";
            var thumbnailImageName = "Thumb_" + imageName;

            var filePath = Path.Combine(folderLocationToSaveFile, imageName);

            var imageConverted = _pdfToImageConverter.ConvertToHighQualityImage(pdfFilePath, filePath, _logger, hideSections, rectangles);

            if (!imageConverted) return null;
            _logger.Info("Convert back to pdf : " + convertImageBackToPdf);

            if (convertImageBackToPdf)
            {
                var pdfName = ConvertJpgAsPdf(filePath, testNamePrefix, folderLocationToSaveFile);
                _logger.Info("pdf file name : " + pdfName);
                return new ResultMedia
                {
                    File = new Core.Application.Domain.File
                    {
                        Path = pdfName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Pdf,
                        FileSize = new FileInfo(filePath).Length
                    }
                };
            }
            CreateThumbnailImage(filePath, folderLocationToSaveFile + thumbnailImageName);
            return new ResultMedia
            {
                File =
                    new Core.Application.Domain.File
                    {
                        Path = imageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Image,
                        FileSize = new FileInfo(filePath).Length
                    },
                Thumbnail =
                    new Core.Application.Domain.File
                    {
                        Path = thumbnailImageName,
                        UploadedOn = DateTime.Now,
                        Type = FileType.Image,
                        FileSize = new FileInfo(folderLocationToSaveFile + thumbnailImageName).Length
                    }
            };

        }

    }
}