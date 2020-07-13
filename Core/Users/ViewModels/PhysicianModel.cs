using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class PhysicianModel
    {
        [DisplayName("Specialization")]
        public long SpecializationId { get; set; }

        public bool CanSeeEarnings { get; set; }
        public bool CanDoAuthorizations { get; set; }
        public bool SkipAudit { get; set; }

        [DisplayName("Cut Off Date")]
        public DateTime? CutOffDate { get; set; }

        public IEnumerable<Test> Tests { get; set; }
        public IEnumerable<long> PermittedTests { get; set; }

        public IEnumerable<Pod> Pods { get; set; }
        public IEnumerable<long> AssignedPodIds { get; set; }

        [DisplayName("Standard Rate")]
        public decimal StandardRate { get; set; }

        [DisplayName("OverRead Rate")]
        public decimal OverReadRate { get; set; }

        [DisplayName("License")]
        public IEnumerable<PhysicianLicenseModel> Licenses { get; set; }

        [DisplayName("Digital Signature")]
        public File SignatureFile { get; set; }

        [DisplayName("Resume")]
        public File ResumeFile { get; set; }
        
        public bool IsDefault { get; set; }

        [UIHint("Hidden")]
        public long PhysicianId { get; set; }

        [DisplayName("Display Name")]
        public string DisplayName { get; set; }

        [DisplayName("Update Result Entry")]
        public bool UpdateResultEntry { get; set; }

        [DisplayName("NPI")]
        public string Npi { get; set; }
    }
}
