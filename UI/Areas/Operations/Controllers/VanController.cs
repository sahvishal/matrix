using System;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class VanController : Controller
    {
        private IVanRepository _vanRepository;
        public VanController(IVanRepository vanRepository)
        {
            _vanRepository = vanRepository;
        }

        public ActionResult Index()
        {
            //TODO:Don't go to legacy van list.
            Response.RedirectUser("/App/Common/VanDetails.aspx");
            return null; 
        }

        public ActionResult Create()
        {
            return View(new VanEditModel());
        }

        [HttpPost]
        public ActionResult Create(VanEditModel vanEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vanRepository.SaveVan(Mapper.Map<VanEditModel, Van>(vanEditModel));

                    vanEditModel.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage(
                            "The Vehicle information was saved successfully. You can add more vehicles or close this page.");

                    return View(vanEditModel);
                }
                return View(vanEditModel);
            }
            catch (Exception exception)
            {
                vanEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(vanEditModel);
            }
            
        }

        public ActionResult Edit(long id)
        {
            return View(Mapper.Map<Van,VanEditModel>(_vanRepository.GetVan(id)));

        }

        [HttpPost]
        public ActionResult Edit(VanEditModel vanEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vanRepository.SaveVan(Mapper.Map<VanEditModel, Van>(vanEditModel));

                    vanEditModel.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage("The Vehicle information was saved successfully. You can make more changes here and save it.");

                    return View(vanEditModel);
                }
                return View(vanEditModel);
            }
            catch (Exception exception)
            {
                vanEditModel.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Error:" + exception);
                return View(vanEditModel);
            }
        }

    }
}
