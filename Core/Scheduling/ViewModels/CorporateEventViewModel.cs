using System;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CorporateEventViewModel 
    {
        public long EventId { get; set; } 
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public Address Address { get; set; }
        public string Pod { get; set; }
        public int CustomerCount { get; set; }
    }

   
}
