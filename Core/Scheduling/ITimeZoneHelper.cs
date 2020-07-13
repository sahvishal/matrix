using Falcon.App.Core.Scheduling.ViewModels;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling
{
    public interface ITimeZoneHelper
    {
        IEnumerable<TimeZoneSettings> GetTimeZones();
    }
}
