using System;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Medical.Controllers
{
    [RoleBasedAuthorize]
    public class AuthorizationController : Controller
    {
        private readonly IScreeningAuthorizationService _screeningAuthorizationService;
        private readonly ISessionContext _sessionContext;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IScreeningAuthorizationRepository _screeningAuthorizationRepository;
        private readonly ISettings _settings;
        

        public AuthorizationController(IScreeningAuthorizationService screeningAuthorizationService, ISessionContext sessionContext,
            IPhysicianRepository physicianRepository, IScreeningAuthorizationRepository screeningAuthorizationRepository, ISettings settings)
        {
            _screeningAuthorizationService = screeningAuthorizationService;
            _sessionContext = sessionContext;
            _physicianRepository = physicianRepository;
            _screeningAuthorizationRepository = screeningAuthorizationRepository;
            _settings = settings;
        }

        public ActionResult GetCustomers()
        {
            if (!_settings.IsAuthorizationRequired)
            {
                Response.RedirectUser(Request.UrlReferrer.OriginalString);
                return null;
            }

            return View(GetModel());
        }

        [HttpPost]
        public ActionResult GetCustomers(EventScreeningAuthorizationEditModel model)
        {
            try
            {
                var validator = IoC.Resolve<EventScreeningAuthorizationEditModelValidator>();
                var result = validator.Validate(model);
                if (result.IsValid)
                {
                    var physician =
                        _physicianRepository.GetPhysician(
                            _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

                    var screeningAuthorizations = (from customer in model.Customers
                                                   where customer.IsAuthorized
                                                   select new ScreeningAuthorization
                                                              {
                                                                  Id = customer.EventCustomerId,
                                                                  PhysicianId = physician.PhysicianId,
                                                                  Signature = physician.SignatureFile.Path,
                                                                  Initials = string.Empty
                                                              }).ToList();
                    _screeningAuthorizationRepository.SaveScreeningAuthorizations(screeningAuthorizations);

                    return RedirectToAction("GetCustomers");
                }
                model = GetModel();
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(result.Errors.Select(e => e.ErrorMessage).FirstOrDefault());
                return View(model);
            }
            catch (Exception exception)
            {
                model = GetModel();
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(model);
            }

        }

        private EventScreeningAuthorizationEditModel GetModel()
        {
            var model = _screeningAuthorizationService.GetCustomersForAuthorization(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            return model;
        }

    }
}
