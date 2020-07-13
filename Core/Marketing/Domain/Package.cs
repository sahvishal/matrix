using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class Package : DomainObjectBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long PackageTypeId { get; set; }
        public bool IsSelectedByDefaultforEvent { get; set; }
        public long RelativeOrder { get; set; }

        public List<Test> Tests { get; set; }
        public bool ShowInPublicWebsite { get; set; }

        public bool IsActive { get; set; }

        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public long? ForOrderDisplayFileId { get; set; }

        public string PackageInfoUrl { get; set; }

        public string DescriptiononUpsellSection { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        public int ScreeningTime { get; set; }

        public long? HealthAssessmentTemplateId { get; set; }

        public long Gender { get; set; }

        public Package()
        { }

        public Package(long packageId)
            : base(packageId)
        { }
    }
}