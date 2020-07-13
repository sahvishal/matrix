using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Audit;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Controllers
{
    [RoleBasedAuthorize]
    [IgnoreAudit]
    public class AuditController : Controller
    {
        private readonly IActivityLogViewService _activityLogViewService;
        private readonly ISettings _settings;
        private readonly IUserRepository<User> _userRepository;
        private readonly ILogger _logger;
        public AuditController(IActivityLogViewService activityLogViewService, ISettings settings, IUserRepository<User> userRepository, ILogManager logManager)
        {
            _activityLogViewService = activityLogViewService;
            _settings = settings;
            _userRepository = userRepository;
            _logger = logManager.GetLogger<AuditController>();
        }

        //
        // GET: /Activity/

        public virtual ActionResult Index(ActivityLogListFilter filter = null, int pageNumber = 1)
        {
            if (filter == null)
            {
                filter = new ActivityLogListFilter
                {
                    StartDate = DateTime.Today.AddDays(-1),
                    EndDate = DateTime.Today

                };
            }
            else
            {
                if (filter.StartDate == DateTime.MinValue)
                {
                    filter.StartDate = DateTime.Today.AddDays(-1);
                    filter.EndDate = DateTime.Today;
                }
            }

            var model = GetRecords(filter, pageNumber);
            return View(model);
        }

        public virtual ActionResult List(ActivityLogListFilter filter, int pageNumber = 1)
        {
            var model = GetRecords(filter, pageNumber);
            return PartialView(model);
        }

        private ActivityLogListModel GetRecords(ActivityLogListFilter filter, int pageNumber)
        {
            int totalCount = 0;
            var model = new ActivityLogListModel();
            try
            {
                filter.EndDate = filter.EndDate.AddHours(23).AddMinutes(59);
                model = _activityLogViewService.GetList(filter, pageNumber, _settings.DefaultPageSizeForReports,
                    out totalCount);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error Occured");
            }

            model.PagingModel = new PagingModel(pageNumber, _settings.DefaultPageSizeForReports, totalCount,
                p =>
                    Server.UrlDecode(Url.Action("Index",
                        new
                        {
                            StartDate = filter.StartDate.Date,
                            EndDate = filter.EndDate.Date,
                            pageNumber = p,
                            filter.AccessedBy,
                            filter.CustomerName,
                            filter.AccessedByName,
                            filter.CustomerId
                        })));

            return model;
        }

        public virtual ActionResult LoggedModelDetails(string logId)
        {
            var model = new ActivityLoggedModelDetailsViewModel();
            try
            {
                model = _activityLogViewService.GetModelDetails(logId);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("Some Error Occured");
            }
            return View(model);
        }

       public ActionResult GetAccessedByList(string prefixText)
        {
            //return _userRepository.SearchUsersByName(prefixText, false).ToList().Select(x => x.Value).ToList();
            return Json(_userRepository.SearchUsersByName(prefixText, false).ToList().Select(x => new { id = x.Key, label = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult GetCustomerList(string prefixText)
        {
            return Json(_userRepository.SearchUsersByName(prefixText, true).ToList().Select(x => new { id = x.Key, label = x.Value }), JsonRequestBehavior.AllowGet);
        }
    }
}
