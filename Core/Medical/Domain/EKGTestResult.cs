using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class EKGTestResult : TestResult
    {
        public ResultReading<int?> VentRate { get; set; }
        public ResultReading<int?> RRInterval { get; set; }
        public ResultReading<decimal?> PRInterval { get; set; }
        public ResultReading<decimal?> QRSDuration { get; set; }
        public ResultReading<decimal?> QTInterval { get; set; }
        public ResultReading<decimal?> QTcInterval { get; set; }
        public ResultReading<int?> QTDispersion { get; set; }
        public PRTAxis PRTAxis { get; set; }

        public ResultReading<bool> SinusRythm { get; set; }
        public ResultReading<bool> SinusArrythmia { get; set; }
        public ResultReading<bool> SinusBradycardia { get; set; }
        public ResultReading<bool> Mild { get; set; }
        public ResultReading<bool> Marked { get; set; }
        public ResultReading<bool> SinusTachycardia { get; set; }
        public ResultReading<bool> AtrialFibrillation { get; set; }
        public ResultReading<bool> AtrialFlutter { get; set; }
        public ResultReading<bool> SupraventricularArrythmia { get; set; }
        public ResultReading<bool> SVT { get; set; }
        public ResultReading<bool> PACs { get; set; }
        public ResultReading<bool> PVCs { get; set; }
        public ResultReading<bool> PacerRythm { get; set; }
        
        public ResultReading<bool> BundleBranchBlock { get; set; }
        public List<StandardFinding<int>> BundleBranchBlockFinding { get; set; }
        public ResultReading<bool> LeftAnteriorFasicularBlock { get; set; }
        public ResultReading<bool> VentricularHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricularHypertrophy { get; set; }
        public ResultReading<bool> RightVentricularHypertrophy { get; set; }
        public ResultReading<bool> IschemicSTTChanges { get; set; }
        public ResultReading<bool> NonSpecificSTTChanges { get; set; }
        public ResultReading<bool> PoorRWaveProgression { get; set; }
        public ResultReading<bool> ProlongedQTInterval { get; set; }
        public ResultReading<bool> InfarctionPattern { get; set; }
        public List<StandardFinding<int>> InfarctionPatternFinding { get; set; }
        public ResultReading<bool> AtypicalQWaveLead { get; set; }
        public ResultReading<bool> AtrialEnlargement { get; set; }
        public ResultReading<bool> LeftAtrialEnlargement { get; set; }
        public ResultReading<bool> RightAtrialEnlargement { get; set; }
        public ResultReading<bool> RepolarizationVariant { get; set; }

        public ResultReading<bool> QRSWidening { get; set; }
        public ResultReading<bool> LeftAxis { get; set; }
        public ResultReading<bool> RightAxis { get; set; }
        public ResultReading<bool> AbnormalAxis { get; set; }
        public ResultReading<bool> Left { get; set; }
        public ResultReading<bool> Right { get; set; }
        public ResultReading<bool> HeartBlock { get; set; }
        public ResultReading<bool> TypeI { get; set; }
        public ResultReading<bool> TypeII { get; set; }
        public ResultReading<bool> FirstDegreeBlock { get; set; }
        public ResultReading<bool> SecondDegreeBlock { get; set; }
        public ResultReading<bool> ThirdDegreeCompleteHeartBlock { get; set; }
        public ResultReading<bool> Artifact { get; set; }

        public ResultReading<bool> ReversedLeads { get; set; }
        public ResultReading<bool> RepeatStudy { get; set; }
        public ResultReading<bool> ComparetoEkg { get; set; }

        public ResultReading<bool> LowVoltage { get; set; }
        public ResultReading<bool> LimbLeads { get; set; }
        public ResultReading<bool> PrecordialLeads { get; set; }



        public ResultMedia ResultImage { get; set; }

        public StandardFinding<int?> Finding { get; set; }

        public EKGTestResult()
            : this(0)
        { }

        public EKGTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.EKG;
        }
    }
}
