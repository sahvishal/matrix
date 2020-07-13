using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class ActivityController : WebService
    {
        [WebMethod (EnableSession = true)]
        public bool DeleteActivity(ActivityType activityType, long activityId)
        {
            IActivityRepository activityRepository = new ActivityRepository();
            return activityRepository.DeleteActivity(activityType, activityId);
        }
        [WebMethod (EnableSession = true)]
        public bool MarkActivity(ActivityType activityType, long activityId,bool markActivity)
        {
            IActivityRepository activityRepository = new ActivityRepository();
            return activityRepository.MarkActivity(activityType, activityId, markActivity);
        }
    }
}
