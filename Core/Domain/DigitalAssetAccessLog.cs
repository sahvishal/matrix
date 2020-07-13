using System;
namespace Falcon.App.Core.Domain
{
    public class DigitalAssetAccessLog : DomainObjectBase
    {
        public long UserLoginLogId { get; set; }
        public long OrganizationRoleUserId { get; set; }
        public string DigitalAssetType { get; set; }
        public string DigitalAsset { get; set; }
        public DateTime AccessedOn { get; set; }

        public DigitalAssetAccessLog()
        { }

        public DigitalAssetAccessLog(long digitalAssetAccesLogId)
            : base(digitalAssetAccesLogId)
        { }
    }
}
