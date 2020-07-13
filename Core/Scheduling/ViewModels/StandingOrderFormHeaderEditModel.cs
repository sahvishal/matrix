using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class StandingOrderFormHeaderEditModel : ViewModelBase
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public Name Name { get; set; }
        public long EventId { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DoB { get; set; }
        public IEnumerable<string> PreApporvedTestNames { get; set; }
    }
}