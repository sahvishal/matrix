using System.ComponentModel;

namespace Falcon.App.Core.Enum
{
    public enum LabInboundTestType
    {
        Echo = 54,

        [Description("A1c")]
        A1C = 59,

        [Description("Lipid Panel")]
        LipidPanel = 57,

        [Description("EKG")]
        Ekg = 50,

        [Description("DRE")]
        DiabeticRetinopathy = 73,

        [Description("LEAD Ultrasound")]
        Lead = 35,

        [Description("Carotid Artery Ultrasound")]
        CarotidArteryUltrasound = 1,

        [Description("Microalbumin Kit")]
        UrineMicroalbumin = 89,

        [Description("Pneumococcal Vaccine")]
        PneumococcalVaccine = 74,

        [Description("Flu Vaccine")]
        FluShot = 31,

        [Description("Flu Vaccine")]
        AwvFluShot = 83,

        [Description("Bone Density")]
        BoneDensity = 60,

        [Description("ABI")]
        AwvAbi = 53,

        [Description("Mammo")]
        MammographyTest = 16,

        [Description("Mammo")]
        ScreeningMammographyDigital = 29,

        [Description("Abd Aortic Ultrasound")]
        Aaa = 10,

        [Description("PFT")]
        AwvSpirometry = 52,

        [Description("BP")]
        BloodPressure = 67,

        [Description("AWV AAA")]
        AwvAaa = 55,

        [Description("iFOBT")]
        Ifobt = 75,

        [Description("Monofilament")]
        Monofilament = 91,

        [Description("QuantaFlo-ABI")]
        QuantaFloAbi = 94
    }
}
