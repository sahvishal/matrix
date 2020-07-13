using System.ComponentModel;
using System.Web.Services;
using Falcon.App.Core.Sales;
using Falcon.App.Infrastructure.Repositories;
using System.Web.Script.Services;

namespace Falcon.App.UI.Controllers
{
    /// <summary>
    /// Summary description for ActivityTemplateController
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class ActivityTemplateController : System.Web.Services.WebService
    {
        [WebMethod (EnableSession = true)]
        public bool ActiveDeActiveTemplate(long activityTemplateId, bool activeStatus)
        {
            IActivityTemplateRepository activityTemplateRepository = new ActivityTemplateRepository();
            return activityTemplateRepository.ActiveDeActiveTemplate(activityTemplateId, activeStatus);
        }
    }
}
