using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class ExitInterviewAnswer : DomainObjectBase
    {
        public long EventCustomerId { get; set; }

        public long QuestionId { get; set; }

        public string Answer { get; set; }

        public int Version { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public long? ModifiedBy { get; set; }
    }
}
