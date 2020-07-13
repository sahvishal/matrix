using System.Collections.Generic;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Sales.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Sales
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class HostRepositoryTester
    {
        private readonly IHostRepository _hostRepository = new HostRepository();
        private const int VALID_HOST_ID = 697;

        [Test]
        public void GetEventTypesForHostReturnsEventTypes()
        {
            List<RegistrationMode> eventTypes = _hostRepository.GetEventTypesForHost(VALID_HOST_ID);

            Assert.IsNotNull(eventTypes, "Null collection of Event Types returned.");
            Assert.IsNotEmpty(eventTypes, "Empty collection of Event Types returned.");
        }
    }
}