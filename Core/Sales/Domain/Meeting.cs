using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Sales.Domain
{
    public class Meeting: Activity
    {
        public string Venue { get; set; }
        public DateTime MeetingTime { get; set; }
        public int Duration { get; set; }
        public List<long> ContactIds { get; set; }

        public List<Activity> FollowUps { get; set; }
        
    }
}