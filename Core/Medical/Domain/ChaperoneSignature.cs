﻿using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class ChaperoneSignature : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public long? SignatureFileId { get; set; }

        public long StaffSignatureFileId { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedBy { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }
    }
}
