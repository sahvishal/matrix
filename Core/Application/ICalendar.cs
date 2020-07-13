using System;

namespace Falcon.App.Core.Application
{
    public interface ICalendar
    {
        DateTime Now { get; }
    }
}