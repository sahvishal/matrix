using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public abstract class Territory : DomainObjectBase
    {
        public long? ParentTerritoryId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ZipCode> ZipCodes { get; set; }
        public abstract TerritoryType TerritoryType { get; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetadata { get; set; }

        protected Territory()
        {}

        protected Territory(long territoryId)
            : base(territoryId)
        {}
    }
}