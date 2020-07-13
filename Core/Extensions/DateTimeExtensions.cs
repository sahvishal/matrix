using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the first day of the quarter of a calendar year.
        /// </summary>
        /// <param name="date">The DateTime object to get the first day of the quarter for.</param>
        /// <returns>The first day of the quarter.</returns>
        public static DateTime GetFirstDayOfQuarter(this DateTime date)
        {
            int monthToReturn = 3 * ((date.Month - 1) / 3) + 1;
            return new DateTime(date.Year, monthToReturn, 1);
        }

        /// <summary>
        /// Gets the last day of the quarter of a calendar year.
        /// </summary>
        /// <param name="date">The DateTime object to get the last day of the quarter for.</param>
        /// <returns>The last day of the quarter.</returns>
        public static DateTime GetLastDayOfQuarter(this DateTime date)
        {
            int monthToReturn = 3 * ((date.Month - 1) / 3) + 3;
            return new DateTime(date.Year, monthToReturn, 1, 23, 59, 59).GetLastDayOfMonth();
        }

        /// <summary>
        /// Gets the first day of the month of the given DateTime object.
        /// </summary>
        /// <param name="dateTime">The DateTime object that has the month to get the first day for.</param>
        /// <returns>The first day of the month of the given DateTime object.</returns>
        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Gets the last day of the month of the given DateTime object.
        /// </summary>
        /// <param name="dateTime">The DateTime object that has the month to get the last day for.</param>
        /// <returns>The last day of the month of the given DateTime object.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, dateTime.Hour, dateTime.Minute, dateTime.Second)
                .AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Gets the first day of the week of the given DateTime object.
        /// </summary>
        /// <param name="dateTime">The date to get the first day of the week of.</param>
        /// <returns>DateTime object of the first day of the week.</returns>
        public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
        {
            var dayOfWeek = (int)dateTime.DayOfWeek;
            return dateTime.Subtract(new TimeSpan(dayOfWeek, 0, 0, 0));
        }

        /// <summary>
        /// Gets the last day of the week of the given DateTime object.
        /// </summary>
        /// <param name="dateTime">The date to get the last day of the week of.</param>
        /// <returns>DateTime object of the last day of the week.</returns>
        public static DateTime GetLastDayOfWeek(this DateTime dateTime)
        {
            var dayOfWeek = (int)dateTime.DayOfWeek;
            return dateTime.Add(new TimeSpan((6 - dayOfWeek), 0, 0, 0));
        }

        /// <summary>
        /// Returns latest date of given enumeration.
        /// </summary>
        /// <param name="dates">The DateTime collection to check.</param>
        /// <returns>Latest date in collection (if any exist); HealthYes EpochDate otherwise.</returns>
        public static DateTime GetLatestDate(this IEnumerable<DateTime> dates)
        {
            try
            {
                return dates.OrderByDescending(d => d).First();
            }
            catch (InvalidOperationException)
            {
                // TODO: Retrieve epoch date from common location.
                return new DateTime(2000, 1, 1);
            }
        }

        /// <summary>
        /// Gets the given date with the time set to 12:00:00 AM.
        /// </summary>
        /// <param name="dateTime">The date to get the first second of.</param>
        /// <returns>The given date with the time set to the first second of the day.</returns>
        public static DateTime GetStartOfDay(this DateTime dateTime)
        {
            var dateTimeToReturn = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                00, 00, 00);
            return dateTimeToReturn;
        }

        /// <summary>
        /// Gets the given date with the time set to 11:59:59 PM.
        /// </summary>
        /// <param name="dateTime">The date to get the last second of.</param>
        /// <returns>The given date with the time set to the last second of the day.</returns>
        public static DateTime GetEndOfDay(this DateTime dateTime)
        {
            var dateTimeToReturn = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                23, 59, 59);
            return dateTimeToReturn;
        }

        /// <summary>
        /// Gets the given date with the different time.
        /// </summary>
        /// <param name="dateTime">The date to get.</param>
        /// <param name="hour">New hour for the given date.</param>
        /// <param name="minutes">New minutes for the given date.</param>
        /// <param name="seconds">New seconds for the given date.</param>
        /// <returns>The given date with the new time set to.</returns>
        public static DateTime GetDateWithDifferentTime(this DateTime dateTime, int hour, int minutes, int seconds)
        {
            return dateTime.Date.Add(new TimeSpan(hour, minutes, seconds));
        }

        public static int GetAge(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
            var birth = dateTime;
            var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

            var currentDayOfYear = now.DayOfYear;
            if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                currentDayOfYear = now.DayOfYear - 1;
            else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                currentDayOfYear = now.DayOfYear + 1;

            var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
            return years;
        }

        public static string GetDetailAge(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
            var birth = dateTime;
            var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

            var currentDayOfYear = now.DayOfYear;
            if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                currentDayOfYear = now.DayOfYear - 1;
            else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                currentDayOfYear = now.DayOfYear + 1;

            var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
            var months = (12 + now.Month - birth.Month - ((now.Day < birth.Day) ? 1 : 0)) % 12;
            var days = now.Day - birth.Day;
            if (days < 0)
                days = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddDays(days).Day;

            //if (days < 0)
            //    days = now.Day - 1;

            return years + " Years " + months + " Months " + days + " Days";

        }

        public static bool IsAgeGreaterThan(this DateTime dateTime, int age)
        {
            var now = DateTime.Now;
            var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
            var birth = dateTime;
            var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

            var currentDayOfYear = now.DayOfYear;
            if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                currentDayOfYear = now.DayOfYear - 1;
            else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                currentDayOfYear = now.DayOfYear + 1;

            var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
            var months = (12 + now.Month - birth.Month - ((now.Day < birth.Day) ? 1 : 0)) % 12;
            var days = now.Day - birth.Day;
            if (days < 0)
                days = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddDays(days).Day;

            if (years > age) return true;
            if (years == age && (months > 0 || days > 0)) return true;

            return false;
        }

        public static bool IsAgeLessThanEqualTo(this DateTime dateTime, int age)
        {
            var now = DateTime.Now;
            var checkCurrentLeapYear = new DateTime(now.Year, 3, 1);
            var birth = dateTime;
            var checkBirthLeapYear = new DateTime(birth.Year, 3, 1);

            var currentDayOfYear = now.DayOfYear;
            if (checkCurrentLeapYear.DayOfYear == 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear != 61)
                currentDayOfYear = now.DayOfYear - 1;
            else if (checkCurrentLeapYear.DayOfYear != 61 && now.Month >= checkCurrentLeapYear.Month && checkBirthLeapYear.DayOfYear == 61)
                currentDayOfYear = now.DayOfYear + 1;

            var years = now.Year - birth.Year - ((currentDayOfYear < birth.DayOfYear) ? 1 : 0);
            var months = (12 + now.Month - birth.Month - ((now.Day < birth.Day) ? 1 : 0)) % 12;
            var days = now.Day - birth.Day;
            if (days < 0)
                days = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddDays(days).Day;

            if (years > age) return false;
            if (years == age && (months > 0 || days > 0)) return false;

            return true;
        }

        public static DateTime GetFirstDateOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        public static DateTime GetLastDateOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
    }
}