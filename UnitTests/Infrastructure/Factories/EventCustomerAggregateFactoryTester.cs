using System;
using System.Linq;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Factories.Events;
using NUnit.Framework;

namespace Falcon.UnitTests.Infrastructure.Factories
{
    [TestFixture]
    public class EventCustomerAggregateFactoryTester
    {
        private readonly IEventCustomerAggregateFactory _eventCustomerAggregateFactory = new EventCustomerAggregateFactory();
        private CustomerEventBasicInfoTypedView _eventBasicInfoTypedView;

        #region AddRowToEventBasicInfoTypedView()

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId)
        {
            AddRowToEventBasicInfoTypedView(eventCustomerId, true);
        }

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId, decimal paymentAmount, bool isDebit)
        {
            AddRowToEventBasicInfoTypedView(eventCustomerId, paymentAmount, isDebit, string.Empty);
        }

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId, decimal paymentAmount, bool isDebit, string eventName)
        {
            AddRowToEventBasicInfoTypedView(eventCustomerId, paymentAmount, isDebit, CustomerEventSignUpMode.Online, true, eventName);
        }

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId, decimal paymentAmount, CustomerEventSignUpMode customerEventSignUpMode)
        {
            AddRowToEventBasicInfoTypedView(eventCustomerId, paymentAmount, false, customerEventSignUpMode, true, string.Empty);
        }

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId, bool isPodActive)
        {
            AddRowToEventBasicInfoTypedView(eventCustomerId, 0m, false, CustomerEventSignUpMode.Online, isPodActive, string.Empty);
        }

        private void AddRowToEventBasicInfoTypedView(int eventCustomerId, decimal paymentAmount, bool isDebit, 
                                                     CustomerEventSignUpMode signUpMode, bool isPodActive, string eventName)
        {
            // Order of parameters matches order in typed view in database.
            _eventBasicInfoTypedView.Rows.Add(3, eventCustomerId, 0, 0, 0, signUpMode, 0, DateTime.MinValue, 0, eventName,
                                              DateTime.MinValue, DateTime.MinValue, 0, 0, 0, paymentAmount, 0, isDebit, 19, 20, 21, 22, isPodActive);
        }

        #endregion

        [SetUp]
        public void SetUp()
        {
            _eventBasicInfoTypedView = new CustomerEventBasicInfoTypedView();
        }

        [TearDown]
        public void TearDown()
        {
            _eventBasicInfoTypedView = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAggregatesFromTypedViewCollectionThrowsExceptionWhenNullTypedViewGiven()
        {
            _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(null);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionReturnsEmptyListWhenEmptyTypedViewGiven()
        {
            var aggregates = _eventCustomerAggregateFactory.
                CreateAggregatesFromTypedViewCollection(new CustomerEventBasicInfoTypedView());
            Assert.IsEmpty(aggregates);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionDoesNotReturnRowsWithDuplicateEventCustomerIds()
        {
            const int eventCustomerId = 5;
            AddRowToEventBasicInfoTypedView(eventCustomerId);
            AddRowToEventBasicInfoTypedView(eventCustomerId);
            AddRowToEventBasicInfoTypedView(eventCustomerId);
            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const int expectedNumberOfRows = 1;
            Assert.IsTrue(eventCustomers.Count == expectedNumberOfRows, 
                          string.Format("{0} rows returned when {1} expected.", eventCustomers.Count, expectedNumberOfRows));
            Assert.AreEqual(eventCustomerId, eventCustomers.Single().EventCustomerId);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionAddsTwoCreditsForSameEventCustomerIdTogether()
        {
            const int eventCustomerId = 5;
            const decimal creditAmount1 = 25.00m;
            const decimal creditAmount2 = 183.33m;
            const bool isDebit = false;
            AddRowToEventBasicInfoTypedView(eventCustomerId, creditAmount1, isDebit);
            AddRowToEventBasicInfoTypedView(eventCustomerId, creditAmount2, isDebit);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const decimal expectedPaymentAmount = creditAmount1 + creditAmount2;
            Assert.AreEqual(expectedPaymentAmount, eventCustomers.Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionSubtractsTwoDebitsForSameEventCustomerIdTogether()
        {
            const int eventCustomerId = 5;
            const decimal debitAmount1 = 23.33m;
            const decimal debitAmount2 = 183.33m;
            const bool isDebit = true;
            AddRowToEventBasicInfoTypedView(eventCustomerId, debitAmount1, isDebit);
            AddRowToEventBasicInfoTypedView(eventCustomerId, debitAmount2, isDebit);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const decimal expectedPaymentAmount = -debitAmount1 - debitAmount2;
            Assert.AreEqual(expectedPaymentAmount, eventCustomers.Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionAggregates3PaymentsForSameEventCustomerIdTogether()
        {
            const int eventCustomerId = 5;
            const decimal creditAmount1 = 163.33m;
            const decimal creditAmount2 = 33.33m;
            const decimal debitAmount = 500.30m;
            AddRowToEventBasicInfoTypedView(eventCustomerId, creditAmount1, false);
            AddRowToEventBasicInfoTypedView(eventCustomerId, creditAmount2, false);
            AddRowToEventBasicInfoTypedView(eventCustomerId, debitAmount, true);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const decimal expectedPaymentAmount = creditAmount1 + creditAmount2 - debitAmount;
            Assert.AreEqual(expectedPaymentAmount, eventCustomers.Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionSubtractsDebitFromSingleRow()
        {
            const int customerEventIdToDebit = 443;
            const decimal debitAmount = 1850.33m;
            const bool isDebit = true;
            AddRowToEventBasicInfoTypedView(customerEventIdToDebit, debitAmount, isDebit);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            Assert.AreEqual(-debitAmount, eventCustomers.Where(e => e.EventCustomerId == customerEventIdToDebit).Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionAddsCreditToSingleEventCustomer()
        {
            const int customerEventIdToCredit = 424;
            const decimal creditAmount = 1850.33m;
            const bool isDebit = false;
            AddRowToEventBasicInfoTypedView(customerEventIdToCredit, creditAmount, isDebit);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            Assert.AreEqual(creditAmount, eventCustomers.Where(e => e.EventCustomerId == customerEventIdToCredit).Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionReturns3RowsWhen3DistinctEventCustomerIdsGiven()
        {
            const int eventCustomerId = 5;
            AddRowToEventBasicInfoTypedView(eventCustomerId);
            AddRowToEventBasicInfoTypedView(eventCustomerId + 1);
            AddRowToEventBasicInfoTypedView(eventCustomerId + 2);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const int expectedNumberOfRows = 3;
            Assert.IsTrue(eventCustomers.Count == expectedNumberOfRows,
                          string.Format("{0} rows returned when {1} expected.", eventCustomers.Count, expectedNumberOfRows));
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionIgnoresInactivePodAggregate()
        {
            const int eventCustomerId = 3;
            AddRowToEventBasicInfoTypedView(eventCustomerId, false);
            AddRowToEventBasicInfoTypedView(eventCustomerId+1, true);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const int expectedNumberOfEventCustomers = 1;
            Assert.AreEqual(expectedNumberOfEventCustomers, eventCustomers.Count);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionDiscludesDuplicates()
        {
            const int eventCustomerId = 3;
            const string eventName = "Name";
            const bool isDebit = false;
            const decimal expectedPaymentAmount = 33.33m;

            AddRowToEventBasicInfoTypedView(eventCustomerId, expectedPaymentAmount, isDebit, eventName);
            AddRowToEventBasicInfoTypedView(eventCustomerId, expectedPaymentAmount, isDebit, eventName);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const int expectedNumberOfEventCustomers = 1;
            Assert.AreEqual(expectedNumberOfEventCustomers, eventCustomers.Count);
            Assert.AreEqual(expectedPaymentAmount, eventCustomers.Single().PaymentAmount);
        }

        [Test]
        public void CreateAggregatesFromTypedViewCollectionRemovesDuplicatesInUnorderedList()
        {
            const int eventCustomerId = 3;
            const string eventName = "Name";
            const bool isDebit = false;
            const decimal expectedPaymentAmount = 33.33m;

            AddRowToEventBasicInfoTypedView(eventCustomerId, expectedPaymentAmount, isDebit, eventName);
            AddRowToEventBasicInfoTypedView(eventCustomerId+1, expectedPaymentAmount, isDebit, eventName);
            AddRowToEventBasicInfoTypedView(eventCustomerId, expectedPaymentAmount, isDebit, eventName);

            var eventCustomers = _eventCustomerAggregateFactory.CreateAggregatesFromTypedViewCollection(_eventBasicInfoTypedView);

            const int expectedNumberOfEventCustomers = 2;
            Assert.AreEqual(expectedNumberOfEventCustomers, eventCustomers.Count);
            Assert.AreEqual(expectedPaymentAmount, 
                            eventCustomers.Where(e => e.EventCustomerId == eventCustomerId).Single().PaymentAmount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEventCustomerAggregateFromTypedViewRowThrowsExceptionWhenNullRowGiven()
        {
            _eventCustomerAggregateFactory.GetEventCustomerAggregateFromTypedViewRow(null);
        }

        [Test]
        public void GetEventCustomerAggregateFromTypedViewRowMapsTypeViewRowPropertiesToAggregateProperties()
        {
            const int eventCustomerId = 3;
            const decimal paymentAmount = 33.43m;
            const bool isDebit = false;
            AddRowToEventBasicInfoTypedView(eventCustomerId, paymentAmount, isDebit);

            var eventCustomerAggregate = _eventCustomerAggregateFactory.
                GetEventCustomerAggregateFromTypedViewRow(_eventBasicInfoTypedView.Single());

            Assert.AreEqual(eventCustomerId, eventCustomerAggregate.EventCustomerId);
            Assert.AreEqual(paymentAmount, eventCustomerAggregate.PaymentAmount);
        }

        [Test]
        public void GetEventCustomerAggregateAssignsSignUpModeToOnlineWhen0Given()
        {
            const int eventCustomerId = 23;
            const decimal paymentAmount = 2.33m;
            const int customerEventSignUpMode = 0;
            AddRowToEventBasicInfoTypedView(eventCustomerId, paymentAmount, customerEventSignUpMode);

            var eventCustomerAggregate = _eventCustomerAggregateFactory.
                GetEventCustomerAggregateFromTypedViewRow(_eventBasicInfoTypedView.Single());

            Assert.AreEqual(CustomerEventSignUpMode.Online, eventCustomerAggregate.SignUpMode);
        }
    }
}