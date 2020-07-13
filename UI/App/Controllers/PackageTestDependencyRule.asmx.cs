using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.DataAccess.Master;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class PackageTestDependencyRule : WebService
    {
        [WebMethod (EnableSession = true)]
        public string CheckPackageTestDependencyRule(string packageIds, string testIds)
        {
            if (!string.IsNullOrEmpty(packageIds))
            packageIds = packageIds.Substring(0, packageIds.Length - 1);

            if (!string.IsNullOrEmpty(testIds))
            testIds = testIds.Substring(0, testIds.Length - 1);

            var masterDal = new MasterDAL();            
            return masterDal.CheckPackageTestDependencyRule(packageIds, testIds);
        }
    }
}
