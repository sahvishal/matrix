using System;

namespace Falcon.App.Core.Services.Common.Environment
{
    public interface IClock
    {
        DateTime LocalTime(TimeZone timeZone);        
        DateTime Now { get;}        
    }
}