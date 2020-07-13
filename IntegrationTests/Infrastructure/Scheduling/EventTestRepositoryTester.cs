using System.Linq;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventTestRepositoryTester
    {
        private IEventTestRepository _eventTestRepository;
        public EventTestRepositoryTester()
        {

        }

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            _eventTestRepository = IoC.Resolve<IEventTestRepository>();
        }

        [Test]
        public void GetById_ValidId_Tester()
        {
            var eventTest = _eventTestRepository.GetbyId(196417);
            Assert.IsNotNull(eventTest);
            Assert.AreEqual(eventTest.EventId, 24762);
            Assert.AreEqual(eventTest.Id, 196417);
            Assert.AreEqual(eventTest.TestId, 2);
        }

        [Test]
        public void GetByIds_ValidId_Tester()
        {
            var eventTests = _eventTestRepository.GetbyIds((new long[] { 196415, 196414 }));
            Assert.IsNotNull(eventTests);
            Assert.IsNotEmpty(eventTests.ToArray());

            var eventIds = eventTests.Select(et => et.EventId);
            var testIds = eventTests.Select(et => et.TestId);
            var eventTestIds = eventTests.Select(et => et.Id);

            Assert.IsTrue(eventIds.Contains(24762));

            Assert.IsTrue(eventTestIds.Contains(196415));
            Assert.IsTrue(eventTestIds.Contains(196414));

            Assert.IsTrue(testIds.Contains(1));
            Assert.IsTrue(testIds.Contains(3));
        }

        [Test]
        public void GetByEventidAndTestId_ValidId_Tester()
        {

            var eventTest = _eventTestRepository.GetByEventAndTestId(24762, 2);
            Assert.IsNotNull(eventTest);
            Assert.AreEqual(eventTest.EventId, 24762);
            Assert.AreEqual(eventTest.Id, 196417);
            Assert.AreEqual(eventTest.TestId, 2);
        }

        [Test]
        public void GetByEventidAndTestIds_ValidId_Tester()
        {
            var eventTests = _eventTestRepository.GetByEventAndTestIds(24762, (new long[] { 1, 3 }).ToList());
            Assert.IsNotNull(eventTests);
            Assert.IsNotEmpty(eventTests.ToArray());

            var eventIds = eventTests.Select(et => et.EventId);
            var testIds = eventTests.Select(et => et.TestId);
            var eventTestIds = eventTests.Select(et => et.Id);

            Assert.IsTrue(eventIds.Contains(24762));
            
            Assert.IsTrue(eventTestIds.Contains(196415));
            Assert.IsTrue(eventTestIds.Contains(196414));
            
            Assert.IsTrue(testIds.Contains(1));
            Assert.IsTrue(testIds.Contains(3));
        }

        [Test]
        public void GetTestForOrder_ValidId_Tester()
        {
            var eventTests = _eventTestRepository.GetTestsForOrder(505275);
            Assert.IsNotNull(eventTests);
            Assert.IsNotEmpty(eventTests.ToArray());
            Assert.IsTrue(eventTests.Select(et => et.EventId).Contains(24671));
            Assert.IsTrue(eventTests.Select(et => et.Id).Contains(195296));
            Assert.IsTrue(eventTests.Select(et => et.TestId).Contains(20));
        }

        [Test]
        public void GetTestForEventByROle_ValidId_Tester()
        {

            var eventTests = _eventTestRepository.GetTestsForEventByRole(24762, 1);
            Assert.IsNotNull(eventTests);
            Assert.IsNotEmpty(eventTests.ToArray());

            var eventIds = eventTests.Select(et => et.EventId);
            var testIds = eventTests.Select(et => et.TestId);
            var eventTestIds = eventTests.Select(et => et.Id);

            Assert.IsTrue(eventIds.Contains(24762));

            Assert.IsTrue(eventTestIds.Contains(196415));
            Assert.IsTrue(eventTestIds.Contains(196414));

            Assert.IsTrue(testIds.Contains(1));
            Assert.IsTrue(testIds.Contains(3));
        }

        [Test]
        public void GetTestForEvent_ValidId_Tester()
        {

            var eventTests = _eventTestRepository.GetTestsForEvent(24762);
            Assert.IsNotNull(eventTests);
            Assert.IsNotEmpty(eventTests.ToArray());

            var eventIds = eventTests.Select(et => et.EventId);
            var testIds = eventTests.Select(et => et.TestId);
            var eventTestIds = eventTests.Select(et => et.Id);

            Assert.IsTrue(eventIds.Contains(24762));

            Assert.IsTrue(eventTestIds.Contains(196415));
            Assert.IsTrue(eventTestIds.Contains(196414));

            Assert.IsTrue(testIds.Contains(1));
            Assert.IsTrue(testIds.Contains(3));
        }


    }
}