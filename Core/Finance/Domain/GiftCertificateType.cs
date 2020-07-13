using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class GiftCertificateType : DomainObjectBase
    {
        public long OrganizationRoleUserCreatorId { get; set; }
        public long ImageId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public GiftCertificateType()
        {}

        public GiftCertificateType(long giftCertificateTypeId)
            : base(giftCertificateTypeId)
        {}
    }
}