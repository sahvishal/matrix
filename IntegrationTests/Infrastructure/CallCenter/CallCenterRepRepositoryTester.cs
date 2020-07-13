using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.CallCenter
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class CallCenterRepRepositoryTester
    {
        private readonly ICallCenterRepRepository _callCenterRepRepository = new CallCenterRepRepository();
        private const long VALID_CALL_CENTER_CALL_CENTER_USER_ID = 105;

        [Test]
        public void GetCallCenterRepsReturnsUserWithId1058WhenCallCenterUser105Given()
        {
            const long expectedUserId = 1058;

            List<Falcon.App.Core.Users.Domain.CallCenterRep> callCenterReps = _callCenterRepRepository.
                GetCallCenterReps(new List<long> {VALID_CALL_CENTER_CALL_CENTER_USER_ID});
            
            Assert.AreEqual(expectedUserId, callCenterReps.Single().Id, "Incorrect User ID returned.");
        }
    }
}