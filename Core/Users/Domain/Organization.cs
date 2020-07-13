using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Users.Domain
{
    public class Organization : DomainObjectBase
    {
        public Organization()
        {}

        public Organization(long organizationId)
            : base(organizationId)
        {}

        public Organization(Organization organization)
        {
            Name = organization.Name;
            Description = organization.Description;
            BusinessAddressId = organization.BusinessAddressId;
            BillingAddressId = organization.BillingAddressId;
            PhoneNumber = organization.PhoneNumber;
            FaxNumber = organization.FaxNumber;
            Email = organization.Email;
            LogoImageId = organization.LogoImageId;
            TeamImageId = organization.TeamImageId;
            Id = organization.Id;
            OrganizationType = organization.OrganizationType;
        }
        
        public OrganizationType OrganizationType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public long BusinessAddressId { get; set; }
        public long BillingAddressId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public PhoneNumber FaxNumber { get; set; }
        public string Email { get; set; }
        public long LogoImageId { get; set; }
        public long TeamImageId { get; set; }
    }
}