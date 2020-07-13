using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    public class PodStaffAssignmentRepositoryTester
    {
        private IPodStaffAssignmentRepository _podStaffAssignmentRepository;

        public PodStaffAssignmentRepositoryTester()
        {
            DependencyRegistrar.RegisterDependencies();

            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _podStaffAssignmentRepository = IoC.Resolve<IPodStaffAssignmentRepository>();
        }


        [Test]
        public void GetPodStaffforMultiplePods_ReturnsValidData()
        {
            long[] validPods = new long[]{1,1};

            IEnumerable<PodStaff> actual = _podStaffAssignmentRepository.GetPodStaffforMultiplePods(validPods);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.First().Id);
        }
    }
}