using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTester
    {
        [Test]
        public void GetLastDayOfMonthReturnsDay31ForMonthsWith31Days()
        {
            var monthsWith31Days = new List<int> { 1, 3, 5, 7, 8, 10, 12 };
            const int expectedDay = 31;
            foreach (var month in monthsWith31Days)
            {
                var dateTime = new DateTime(2001, month, 1 + month);
                DateTime lastDayOfMonth = dateTime.GetLastDayOfMonth();
                Assert.AreEqual(expectedDay, lastDayOfMonth.Day);
            }
        }

        [Test]
        public void GetLastDayOfMonthReturnsDay30ForMonthsWith30Days()
        {
            var monthsWith30Days = new List<int> { 4, 6, 9, 11 };
            const int expectedDay = 30;
            foreach (var month in monthsWith30Days)
            {
                var dateTime = new DateTime(2001, month, 1 + month);
                DateTime lastDayOfMonth = dateTime.GetLastDayOfMonth();
                Assert.AreEqual(expectedDay, lastDayOfMonth.Day);
            }
        }

        [Test]
        public void GetLastDayOfMonthReturnsDay28ForFebruaryOnNonLeapYear()
        {
            const int expectedDay = 28;
            var dateTime = new DateTime(2001, 2, 3);

            DateTime lastDayOfMonth = dateTime.GetLastDayOfMonth();

            Assert.AreEqual(expectedDay, lastDayOfMonth.Day);
        }

        [Test]
        public void GetLastDayOfMonthReturnsDay29ForFebruaryOnLeapYear()
        {
            const int expectedDay = 29;
            var dateTime = new DateTime(2000, 2, 3);

            DateTime lastDayOfMonth = dateTime.GetLastDayOfMonth();

            Assert.AreEqual(expectedDay, lastDayOfMonth.Day);
        }

        [Test]
        public void GetLastDayOfMonthReturnsSameYearAsGivenDate()
        {
            const int expectedYear = 2007;
            for (int i = 1; i <= 12; i++)
            {
                var dateTime = new DateTime(expectedYear, i, 2 + i);
                int year = dateTime.GetLastDayOfMonth().Year;
                Assert.AreEqual(expectedYear, year, string.Format("Year for {0} incorrect.",
                                                                  dateTime.ToShortDateString()));
            }
        }

        [Test]
        public void GetLastDayOfMonthsReturnsSameMonthAsGivenDate()
        {
            for (int i = 1; i <= 12; i++)
            {
                var dateTime = new DateTime(2002, i, 3 + i);
                int month = dateTime.GetLastDayOfMonth().Month;
                Assert.AreEqual(dateTime.Month, month, string.Format("Month for {0} incorrect.",
                                                                     dateTime.ToShortDateString()));
            }
        }

        [Test]
        public void GetLastDayOfMonthReturnsSameTimeAsGivenDate()
        {
            const int expectedHour = 23;
            const int expectedMinute = 33;
            const int expectedSecond = 35;
            var dateTime = new DateTime(2001, 1, 1, expectedHour, expectedMinute, expectedSecond);

            DateTime lastDayOfMonth = dateTime.GetLastDayOfMonth();

            Assert.AreEqual(expectedHour, lastDayOfMonth.Hour, "Hour mismatch.");
            Assert.AreEqual(expectedMinute, lastDayOfMonth.Minute, "Minute mismatch.");
            Assert.AreEqual(expectedSecond, lastDayOfMonth.Second, "Second mismatch.");
        }

        [Test]
        public void GetFirstDayOfQuarterReturnsGivenYear()
        {
            const int expectedYear = 1987;
            for (int i = 1; i <= 12; i++)
            {
                var dateTime = new DateTime(expectedYear, i, 4 + i);
                DateTime firstDayOfQuarter = dateTime.GetFirstDayOfQuarter();
                Assert.AreEqual(expectedYear, firstDayOfQuarter.Year,
                                string.Format("{0} did not return year {1}.", dateTime.ToShortDateString(), expectedYear));
            }
        }

        [Test]
        public void GetFirstDayOfQuarterReturnsJanuary1ForFirstQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 1, 1);
            for (int month = 1; month <= 3; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 29 && month == 2) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime firstDayOfQuarter = dateTime.GetFirstDayOfQuarter();
                    Assert.AreEqual(expectedDate, firstDayOfQuarter,
                                    string.Format("{0} did not return first day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetFirstDayOfQuarterReturnsApril1ForSecondQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 4, 1);
            for (int month = 4; month <= 6; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && (month == 4 || month == 6)) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime firstDayOfQuarter = dateTime.GetFirstDayOfQuarter();
                    Assert.AreEqual(expectedDate, firstDayOfQuarter,
                                    string.Format("{0} did not return first day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetFirstDayOfQuarterReturnsJuly1ForThirdQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 7, 1);
            for (int month = 7; month <= 9; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && month == 9) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime firstDayOfQuarter = dateTime.GetFirstDayOfQuarter();
                    Assert.AreEqual(expectedDate, firstDayOfQuarter,
                                    string.Format("{0} did not return first day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetFirstDayOfQuarterReturnsOctober1ForFourthQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 10, 1);
            for (int month = 10; month <= 12; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && month == 11) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime firstDayOfQuarter = dateTime.GetFirstDayOfQuarter();
                    Assert.AreEqual(expectedDate, firstDayOfQuarter,
                                    string.Format("{0} did not return first day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsGivenYear()
        {
            const int expectedYear = 1987;
            for (int i = 1; i <= 12; i++)
            {
                var dateTime = new DateTime(expectedYear, i, 4 + i);
                DateTime firstDayOfQuarter = dateTime.GetLastDayOfQuarter();
                Assert.AreEqual(expectedYear, firstDayOfQuarter.Year,
                                string.Format("{0} did not return year {1}.", dateTime.ToShortDateString(), expectedYear));
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsTimeOf1159PM()
        {
            string expectedTime = new DateTime(2001, 1, 1, 23, 59, 59).ToShortTimeString();
            for (int i = 1; i <= 12; i++)
            {
                var dateTime = new DateTime(2002, i, 4 + i);
                DateTime lastDayOfQuarter = dateTime.GetLastDayOfQuarter();
                Assert.AreEqual(expectedTime, lastDayOfQuarter.ToShortTimeString());
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsMarch31ForFirstQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 3, 31, 23, 59, 59);
            for (int month = 1; month <= 3; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 29 && month == 2) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime lastDayOfQuarter = dateTime.GetLastDayOfQuarter();
                    Assert.AreEqual(expectedDate, lastDayOfQuarter,
                                    string.Format("{0} did not return last day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsJune30ForSecondQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 6, 30, 23, 59, 59);
            for (int month = 4; month <= 6; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && (month == 4 || month == 6)) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime lastDayOfQuarter = dateTime.GetLastDayOfQuarter();
                    Assert.AreEqual(expectedDate, lastDayOfQuarter,
                                    string.Format("{0} did not return last day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsSeptember30ForThirdQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 9, 30, 23, 59, 59);
            for (int month = 7; month <= 9; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && month == 9) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime lastDayOfQuarter = dateTime.GetLastDayOfQuarter();
                    Assert.AreEqual(expectedDate, lastDayOfQuarter,
                                    string.Format("{0} did not return last day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetLastDayOfQuarterReturnsDecember31ForFourthQuarterDates()
        {
            const int year = 2008;
            var expectedDate = new DateTime(year, 12, 31, 23, 59, 59);
            for (int month = 10; month <= 12; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day > 30 && month == 11) break;
                    var dateTime = new DateTime(year, month, day);
                    DateTime lastDayOfQuarter = dateTime.GetLastDayOfQuarter();
                    Assert.AreEqual(expectedDate, lastDayOfQuarter,
                                    string.Format("{0} did not return last day of quarter.", dateTime.ToShortDateString()));
                }
            }
        }

        [Test]
        public void GetLatestDateReturnsEpochDateWhenEmptyEnumerationGiven()
        {
            var emptyDateTimeList = new List<DateTime>();

            DateTime latestDate = emptyDateTimeList.GetLatestDate();

            // TODO: Retrieve epoch date from common location.
            Assert.AreEqual(new DateTime(2000, 1, 1), latestDate);
        }

        [Test]
        public void GetLatestDateReturnsSingleGivenDate()
        {
            var dateTimesWithSingleItem = new List<DateTime> { new DateTime(2003, 2, 1) };

            DateTime latestDate = dateTimesWithSingleItem.GetLatestDate();

            Assert.AreEqual(dateTimesWithSingleItem.Single(), latestDate);
        }

        [Test]
        public void GetLatestDateReturnsLaterOfTwoDates()
        {
            var expectedDate = new DateTime(2003, 4, 2);
            var dateTimes = new List<DateTime> { expectedDate, expectedDate.AddDays(-1) };

            DateTime latestDate = dateTimes.GetLatestDate();

            Assert.AreEqual(expectedDate, latestDate);
        }

        [Test]
        public void GetLatestDateReturnsLatestDateOfGivenDateCollection()
        {
            var expectedDate = new DateTime(2003, 4, 4);
            var dateTimes = new List<DateTime> { expectedDate, expectedDate.AddDays(-1), expectedDate.AddDays(-2) };

            for (int i = 0; i < 10; i++)
            {
                DateTime latestDate = dateTimes.GetLatestDate();
                Assert.AreEqual(expectedDate, latestDate);
                expectedDate = expectedDate.AddDays(1);
                dateTimes.Add(expectedDate);
            }
        }

        [Test]
        public void GetFirstDayOfMonthReturnsMayFirstForMayDates()
        {
            var expectedDate = new DateTime(2008, 5, 1);
            for (int i = 1; i <= 31; i++)
            {
                var dateTime = new DateTime(2008, 5, i);
                DateTime firstDayOfMonth = dateTime.GetFirstDayOfMonth();
                Assert.AreEqual(expectedDate, firstDayOfMonth, "{0} returned {1}.", 
                                dateTime.ToShortDateString(), firstDayOfMonth.ToShortDateString());
            }
        }

        [Test]
        public void GetFirstDayOfMonthReturnsTheFirstOfAnyMonthForAnyDate()
        {
            const int expectedDay = 1;
            for (int i = 0; i < 50; i++)
            {
                var dateTime = new DateTime(i+1000, i%12 + 1, i%25 + 1);
                DateTime firstDayOfMonth = dateTime.GetFirstDayOfMonth();
                Assert.AreEqual(expectedDay, firstDayOfMonth.Day, "{0} returned day {1}.",
                                dateTime.ToShortDateString(), firstDayOfMonth.Day);
            }
        }

        [Test]
        public void GetFirstDayOfWeekReturnsJulyTwelth2009ForJulySeventeenth2009()
        {
            var dateTime = new DateTime(2009, 7, 17);
            var expectedDateTime = new DateTime(2009, 7, 12);

            DateTime firstDayOfWeek = dateTime.GetFirstDayOfWeek();

            Assert.AreEqual(expectedDateTime.ToShortDateString(), firstDayOfWeek.ToShortDateString());
        }

        [Test]
        public void GetFirstDayOfWeekReturnsGivenDayWhenFirstDayOfWeekGiven()
        {
            var dateTime = new DateTime(2009, 8, 2);

            DateTime firstDayOfWeek = dateTime.GetFirstDayOfWeek();

            Assert.AreEqual(dateTime, firstDayOfWeek);
        }

        [Test]
        public void GetFirstDayOfWeekReturnsSixDaysAgoWhenLastDayOfWeekGiven()
        {
            var dateTime = new DateTime(2009, 8, 8);

            DateTime firstDayOfWeek = dateTime.GetFirstDayOfWeek();

            Assert.AreEqual(dateTime.AddDays(-6), firstDayOfWeek);
        }

        [Test]
        public void GetLastDayOfWeekReturnsJulyEighteenth2009ForJulySeventeenth2009()
        {
            var dateTime = new DateTime(2009, 7, 17);
            var expectedDateTime = new DateTime(2009, 7, 18);

            DateTime lastDayOfWeek = dateTime.GetLastDayOfWeek();

            Assert.AreEqual(expectedDateTime.ToShortDateString(), lastDayOfWeek.ToShortDateString());
        }

        [Test]
        public void GetLastDayOfWeekReturnsGivenDayWhenLastDayOfWeekGiven()
        {
            var dateTime = new DateTime(2009, 8, 8);

            DateTime lastDayOfWeek = dateTime.GetLastDayOfWeek();

            Assert.AreEqual(dateTime, lastDayOfWeek);
        }

        [Test]
        public void GetLastDayOfWeekReturnsSixDaysLaterWhenFirstDayOfWeekGiven()
        {
            var dateTime = new DateTime(2000, 12, 31);

            DateTime lastDayOfWeek = dateTime.GetLastDayOfWeek();

            Assert.AreEqual(dateTime.AddDays(6), lastDayOfWeek);
        }

        [Test]
        public void GetEndOfDayReturnsGivenDate()
        {
            DateTime dateTime;
            for (int i = 1; i < 5; i++)
            {
                dateTime = new DateTime(2001, 1, i);
                DateTime lastSecondOfDay = dateTime.GetEndOfDay();
                Assert.AreEqual(dateTime.ToShortDateString(), lastSecondOfDay.ToShortDateString());
            }
        }

        [Test]
        public void GetEndOfDayReturns23AsHour()
        {
            const int expectedHour = 23;
            var dateTime = new DateTime(2001, 1, 1);

            int lastHourOfDay = dateTime.GetEndOfDay().Hour;

            Assert.AreEqual(expectedHour, lastHourOfDay, "Expected {0}00 hours but {1}00 hours returned.",
                expectedHour, lastHourOfDay);
        }

        [Test]
        public void GetEndOfDayReturns59AsMinute()
        {
            const int expectedMinute = 59;
            var dateTime = new DateTime(2001, 1, 1);

            int lastMinuteOfDay = dateTime.GetEndOfDay().Minute;

            Assert.AreEqual(expectedMinute, lastMinuteOfDay, "Expected minute {0} but minute {1} returned.",
                expectedMinute, lastMinuteOfDay);
        }

        [Test]
        public void GetEndOfDayReturns59AsSecond()
        {
            const int expectedSecond = 59;
            var dateTime = new DateTime(2001, 1, 1, 13, 45, 22);

            int lastSecondOfDay = dateTime.GetEndOfDay().Second;

            Assert.AreEqual(expectedSecond, lastSecondOfDay, "Expected second {0} but second {1} returned.",
                expectedSecond, lastSecondOfDay);
            
        }
    }
}