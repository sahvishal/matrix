using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Users.Domain
{
    public class User : DomainObjectBase
    {
        public UserLogin UserLogin { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }
        public Email AlternateEmail { get; set; }
        public PhoneNumber HomePhoneNumber { get; set; }
        public PhoneNumber OfficePhoneNumber { get; set; }
        public PhoneNumber MobilePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Roles DefaultRole { get; set; }

        // Used in Ajax calls.
        public string NameAsString { get { return Name != null ? Name.ToString() : string.Empty; } }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public string PhoneOfficeExtension { get; set; }

        public string Ssn { get; set; }

        public User()
        {}

        /// <remarks>
        /// In all derived types, a constructor must be provided that takes one parameter, the userId.
        /// </remarks>
        public User(long userId)
            : base(userId)
        {}
    }
}