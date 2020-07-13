using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class DiabeticRetinopathyTestResult : TestResult
    {
        public ResultReading<bool> SuspectedVeinOcclusion { get; set; }
        public ResultReading<bool> SuspectedWetAmd { get; set; }
        public ResultReading<bool> SuspectedHtnRetinopathy { get; set; }
        public ResultReading<bool> SuspectedEpiretinalMembrane { get; set; }
        public ResultReading<bool> SuspectedMacularHole { get; set; }
        public ResultReading<bool> SuspectedCataract { get; set; }
        public ResultReading<bool> SuspectedOtherDisease { get; set; }
        public ResultReading<bool> SuspectedGlaucoma { get; set; }
        public ResultReading<bool> SuspectedDryAmd { get; set; }

        //property will not to be show on UI
        public ResultReading<bool> DiabeticRetinopathyHighestLevelOfSpecificity { get; set; }
        public StandardFinding<int> DiabeticRetinopathyLevel { get; set; }

        //property will not to be show on UI
        public ResultReading<bool> MacularEdemaHighestLevelOfSpecificity { get; set; }
        public StandardFinding<int> MacularEdemaLevel { get; set; }

        public StandardFinding<int> Finding { get; set; }

        public ResultMedia ResultImage { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }

        public DiabeticRetinopathyTestResult()
            : this(0)
        { }

        public DiabeticRetinopathyTestResult(long id)
            : base(id)
        { TestType = TestType.DiabeticRetinopathy; }
    }
}