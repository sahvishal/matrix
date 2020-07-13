using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class BloodworksLabelViewModel
    {
        public DateTime TestDate { get; set; }
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public Address CustomerAddress { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string BloodTests { get; set; }
        public long EventId { get; set; }
        public IEnumerable<long> BloodTestIds { get; set; }
    }
}
