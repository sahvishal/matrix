using System;
using System.Transactions;
using System.Web.Mvc;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class OnSiteRegistrationController : Controller
    {
        private readonly IEventPackageSelectorService _eventPackageSelectorService;
        private readonly ICustomerRegistrationService _customerRegistrationService;

        public OnSiteRegistrationController(IEventPackageSelectorService eventPackageSelectorService, ICustomerRegistrationService customerRegistrationService)
        {
            _eventPackageSelectorService = eventPackageSelectorService;
            _customerRegistrationService = customerRegistrationService;
        }
        //
        // GET: /Scheduling/OnSiteRegistration/
        public ActionResult Create(long eventId)
        {
            var model = _eventPackageSelectorService.SetEventAndPackageDetail(null, eventId, Roles.Technician);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OnSiteRegistrationEditModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var order = _customerRegistrationService.RegisterOnsiteCustomer(model);
                        scope.Complete();
                        if (order.DiscountedTotal > 0)
                        {
                            Response.RedirectUser("/Scheduling/EventCustomerList/Index?id=" + model.EventId + "&customerIdforAcceptPayment=" + order.CustomerId);
                            return null; 
                        }
                        Response.RedirectUser("/Scheduling/EventCustomerList/Index?id=" + model.EventId);
                        return null; 

                    }
                }
                catch (Exception ex)
                {
                    model = _eventPackageSelectorService.SetEventAndPackageDetail(model, model.EventId, Roles.Technician);
                    model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + ex.Message);
                    return View(model);
                }
            }
            model = _eventPackageSelectorService.SetEventAndPackageDetail(model, model.EventId, Roles.Technician);
            return View(model);
        }
    }
}
