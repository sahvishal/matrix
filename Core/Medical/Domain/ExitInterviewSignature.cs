using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class ExitInterviewSignature : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public long QuestionId { get; set; }

        public long SignatureFileId { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedBy { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }
    }
}
