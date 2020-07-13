using System.Web.Http;
using API.Areas.Application.Controllers;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;

namespace API.Areas.CallCenter.Controllers
{
    public class HealthPlanCriteriaController : BaseController
    {
        private readonly IHealthPlanCallQueueCriteriaService _healthPlanCallQueueCriteriaService;
        private readonly ISessionContext _sessionContext;


        public HealthPlanCriteriaController(IHealthPlanCallQueueCriteriaService healthPlanCallQueueCriteriaService, ISessionContext sessionContext)
        {
            _healthPlanCallQueueCriteriaService = healthPlanCallQueueCriteriaService;
            _sessionContext = sessionContext;
        }

        [HttpGet]
        public HealthPlanCallQueueCriteria GetHealthGeneratedCallQueueCriteria(long callQueueId, long healthPlanId, long criteriaId, long? campaignId)
        {

            return _healthPlanCallQueueCriteriaService.GetSystemGeneratedCallQueueCriteria(callQueueId, healthPlanId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, campaignId.HasValue ? campaignId.Value : 0, criteriaId);
        }
    }
}
