using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class PackageController : WebService
    {
        [WebMethod (EnableSession = true)]
        public OrderedPair<List<Package>, List<Test>> GetPackagesAndTests(long eventId, long roleId)
        {
            IEventPackageRepository packageRepository = new EventPackageRepository();
            var eventPackages =
                packageRepository.GetPackagesForEventByRole(eventId, roleId).OrderByDescending(p => p.Price);
            var packages = eventPackages.Select(ep => ep.Package).ToList();

            IEventTestRepository eventTestRepository = new EventTestRepository();
            var eventTests = eventTestRepository.GetTestsForEventByRole(eventId, roleId);
            var tests = eventTests.Select(et => et.Test).ToList();

            var packagesAndTests = new OrderedPair<List<Package>, List<Test>>(packages, tests);
            return packagesAndTests;
        }

        [WebMethod (EnableSession = true)]
        public List<Test> GetTests(long eventId, long roleId)
        {
            IEventTestRepository eventTestRepository = new EventTestRepository();
            var eventTests = eventTestRepository.GetTestsForEventByRole(eventId, roleId);
            var tests = eventTests.Select(et => et.Test).ToList();
            return tests; //AdjustAndSortTests(tests);
        }

        [WebMethod (EnableSession = true)]
        public List<OrderedPair<long, long>> GetTestDependencyData()
        {
            ITestRepository testRepository = new TestRepository();
            return testRepository.GetTestDependencyData();
        }

    }
}
