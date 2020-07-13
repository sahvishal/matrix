using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Sales.Controllers
{
    [RoleBasedAuthorize]
    public class CorporateAccountController : Controller
    {
        private readonly int _pageSize;
        private readonly IEventService _eventService;
        private readonly ISessionContext _sessionContext;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ILogger _logger;
        private readonly ICustomTagService _customTagService;
        private readonly ICorporateAccountService _corporateAccountService;


        public CorporateAccountController(IEventService eventService, ISessionContext sessionContext, ISettings settings, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            ILogManager logManager, ICustomTagService customTagService, ICorporateAccountService corporateAccountService)
        {
            _pageSize = settings.DefaultPageSizeForReports;
            _eventService = eventService;
            _sessionContext = sessionContext;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _logger = logManager.GetLogger<CorporateAccountController>();
            _customTagService = customTagService;
            _corporateAccountService = corporateAccountService;
        }

        public ActionResult SearchEvents(CorporateAccountEventListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new CorporateAccountEventListModelFilter { AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId };
            else
                filter.AccountId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            var model = _eventService.GetCorporateAccountEvents(pageNumber, _pageSize, filter, out totalRecords) ??
                new CorporateAccountEventListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new
                                                    {
                                                        pageNumber = pn,
                                                        filter.FromDate,
                                                        filter.ToDate,
                                                        filter.AccountId,
                                                        filter.ResultInterpretation
                                                    });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult ManageCustomerTag(long customerId)
        {
            var customreTags = _corporateCustomerCustomTagRepository.GetByCustomerId(customerId).ToList();

            return PartialView(customreTags);
        }

        [HttpPost]
        public JsonResult RemoveCustomerTag(long[] tagIds)
        {
            try
            {
                var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                _corporateCustomerCustomTagRepository.UpdateCorporateCustomerTag(tagIds, false, orgId);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                _logger.Error("Some Error Occured");
                _logger.Error("Message : " + exception.Message);
                _logger.Error("Stack Trace : " + exception.StackTrace);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageCustomTag(CustomTagListModelFilter filter, int pageNumber = 1)
        {
            var totalRecords = 0;

            var model = new CustomTagListModel
            {
                Collection = _customTagService.GetCustomTagFilterList(filter, pageNumber, _pageSize, out totalRecords),
                Filter = filter
            };

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
               pn => Url.Action(currentAction, new
               {
                   pageNumber = pn,
                   filter.CorporateId,
                   filter.CustomTag,
                   filter.DisabledTag,
                   filter.EnabledTag
               });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteCustomTag(long customTagId)
        {
            try
            {
                var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                _customTagService.DeleteCorporateTag(customTagId, orgId);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                _logger.Error("Some Error Occured");
                _logger.Error("Message : " + exception.Message);
                _logger.Error("Stack Trace : " + exception.StackTrace);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DisableCorporateTagCustomTag(long customTagId, bool disable)
        {
            try
            {
                var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

                _customTagService.DisabledCorporateTag(customTagId, disable, orgId);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                _logger.Error("Some Error Occured");
                _logger.Error("Message : " + exception.Message);
                _logger.Error("Stack Trace : " + exception.StackTrace);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MemberResultSummary(CorporateAccountCustomerListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            var model = _corporateAccountService.GetMemberResultSummary(pageNumber, _pageSize, filter, out totalRecords) ?? new CorporateAccountCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc = pn => Url.Action(currentAction, new
                                        {
                                            pageNumber = pn,
                                            filter.CustomerId,
                                            filter.CustomerName,
                                            filter.EventId,
                                            filter.DateOfBirthFrom,
                                            filter.DateOfBirthTo,
                                            filter.MemberId,
                                            filter.HICN
                                        });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
        [HttpGet]
        public ActionResult CreateCustomTag(long customeTagId = 0)
        {
            var customeTag = new CustomTagEditViewModel();
            if (customeTagId > 0)
            {
                customeTag = _customTagService.GetCustomTag(customeTagId);
            }

            return View(customeTag);
        }
        [HttpPost]
        public ActionResult CreateCustomTag(CustomTagEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var orgId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
                    if(model.TagId > 0)
                    {
                        _customTagService.UpdateCustomeTag(model);
                    }
                    else
                    {
                        _customTagService.SaveCustomeTag(model, orgId);
                    }
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("CustomTag has been saved successfully!");
                }
                catch (Exception ex)
                {

                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(string.Format("System Failure! Message: {0}", ex.Message));
                    _logger.Info(string.Format("New CustomTag {0}!  Message: {1} \nStackTrace: {2}", model.CustomTag, ex.Message, ex.StackTrace));
                }
            }
            return View(model);
        }
    }
}