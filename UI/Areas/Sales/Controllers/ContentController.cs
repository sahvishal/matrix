using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Sales.Controllers
{
    [RoleBasedAuthorize]
    public class ContentController : Controller
    {
        private IContentService _contentService;
        private IContentRepository _contentRepository;
        private ISessionContext _sessionContext;
        private ILogger _logger;

        private int _defaultSize;

        public ContentController(IContentService contentService, ISessionContext sessionContext, ISettings settings, ILogManager logManager, IContentRepository contentRepository)
        {
            _contentService = contentService;
            _contentRepository = contentRepository;
            _sessionContext = sessionContext;
            _logger = logManager.GetLogger<Global>();
            _defaultSize = settings.DefaultPageSizeForReports;
        }

        public ActionResult Index(ContentListModelFilter filter = null, int pageNumber = 1)
        {
            if (filter == null)
                filter = new ContentListModelFilter();

            int totalRecords;

            var model = _contentService.GetListModel(filter, pageNumber, _defaultSize, out totalRecords);

            model.PagingModel = new PagingModel(pageNumber, _defaultSize, totalRecords, p => Url.Action("Index", new { filter.Title, filter.Inactive, filter.Active, pageNumber = p }));
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new ContentEditModel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ContentEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model = _contentService.SaveModel(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model = new ContentEditModel
                            {
                                FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Content Saved successfully! Create another.")
                            };

                ModelState.Clear();

                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage(string.Format("System Failure! Message: {0}", ex.Message));
                _logger.Info(string.Format("Create New Content {0}!  Message: {1} \nStackTrace: {2}", model.Title, ex.Message, ex.StackTrace));
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = _contentService.GetModel(id);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ContentEditModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model = _contentService.SaveModel(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Content Saved successfully!");

                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage(string.Format("System Failure! Message: {0}", ex.Message));
                _logger.Info(string.Format("Edit Content {0}!  Message: {1} \nStackTrace: {2}", model.Title, ex.Message, ex.StackTrace));
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Activate(long id)
        {
            try
            {
                _contentRepository.Activate(id, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                return Json(new { Message = "Activated !", IsSuccess = true, RefreshWindow = true });
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Activate Content {0}!  Message: {1} \nStackTrace: {2}", id, ex.Message, ex.StackTrace));
                return Json(new { Message = "System Failure!", IsSuccess = false, RefreshWindow = false });
            }
        }

        [HttpPost]
        public ActionResult Deactivate(long id)
        {
            try
            {
                _contentRepository.Deactivate(id, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                return Json(new { Message = "Deactivated !", IsSuccess = true, RefreshWindow = true });
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Deactivate Content {0}!  Message: {1} \nStackTrace: {2}", id, ex.Message, ex.StackTrace));
                return Json(new { Message = "System Failure!", IsSuccess = false, RefreshWindow = false });
            }
        }

        public ActionResult Preview(long id)
        {
            var content = _contentRepository.Get(id);
            return Json(content.ContentHtml, JsonRequestBehavior.AllowGet);
        }
    }
}
