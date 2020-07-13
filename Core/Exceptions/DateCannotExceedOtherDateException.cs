using System;

namespace Falcon.App.Core.Exceptions
{
    public class DateCannotExceedOtherDateException : ArgumentException
    {
        public DateCannotExceedOtherDateException(DateTime exceedingDate, DateTime dateExceeded)
            : base (string.Format("Date {0} cannot exceed date {1}.", exceedingDate.ToShortDateString(),
                dateExceeded.ToShortDateString()))
        {}
    }
}