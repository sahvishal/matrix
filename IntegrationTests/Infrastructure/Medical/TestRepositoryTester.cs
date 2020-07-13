using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class TestRepositoryTester
    {
        private const long VALID_TEST_ID = 1;
        private const long VALID_EVENT_ID = 1912;
        private readonly ITestRepository _testRepository = new TestRepository();
        private readonly IUniqueItemRepository<Test> _uniqueItemRepository = new TestRepository();

        [Test]
        public void GetReturnsTestWhenValidIdGiven()
        {
            Test test = _uniqueItemRepository.GetById(VALID_TEST_ID);

            Assert.IsNotNull(test);
        }

        [Test]
        public void GetAllReturnsAll5ActiveTestsInPersistence()
        {
            const int expectedNumberOfTests = 5;
            int numberOfTests = _testRepository.GetAll().Count;

            Assert.IsTrue(numberOfTests == expectedNumberOfTests, "{0} tests returned ({1} expected).", 
                numberOfTests, expectedNumberOfTests);
        }

        
        [Test]
        public void GetPermittedTestsForMedicalVendorMedicalVendorUserReturnsTestsForValidMVMVUser()
        {
            List<Test> permittedTests = _testRepository.GetPermittedTestsForaPhysician(609);

            Assert.IsNotNull(permittedTests);
            Assert.IsNotEmpty(permittedTests);
        }

    }
}