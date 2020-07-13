using System;

namespace Falcon.App.Core.Scheduling
{
    public interface ISmsHelper
    {
        DateTime ConvertLocalTimeToClientTime(DateTime serverTime, string timeZone);
        DateTime CalculatefromClientToServer(DateTime clientTime, string timeZone);
        DateTime ConvertLocalTimeToCompleteClientTime(DateTime serverTime, string timeZone);
        DateTime ConvertToServerTime(DateTime clientTime, string timeZone, bool isDaylightSavingApplicable = true);
    }
}
