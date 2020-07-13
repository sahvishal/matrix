using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.IO;
using Falcon.App.Core.Application;
using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using System.Web.Script.Serialization;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.UI;
using File = Falcon.App.Core.Application.Domain.File;

public partial class App_Franchisee_Technician_UploadTestImages : System.Web.UI.Page
{
    private Int16 _numberOfUploaders = 3;

    public string CustomerId { get { return Request.QueryString["CustomerId"]; } }

    ILogger _logger = IoC.Resolve<ILogManager>().GetLogger("Upload Test Media");
    private IMediaHelper _mediaHelper = IoC.Resolve<IMediaHelper>();

    public TestType Test { get { return (TestType)Convert.ToInt32(Request.QueryString["TestType"]); } }
    public bool RestricttoOne
    {
        get
        {
            if (Request.QueryString["RestricttoOne"] == null) return false;
            return Convert.ToBoolean(Request.QueryString["RestricttoOne"]);
        }
    }

    private IEnumerable<ResultMedia> _resultMedia;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RestricttoOne)
            {
                _numberOfUploaders = 1;
            }
            DisplayFileUploaders();
            ClientScript.RegisterStartupScript(Page.GetType(), "js_InitValues", "setValues(); getJsonToDisplay();", true);
        }
    }

    private void ProcessMedia()
    {
        if (!string.IsNullOrEmpty(JsonForImageObject.Value))
        {
            var serializer = new JavaScriptSerializer();
            _resultMedia = serializer.Deserialize<List<ResultMedia>>(JsonForImageObject.Value);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        ProcessMedia();
        List<ResultMedia> resultMedia = _resultMedia != null ? _resultMedia.ToList() : new List<ResultMedia>();

        string foldername = ImageLocationPrefix.Value;
        if (foldername.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            throw new InvalidDirectoryPathException();

        if (!Directory.Exists(foldername))
            Directory.CreateDirectory(foldername);

        int imgnamecounter = 1;
        foreach (GridViewRow gvrfluploader in gvUploadFiles.Rows)
        {
            var objflupload = (FileUpload)gvrfluploader.FindControl("fluploadImage");
            var fileType = GetFileTypefortheContentType(objflupload.PostedFile.ContentType);
            if (objflupload.FileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                continue;
            }
            if (objflupload.FileName.Trim().Length < 1) continue;


            string fileNamewoExt = Test + "_" + DateTime.Now.ToFileTimeUtc() + "_" + imgnamecounter;
            //var movieFileName = fileNamewoExt + ".flv";
            var movieFileName = fileNamewoExt + ".mp4";
            var fileTypeExtension = Path.GetExtension(objflupload.FileName).ToLower();
            string fileName = fileNamewoExt + fileTypeExtension;
            string filePath = foldername + fileName;

            if (filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                continue;


            var settings = IoC.Resolve<ISettings>();

            if (!System.IO.File.Exists(filePath))
            {
                if (Test == TestType.EKG && fileType == FileType.Image && !fileTypeExtension.ToLower().Contains("pdf"))
                {
                    var tempFilePath = foldername + fileNamewoExt + "_" + Guid.NewGuid() + fileTypeExtension;
                    objflupload.SaveAs(tempFilePath);
                    var pdfToImageConverter = IoC.Resolve<IPdftoImageConverter>();
                    /*if (settings.HideEkgSection)
                    {
                        var rectangles = new List<RectangleDimesion>
                                             {
                                                 new RectangleDimesion(0, 230, 1050, 270)
                                             };
                        pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, rectangles);
                    }
                    else
                    {
                        pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, null);
                    }*/

                    pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, null);
                }
                else if (Test == TestType.QuantaFloABI && fileType == FileType.Image && !fileTypeExtension.ToLower().Contains("pdf"))
                {
                    var tempFilePath = foldername + fileNamewoExt + "_" + Guid.NewGuid() + fileTypeExtension;
                    objflupload.SaveAs(tempFilePath);
                    var pdfToImageConverter = IoC.Resolve<IPdftoImageConverter>();
                    /*if (settings.HideQuantaFloAbiSection)
                    {

                        var rectangles = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(410, 116, 150, 15)
                                         };
                        pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, rectangles);
                    }
                    else
                    {
                        pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, null);
                    }*/
                    pdfToImageConverter.HideEcgFinding(tempFilePath, filePath, null, null);
                }
                else
                {
                    objflupload.SaveAs(filePath);

                    if (fileTypeExtension.Contains("svg"))
                    {
                        var imageFilePath = IoC.Resolve<ISvgToImageConverter>().GenerateImage(filePath);
                        if (string.IsNullOrEmpty(imageFilePath) || !System.IO.File.Exists(imageFilePath))
                        {
                            _logger.Info("Svg not converted to Image file.");
                            continue;
                        }
                        filePath = imageFilePath;
                    }
                    else if (fileTypeExtension.Contains("bmp"))
                    {
                        filePath = _mediaHelper.ConvertBmptoJpeg(filePath);
                    }

                    fileName = Path.GetFileName(filePath);
                }
            }

            var fileSize = new FileInfo(filePath).Length;
            decimal thumbnailSize = 0;
            string thumbnailfilename = string.Empty;

            if (fileTypeExtension.ToLower().Contains("pdf"))
            {
                string imageFileName = filePath.ToLower().Replace(".pdf", ".jpg");
                if (Test == TestType.EKG || Test == TestType.AwvEkg || Test == TestType.AwvEkgIPPE)
                {
                    var pdfToImageConverter = IoC.Resolve<IPdftoImageConverter>();
                    //pdfToImageConverter.ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), settings.HideEkgSection);
                    pdfToImageConverter.ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), false);
                }
                else if (Test == TestType.QuantaFloABI)
                {
                    var pdfToImageConverter = IoC.Resolve<IPdftoImageConverter>();
                    /*var rectangles = new List<RectangleDimesion>
                                         {
                                             new RectangleDimesion(410, 116, 150, 15)
                                         };
                    pdfToImageConverter.ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), settings.HideQuantaFloAbiSection, rectangles);*/
                    pdfToImageConverter.ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), false, null, null);
                }
                else
                {
                    var fileFound = IoC.Resolve<IPdftoImageConverter>().ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), false);
                    if (!fileFound)
                    {
                        ClientScript.RegisterStartupScript(typeof(string), "jscode", " alert('File could not be uploded!'); parent.ClosePopUp(); ", true);
                    }
                }
                fileType = FileType.Image;
                fileSize = new FileInfo(imageFileName).Length;
                filePath = imageFileName;
                fileName = fileNamewoExt + ".jpg";
            }

            if (fileType == FileType.Image)
            {
                thumbnailfilename = CreateThumbnailImage(filePath, out thumbnailSize);
            }
            else if (fileType == FileType.Video)
            {
                bool result = SaveVideo(filePath, movieFileName);
                if (!result) continue;
                fileName = movieFileName;
            }

            imgnamecounter++;

            var media = new ResultMedia
            {
                File = new File { Path = fileName, FileSize = fileSize, Type = fileType, UploadedOn = DateTime.Now, UploadedBy = new OrganizationRoleUser(0) },
                Thumbnail = string.IsNullOrEmpty(thumbnailfilename) ? null : new File { Path = thumbnailfilename, Type = FileType.Image, FileSize = thumbnailSize, UploadedOn = DateTime.Now, UploadedBy = new OrganizationRoleUser(0) },
                ReadingSource = ReadingSource.Manual
            };

            if (imgnamecounter == 2 && RestricttoOne)
            {
                resultMedia = new List<ResultMedia>();
            }

            resultMedia.Add(media);
        }

        var jsonSerializer = new JavaScriptSerializer();
        ClientScript.RegisterStartupScript(Page.GetType(), "js_JsonMediaObject", "var jsonMedia = " + jsonSerializer.Serialize(resultMedia) + ";", true);

        if (Test == TestType.AAA)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", " parent.LoadNewImagesAAA(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.Stroke)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesCarotid(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.Lead)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesLead(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.Echocardiogram)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewMediaEcho(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.IMT)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesImt(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.Thyroid)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesThyroid(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.EKG)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesEkg(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.PulmonaryFunction)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesPulmonary(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.Spiro)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesSpiro(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvSpiro)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesAwvSpiro(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.PPAAA)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", " parent.LoadNewImagesPpAAA(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.PPEcho)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewMediaPpEcho(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.HCPAAA)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesHcpAAA(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.HCPCarotid)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesHcpCarotid(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.HCPEcho)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewMediaHcpEcho(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvAAA)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", " parent.LoadNewImagesAwvAaa(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvCarotid)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", " parent.LoadNewImagesAwvCarotid(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvEcho)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewMediaAwvEcho(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvEkgIPPE)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesAwvEkgIppe(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.AwvEkg)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesAwvEkg(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.FloChecABI)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesFloChecABI(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
        else if (Test == TestType.QuantaFloABI)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "parent.LoadNewImagesQuantaFloABI(jsonMedia, true); parent.ClosePopUp(); ", true);
        }
    }

    private bool SaveVideo(string filePath, string toSaveFileName)
    {

        IMovieMaker moviewMaker = new MovieMaker(Server.MapPath("/bin"), _logger);
        var movieFile = new FileInfo(filePath);
        if (movieFile.Extension.ToLower().Contains(".flv"))
        {
            moviewMaker.GenerateMPEG(filePath, movieFile.Directory.FullName + "\\", Path.GetFileNameWithoutExtension(filePath));
            return true;
        }
        try
        {
            var videoFile = moviewMaker.GenerateMoviefromAvi(filePath, movieFile.Directory.FullName + "\\", Path.GetFileNameWithoutExtension(toSaveFileName));
            moviewMaker.GenerateMPEG(movieFile.Directory.FullName + "\\" + videoFile, movieFile.Directory.FullName + "\\", Path.GetFileNameWithoutExtension(toSaveFileName));
            return true;
        }
        catch (Exception ex)
        {
            _logger.Info("Video File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            return false;
        }
    }

    private string CreateThumbnailImage(string filePath, out decimal fileSize)
    {
        var thumbnailFileName = "Thumb_" + Path.GetFileName(filePath);
        string thumbnailimagefilepath = Path.GetDirectoryName(filePath) + "\\" + thumbnailFileName;

        _mediaHelper.CreateThumbnailImage(filePath, thumbnailimagefilepath);

        fileSize = decimal.Round(new FileInfo(thumbnailimagefilepath).Length, 2);
        return thumbnailFileName;
    }

    private static FileType GetFileTypefortheContentType(string contentType)
    {
        switch (contentType.ToLower())
        {
            case "application/mpeg4":
                return FileType.Video;
            case "video/mpeg":
                return FileType.Video;
            case "video/x-ms-wmv":
                return FileType.Video;
            case "video/avi":
                return FileType.Video;
            case "video/quicktime":
                return FileType.Video;
            case "video/mp4":
                return FileType.Video;
            case "image/gif":
                return FileType.Image;
            case "image/jpeg":
                return FileType.Image;
            case "image/png":
                return FileType.Image;
            case "application/octet-stream":
                return FileType.Video;
            default:
                return FileType.Image;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void DisplayFileUploaders()
    {
        DataTable dtfileuploaders = new DataTable();

        dtfileuploaders.Columns.Add("ImagePathString"); // Adding a column 

        for (Int16 counter = 0; counter < _numberOfUploaders; counter++)
        {
            dtfileuploaders.Rows.Add(new object[] { "" });
        }

        gvUploadFiles.DataSource = dtfileuploaders;
        gvUploadFiles.DataBind();

    }

}

