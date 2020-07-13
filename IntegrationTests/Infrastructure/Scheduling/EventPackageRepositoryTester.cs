using System.Linq;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;
namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventPackageRepositoryTester
    {
        private IEventPackageRepository _eventPackageRepository;
        public EventPackageRepositoryTester()
        {
            
        }

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _eventPackageRepository = IoC.Resolve<IEventPackageRepository>();
        }
        
        [Test]
        public void GetbyId_ValidId_Tester()
        {
            var eventPackage = _eventPackageRepository.GetById(73563);
            Assert.IsNotNull(eventPackage);
            Assert.AreEqual(eventPackage.Id, 73563);
            Assert.AreEqual(eventPackage.PackageId, 124);
            Assert.AreEqual(eventPackage.EventId, 24759);  
 
            Assert.IsNotNull(eventPackage.Tests);
            Assert.IsNotEmpty(eventPackage.Tests.ToArray());
        }

        [Test]
        public void GetbyIds_ValidId_Tester()
        {
            var eventPackages = _eventPackageRepository.GetByIds(new long[] {73563, 73562});
            Assert.IsNotNull(eventPackages);
            Assert.IsNotEmpty(eventPackages.ToArray());

            var eventPackageIds = eventPackages.Select(ep => ep.Id).ToArray();
            var packageIds = eventPackages.Select(ep => ep.PackageId).ToArray();
            var eventIds = eventPackages.Select(ep => ep.EventId).ToArray();

            Assert.IsTrue(eventPackageIds.Contains(73563));
            Assert.IsTrue(eventPackageIds.Contains(73562));

            Assert.IsTrue(packageIds.Contains(124));
            Assert.IsTrue(packageIds.Contains(107));

            Assert.IsTrue(eventIds.Contains(24759));

            Assert.IsNotNull(eventPackages.First().Tests);
            Assert.IsNotEmpty(eventPackages.First().Tests.ToArray());
        }

        [Test]
        public void GetbyEventIdAndPackageId_ValidId_Tester()
        {
            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(24759, 124);
            Assert.IsNotNull(eventPackage);
            Assert.AreEqual(eventPackage.Id, 73563);
            Assert.AreEqual(eventPackage.PackageId, 124);
            Assert.AreEqual(eventPackage.EventId, 24759);
        }

        [Test]
        public void GetbyOrderId_ValidId_Tester()
        {
            var eventPackage = _eventPackageRepository.GetPackageForOrder(432902);

            Assert.IsNotNull(eventPackage);
            Assert.AreEqual(eventPackage.Id, 51833);
            Assert.AreEqual(eventPackage.PackageId, 28);
            Assert.AreEqual(eventPackage.EventId, 20616);
        }

        [Test]
        public void GetbyEventidAndRole_ValidId_Tester()
        {

            var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(24759, 8);
            Assert.IsNotNull(eventPackages);
            Assert.IsNotEmpty(eventPackages.ToArray());

            var eventPackageIds = eventPackages.Select(ep => ep.Id).ToArray();
            var packageIds = eventPackages.Select(ep => ep.PackageId).ToArray();
            var eventIds = eventPackages.Select(ep => ep.EventId).ToArray();

            Assert.IsTrue(eventPackageIds.Contains(73563));
            Assert.IsTrue(eventPackageIds.Contains(73562));

            Assert.IsTrue(packageIds.Contains(124));
            Assert.IsTrue(packageIds.Contains(107));

            Assert.IsTrue(eventIds.Contains(24759));      
        }

        public void GetbyEventId_ValidId_Tester()
        {

            var eventPackages = _eventPackageRepository.GetPackagesForEvent(24759);
            Assert.IsNotNull(eventPackages);
            Assert.IsNotEmpty(eventPackages.ToArray());

            var eventPackageIds = eventPackages.Select(ep => ep.Id).ToArray();
            var packageIds = eventPackages.Select(ep => ep.PackageId).ToArray();
            var eventIds = eventPackages.Select(ep => ep.EventId).ToArray();

            Assert.IsTrue(eventPackageIds.Contains(73563));
            Assert.IsTrue(eventPackageIds.Contains(73562));

            Assert.IsTrue(packageIds.Contains(124));
            Assert.IsTrue(packageIds.Contains(107));

            Assert.IsTrue(eventIds.Contains(24759));   
        }

    }
}