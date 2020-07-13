using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class BasicBiometric : DomainObjectBase
    {
        public int? SystolicPressure { get; set; }
        public int? DiastolicPressure { get; set; }
        public bool IsRightArmBpMeasurement { get; set; }

        public bool IsBloodPressureElevated { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedByOrgRoleUserId { get; set; }

        public int? PulseRate { get; set; }
    }
}
