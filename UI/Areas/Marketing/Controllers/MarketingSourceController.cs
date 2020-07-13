using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Marketing.Controllers
{
    [RoleBasedAuthorize]
    public class MarketingSourceController : Controller
    {
        private IMarketingSourceService _marketingSourceService;
        private ITerritoryRepository _territoryRepository;

        private readonly int _pageSize ;

        public MarketingSourceController(IMarketingSourceService marketingSourceService, ITerritoryRepository territoryRepository,ISettings settings)
        {
            _marketingSourceService = marketingSourceService;
            _pageSize = settings.DefaultPageSizeForReports;
            _territoryRepository = territoryRepository;
        }

        public ActionResult Index(MarketingSourceListModelFilter filter = null,int pageNumber = 1)
        {
            int totalRecords;

            var model = _marketingSourceService.GetPagedRecords(pageNumber, _pageSize, filter,out totalRecords);


            if (filter == null) filter = new MarketingSourceListModelFilter();
                model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc = pn => Url.Action(currentAction, new { pageNumber = pn, filter.MarketingSourceName });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            
            return View(model);
        }

       
        //
        // GET: /Marketing/MarketingSource/Create

        public ActionResult Create()
        {
            return View(new MarketingSourceEditModel(_territoryRepository));
        } 

        //
        // POST: /Marketing/MarketingSource/Create

        [HttpPost]
        public ActionResult Create(MarketingSourceEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _marketingSourceService.Save(model);
                    var newModel = new MarketingSourceEditModel(_territoryRepository);
                    newModel.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Marketing source created successfully!");
                    return View(newModel);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Advertiser);
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure: " + ex.Message);
                return View(model);
            }
        }
        
        //
        // GET: /Marketing/MarketingSource/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_marketingSourceService.Get(id));
        }

        //
        // POST: /Marketing/MarketingSource/Edit/5

        [HttpPost]
        public ActionResult Edit(MarketingSourceEditModel model)
        {
            try
            {
                model.Territories = _territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Advertiser);
                if (ModelState.IsValid)
                {
                    _marketingSourceService.Save(model);
                    model.FeedbackMessage = FeedbackMessageModel.CreateSuccessMessage("Marketing source created successfully!");
                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage("System Failure: " + ex.Message);
                return View(model);
            }
        }

        //
        // /Marketing/MarketingSource/Delete/5
        [HttpPost]
        public ContentResult Delete(int id)
        {
            _marketingSourceService.Delete(id);
            return Content("Deleted succesfully!");
        }

    }
}
