using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class CallCenterNotes : DomainObjectBase
    {
        public long CallId { get; set; }

        public string Notes { get; set; }

        public long NotesSequence { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public bool IsActive { get; set; }

        public CallCenterNotes()
        { }

        public CallCenterNotes(long id)
            : base(id)
        { }
    }
}
