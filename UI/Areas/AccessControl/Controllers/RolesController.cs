using System;
using System.Web.Mvc;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.AccessControl.Controllers
{
    [RoleBasedAuthorize]
    public class RolesController : Controller
    {
        private readonly ILogger _logger;
        private readonly IRoleService _roleService;

        public RolesController(ILogManager logManager, IRoleService roleService)
        {
            _roleService = roleService;
            _logger = logManager.GetLogger("RolesController");
        }

        public virtual ActionResult Index()
        {
            return View(_roleService.Get(new RoleListModelFilter()));
        }

        [HttpPost]
        public virtual ActionResult List(RoleListModelFilter filter = null)
        {
            filter = filter ?? new RoleListModelFilter();
            return View("List", _roleService.Get(filter));
        }

        public virtual ActionResult Edit(long id = 0)
        {
            var model = _roleService.Get(id);
            return PartialView(model);
        }

        [HttpPost]
        public virtual ActionResult EditModel(RoleEditModel model)
        {
            if (!ModelState.IsValid) return PartialView(model);

            try
            {
                var isNew = model.Id <= 0;
                model = _roleService.Save(model);

                if (isNew)
                {
                    ModelState.Clear();
                    model = new RoleEditModel();
                }

                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Saved Successfully.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Duplicate Name")
                {
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("A role with same name already exists.");
                }
                else
                {
                    _logger.Error(string.Format("Some error while add/edit role - {0}", model.Name), ex);
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error Occured.");
                }
            }

            return PartialView(model);
        }
    }
}
