using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Operations.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class PodController : WebService, IPodController
    {
        private readonly IPodRepository _podRepository;

        public PodController()
            : this(new PodRepository())
        { }

        public PodController(IPodRepository podRepository)
        {
            _podRepository = podRepository;
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetPodsAssignedToSalesRep(long salesRepId)
        {
            return _podRepository.GetPodsAssignedToSalesRep(salesRepId);

        }

        [WebMethod (EnableSession = true)]
        public bool AssignPodToSalesRep(long podId, long salesRepId)
        {
            return _podRepository.AssignPodToSalesRep(podId, salesRepId);
        }

        [WebMethod (EnableSession = true)]
        public bool UnassignPodFromSalesRep(long podId, long salesRepId)
        {
            return _podRepository.UnassignPodFromSalesRep(podId, salesRepId);
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetPodsAvailableForSalesRep(long salesRepId)
        {
            var assignedPods = _podRepository.GetPodsAssignedToSalesRep(salesRepId);
            return _podRepository.GetAllPods().Where(p => !assignedPods.Select(ap => ap.Id).Contains(p.Id)).ToList();
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetAllPods()
        {
            return _podRepository.GetAllPods();
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetPodsAssignedToFranchisee(long franchiseeId)
        {
            return _podRepository.GetPodsAssignedToFranchisee(franchiseeId);
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetPodsAvailableForEvent(long franchiseeId, DateTime eventDate, long territoryId)
        {
            if (territoryId>0)
                return _podRepository.GetPodsAvailableForEventByTerritoryId(territoryId, eventDate);
            return _podRepository.GetPodsAvailableForEvent(franchiseeId, eventDate);
        }

        [WebMethod (EnableSession = true)]
        public List<Pod> GetPodsAvailableForEvent(long franchiseeId, long territoryId)
        {
            if (territoryId > 0)
                return _podRepository.GetPodsAvailableForEventByTerritoryId(territoryId);
            return _podRepository.GetPodsAvailableForEvent(franchiseeId);
        }

        [WebMethod (EnableSession = true)]
        public List<OrderedPair<string, OrderedPair<string , string >>> GetPodBookedInformation(long podId, DateTime eventDate, long eventId = 0)
        {
            return _podRepository.GetPodBookedInformation(podId, eventDate, eventId);
        }
    }
}
