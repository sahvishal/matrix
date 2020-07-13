using System.ComponentModel;

namespace Falcon.App.Core.Insurance.Enum
{
    public enum EligibleCoverageStatus
    {
        [Description("Active Coverage")]
        ActiveCoverage = 1,

        [Description("Active - Full Risk Capitation")]
        ActiveFullRiskCapitation = 2,

        [Description("Active - Services Capitated")]
        ActiveServicesCapitated = 3,

        [Description("Active - Services Capitated to Primary Care Physician")]
        ActiveServicesCapitatedToPrimaryCarePhysician = 4,

        [Description("Active - Pending Investigation")]
        ActivePendingInvestigation = 5,

        [Description("Inactive")]
        Inactive = 6,

        [Description("Inactive - Pending Eligibility Update")]
        InactivePendingEligibilityUpdate = 7,

        [Description("Inactive - Pending Investigation")]
        InactivePendingInvestigation = 8,

        [Description("Not Covered")]
        NotCovered = 9,

        [Description("Cannot process")]
        CannotProcess = 10,

        Unknown = 11,

        [Description("Not deemed a medical necessity")]
        NotDeemed = 12,

        [Description("Second surgical opinion required")]
        SecondSurgicalOpinionRequired = 13,

        [Description("Card reported stolen")]
        CardReportedStolen = 14,

        [Description("Contact following entity for coverage info")]
        ContactEntity = 15
    }
}
