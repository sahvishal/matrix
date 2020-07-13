using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Marketing.Impl;
using Falcon.App.UI.Filters;
using FluentValidation;

namespace Falcon.App.UI.Areas.Marketing.Controllers
{
    [RoleBasedAuthorize]
    public class SourceCodeController : Controller
    {
        //
        // GET: /Marketing/SourceCode/

        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly ISourceCodeService _sourceCodeService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly IValidator<SourceCodeItemWiseDiscountEditModel> _sourceCodeItemWiseValidator;
        private readonly ISessionContext _sessionContext;
        private readonly int _pageSize;
        private readonly IEventRepository _eventRepository;

        public SourceCodeController(ISourceCodeRepository sourceCodeRepository, IConfigurationSettingRepository configurationSettingRepository, ISessionContext sessionContext, ISettings settings,
            ISourceCodeService sourceCodeService, IValidator<SourceCodeItemWiseDiscountEditModel> sourceCodeItemWiseValidator, IEventRepository eventRepository)
        {
            _configurationSettingRepository = configurationSettingRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _sourceCodeItemWiseValidator = sourceCodeItemWiseValidator;
            _sessionContext = sessionContext;
            _sourceCodeService = sourceCodeService;
            _pageSize = settings.DefaultPageSizeForReports;
            _eventRepository = eventRepository;
        }

        public ActionResult Index(SourceCodeListModelFilter filter = null, int pageNumber = 1)
        {
            long totalRecords = 0;
            var model = _sourceCodeService.Get(filter, pageNumber, _pageSize, out totalRecords) ??
                        new SourceCodeListModel();

            if (filter == null) filter = new SourceCodeListModelFilter();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.SourceCodeName, filter.SourceCodeTypeId });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, (int)totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult Create()
        {
            return View(_sourceCodeService.Get());
        }

        [HttpPost]
        public ActionResult Create(SourceCodeEditModel model)
        {
            if (!ModelState.IsValid)
            {
                ValidateItemWiseDiscount(model.PackageDiscounts);
                ValidateItemWiseDiscount(model.TestDiscounts);
                ValidateItemWiseDiscount(model.ProductDiscounts);
                ValidateItemWiseDiscount(model.ShippingDiscounts);

                return View(_sourceCodeService.Get(model));
            }

            Save(model);
            model = _sourceCodeService.Get(model);
            return View(model);
        }

        public ActionResult Edit(long id)
        {
            return View(_sourceCodeService.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(SourceCodeEditModel model)
        {
            if (!ModelState.IsValid)
            {
                ValidateItemWiseDiscount(model.PackageDiscounts);
                ValidateItemWiseDiscount(model.TestDiscounts);
                ValidateItemWiseDiscount(model.ProductDiscounts);
                ValidateItemWiseDiscount(model.ShippingDiscounts);

                return View(_sourceCodeService.Get(model));
            }

            Save(model);

            model = _sourceCodeService.Get(model);
            return View(model);
        }

        private void Save(SourceCodeEditModel model)
        {
            try
            {
                var sourceCode = Mapper.Map<SourceCodeEditModel, SourceCode>(model);
                bool forEdit = false;
                if (model.Id > 0)
                {
                    forEdit = true;
                    var sourceCodeInDb = _sourceCodeRepository.GetSourceCodeById(model.Id);
                    sourceCode.DataRecorderMetaData = sourceCodeInDb.DataRecorderMetaData;
                    sourceCode.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                    sourceCode.DataRecorderMetaData.DateModified = DateTime.Now;
                }
                else
                {
                    sourceCode.DataRecorderMetaData = new DataRecorderMetaData(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null) { DataRecorderModifier = null };
                }

                _sourceCodeRepository.SaveSourceCode(sourceCode);
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateSuccessMessage("Source Code " + (forEdit ? "edited" : "created") +
                                                              " successfully!");
            }
            catch (Exception ex)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("System Failure! Message: " + ex.Message);
            }
        }

        public ActionResult GetRandomUniqueSourceCodeInstance()
        {
            var prefix = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.CouponPrefix);
            var sourceCodeGenerator = new UniqueSourceCodeGenerator(_sourceCodeRepository, new SourceCodeGenerator(prefix));
            var sourceCode = sourceCodeGenerator.GenerateSourceCode();
            return Json(sourceCode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SetSourceCodeIsActiveStatus(long id, bool isActive)
        {
            try
            {
                _sourceCodeRepository.SetSourceCodeIsActiveState(id, isActive);
                return Json(new { Result = true, Message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "System Failure! " + ex.Message });
            }
        }

        private void ValidateItemWiseDiscount(IEnumerable<SourceCodeItemWiseDiscountEditModel> itemWiseDiscountModels)
        {
            if (itemWiseDiscountModels == null) return;

            foreach (var item in itemWiseDiscountModels)
            {
                var validateResult = _sourceCodeItemWiseValidator.Validate(item);
                if (validateResult.IsValid) continue;

                string feedbackMessage = validateResult.Errors.Aggregate("", (current, error) => current + (error.ErrorMessage + "<br />"));
                item.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(feedbackMessage);
            }
        }

        public ActionResult SearchEvent(long? eventId, string hostName, DateTime? eventDate)
        {
            try
            {
                Event theEvent = null;
                if (eventId.HasValue &&  eventId.Value> 0)
                {
                    theEvent = _eventRepository.GetById(eventId.Value);
                }
                else if (eventDate.HasValue && !string.IsNullOrEmpty(hostName))
                {
                    theEvent = _eventRepository.GetEventbyHostName(hostName, eventDate);
                }
                else
                {
                    return null;
                }

                if (theEvent == null || theEvent.Status != EventStatus.Active)
                    return null;
                return Json(theEvent);
            }
            catch
            {
                return null;
            }
        }

    }
}
