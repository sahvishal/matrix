using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Domain.MedicalVendors
{
    public class PhysicianMaster : DomainObjectBase
    {
        public string Npi { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PrefixText { get; set; }
        public string SuffixText { get; set; }
        public string CredentialText { get; set; }
        public string PracticeAddress1 { get; set; }
        public string PracticeAddress2 { get; set; }
        public string PracticeCity { get; set; }
        public string PracticeState { get; set; }
        public string PracticeZip { get; set; }
        public PhoneNumber PracticePhone { get; set; }
        public PhoneNumber PracticeFax { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsImported { get; set; }
        public bool IsActive { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }

        public PhysicianMaster()
        { }

        public PhysicianMaster(long physicianMasterId)
            : base(physicianMasterId)
        { }
    }
}
