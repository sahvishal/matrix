using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class HcpEchocardiogramTestResult : MediaTestResult
    {
        public StandardFinding<int> Finding { get; set; }
        public StandardFinding<int> EstimatedEjactionFraction { get; set; }

        public ResultReading<bool> Aortic { get; set; }
        public List<StandardFinding<int>> AorticMorphology { get; set; }
        public StandardFinding<int> AorticRegurgitation { get; set; }

        public ResultReading<bool> Mitral { get; set; }
        public List<StandardFinding<int>> MitralMorphology { get; set; }
        public StandardFinding<int> MitralRegurgitation { get; set; }

        public ResultReading<bool> Pulmonic { get; set; }
        public List<StandardFinding<int>> PulmonicMorphology { get; set; }
        public StandardFinding<int> PulmonicRegurgitation { get; set; }

        public ResultReading<bool> Tricuspid { get; set; }
        public List<StandardFinding<int>> TricuspidMorphology { get; set; }
        public StandardFinding<int> TricuspidRegurgitation { get; set; }

        public ResultReading<string> AoticVelocity { get; set; }
        public ResultReading<string> MitralPT { get; set; }
        public ResultReading<string> PulmonicVelocity { get; set; }
        public ResultReading<string> TricuspidVelocity { get; set; }
        public ResultReading<string> TricuspidPap { get; set; }

        public ResultReading<bool> DiastolicDysfunction { get; set; }
        public StandardFinding<int> DistolicDysfunctionFinding { get; set; }

        public ResultReading<bool> PericardialEffusion { get; set; }
        public List<StandardFinding<int>> PericardialEffusionFinding { get; set; }

        public ResultReading<bool> VentricularEnlargement { get; set; }
        public ResultReading<bool> LeftVentricularEnlargment { get; set; }
        public ResultReading<string> LeftVentricularEnlargmentValue { get; set; }
        public ResultReading<bool> RightVentricularEnlargment { get; set; }
        public ResultReading<string> RightVentricularEnlargmentValue { get; set; }

        public ResultReading<bool> AorticRoot { get; set; }
        public ResultReading<bool> Sclerotic { get; set; }
        public ResultReading<bool> Calcified { get; set; }
        public ResultReading<bool> Enlarged { get; set; }
        public ResultReading<string> EnlargedValue { get; set; }

        public ResultReading<bool> VentricularHypertrophy { get; set; }
        public ResultReading<string> LeftVHypertrophyValue { get; set; }
        public ResultReading<string> RightVHypertrophyValue { get; set; }
        public ResultReading<string> IvshHypertrophyValue { get; set; }
        public ResultReading<bool> LeftVHypertrophy { get; set; }
        public ResultReading<bool> RightVHypertrophy { get; set; }
        public ResultReading<bool> IvshHypertrophy { get; set; }

        public ResultReading<bool> AtrialEnlargement { get; set; }
        public ResultReading<bool> LeftAtrialEnlargment { get; set; }
        public ResultReading<bool> RightAtrialEnlargment { get; set; }
        public ResultReading<string> LeftAtrialEnlargmentValue { get; set; }
        public ResultReading<string> RightAtrialEnlargmentValue { get; set; }
        public ResultReading<bool> Arrythmia { get; set; }

        public ResultReading<bool> AFib { get; set; }
        public ResultReading<bool> AFlutter { get; set; }
        public ResultReading<bool> PAC { get; set; }
        public ResultReading<bool> PVC { get; set; }

        public ResultReading<bool> ASD { get; set; }
        public ResultReading<bool> PFO { get; set; }
        public ResultReading<bool> VSD { get; set; }
        public ResultReading<bool> FlailAS { get; set; }
        public ResultReading<bool> SAM { get; set; }
        public ResultReading<bool> LVOTO { get; set; }
        public ResultReading<bool> MitralAnnularCa { get; set; }

        public ResultReading<bool> Hypokinetic { get; set; }
        public ResultReading<bool> Akinetic { get; set; }
        public ResultReading<bool> Dyskinetic { get; set; }
        public ResultReading<bool> Anterior { get; set; }
        public ResultReading<bool> Posterior { get; set; }
        public ResultReading<bool> Apical { get; set; }
        public ResultReading<bool> Septal { get; set; }
        public ResultReading<bool> Lateral { get; set; }
        public ResultReading<bool> Inferior { get; set; }

        public ResultReading<bool> RestrictedLeafletMotion { get; set; }
        public ResultReading<bool> RestrictedLeafletMotionAortic { get; set; }
        public ResultReading<bool> RestrictedLeafletMotionMitral { get; set; }
        public ResultReading<bool> RestrictedLeafletMotionPulmonic { get; set; }
        public ResultReading<bool> RestrictedLeafletMotionTricuspid { get; set; }

        public ResultReading<bool> TechnicallyLimitedbutReadable { get; set; }
        public ResultReading<bool> RepeatStudyUnreadable { get; set; }

        public ResultReading<bool> MorphologyTricuspidHighOrGreater { get; set; }
        public ResultReading<bool> MorphologyTricuspidNormal { get; set; }

        public HcpEchocardiogramTestResult()
            : this(0)
        { }

        public HcpEchocardiogramTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.HCPEcho;
        }
    }
}