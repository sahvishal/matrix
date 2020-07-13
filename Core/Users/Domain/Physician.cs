using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Core.Users.Domain
{
    //TODO: This is more like a model. Need to refactor.
    public class Physician : User
    {
        public long PhysicianId { get; set; }
        public long MedicalVendorId { get; set; }
        
        public long SpecializationId { get; set; }
        public bool CanSeeEarnings { get; set; }
        public bool CanDoAuthorizations { get; set; }
        public bool SkipAudit { get; set; }
        public DateTime? CutOffDate { get; set; }

        public IEnumerable<long> PermittedTests { get; set; }
        
        public IEnumerable<long> AssignedPodIds { get; set; }
        
        public decimal StandardRate { get; set; }
        public decimal OverReadRate { get; set; }

        public IEnumerable<PhysicianLicense> AuthorizedStateLicenses { get; set; }

        public File SignatureFile { get; set; }
        public File ResumeFile { get; set; }

        public bool IsDefault { get; set; }
        
        public string DisplayName { get; set; }

        public bool UpdateResultEntry { get; set; }

        public string Npi { get; set; }
        
        public Physician()
        { }

        public Physician(long userId)
            : base(userId)
        { }

        public Physician(long userId, long physicianId)
            : base(userId)
        {
            PhysicianId = physicianId;
        }
    }
}
