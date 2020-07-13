using System;
using System.Web.UI;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class PdfFileUpload : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "js_InitValues", "setValues(); ", true);
        }

        protected void UploadImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string folderName = ImageLocationPrefix.Value;
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            if (fileUpload.FileName.Trim().Length < 1)
                return;

            string fileName = "Ekg_" + DateTime.Now.ToFileTimeUtc() + new FileInfo(fileUpload.FileName).Extension;
            string thumbnailFileName = "Thumb_" + fileName;

            string filePath = folderName + fileName;
            string thumbNailFilePath = folderName + thumbnailFileName;
            if (!File.Exists(filePath))
            {
                fileUpload.SaveAs(filePath);
            }

            string imageFileName = filePath.ToLower().Replace(".pdf", ".jpg");
            string thumbnailImageFileName = thumbNailFilePath.ToLower().Replace(".pdf", ".jpg");

            if (!File.Exists(imageFileName))
            {
                var fileFound = IoC.Resolve<IPdftoImageConverter>().ConvertToImage(filePath, imageFileName, IoC.Resolve<ILogManager>().GetLogger<Global>(), false);
                if (!fileFound)
                {
                    ClientScript.RegisterStartupScript(typeof(string), "jscode", " alert('File could not be upladed!'); parent.ClosePopUp(); ", true);
                }
            }

            decimal fileSize, thumbnailFileSize = 0;
            fileSize = new FileInfo(imageFileName).Length;
            if (!File.Exists(thumbnailImageFileName))
            {
                CreateThumbnailImage(imageFileName, thumbnailImageFileName);
                thumbnailFileSize = new FileInfo(thumbnailImageFileName).Length;
            }


            ClientScript.RegisterStartupScript(typeof(string), "jscode", " parent.SetPdfImageUrl('" + Path.GetFileName(imageFileName) + "', '" + fileSize + "', '" + Path.GetFileName(thumbnailImageFileName) + "', '" + thumbnailFileSize + "'); parent.ClosePopUp(); ", true);

        }

        private void CreateThumbnailImage(string imageFileName, string thumbnailImageFileName)
        {
            //System.Drawing.Image image = System.Drawing.Image.FromFile(imageFileName);
            //System.Drawing.Image thumbnailImage = image.GetThumbnailImage(64, 64, ThumbnailCallback, IntPtr.Zero);

            //if (!File.Exists(thumbnailImageFileName))
            //    thumbnailImage.Save(thumbnailImageFileName);

            using (var image = System.Drawing.Image.FromFile(imageFileName))
            {
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

    }
}
