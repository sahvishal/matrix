using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Communication.Controllers
{
    [RoleBasedAuthorize]
    public class EmailTemplateController : Controller
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly ISessionContext _sessionContext;

        public EmailTemplateController(IEmailTemplateRepository emailTemplateRepository,
            IEmailTemplateService emailTemplateService, ISessionContext sessionContext)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _emailTemplateService = emailTemplateService;
            _sessionContext = sessionContext;
        }

        public ActionResult ViewTemplate(string emailTemplateAlias, string emailSubject)
        {
            var emailTemplate = _emailTemplateRepository.GetByAlias(emailTemplateAlias);
            if (emailTemplate != null)
            {
                TempData["notificationTypeId"] = emailTemplate.NotificationTypeId;
            }
            return View();
        }

        public ContentResult PreviewTemplate(long emailTemplateId, long notificationTypeId, string emailTemplateAlias, string body)
        {
            if (emailTemplateId > 0)
            {
                var emailTemplate = _emailTemplateRepository.GetById(emailTemplateId);

                var isValid = _emailTemplateService.IsEmailTemplateValid(emailTemplateId, body,
                    emailTemplate.NotificationTypeId);

                if (!isValid)
                    return Content("<h2>Parsed unsuccessfully. This Email Template body contains some errors. Please review.</h2>");

                return LoadTemplate(emailTemplateAlias, notificationTypeId, _emailTemplateService.ReplaceMacroswithCodeString(body, emailTemplateId));
            }

            return LoadTemplate(emailTemplateAlias, notificationTypeId, _emailTemplateService.ReplaceCodeStringwithMacroParameterValueForNotificationTypeId(body, notificationTypeId));
            
        }

        [HttpPost]
        public ContentResult LoadTemplate(string emailTemplateAlias, long notificationTypeId, string body = null)
        {
            return Content(_emailTemplateService.LoadTemplate(emailTemplateAlias, notificationTypeId, body));
        }

        public ActionResult Edit(long id)
        {
            return View(_emailTemplateService.GetModel(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EmailTemplateEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(_emailTemplateService.CompleteModel(model));
            }

            try
            {
                model = _emailTemplateService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template updated successfully!");
            }
            catch (Exception ex)
            {
                model = _emailTemplateService.CompleteModel(model);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(string.Concat("System Failure! Message: ", ex.Message));
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new EmailTemplateEditModel { TemplateType = (long)TemplateType.Email });
        }

        public ActionResult TemplateMacros(long notificationId)
        {
            return PartialView("TeplateMacros", _emailTemplateService.GetMacrosForNotificationTypeId(notificationId));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(EmailTemplateEditModel model)
        {
            if (!ModelState.IsValid)
            {
                var templateMacros = _emailTemplateService.GetMacrosForNotificationTypeId(model.NotificationTypeId);

                model.TemplateMacros = templateMacros.Select(tm => tm.IdentifierName).OrderBy(t => t);
                return View(model);
            }

            try
            {
                if (model.Id > 0)
                {
                    model = _emailTemplateService.Save(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }
                else
                {
                    model = _emailTemplateService.SaveNewTemplate(model, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }

                model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Template Created successfully!");
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                var templateMacros = _emailTemplateService.GetMacrosForNotificationTypeId(model.NotificationTypeId);
                model.TemplateMacros = templateMacros.Select(tm => tm.IdentifierName).OrderBy(t => t);

                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(string.Concat("System Failure! Message: ", ex.Message));
            }

            return View(model);
        }


    }
}
