using System.ComponentModel;

namespace Falcon.App.Core.OutboundReport.Enum
{
    public enum OutboundUploadType
    {
        [Description("Chase Outbound")]
        ChaseOutbound = 306,

        [Description("Care Coding Outbound")]
        CareCodingOutbound = 307,

        [Description("Patient Detail")]
        PatientDetail = 329,

        [Description("Diagnosis Report")]
        DiagnosisReport = 330,

        [Description("Loinc Crosswalk")]
        LoincCrosswalk = 341,

        [Description("Loinc Lab Data")]
        LoincLabData = 342
    }
}
