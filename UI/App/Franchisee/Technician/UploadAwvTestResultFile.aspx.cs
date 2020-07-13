using System;
using System.IO;
using System.Web.UI;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Interfaces;
using System.Web.Script.Serialization;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using File = Falcon.App.Core.Application.Domain.File;
using System.Collections.Generic;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class UploadAwvTestResultFile : Page
    {

        public TestType TestType { get; set; }
        public string FileType { get; set; }
        private IMediaHelper _mediaHelper = IoC.Resolve<IMediaHelper>();

        private string GetClintSideSetFileUrl(string fileName, decimal fileSize)
        {
            var clientSideUrl = string.Empty;
            var jsonSerializer = new JavaScriptSerializer();

            //if (TestType.DPN == TestType)
            //{

            //    ClientScript.RegisterStartupScript(Page.GetType(), "js_JsonMediaObject", "var jsonMedia = " + jsonSerializer.Serialize(media) + ";", true);
            //}

            switch (TestType)
            {

                case TestType.AWV:
                    clientSideUrl = "parent.setAwvFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "' ); parent.ClosePopUp();";
                    break;
                case TestType.Medicare:
                    clientSideUrl = "parent.setMedicareFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.AwvSubsequent:
                    clientSideUrl = "parent.setSubsequentFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.eAWV:
                    clientSideUrl = "parent.seteAwvFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.DiabeticRetinopathy:
                    clientSideUrl = "parent.setDiabeticRetinopathyFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.FocAttestation:
                    clientSideUrl = "parent.setFocAttestationFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.Mammogram:
                    clientSideUrl = "parent.setMammogramFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.IFOBT:
                    clientSideUrl = "parent.setIfobtFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.UrineMicroalbumin:
                    clientSideUrl = "parent.setUrineMicroalbuminFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.Chlamydia:
                    clientSideUrl = "parent.setChlamydiaFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.Osteoporosis:
                    clientSideUrl = "parent.setOsteoporosisFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.AwvBoneMass:
                    clientSideUrl = "parent.setAwvBoneMassFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;
                case TestType.QuantaFloABI:
                    clientSideUrl = "parent.setQuantaFloABIFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;

                case TestType.MyBioCheckAssessment:
                    clientSideUrl = "parent.setMyBioCheckFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;

                case TestType.DPN:
                    clientSideUrl = "parent.setDpnFileUrl('" + Path.GetFileName(fileName) + "', '" + fileSize + "'); parent.ClosePopUp();";
                    break;

                //case TestType.DPN:
                //    clientSideUrl = "parent.setDPNFileUrl(jsonMedia, true); parent.ClosePopUp();";
                //    break;
            }

            return clientSideUrl;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "js_InitValues", "setValues();", true);

            long s = 0;
            if (Request.QueryString["TestType"] != null && long.TryParse(Request.QueryString["TestType"], out s))
            {
                TestType = (TestType)s;
            }

            if (!(Request.QueryString["fileType"] == null || string.IsNullOrEmpty(Request.QueryString["FileType"].Trim())))
            {
                FileType = Request.QueryString["fileType"];
            }
        }


        protected void UploadImageButton_Click(object sender, ImageClickEventArgs e)
        {
            var folderName = ImageLocationPrefix.Value;

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            if (fileUpload.FileName.Trim().Length < 1)
                return;

            var fileName = TestType + "_" + (!string.IsNullOrEmpty(FileType) ? FileType + "_" : "") + DateTime.Now.ToFileTimeUtc() + new FileInfo(fileUpload.FileName).Extension;

            var filePath = folderName + fileName;
            decimal fileSize = 0;

            if (!System.IO.File.Exists(filePath))
            {
                fileUpload.SaveAs(filePath);
            }

            if (TestType == TestType.DPN)
            {
                var fileTypeExtension = Path.GetExtension(fileName).ToLower();
                string imageFileName = filePath.ToLower().Replace(".pdf", ".jpg");

                var pdfFileName = string.Empty;
                if (fileTypeExtension.ToLower().Contains("pdf"))
                {
                    var pdfToImageConverter = IoC.Resolve<IPdftoImageConverter>();

                    var highQualityRectangles = new List<RectangleDimesion>
                                         {
                                           new RectangleDimesion(52, 3200, 3200, 1200)
                                         };

                    var resultMedia = _mediaHelper.GetOnlyHighMediaFromPdfFile(filePath, folderName, TestType.DPN.ToString(), true, highQualityRectangles, true);

                    pdfFileName = folderName + resultMedia.File.Path;
                    fileSize = resultMedia.File.FileSize;
                }

                fileName = pdfFileName;
                //var completePdfPath = folderName + pdfFileName;


            }
            else
            {
                var imageFileName = filePath.ToLower();

                fileSize = new FileInfo(imageFileName).Length;
            }

            ClientScript.RegisterStartupScript(typeof(string), "jscode", GetClintSideSetFileUrl(fileName, fileSize), true);
        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        public string CreateThumbnailImage(string filePath, out decimal fileSize)
        {
            var thumbnailFileName = "Thumb_" + Path.GetFileName(filePath);
            string thumbnailimagefilepath = Path.GetDirectoryName(filePath) + "\\" + thumbnailFileName;

            _mediaHelper.CreateThumbnailImage(filePath, thumbnailimagefilepath);

            fileSize = decimal.Round(new FileInfo(thumbnailimagefilepath).Length, 2);
            return thumbnailFileName;
        }
    }
}