using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class EventCustomerServiceTester
    {
        private const long VALID_EVENT_CUSTOMER_ID = 25107;
        private const long INVALID_EVENT_CUSTOMER_ID = 999999;
        private IEventCustomerService _eventCustomerService;

        [SetUp]
        public void Setup()
        {
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            DependencyRegistrar.RegisterDependencies();
            _eventCustomerService = IoC.Resolve<IEventCustomerService>();
        }

        [Test]
        public void GetEventCustomerAggregateTester()
        {
            var eventCustomerAggregate = _eventCustomerService.GetEventCustomerAggregate(VALID_EVENT_CUSTOMER_ID);
            Assert.IsNotNull(eventCustomerAggregate);
        }

        [Test]
        [ExpectedException(typeof(ObjectNotFoundInPersistenceException<EventCustomer>))]
        public void GetEventCustomerAggregateTesterThrowsExceptionWhenEventCustomerDoesNotExist()
        {
            var eventCustomerAggregate = _eventCustomerService.GetEventCustomerAggregate(INVALID_EVENT_CUSTOMER_ID);
            Assert.IsNotNull(eventCustomerAggregate);
        }

    }
}