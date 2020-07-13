using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Users.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Users
{
    [TestFixture]
    [Ignore]
    public class PhysicianRepositoryTester
    {
        private readonly IPhysicianRepository _physicianRepository = new PhysicianRepository();

        private const long VALID_EVENT_ID = 24032;
        private const long VALID_EventCUSTOMER_ID = 488149;
        private const long INVALID_PHYSICIAN_ID = 0;
        private const long VALID_PHYSICIAN_ID = 468540;

        [Test]
        public void GetPhysiciansForEvent()
        {
            var physicians = _physicianRepository.GetAvailablePhysiciansIdNamePairForEvent(VALID_EVENT_ID).ToList();
            Assert.IsNotEmpty(physicians);
        }

        [Test]
        public void GetPhysiciansForCustomer()
        {
            var physicians = _physicianRepository.GetAvailablePhysiciansIdNamePairForCustomer(VALID_EventCUSTOMER_ID).ToList();
            Assert.IsNotEmpty(physicians);
        }

        [Test]
        public void GetEventCustomerIdForPhysicianEvaluationReturnNoEventCustomerId()
        {
            var eventCustomerIdAndEvaluationCount = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(INVALID_PHYSICIAN_ID);
            Assert.IsNotNull(eventCustomerIdAndEvaluationCount);
            Assert.AreEqual(eventCustomerIdAndEvaluationCount.ItemsDone,0);
            Assert.AreEqual(eventCustomerIdAndEvaluationCount.FirstItemInTheQueue, 0);
        }

        [Test]
        public void GetEventCustomerIdForPhysicianEvaluationReturnEventCustomerId()
        {
            var eventCustomerIdAndEvaluationCount = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(VALID_PHYSICIAN_ID);
            Assert.IsNotNull(eventCustomerIdAndEvaluationCount);
            Assert.Greater(eventCustomerIdAndEvaluationCount.ItemsDone, 0);
            Assert.Greater(eventCustomerIdAndEvaluationCount.FirstItemInTheQueue, 0);
        }

        [Test]
        public void GetEventCustomerIdForOverReadPhysicianEvaluationReturnNoEventCustomerId()
        {
            var eventCustomerIdAndEvaluationCount = _physicianRepository.GetEventCustomerIdForOverReadPhysicianEvaluation(INVALID_PHYSICIAN_ID);
            Assert.IsNotNull(eventCustomerIdAndEvaluationCount);
            Assert.AreEqual(eventCustomerIdAndEvaluationCount.ItemsDone, 0);
            Assert.AreEqual(eventCustomerIdAndEvaluationCount.FirstItemInTheQueue, 0);
        }
    }
}
