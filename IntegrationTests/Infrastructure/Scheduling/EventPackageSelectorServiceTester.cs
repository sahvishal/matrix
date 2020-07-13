using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventPackageSelectorServiceTester
    {
        private IEventPackageSelectorService _eventPackageSelectorService;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _eventPackageSelectorService = IoC.Resolve<IEventPackageSelectorService>();
        }

        [Test]
        public void GetRetailPackageTesterReturnsNull()
        {
            var eventCustomerAggregate = _eventPackageSelectorService.GetEventPackage(0,0,0,EventType.Corporate);
            Assert.IsNull(eventCustomerAggregate);
        }

    }
}