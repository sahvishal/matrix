using System;
using System.Net;
using System.Web.Mvc;
using Falcon.App.Core.ACL;
using Falcon.App.Core.ACL.ViewModel;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.ACL.Impl;
using Falcon.App.UI.Filters;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.UI.Areas.AccessControl.Controllers
{
    [RoleBasedAuthorize]
    public class ListController : Controller
    {
        private readonly IRoleAccessControlListService _service;
        private readonly ISettings _settings;
        private readonly ISessionContext _sessionContext;
        private readonly ILogger _logger;

        public ListController(IRoleAccessControlListService service, ILogManager logManager,ISettings settings,ISessionContext sessionContext)
        {
            _service = service;
            _settings = settings;
            _sessionContext = sessionContext;
            _logger = logManager.GetLogger("ListController");
        }

        public virtual ActionResult Index(long roleId)
        {
            return PartialView(_service.Get(roleId));
        }

        [HttpPost]
        public virtual ActionResult Edit(RoleAccessControlObjectEditModel model)
        {
            if (!ModelState.IsValid) return PartialView(model);

            try
            {
                _service.Save(model);
                AccessControlCacheHelper.BuildSystemCache(model.RoleId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Saved Successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error Occured.");
            }
            model.AccessControlObjects = _service.Get(model.RoleId).AccessControlObjects;
            return PartialView("Index", model);
        }

    }
}
