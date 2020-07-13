using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class DateTimeCalendarTester
    {
        [Test]
        public void NowReturnsSameTimeAsDateTimeNow()
        {
            string expectedNowLongTimeString = DateTime.Now.ToLongTimeString();
            ICalendar calendar = new DateTimeCalendar();

            string nowLongTimeString = calendar.Now.ToLongTimeString();

            Assert.AreEqual(expectedNowLongTimeString, nowLongTimeString,
                "DateTimeCalendar's Now did not return the same time as DateTime's Now.");
        }

        [Test]
        public void NowReturnsSameDateAsDateTimeNow()
        {
            string expectedNowShortDateString = DateTime.Now.ToShortDateString();
            ICalendar calendar = new DateTimeCalendar();

            string nowShortDateString = calendar.Now.ToShortDateString();

            Assert.AreEqual(expectedNowShortDateString, nowShortDateString,
                "DateTimeCalendar's Now did not return the same date as DateTime's Now.");
        }
    }
}