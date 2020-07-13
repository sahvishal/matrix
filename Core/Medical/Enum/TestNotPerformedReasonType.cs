using System.ComponentModel;

namespace Falcon.App.Core.Medical.Enum
{
    public enum TestNotPerformedReasonType
    {
        [Description("Patient refused")]
        PatientRefused = 1,
        Contraindication = 2,
        [Description("Patient Left Without Test Being Performed")]
        PatientLeftWithoutTestBeingPerformed = 3,
        [Description("Test previously performed this year")]
        TestPreviouslyPerformedThisYear = 4,
        [Description("Equipment Malfunction")]
        EquipmentMalfunction = 5,
        [Description("Test Unreadable")]
        TestUnreadable = 6,
        [Description("Supply Issue")]
        SupplyIssue = 7,
        [Description("Staff Not Available")]
        StaffNotAvailable = 8,
        [Description("Plan Restriction")] 
        PlanRestriction = 9
    }
}
