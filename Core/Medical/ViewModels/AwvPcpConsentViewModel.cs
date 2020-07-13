using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class AwvPcpConsentViewModel
    {
        public Name CustomerName { get; set; }
        public DateTime ScreeningDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public PrimaryCarePhysician Pcp { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }

        public bool Print { get; set; }
        public string PrintUrl { get; set; }

        public string SignatureImageUrl { get; set; }
        public string ConsentSignedDate { get; set; }
    }
}
