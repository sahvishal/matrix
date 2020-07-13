using System.Web.Services;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Repositories.Host;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Service;
using System.Collections.Generic;

namespace Falcon.App.UI.Controllers
{
    /// <summary>
    /// Summary description for HostFacilityRankingController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
       
    public class HostFacilityRankingController : System.Web.Services.WebService
    {
        IHostFacilityRankingService _hostFacilityRankingService = new HostFacilityRankingService();

        [WebMethod (EnableSession = true)]
        public HostFacilityViability GetHostFacilityViabilityforHSC(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityRankingByHSC(hostId);
        }

        [WebMethod (EnableSession = true)]
        public HostFacilityViability GetHostFacilityViabilityforTechnician(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityRankingByTechnician(hostId);
        }
        
        [WebMethod (EnableSession = true)]
        public HostFacilityViability GetHostFacilityViabilityforFranchisee(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityRankingByFranchisee(hostId);
        }

        [WebMethod (EnableSession = true)]
        public HostFacilityViability GetHostFacilityViabilityforEventWizard(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityViabilityforEventWizard(hostId);
        }

        [WebMethod (EnableSession = true)]
        public List<HostImage> GetHostImages(long hostId)
        {
            IHostRepository hostRepository = new HostRepository();
            return hostRepository.GetHostImages(hostId);
        }

        [WebMethod (EnableSession = true)]
        public List<HostImage> GetHostFacilityImagesByTechnician(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityImagesbyTechnician(hostId);
        }

        [WebMethod (EnableSession = true)]
        public List<HostImage> GetHostFacilityImagesByHsc(long hostId)
        {
            return _hostFacilityRankingService.GetHostFacilityImagesbyHSC(hostId);
        }
    }
}
