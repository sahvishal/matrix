using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum CancelAppointmentSubReason
    {
        [Description("Not Eligible")]
        NotEligible = 12,

        [Description("Change insurance")]
        ChangeInsurance = 13,

        [Description("Request by Healthplan")]
        RequestByHealthplan = 14,

        [Description("Field/Bus Issue")]
        FieldBusIssue = 15,

        [Description("RED FLAG")]
        REDFLAG = 16,

        [Description("YELLOW FLAG")]
        YELLOWFLAG = 17,

        [Description("Unit request")]
        UnitRequest = 18,

        [Description("Temporary Mobility Issue")]
        TemporaryMobilityIssue = 19,

        [Description("Permanent Mobility Issue")]
        PermanentMobilityIssue = 20,

        [Description("PT does not have transportation, plan does not offer")]
        PTDoesNotHaveTransportationPlanDoesNotOffer = 21,

        [Description("Matrix Medical Network did not request/confirm transportation")]
        HealthfairDidNotRequestConfirmTransportation = 22,

        [Description("Out of Town")]
        OutOfTown = 23,

        [Description("Death in family/Funeral")]
        DeathInFamilyFuneral = 24,

        Emergency = 25,

        Work = 26,

        [Description("Site Change")]
        SiteChange = 34,

        [Description("Low Volume")]
        LowVolume = 35,

        [Description("Event Cancelled")]
        EventCancelled = 36,

        [Description("Date Change")]
        DateChange = 37,

        [Description("Template Change")]
        TemplateChange = 38,

        [Description("Good News")]
        GoodNews = 39,

        Pack = 40,
    }
}
