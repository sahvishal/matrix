using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Franchisee.Technician
{
    public partial class UploadKynFile : Page
    {
        protected long EventId { get; set; }
        protected long CustomerId { get; set; }
        public string FileType { get; set; }
        public long TestId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            long s = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out s))
            {
                EventId = s;
            }

            s = 0;
            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out s))
            {
                CustomerId = s;
            }

            if (Request.QueryString["FileType"] != null)
            {
                FileType = Request.QueryString["FileType"].ToLower();
            }
            long testId = 0;
            if (Request.QueryString["TestType"] != null && long.TryParse(Request.QueryString["TestType"], out testId))
            {
                TestId = testId;
            }
        }

        protected void UploadImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (fileUpload.FileName.Trim().Length < 1)
                return;

            if (fileUpload.PostedFile.ContentType != "application/pdf")
            {
                ClientScript.RegisterStartupScript(GetType(), "js_warning", "alert('Please post a PDF file.');", true);
                return;
            }

            if (EventId < 1 || CustomerId < 1)
            {
                return;
            }

            var testType = (TestType)TestId;
            var repository = IoC.Resolve<IMediaRepository>();
            var location = repository.GetKynIntegrationOutputDataLocation(EventId, CustomerId);
            var tempLocation = repository.GetTempMediaFileLocation();

            if (!Directory.Exists(location.PhysicalPath)) Directory.CreateDirectory(location.PhysicalPath);
            else
            {
                var files = Directory.GetFiles(location.PhysicalPath, testType + "*.pdf");
                var filePath = files.SingleOrDefault(f => Path.GetFileName(f).ToLower().Contains(FileType));

                if (!string.IsNullOrEmpty(filePath))
                    File.Move(filePath, tempLocation.PhysicalPath + "Delete_" + DateTime.Now.ToFileTimeUtc() + ".pdf");
            }
            if (FileType == KynFileTypes.LetterWriter || FileType == KynFileTypes.ParticipantSummaryReport || FileType == KynFileTypes.PhysicianSummaryReport || FileType == KynFileTypes.LongitudinalPrompt)
            {
                fileUpload.SaveAs(location.PhysicalPath + KynFileTypes.GetFileName(testType, FileType));
                if(testType==TestType.Kyn)
                ClientScript.RegisterStartupScript(GetType(), "js_parent", "window.opener.setFileUrlforFileType('" + location.Url + KynFileTypes.GetFileName(testType, FileType) + "', '" + FileType + "'); window.close();", true);
                else if(testType==TestType.HKYN)
                    ClientScript.RegisterStartupScript(GetType(), "js_parent", "window.opener.setFileUrlforHkynFileType('" + location.Url + KynFileTypes.GetFileName(testType, FileType) + "', '" + FileType + "'); window.close();", true);
            }

        }
    }
}
