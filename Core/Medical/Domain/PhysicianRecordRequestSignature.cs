using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class PhysicianRecordRequestSignature : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public long SignatureFileId { get; set; }

        public DateTime ConsentSignedDate { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedBy { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }
    }
}
