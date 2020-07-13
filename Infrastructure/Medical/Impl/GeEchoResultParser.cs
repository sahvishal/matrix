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
using Falcon.App.Infrastructure.Application.Impl;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class GeEchoResultParser : IGeTestParser
    {
        private readonly ILogger _logger;
        private readonly IEnumerable<string> _pathToMediaFolder;
        private readonly string _mediaLocation;
        private readonly IMovieMaker _movieMaker;

        private string _errorSummary;
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        public GeEchoResultParser(IEnumerable<string> pathToMediaFolder, string mediaLocation, ILogger logger)
        {
            _errorSummary = string.Empty;
            _logger = logger;
            _pathToMediaFolder = pathToMediaFolder;
            _mediaLocation = mediaLocation;
            _movieMaker = new MovieMaker(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, _logger);
        }

        public TestResult Parse(DataTable dtSourceFromExcel)
        {
            var testResult = new EchocardiogramTestResult();

            testResult.Media = new List<ResultMedia>();
            foreach (var path in _pathToMediaFolder)
            {
                var media = GetMediaforTest(path);
                if (media != null)
                    testResult.Media.AddRange(media);
            }

            if(testResult.Media.Count < 1) return null;

            return testResult;
        }

        public bool CheckifDatatableisValidfortheTestType(DataTable dtSourceFromExcel)
        {
            return true;
        }

        public IEnumerable<ResultMedia> GetMediaforTest(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;
            _logger.Info("\nMedia Path: " + path);
            var media = new List<ResultMedia>();
            var fileName = "Echo_" + Guid.NewGuid() + "(1)";
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
                                                  new Core.Application.Domain.File
                                                      {
                                                          FileSize = file.Length,
                                                          Path = mp4File,//fileName,
                                                          UploadedOn = DateTime.Now,
                                                          Type = FileType.Video
                                                      }
                                          };
                    media.Add(resultMedia);
                }
                else if(counter > 0)
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
                            new Core.Application.Domain.File
                            {
                                FileSize = file.Length,
                                Path = imageName,
                                UploadedOn = DateTime.Now,
                                Type = FileType.Image
                            },
                        Thumbnail =
                            new Core.Application.Domain.File
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
            //if (!File.Exists(thumbnailimagefilepath))
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
                    if (!File.Exists(thumbnailimagefilepath))
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

    }
}