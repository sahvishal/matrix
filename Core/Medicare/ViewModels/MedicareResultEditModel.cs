namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareResultEditModel
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public long PhysicianOruId { get; set; }
        public string PhysicianName { get; set; }
        public int ResultState { get; set; }
        public string MammogramReading { get; set; }
        public int AwvEchoStateNumber { get; set; }
        public int MonoFilamentStateNumber { get; set; }
        public string AwvEchoFindingLabel { get; set; }
        public int AwvLipidStateNumber { get; set; }
        public string AwvLipidTotalCholestrol { get; set; }
        public int AwvSpiroStateNumber { get; set; }
        public string AwvSpiroFindingLabel { get; set; }
        public string AwvSpiroObstructiveLabel { get; set; }

        public int AwvDrsStateNumber { get; set; }
        public int AwvUrinStateNumber { get; set; }
        public string AwvUrinFindingLabel { get; set; }
        public int AwvEkgStateNumber { get; set; }
        public int AwvHbA1CStateNumber { get; set; }
        public AaaReadings AaaResult { get; set; }
        public PadTestReadings PadReading { get; set; }
        public QuantaFloReadings QuantaFloReading { get; set; }
        public LeadReadings LeadReading { get; set; }
        public EchocardiogramReadings EchocardiogramReading { get; set; }
        public Bp BpReading { get; set; }
        public Lipid LipidReading { get; set; }

        public class Lipid
        {
            public string Tc { get; set; }
            public int? Ldl { get; set; }
            public string Hdl { get; set; }
            public string Trig { get; set; }
        }
        public class Bp
        {
            public int? Systolic { get; set; }
            public int? Diastolic { get; set; } 
        }
        public class AaaReadings
        {
            public string AortaSize { get; set; }
            public bool AorticDissection { get; set; }
            public bool Plaque { get; set; }
            public bool Thrombus { get; set; }
            public bool AorticStenosis { get; set; }
        }
        public class PadTestReadings
        {
            public string Finding { get; set; }
        }
        public class QuantaFloReadings
        {
            public string Finding { get; set; }
        }
        public class LeadReadings
        {
            public bool LNoVisualPlaque { get; set; }
            public bool LVisuallyDemonstratedPlaque { get; set; }
            public bool LModerateStenosis { get; set; }
            public bool LPossibleOcclusion { get; set; }
            public bool LowVelocityLeft { get; set; }

            public bool RNoVisualPlaque { get; set; }
            public bool RVisuallyDemonstratedPlaque { get; set; }
            public bool RModerateStenosis { get; set; }
            public bool RPossibleOcclusion { get; set; }
            public bool LowVelocityRight { get; set; }


        }
        public class EchocardiogramReadings
        {
            public int EstimatedEjactionFractionMin { get; set; }
            public int EstimatedEjactionFractionMax { get; set; }
            public bool Aortic { get; set; }
            public bool AorticStenosis { get; set; }
            public string AorticRegurgitation { get; set; }

            public bool Mitral { get; set; }
            public bool MitralStenosis { get; set; }
            public bool MitralProlapse { get; set; }
            public string MitralRegurgitation { get; set; }

            public bool Pulmonic { get; set; }
            public string PulmonicRegurgitation { get; set; }

            public bool Tricuspid { get; set; }
            public string TricuspidRegurgitation { get; set; }
            public string TricuspidPap { get; set; }
            public bool HighOrGreater { get; set; }


            public bool DiastolicDysfunction { get; set; }
            public string DistolicDysfunctionFinding { get; set; }
            public string DiastolicDysfunctionEeRatio { get; set; }


            public bool AorticRoot { get; set; }
            public bool Sclerotic { get; set; }
            public bool Atherosclerosis { get; set; }
            
            public bool VentricularHypertrophy { get; set; }
            public bool Arrythmia { get; set; }
            public bool AFib { get; set; }
            public bool AFlutter { get; set; }
        }
    }
}
