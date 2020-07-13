using System.Collections.Generic;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class HospitalPartnerTerritory : Territory
    {
        public List<long> HospitalPartnerOwnerIds { get; set; }
        public override TerritoryType TerritoryType { get { return TerritoryType.HospitalPartner; } }

        public HospitalPartnerTerritory()
        {}

        public HospitalPartnerTerritory(long territoryId)
            : base(territoryId)
        {
            
        }
    }
}