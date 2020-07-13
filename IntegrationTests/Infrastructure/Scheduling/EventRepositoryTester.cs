using System;
using System.Linq;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using NUnit.Framework;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    [Ignore("These integration tests will fail until the QA database is unreverted.")]
    public class EventRepositoryTester
    {
        private const string VALID_ZIP_CODE = "78705";
        private const int DISTANCE_RANGE = 25;
        private readonly IEventRepository _eventRepository = new EventRepository();

        [Test]
        public void GetEventsByFiltersWithZipCodeAndRangeTest()
        {
            var events = _eventRepository.GetEventsByFilters(VALID_ZIP_CODE, DISTANCE_RANGE, string.Empty, string.Empty,
                                                             null, null, string.Empty, 1, 20);
            Assert.IsNotNull(events);
        }

        [Test]
        public void GetEventsByFiltersWithOutZipCodeAndRangeTest()
        {
            var events = _eventRepository.GetEventsByFilters(string.Empty, null, string.Empty, string.Empty,
                                                             null, null, string.Empty, 1, 20);
            Assert.IsNotNull(events);
        }

        [Test]
        public void GetEventsByFiltersWithDateRange()
        {
            var events = _eventRepository.GetEventsByFilters(string.Empty, null, string.Empty, string.Empty,
                                                             DateTime.Now.AddDays(4), DateTime.Now.AddDays(14), string.Empty, 1, 20);
            Assert.IsNotNull(events);
        }

        [Test]
        public void GetTechnicianNotesTester()
        {
            var events = _eventRepository.GetTechnicianNotes(123);

            Assert.IsNotNull(events);
        }

        [Test]
        public void GetCorporateEventsTest()
        {
            int totalRecords = 0;
            var events = _eventRepository.GetCorporteEvents(1, 20, null, out totalRecords);
            Assert.IsNotNull(events);
        }

        [Test]
        public void GetCorporateEventswithFiltersTest()
        {
            int totalRecords = 0;
            var filter = new EventVolumeListModelFilter()
                             {
                                 Vehicle = "pod1",
                                 ZipCode = "78705"
                             };
            var events = _eventRepository.GetCorporteEvents(1, 20, filter, out totalRecords);
            Assert.IsNull(events);
        }


        [Test]
        public void GetPublicEventsTest()
        {
            int totalRecords = 0;
            var events = _eventRepository.GetRetailEvents(1, 20, null, out totalRecords);
            Assert.IsNotNull(events);
            Assert.IsNotEmpty(events.ToList());
        }

        [Test]
        public void GetPublicEventswithFiltersTest()
        {
            int totalRecords = 0;
            var filter = new EventVolumeListModelFilter()
            {
                Vehicle = "pod1",
                ZipCode = "16910"
            };
            var events = _eventRepository.GetRetailEvents(1, 20, filter, out totalRecords);
            Assert.IsNotNull(events);
            Assert.IsNotEmpty(events.ToList());
        }

        [Test]
        public void GetEventsforDetailOpenOrderTest()
        {
            int totalRecords = 0;
            var events = _eventRepository.GetEventsforDetailOpenOrder(1, 20, null, out totalRecords);
            Assert.IsNotNull(events);
            Assert.IsNotEmpty(events.ToList());
        }

        [Test]
        public void GetEventsforDetailOpenOrderwithFilterTest()
        {
            int totalRecords = 0;
            var filter = new DetailOpenOrderModelFilter()
                             {
                                 IsCorporateEvent = false,
                                 IsRetailEvent = true
                             };
            var events = _eventRepository.GetEventsforDetailOpenOrder(1, 20, filter, out totalRecords);
            Assert.IsNotNull(events);
            Assert.IsNotEmpty(events.ToList());
        }

    }
}