using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.ValueTypes
{
    [DefaultImplementation(Interface = typeof(ICalendar))]
    public class DateTimeCalendar : ICalendar
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}