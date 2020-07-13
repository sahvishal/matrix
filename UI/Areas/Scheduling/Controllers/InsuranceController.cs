using System.Collections.Generic;
using System.Web.Mvc;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Application;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class InsuranceController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IEligibilityService _eligibilityService;
        private readonly IChargeCardRepository _chargeCardRepository;

        public InsuranceController(ISessionContext sessionContext, IEligibilityService eligibilityService, IChargeCardRepository chargeCardRepository)
        {
            _sessionContext = sessionContext;
            _eligibilityService = eligibilityService;
            _chargeCardRepository = chargeCardRepository;
        }
        //
        // GET: /Scheduling/Insurance/

        public ActionResult Edit(long chargeCardId = 0)
        {
            if (chargeCardId > 0)
            {
                var chargeCard = _chargeCardRepository.GetById(chargeCardId);
                var model = new EligibilityEditModel
                {
                    CardDetail = chargeCard,
                    HideCardDetails = true
                };
                return View(model);
            }
            return View(new EligibilityEditModel());
        }

        [HttpPost]
        public ActionResult CheckEligibility(EligibilityEditModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            long? createdByOrgRoleUserId = null;

            if (_sessionContext != null && _sessionContext.UserSession != null)
                createdByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            model = _eligibilityService.CheckEligibility(model, createdByOrgRoleUserId);

            ModelState.Clear();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult GetInsuranceDetail(long eligibilityId, long eventId, long packageId, IEnumerable<long> addOnTestIds)
        {
            var model = _eligibilityService.GetEligibilityDetail(eligibilityId, eventId, packageId, addOnTestIds);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool CheckTestCoveredByInsurance(long eventId, long packageId, IEnumerable<long> addOnTestIds)
        {
            return _eligibilityService.CheckTestCoveredByinsurance(eventId, packageId, addOnTestIds);
        }

    }
}
