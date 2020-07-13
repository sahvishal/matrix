using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.ValueType
{
    public sealed class TestGroup
    {
        public static long[] AwvTestIds = { (long)TestType.AWV, (long)TestType.AwvSubsequent, (long)TestType.Medicare };

        public static long[] BloodWorkTestIds = { (long)TestType.Thyroid, (long)TestType.Psa, (long)TestType.Crp, (long)TestType.Testosterone, (long)TestType.MenBloodPanel, (long)TestType.WomenBloodPanel, (long)TestType.VitaminD };

        public static long[] BasicBiometricReportTestIds = { (long)TestType.Hypertension, (long)TestType.Lipid, (long)TestType.AwvGlucose, (long)TestType.Diabetes, (long)TestType.A1C, (long)TestType.AwvHBA1C, };

        public static long[] MensBloodPanelTestIds = { (long)TestType.Psa, (long)TestType.Crp, (long)TestType.Testosterone };

        public static long[] WomenBloodPanelTestIds = { (long)TestType.Thyroid, (long)TestType.Crp, (long)TestType.VitaminD };

        public static long[] OsteoTestIds = { (long)TestType.Osteoporosis, (long)TestType.AwvBoneMass };

        public static long[] PadTestIds = { (long)TestType.PAD, (long)TestType.AwvABI };

        public static long[] AaaTestIds = { (long)TestType.AAA, (long)TestType.HCPAAA, (long)TestType.AwvAAA, (long)TestType.PPAAA };

        public static long[] StrokeTesIds = { (long)TestType.Stroke, (long)TestType.HCPCarotid, (long)TestType.AwvCarotid };

        public static long[] EchoTestIds = { (long)TestType.Echocardiogram, (long)TestType.HCPEcho, (long)TestType.AwvEcho, (long)TestType.PPEcho };

        public static long[] SpiroTestIds = { (long)TestType.Spiro, (long)TestType.AwvSpiro };

        public static long[] FluShotTestIds = { (long)TestType.FluShot, (long)TestType.Pneumococcal, (long)TestType.AwvFluShot };

        public static long[] UltraSoundImageTestIds =
        {
            (long)TestType.AAA, (long)TestType.HCPAAA, (long)TestType.AwvAAA, (long)TestType.PPAAA,
            (long)TestType.Stroke, (long)TestType.HCPCarotid, (long)TestType.AwvCarotid,
            (long)TestType.Echocardiogram, (long)TestType.HCPEcho, (long)TestType.AwvEcho, (long)TestType.PPEcho
        };

        public static long[] AttachUploadedPdfTestIds =
        {
            (long) TestType.AWV, (long) TestType.AwvSubsequent,
            (long) TestType.Medicare, (long) TestType.DiabeticRetinopathy, (long) TestType.eAWV, (long) TestType.FloChecABI
        };

        // public static long[] BreastCancer = { (long)TestType.BreastCancer, (long)TestType.Mammogram };
        public static long[] BreastCancer = { (long)TestType.Mammogram };

        public static long[] TestReviewableByPhysician =
        {
            (long) TestType.Lead, (long) TestType.AwvEkg, (long) TestType.AwvEcho,
            (long) TestType.AwvAAA, (long) TestType.AwvCarotid
        };

        public static long[] TestIdForIpPdf =
        {
            (long) TestType.Lead, (long) TestType.AwvEkg, (long) TestType.AwvEcho,
            (long) TestType.AwvAAA
        };

        public static string[] SinglePdfTest = new string[] { TestType.Lead.ToString(), TestType.AwvEcho.ToString(), TestType.AwvAAA.ToString(), TestType.AwvEkg.ToString() };
        public static string[] FormType = new string[] { PatientFormType.Chaperone.ToString() };
    }
}
