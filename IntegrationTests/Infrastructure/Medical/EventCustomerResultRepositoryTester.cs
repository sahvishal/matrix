using System.Linq;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class EventCustomerResultRepositoryTester
    {
        private IEventCustomerResultRepository _eventCustomerResultRepository;

        [SetUp]
        public void Setup()
        {
            DependencyRegistrar.RegisterDependencies();
            _eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
        }

        [Test]
        public void GetRecordsforRegenerationTester()
        {
           var records = _eventCustomerResultRepository.GetRecordsforRegeneration();
            Assert.IsNotNull(records);
            Assert.IsNotEmpty(records.ToArray());
        }

    }
}