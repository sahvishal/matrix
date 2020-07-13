using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentFooterEditModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }

        public DateTime EventDate { get; set; }

        public string EmergencyContact { get; set; }
        public string Relationship { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
}
