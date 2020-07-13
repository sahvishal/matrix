using System;

namespace Falcon.App.Core.Services.Common.Environment.Impl
{
    public class Clock : IClock
    {

        private readonly DateTime _currentSystemTime;

        public DateTime LocalTime(TimeZone timeZone)
        {
            throw new NotImplementedException();
        }

        public DateTime Now
        {
            get { return _currentSystemTime; }           
        }

        
        public Clock()
            : this(DateTime.Now)
        {            
        }


        public Clock(DateTime currentSystemTime)
        {
            _currentSystemTime = currentSystemTime;
        }        
    }
}