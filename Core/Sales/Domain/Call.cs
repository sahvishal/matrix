using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Domain
{
    public class Call : Activity
    {
        public DateTime CallDateTime { get; set; }
        public int? Duration { get; set; }        

        public CallDirection? Direction { get; set; }
        public CallResult?  Result { get; set; }

        public List<long> ContactIds { get; set; } //should this be here?
        
        public List<Activity> FollowUps { get; set; }

    }
}