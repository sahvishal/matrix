using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class TimeZoneHelper : ITimeZoneHelper
    {
        public IEnumerable<TimeZoneSettings> GetTimeZones()
        {
            return new List<TimeZoneSettings>
            {
                new TimeZoneSettings
                {
                    Hours = 10,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -10:00  U.S. Hawaiian Time",
                    IsDayLightSaving=false
                },new TimeZoneSettings
                {
                    Hours = 9,
                    Minutes = 30,
                    IsNegative = true,
                    Name = "GMT -09:30  Marquesas",
                    IsDayLightSaving=false
                }
                ,new TimeZoneSettings
                {
                    Hours = 9,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -09:00  U.S. Alaska Time",
                    IsDayLightSaving=true
                }
                ,new TimeZoneSettings
                {
                    Hours = 8,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -08:00  Pacific Time",
                    IsDayLightSaving=true
                }
                ,new TimeZoneSettings
                {
                    Hours = 7,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -07:00  U.S. Mountain Time",
                    IsDayLightSaving=true,
                }
                ,new TimeZoneSettings
                {
                    Hours = 7,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -07:00  U.S. Mountain Time (Arizona)",
                    IsDayLightSaving=false
                }
                ,new TimeZoneSettings
                {
                    Hours = 6,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -06:00  U.S. Central Time",
                    IsDayLightSaving=true
                }
                 ,new TimeZoneSettings
                {
                    Hours = 6,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -06:00  Mexico",
                    IsDayLightSaving = false
                }
                 ,new TimeZoneSettings
                {
                    Hours = 5,
                    Minutes = 0,
                    IsNegative = true,
                    Name = "GMT -05:00  U.S. Eastern Time",
                    IsDayLightSaving = true
                }
                //,new TimeZoneSettings
                //{
                //    Hours = 5,
                //    Minutes = 0,
                //    IsNegative = true,
                //    Name = "GMT -05:00  U.S. Eastern Time (Indiana)",
                //    IsDayLightSaving = true
                //}
            };
        }
    }
}
