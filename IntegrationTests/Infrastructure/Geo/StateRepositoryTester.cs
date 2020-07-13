using System.Collections.Generic;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Geo
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class StateRepositoryTester
    {
        [Test]
        public void GetAllStatesReturnsStates()
        {
            IStateRepository stateRepository = new StateRepository();

            List<State> states = stateRepository.GetAllStates();

            Assert.IsNotNull(states);
            Assert.IsNotEmpty(states, "No states were returned from persistence.");
        }
    }
}