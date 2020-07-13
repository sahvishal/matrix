using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class GiftCertificateViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public decimal GiftAmmount { get; set; }

        public bool? GiftCardReceived { get; set; }
        public string PatientSignatureUrl { get; set; }
        public string TechnicianSignatureUrl { get; set; }
    }
}