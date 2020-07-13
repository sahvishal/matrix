using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Operations.Controllers
{
    [RoleBasedAuthorize]
    public class CdContentTrackingController : Controller
    {
        //
        // GET: /Operations/CdContentTracking/
        private readonly int _pageSize;
        private readonly IOperationsReportingService _operationsReportingService;
        private readonly ICdContentGeneratorTrackingRepository _cdContentGeneratorTrackingRepository;
        public CdContentTrackingController(IOperationsReportingService operationsReportingService, ISettings settings, ICdContentGeneratorTrackingRepository cdContentGeneratorTrackingRepository)
        {
            _operationsReportingService = operationsReportingService;
            _cdContentGeneratorTrackingRepository = cdContentGeneratorTrackingRepository;

            _pageSize = settings.DefaultPageSizeForReports;
        }

        public ActionResult CustomerCdContentTracking(CustomerCdConentTrackingModelFilter filter = null, int pageNumber = 1, long eventId = 0)
        {
            int totalRecords = 0;
            if (eventId > 0)
                filter = new CustomerCdConentTrackingModelFilter { EventId = eventId };
            var model = _operationsReportingService.GetCustomerCdContentTrackingModel(pageNumber, _pageSize, filter, out totalRecords);

            if (model == null)
                model = new CustomerCdContentTrackingListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventId,
                    filter.CustomerId,
                    filter.CustomerName,
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public bool UpdateDowloadinfo(long id)
        {
            var cdContentTracking = _cdContentGeneratorTrackingRepository.Get(id);
            if (cdContentTracking == null)
                return false;
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            cdContentTracking.IsContentDownloaded = true;
            cdContentTracking.DownloadedByOrgRoleUserId = currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
            cdContentTracking.DownloadedDate = DateTime.Now;
            _cdContentGeneratorTrackingRepository.Save(cdContentTracking);
            return true;
        }

        public bool UpdateEventCdContentDownloadInfo(long eventId)
        {
            var currentSession = IoC.Resolve<ISessionContext>().UserSession;
            return _cdContentGeneratorTrackingRepository.UpdateCdContentDownloadedinfo(eventId,
                                                                                       currentSession.
                                                                                           CurrentOrganizationRole.
                                                                                           OrganizationRoleUserId);
        }

    }
}
