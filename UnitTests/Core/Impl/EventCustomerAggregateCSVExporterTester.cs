using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using NUnit.Framework;

namespace Falcon.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class EventCustomerAggregateCSVExporterTester
    {
        private readonly ICSVExportable<EventCustomerAggregate> _exporter = new EventCustomerAggregateCSVExporter();

        #region GetEventCustomerAggregate()

        private static EventCustomerAggregate GetEventCustomerAggregate()
        {
            return GetEventCustomerAggregate(0m, string.Empty);
        }

        private static EventCustomerAggregate GetEventCustomerAggregate(decimal paymentAmount)
        {
            return GetEventCustomerAggregate(paymentAmount, string.Empty);
        }

        private static EventCustomerAggregate GetEventCustomerAggregate(string eventName)
        {
            return GetEventCustomerAggregate(0m, eventName);
        }

        private static EventCustomerAggregate GetEventCustomerAggregate(decimal paymentAmount, string eventName)
        {
            return new EventCustomerAggregate
                       {
                           PaymentAmount = paymentAmount,
                           MarketingSource = string.Empty,
                           PackageName = string.Empty,
                           EventName = eventName,
                           SourceCode = string.Empty,
                           IncomingPhoneNumber = string.Empty,
                           PodName = string.Empty
                       };
        }

        #endregion

        [Test]
        public void GetSingleLineReturns11CommasAnd2LinesForEventCustomerAggregate()
        {
            string commaSeparatedLine = _exporter.GetSingleLine(GetEventCustomerAggregate());
            var numberOfLines = commaSeparatedLine.LineCount();

            const int expectedNumberOfCommas = 11;
            const int expectedNumberOfLines = 2;
            Assert.AreEqual(expectedNumberOfCommas, commaSeparatedLine.ToList().Where(c => c == ',').Count());
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);
        }

        [Test]
        public void ExportToCSVAppendsHeaderToList()
        {
            const string expectedHeader = "TestHeader";
            var exporter = new EventCustomerAggregateCSVExporter(expectedHeader);
            string commaSeparatedValues = exporter.ExportToCSV(new List<EventCustomerAggregate>());

            Assert.IsTrue(commaSeparatedValues.Contains(expectedHeader));
        }

        [Test]
        public void ExportToCSVReturns33CommasAnd4LinesForTwoEventCustomerAggregates()
        {
            var eventCustomerAggregates = new List<EventCustomerAggregate> { GetEventCustomerAggregate(), GetEventCustomerAggregate()};
            
            string commaSeparatedLines = _exporter.ExportToCSV(eventCustomerAggregates);

            const int expectedNumberOfCommas = 33;
            const int expectedNumberOfLines = 4;
            var numberOfLines = commaSeparatedLines.LineCount();
            Assert.AreEqual(expectedNumberOfCommas, commaSeparatedLines.ToList().Where(c => c == ',').Count());
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);
        }

        [Test]
        public void ExportToCSVRemovesCommasFromPaymentsGreaterThan1000Dollars()
        {
            var eventCustomerAggregates = new List<EventCustomerAggregate> { GetEventCustomerAggregate(1000.01m) };
            
            string commaSeparatedLines = _exporter.ExportToCSV(eventCustomerAggregates);

            const int expectedNumberOfCommas = 22;
            Assert.AreEqual(expectedNumberOfCommas, commaSeparatedLines.ToList().Where(c => c == ',').Count());
        }

        [Test]
        public void ExportToCSVInsertsBlankLineBetweenTwoDifferentEvents()
        {
            var eventCustomerAggregates = new List<EventCustomerAggregate>
                                              {GetEventCustomerAggregate("A"), GetEventCustomerAggregate("B")};

            string commaSeparatedLines = _exporter.ExportToCSV(eventCustomerAggregates);

            var numberOfLines = commaSeparatedLines.LineCount();
            const int expectedNumberOfLines = 5;
            Assert.AreEqual(expectedNumberOfLines, numberOfLines);

        }
    }
}