using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class QualityAssuranceResultViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int Gender { get; set; }
        public int Race { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public string AlCarteTests { get; set; }
        public DateTime EventDate { get; set; }
    }
}
