using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.Enum
{
    public enum RescheduleAppointmentSubReason
    {
        [Description("Field/Bus Issue")]
        FieldBusIssue = 1,

        [Description("RED FLAG")]
        REDFLAG = 2,

        [Description("YELLOW FLAG")]
        YELLOWFLAG = 3,

        [Description("Unit request")]
        UnitRequest = 4,

        [Description("Temporary Mobility Issue")]
        TemporaryMobilityIssue = 5,

        [Description("Out of Town")]
        OutOfTown = 6,

        [Description("Death in family/Funeral")]
        DeathInFamilyFuneral = 7,

        Emergency = 8,

        Work = 9,

        [Description("PT does not have transportation, plan does not offer")]
        PTDoesNotHaveTransportationPlanDoesNotOffer = 10,

        [Description("Matrix Medical Network did not request/confirm transportation")]
        HealthfairDidNotRequestConfirmTransportation = 11,

        [Description("Site Change")]
        SiteChange = 27,

        [Description("Low Volume")]
        LowVolume = 28,

        [Description("Event Cancelled")]
        EventCancelled = 29,

        [Description("Date Change")]
        DateChange = 30,

        [Description("Template Change")]
        TemplateChange = 31,

        [Description("Good News")]
        GoodNews = 32,

        Pack = 33,
    }
}
