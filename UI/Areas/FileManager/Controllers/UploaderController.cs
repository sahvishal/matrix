using System;
using System.IO;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.FileManager.Controllers
{
    [RoleBasedAuthorize]
    public class UploaderController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IMediaRepository _mediaRepository;
        public UploaderController(ISessionContext sessionContext, IMediaRepository mediaRepository)
        {
            _sessionContext = sessionContext;
            _mediaRepository = mediaRepository;
        }
        //
        // GET: /FileManager/Uploader/

        public ActionResult Index()
        {
            try
            {
                var file = RetrieveFileFromRequest();
                return Json(new
                {
                    success = true,
                    file.Caption,
                    file.Url,
                    file.FolderPath,
                    file.FileName,
                    file.Id,
                    file.FileSize,
                    file.IsTemporaryLocated,
                    file.FileType,
                    file.UploadedBy,
                    file.PhisicalPath
                }, "text/html");
            }
            catch (Exception)
            {
                return Json(new { success = false }, "text/html");
            }
        }

        public ActionResult FileHolder(string prefix, string fileTypeExtention = null)
        {
            ViewData.TemplateInfo = new TemplateInfo
            {
                HtmlFieldPrefix = prefix
            };
            ViewData["fileTypeExtention"] = fileTypeExtention;
            var model = new FileModel();

            return PartialView("Index", model);
        }

        [HttpPost]
        public ActionResult FileView(string prefix,string allowedExt, long id = 0, FileModel model = null)
        {
            ViewData.TemplateInfo = new TemplateInfo
            {
                HtmlFieldPrefix = prefix
            };
            ViewData["fileTypeExtention"] = allowedExt;

            if (model != null)
            {
                return PartialView(model);
            }

            //Todo: In case file id is provided.
            return PartialView(new FileModel());
        }
        private FileModel RetrieveFileFromRequest()
        {
            string fileNameWithoutExtension = Guid.NewGuid().ToString();
            var location = _mediaRepository.GetTempMediaFileLocation().PhysicalPath;//_mediaLocation + @"/temp";
            if (location.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidFileNameException();

            var fileModel = new FileModel
            {
                FolderPath = location,
                IsTemporaryLocated = true
            };

            if (!Directory.Exists(location))
            {
                DirectoryOperationsHelper.CreateDirectory(location);
            }

            var req = ControllerContext.HttpContext.Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                fileModel.Caption = Path.GetFileNameWithoutExtension(file.FileName);
                fileModel.FileName = fileNameWithoutExtension + Path.GetExtension(file.FileName);

                fileModel.MimeType = Request.ContentType;
                fileModel.FileSize = file.ContentLength;

                file.SaveAs(location + fileModel.FileName);
            }
            else if (Request.ContentLength > 0)
            {
                var fileName = Request.Headers["X-File-Name"];
                fileModel.Caption = Server.UrlDecode(Path.GetFileNameWithoutExtension(fileName));
                fileModel.FileName = fileNameWithoutExtension + Path.GetExtension(fileName);
                fileModel.MimeType = Request.ContentType;
                fileModel.FileSize = Request.ContentLength;
                var fileContents = new byte[Request.ContentLength];

                Request.InputStream.Seek(0, SeekOrigin.Begin);
                Request.InputStream.Read(fileContents, 0, Request.ContentLength);

                using (var fileStream = new FileStream(location + fileModel.FileName, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(fileContents, 0, fileContents.Length);
                }
            }

            fileModel.Url = _mediaRepository.GetTempMediaFileLocation().Url;
            fileModel.UploadedBy = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            fileModel.PhisicalPath = location;

            return fileModel;
        }
    }
}
