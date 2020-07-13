using System.ComponentModel;

namespace Falcon.App.Core.Sales.Enum
{
    public enum HospitalPartnerCustomerOutcome
    {
        [Description("Scheduled")]
        Scheduled = 100,
        [Description("Scheduled with Affiliated PCP")]
        ScheduledWithAffiliatedPcp = 119,
        [Description("Scheduled with Affiliated Specialist")]
        ScheduledWithAffiliatedSpecialist = 120,
        [Description("Referred to Affiliated PCP")]
        ReferredToAffiliatedPcp = 121,
        [Description("Referred to Affiliated Specialist")]
        ReferredToAffiliatedSpecialist = 137,
        [Description("Self Scheduled with Non Affiliated Physician")]
        SelfScheduledWithNonAffiliatedPhysician = 122,
        [Description("Self Scheduled with Affiliated Physician")]
        SelfScheduledWithAffiliatedPhysician = 138,
        [Description("Scheduled with Employed Physician")]
        ScheduledWithEmployedPhysician = 189,
        [Description("Referred to Employed Physician")]
        ReferredToEmployedPhysician = 190,
        [Description("Self Scheduled with Employed Physician")]
        SelfScheduledWithEmployedPhysician = 191,
        [Description("Uninsured")]
        Uninsured = 156,

        [Description("Not Scheduled")]
        NotScheduled = 101,
        [Description("Not Scheduled / Sent Information")]
        NotScheduledSentInformation = 105,

        [Description("Not Scheduled / Not Interested")]
        NotScheduledNotInterested = 132,

        [Description("Not Reached")]
        NotReached = 139,

        Other = 123,

        [Description("Not Called")]
        NotCalled = 147,

        [Description("Requires CallBack")]
        RequiresCallBack = 176

    }
}
