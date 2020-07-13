using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class EventCustomerGiftCard : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public bool GiftCardReceived { get; set; }

        public long? PatientSignatureFileId { get; set; }

        public long? TechnicianSignatureFileId { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedBy { get; set; }
    }
}
