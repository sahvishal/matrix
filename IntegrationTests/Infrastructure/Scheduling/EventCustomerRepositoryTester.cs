using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    //[Ignore("These integration tests will fail until the QA database is unreverted.")]
    public class EventCustomerRepositoryTester
    {
        private readonly IEventCustomerAggregateRepository _eventCustomerAggregateRepository = new EventCustomerAggregateRepository();
        private readonly IEventCustomerRepository _eventCustomerRepository = new EventCustomerRepository();

        const int VALID_SALES_REP_ID = 179;
        const int INVALID_SALES_REP_ID = 0;

        [Test]
        public void GetAllEventCustomerInfoBySalesRepConnectsToDatabase()
        {
            var salesRepEventCustomerInformation = _eventCustomerAggregateRepository.GetAllEventCustomerInfoBySalesRep(VALID_SALES_REP_ID);
            Assert.IsNotNull(salesRepEventCustomerInformation);
        }

        [Test]
        public void GetAllEventCustomerInfoBySalesRepReturnsRecordsForValidSalesRepId()
        {
            var salesRepEventCustomerInformation = _eventCustomerAggregateRepository.GetAllEventCustomerInfoBySalesRep(VALID_SALES_REP_ID);
            Assert.IsNotEmpty(salesRepEventCustomerInformation);
        }

        [Test]
        public void GetAllEventCustomerInfoBySalesRepDoesNotReturnRecordsForInvalidSalesRepId()
        {
            var salesRepEventCustomterInformation = _eventCustomerAggregateRepository.
                GetAllEventCustomerInfoBySalesRep(INVALID_SALES_REP_ID);
            Assert.IsEmpty(salesRepEventCustomterInformation);
        }

        [Test]
        public void GetEventCustomerInfoBySalesRepDoesNotReturnEventsBeforeGivenStartDate()
        {
            var eventStartDate = new DateTime(2009, 5, 1);
            var salesRepEventCustomerInformation = _eventCustomerAggregateRepository.
                GetEventCustomerInfoBySalesRep(VALID_SALES_REP_ID, eventStartDate);

            bool containsEventsBeforeStartDate = salesRepEventCustomerInformation.
                                                     Where(s => s.EventDate < eventStartDate).Count() == 0;
            Assert.IsTrue(containsEventsBeforeStartDate);
        }

        [Test]
        public void GetEventCustomerInfoBySalesRepReturnsNothingWhenNoEventStartsAfterEventStartDate()
        {
            var dateAfterAllEvents = DateTime.MaxValue;
            Assert.IsEmpty(_eventCustomerAggregateRepository.GetEventCustomerInfoBySalesRep(VALID_SALES_REP_ID, dateAfterAllEvents));
        }

        [Test]
        public void GetEventCustomerByIdReturnsNullForUnknownEventCustomerId()
        {
            const long unknownCustomerId = 0;
            EventCustomerAggregate eventCustomerAggregate = _eventCustomerAggregateRepository.GetEventCustomerById(unknownCustomerId);
            Assert.IsNull(eventCustomerAggregate);
        }

        [Test]
        [Ignore("This will only function in the local development environment.")]
        public void GetEventCustomerByIdReturnsEventCustomerAggregateForKnownEventCustomer()
        {
            const long knownCustomerId = 12879;
            EventCustomerAggregate eventCustomerAggregate = _eventCustomerAggregateRepository.GetEventCustomerById(knownCustomerId);
            Assert.IsNotNull(eventCustomerAggregate);
        }

        [Test]
        [Ignore("This will only function in the local development environment.")]
        public void GetEventCustomerByIdReturnsTwoEventCustomerAggregatesWhenGivenTwoValidAndOneInvalidEventCustomerIds()
        {
            long[] knownCustomerIds = { 12879, 12880 };
            long[] unknownCustomerIds = { 0 };

            long[] customerIds = knownCustomerIds.Union(unknownCustomerIds).ToArray();

            List<EventCustomerAggregate> eventCustomerAggregates = _eventCustomerAggregateRepository.GetEventCustomersByIds(customerIds);

            Assert.IsNotNull(eventCustomerAggregates);
            Assert.AreEqual(knownCustomerIds.Count(), eventCustomerAggregates.Count);
            Assert.AreEqual(knownCustomerIds, eventCustomerAggregates.Select(c => c.EventCustomerId).ToArray());
        }

        [Test]
        public void GetEventCustomersbyRegisterationDateTest()
        {
            int totalRecords = 0;
            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyRegisterationDate(1, 20, null, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomersbyRegisterationDateWithFilterTest()
        {
            int totalRecords = 0;
            var filter = new AppointmentsBookedListModelFilter
                             {
                                 IsCorporateEvent = false,
                                 IsRetailEvent = true
                             };
            var eventCustomers = _eventCustomerRepository.GetEventCustomersbyRegisterationDate(1, 20, filter, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomersforPateintScheduleTest()
        {
            int totalRecords = 0;
            var eventCustomers = _eventCustomerRepository.GetEventCustomersforPatientSchedule(1, 20, null, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomersforPateintSchedulewithFiltersTest()
        {
            int totalRecords = 0;
            var filter = new CustomerScheduleModelFilter()
                             {
                                 IsCorporateEvent = false,
                                 IsRetailEvent = true
                             };

            var eventCustomers = _eventCustomerRepository.GetEventCustomersforPatientSchedule(1, 20, filter, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetNoshowEventCustomersTest()
        {
            int totalRecords = 0;
            var eventCustomers = _eventCustomerRepository.GetNoShowEventCustomers(1, 20, null, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetNoshowEventCustomerswithFilterTest()
        {
            int totalRecords = 0;
            var filter = new NoShowCustomerModelFilter()
                             {
                                 FromDate = DateTime.Now.AddDays(-30),
                                 ToDate = DateTime.Now.AddDays(30)
                             };
            var eventCustomers = _eventCustomerRepository.GetNoShowEventCustomers(1, 20, filter, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomerswithCdPurchaseTest()
        {
            int totalRecords = 0;
            var eventCustomers = _eventCustomerRepository.GetEventCustomerswithCdPurchase(1, 20, null, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomerswithCdPurchasewithFilterTest()
        {
            int totalRecords = 0;
            var filter = new CdImageStatusModelFilter
                             {
                                 FromDate = DateTime.Now.AddDays(-30),
                                 ToDate = DateTime.Now.AddDays(30)
                             };
            var eventCustomers = _eventCustomerRepository.GetEventCustomerswithCdPurchase(1, 20, filter, out totalRecords);
            Assert.IsNotNull(eventCustomers);
            Assert.IsNotEmpty(eventCustomers.ToList());
        }

        [Test]
        public void GetEventCustomerCountForHealthPlanRevenueByPackage()
        {

            var result = _eventCustomerRepository.GetEventCustomerCountForHealthPlanRevenueByPackage(1003,
                   DateTime.Today.AddDays(-565), DateTime.Today, new long[] { 399, 437, 438 });

            if (result != null)
            {
                var packageIds = result.Select(x => x.FirstValue).Distinct();
                foreach (var packageId in packageIds)
                {
                    var count = result.Count(x => x.FirstValue == packageId);
                }
            }

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.ToList());
        }
    }
}