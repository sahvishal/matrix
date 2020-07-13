using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class SmsHelper : ISmsHelper
    {
        private static IEnumerable<TimeZoneSettings> GetTimeZones()
        {
            return new List<TimeZoneSettings>
            {
                new TimeZoneSettings
                {
                    Hours = 10,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -10:00  U.S. Hawaiian Time"
                },new TimeZoneSettings
                {
                    Hours = 9,
                    Minutes = 30,
                    IsNegative = true,
                    Name = "GMT -09:30  Marquesas"
                }
                ,new TimeZoneSettings
                {
                    Hours = 9,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -09:00  U.S. Alaska Time"
                }
                ,new TimeZoneSettings
                {
                    Hours = 8,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -08:00  Pacific Time"
                }
                ,new TimeZoneSettings
                {
                    Hours = 7,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -07:00  U.S. Mountain Time"
                }
                ,new TimeZoneSettings
                {
                    Hours = 7,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -07:00  U.S. Mountain Time (Arizona)"
                }
                ,new TimeZoneSettings
                {
                    Hours = 6,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -06:00  U.S. Central Time"
                }
                 ,new TimeZoneSettings
                {
                    Hours = 6,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -06:00  Mexico"
                }
                 ,new TimeZoneSettings
                {
                    Hours = 5,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -05:00  U.S. Eastern Time"
                }
                //,new TimeZoneSettings
                //{
                //    Hours = 5,
                //    Minutes = 0,
                //    IsNegative = true,
                //    Name = "GMT -05:00  U.S. Eastern Time (Indiana)"
                //}
            };
        }

        public static readonly string[] DaylightSavingNotApplicableStates = { "AZ", "HI", "VI", "PR", "GU" };
        //Todo: Move into ICalander
        public DateTime CalculatefromClientToServer(DateTime clientTime, string timeZone)
        {
            var timeZoneSetting = GetTimeZones().FirstOrDefault(x => x.Name == timeZone || x.Name.Contains(timeZone));

            var offsetHours = (DateTime.Now - DateTime.UtcNow).TotalHours;

            var clientTimeOnUtc = (timeZoneSetting.IsNegative)
                ? clientTime.AddHours(timeZoneSetting.Hours).AddMinutes(timeZoneSetting.Minutes)
                : clientTime.AddHours(-timeZoneSetting.Hours).AddMinutes(-timeZoneSetting.Minutes);

            var serverTime = (DateTime.Now > DateTime.UtcNow)
                 ? clientTimeOnUtc.AddHours(offsetHours)
                 : clientTimeOnUtc.AddHours(-offsetHours);

            return serverTime;
        }

        public DateTime ConvertLocalTimeToClientTime(DateTime serverTime, string timeZone)
        {
            var timeZoneSetting = GetTimeZones().FirstOrDefault(x => x.Name == timeZone || x.Name.Contains(timeZone));
            var utcTime = serverTime.ToUniversalTime();

            var clientTime = (timeZoneSetting.IsNegative)
                 ? utcTime.AddHours(-timeZoneSetting.Hours).AddMinutes(-timeZoneSetting.Minutes)
                 : utcTime.AddHours(timeZoneSetting.Hours).AddMinutes(timeZoneSetting.Minutes);

            return new DateTime(clientTime.Year, clientTime.Month, clientTime.Day, clientTime.Hour, 0, 0);
        }

        public DateTime ConvertLocalTimeToCompleteClientTime(DateTime serverTime, string timeZone)
        {
            var timeZoneSetting = GetTimeZones().First(x => x.Name == timeZone || x.Name.Contains(timeZone));
            var utcTime = serverTime.ToUniversalTime();

            DateTime thisTime = DateTime.Now;
            bool isDaylight = TimeZoneInfo.Local.IsDaylightSavingTime(thisTime);

            timeZoneSetting.Hours = isDaylight ? timeZoneSetting.Hours - 1 : timeZoneSetting.Hours;

            var clientTime = (timeZoneSetting.IsNegative)
                 ? utcTime.AddHours(-timeZoneSetting.Hours).AddMinutes(-timeZoneSetting.Minutes)
                 : utcTime.AddHours(timeZoneSetting.Hours).AddMinutes(timeZoneSetting.Minutes);

            return new DateTime(clientTime.Year, clientTime.Month, clientTime.Day, clientTime.Hour, clientTime.Minute, clientTime.Second);
        }

        public DateTime ConvertToServerTime(DateTime clientTime, string timeZone, bool isDaylightSavingApplicable = true)
        {
            var timeZoneSetting = GetTimeZones().FirstOrDefault(x => x.Name == timeZone || x.Name.Contains(timeZone));

            var settingHours = timeZoneSetting.Hours;
            if (TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.Now) && isDaylightSavingApplicable)
                settingHours = timeZoneSetting.IsNegative ? settingHours - 1 : settingHours + 1;

            var offsetHours = (DateTime.Now - DateTime.UtcNow).TotalHours;

            var clientTimeOnUtc = (timeZoneSetting.IsNegative)
                ? clientTime.AddHours(settingHours).AddMinutes(timeZoneSetting.Minutes)
                : clientTime.AddHours(-settingHours).AddMinutes(-timeZoneSetting.Minutes);

            var serverTime = clientTimeOnUtc.AddHours(offsetHours);

            return serverTime;
        }
    }
}
