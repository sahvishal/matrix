using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class CdContentGeneratorTracking : DomainObjectBase
    {
        public long EventCustomerResultId { get; set; }
        public bool IsContentGenerated { get; set; }
        public bool IsContentDownloaded { get; set; }

        public long? DownloadedByOrgRoleUserId { get; set; }
        public DateTime? DownloadedDate { get; set; }
        public DateTime? ContentGeneratedDate { get; set; }

         public CdContentGeneratorTracking()
        { }

         public CdContentGeneratorTracking(long id)
            : base(id)
        { }
    }
}
