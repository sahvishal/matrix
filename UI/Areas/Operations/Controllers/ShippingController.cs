using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class ShippingController : Controller
    {
        private readonly IShippingDetailService _shippingDetailService;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;

        public ShippingController(IShippingDetailService shippingDetailService, IHospitalPartnerRepository hospitalPartnerRepository, IShippingOptionRepository shippingOptionRepository)
        {
            _shippingDetailService = shippingDetailService;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _shippingOptionRepository = shippingOptionRepository;
        }

        //
        // GET: /Operations/Shipping/

        public ActionResult GetShippingDetails(long eventId, long customerId)
        {
            var model = _shippingDetailService.GetShippingDetailEditModels(eventId, customerId);

            return View(model);
        }

        public bool UpdateShippingStatus(long shippingDetailId, int status)
        {
            var modifiedByOrgRoleUserId = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            return _shippingDetailService.UpdateShippingStatus(shippingDetailId, (ShipmentStatus)status, modifiedByOrgRoleUserId);
        }

        public JsonResult GetShippingOptionForEvent(long eventId)
        {
            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            var shippingOptionViewModel = new ShippingOptionViewModel { IsHospitalPartnerEvent = false };

            if (hospitalPartnerId > 0)
            {
                shippingOptionViewModel = new ShippingOptionViewModel { IsHospitalPartnerEvent = true };
                var shippingOptionsToBind = new List<ShippingOption>();

                var shippingOptions = _shippingOptionRepository.GetAllShippingOptionForHospitalPartner(hospitalPartnerId);

                if (shippingOptions != null && shippingOptions.Count > 0)
                {
                    shippingOptionsToBind.AddRange(shippingOptions);
                    shippingOptionViewModel.AllShippingOptions = Mapper.Map<IEnumerable<ShippingOption>, IEnumerable<ShippingOptionOrderItemViewModel>>(shippingOptionsToBind);
                }
            }

            return Json(shippingOptionViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
