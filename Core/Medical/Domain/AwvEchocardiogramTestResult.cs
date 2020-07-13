using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class AwvEchocardiogramTestResult : MediaTestResult
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
        public ResultReading<string> PeakGradient { get; set; }
        public ResultReading<string> MitralPT { get; set; }
        public ResultReading<string> PulmonicVelocity { get; set; }
        public ResultReading<string> TricuspidVelocity { get; set; }
        public ResultReading<string> TricuspidPap { get; set; }

        public ResultReading<string> AorticEstimatedValveArea { get; set; }
        public ResultReading<string> MitralEstimatedValveArea { get; set; }
        public ResultReading<string> PulmonicEstimatedValveArea { get; set; }
        public ResultReading<string> TricuspidEstimatedValveArea { get; set; }

        public ResultReading<string> AorticEstimatedRightValve { get; set; }
        public ResultReading<string> MitralEstimatedRightValve { get; set; }

        public ResultReading<bool> DiastolicDysfunction { get; set; }
        public StandardFinding<int> DistolicDysfunctionFinding { get; set; }
        public ResultReading<string> DiastolicDysfunctionEeRatio { get; set; } 

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

        public ResultReading<bool> AscendingAortaArch { get; set; }
        public ResultReading<bool> Atherosclerosis { get; set; }

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
        public ResultReading<bool> FlailAS { get; set; }

        public ResultReading<bool> VSD { get; set; }
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

        public ResultReading<string> Conclusion { get; set; }
       
        public ResultReading<bool> LeftVentricleOverallFunctionNotEvaluated { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionNormal { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionReduced { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionBorderline { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionHyperkinesis { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionHypokinesis { get; set; }
        public ResultReading<bool> LeftVentricleOverallFunctionConsistentLvSystolicFailure { get; set; }

        public ResultReading<bool> LeftVentricleDimensionsNotEvaluated { get; set; }
        public ResultReading<bool> LeftVentricleDimensionsNormal { get; set; }
        public ResultReading<bool> LeftVentricleDimensionsSmall { get; set; }
        public ResultReading<bool> LeftVentricleDimensionsDilated { get; set; }
        public ResultReading<bool> LeftVentricleDimensionsSlightlyEnlarged { get; set; }
        public ResultReading<bool> LeftVentricleDimensionsSeverelyDilated { get; set; }

        public ResultReading<bool> LeftVentricleThicknessesNotEvaluated { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesNormal { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesApicalHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesAsymmetricalHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesIVSeptumObstructiveHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesSevereIVSeptumHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesMinorModerateSymmetricHypertrophy { get; set; }
        public ResultReading<bool> LeftVentricleThicknessesSevereSymmetricHypertrophy { get; set; }
        public ResultReading<string> LeftVentricleComment { get; set; }

        //LeftAtrium
        public ResultReading<bool> LeftAtriumIASLADimensionsNotEvaluated { get; set; }
        public ResultReading<bool> LeftAtriumIASLADimensionsNormal { get; set; }
        public ResultReading<bool> LeftAtriumIASLADimensionsMildlyDilated { get; set; }
        public ResultReading<bool> LeftAtriumIASLADimensionsModeratelyDilated { get; set; } 
        public ResultReading<bool> LeftAtriumIASLADimensionsSeverelyDilated { get; set; }
        public ResultReading<string> LeftAtriumIASComment { get; set; }

        //RightVentricle
        public ResultReading<bool> RightVentricleOverallFunctionNotEvaluated { get; set; }
        public ResultReading<bool> RightVentricleOverallFunctionNormal { get; set; }
        public ResultReading<bool> RightVentricleOverallFunctionReduced { get; set; }
        public ResultReading<bool> RightVentricleOverallFunctionBorderline { get; set; }
        public ResultReading<bool> RightVentricleOverallFunctionHyperkinesis { get; set; }
        public ResultReading<bool> RightVentricleOverallFunctionHypokinesis { get; set; }
        
        public ResultReading<bool> RightVentricleDimensionsNotEvaluated { get; set; }
        public ResultReading<bool> RightVentricleDimensionsNormal { get; set; }
        public ResultReading<bool> RightVentricleDimensionsSmall { get; set; }
        public ResultReading<bool> RightVentricleDimensionsDilated { get; set; }
        public ResultReading<bool> RightVentricleDimensionsSlightlyEnlarged { get; set; }
        public ResultReading<bool> RightVentricleDimensionsSeverelyDilated { get; set; }
        
        public ResultReading<bool> RightVentricleThicknessesNotEvaluated { get; set; }
        public ResultReading<bool> RightVentricleThicknessesNormal { get; set; }
        public ResultReading<bool> RightVentricleThicknessesApicalHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesAsymmetricalHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesIVSeptumObstructiveHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesMinorModerateIVSeptumHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesSevereIVSeptumHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesMinorModerateSymmetricHypertrophy { get; set; }
        public ResultReading<bool> RightVentricleThicknessesSevereSymmetricHypertrophy { get; set; }
        public ResultReading<string> RightVentricleComment { get; set; }

        // RightAtrium
        public ResultReading<bool> RightAtriumRADimensionsNotEvaluated { get; set; }
        public ResultReading<bool> RightAtriumRADimensionsNormal { get; set; }
        public ResultReading<bool> RightAtriumRADimensionsMildlyDilated { get; set; }
        public ResultReading<bool> RightAtriumRADimensionsModeratelyDilated { get; set; }
        public ResultReading<bool> RightAtriumRADimensionsSeverelyDilated { get; set; }
        public ResultReading<string> RightAtriumComment { get; set; }

        //Aorta
        public ResultReading<bool> AortaInsufficiencyAbsent { get; set; }
        public ResultReading<bool> AortaInsufficiencyMinor { get; set; }
        public ResultReading<bool> AortaInsufficiencyModerate { get; set; }
        public ResultReading<bool> AortaInsufficiencySevere { get; set; }

        public ResultReading<bool> AortaLeafletsNotEvaluated { get; set; }
        public ResultReading<bool> AortaLeafletsNormal { get; set; }
        public ResultReading<bool> AortaLeafletsMildStenosis { get; set; }
        public ResultReading<bool> AortaLeafletsModerateStenosis { get; set; }
        public ResultReading<bool> AortaLeafletsSevereStenosis { get; set; }
        
        public ResultReading<bool> AortaValveNotEvaluated { get; set; }
        public ResultReading<bool> AortaValveBicuspid { get; set; }
        public ResultReading<bool> AortaValveAtherosclerotic { get; set; }
        public ResultReading<bool> AortaValveNormalFunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> AortaValveNormalFunctioningMechanicalProsthesis { get; set; }
        public ResultReading<bool> AortaValveMalfunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> AortaValveMalfunctioningMechanicalProsthesis { get; set; }
        public ResultReading<bool> AortaValveDilatedAorticRoot { get; set; }
        public ResultReading<bool> AortaValveSinusValsalvaAneurysm { get; set; }
        public ResultReading<string> AortaComment { get; set; }

        //Mitral
        public ResultReading<bool> MitralInsufficiencyAbsent { get; set; }
        public ResultReading<bool> MitralInsufficiencyMinor { get; set; }
        public ResultReading<bool> MitralInsufficiencyModerate { get; set; }
        public ResultReading<bool> MitralInsufficiencySevere { get; set; }

        public ResultReading<bool> MitralLeafletsNotEvaluated { get; set; }
        public ResultReading<bool> MitralLeafletsNormal { get; set; }
        public ResultReading<bool> MitralLeafletsRedundant { get; set; }
        public ResultReading<bool> MitralLeafletsMildStenosis { get; set; }
        public ResultReading<bool> MitralLeafletsModerateStenosis { get; set; }
        public ResultReading<bool> MitralLeafletsSevereStenosis { get; set; }

        public ResultReading<bool> MitralValveNotEvaluated { get; set; }
        public ResultReading<bool> MitralValveBicuspid { get; set; }
        public ResultReading<bool> MitralValveAtherosclerotic { get; set; }
        public ResultReading<bool> MitralValveNormalFunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> MitralValveNormalFunctioningMechanicalProsthesis { get; set; }
        public ResultReading<bool> MitralValveMalfunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> MitralValveMalfunctioningMechanicalProsthesis { get; set; }
        public ResultReading<string> MitralValveComment { get; set; }

        //Pulmonary
        public ResultReading<bool> PulmonaryInsufficiencyAbsent { get; set; }
        public ResultReading<bool> PulmonaryInsufficiencyMinor { get; set; }
        public ResultReading<bool> PulmonaryInsufficiencyModerate { get; set; }
        public ResultReading<bool> PulmonaryInsufficiencySevere { get; set; }

        public ResultReading<bool> PulmonaryLeafletsNormal { get; set; }
        public ResultReading<bool> PulmonaryLeafletsThickened { get; set; }
        public ResultReading<bool> PulmonaryLeafletsStenotic { get; set; }
        public ResultReading<bool> PulmonaryLeafletsMildStenosis { get; set; }
        public ResultReading<bool> PulmonaryLeafletsModerateStenosis { get; set; }
        public ResultReading<bool> PulmonaryLeafletsSevereStenosis { get; set; }
        
        public ResultReading<bool> PulmonaryValveNotEvaluated { get; set; }
        public ResultReading<bool> PulmonaryValveBicuspid { get; set; }
        public ResultReading<bool> PulmonaryValveAtherosclerotic { get; set; }
        public ResultReading<bool> PulmonaryValveNormalFunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> PulmonaryValveNormalFunctioningMechanicalProsthesis { get; set; }
        public ResultReading<bool> PulmonaryValveMalfunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> PulmonaryValveMalfunctioningMechanicalProsthesis { get; set; }
        public ResultReading<string> PulmonaryComment { get; set; }

        public ResultReading<bool> TricuspidInsufficiencyAbsent { get; set; }
        public ResultReading<bool> TricuspidInsufficiencyMinor { get; set; }
        public ResultReading<bool> TricuspidInsufficiencyModerate { get; set; }
        public ResultReading<bool> TricuspidInsufficiencySevere { get; set; }

        public ResultReading<bool> TricuspidLeafletsNormal { get; set; }
        public ResultReading<bool> TricuspidLeafletsThickened { get; set; }
        public ResultReading<bool> TricuspidLeafletsRedundant { get; set; }
        public ResultReading<bool> TricuspidLeafletsMildStenosis { get; set; }
        public ResultReading<bool> TricuspidLeafletsModerateStenosis { get; set; }
        public ResultReading<bool> TricuspidLeafletsSevereStenosis { get; set; }

        public ResultReading<bool> TricuspidValveNotEvaluated { get; set; }
        public ResultReading<bool> TricuspidValveBicuspid { get; set; }
        public ResultReading<bool> TricuspidValveAtherosclerotic { get; set; }
        public ResultReading<bool> TricuspidValveNormalFunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> TricuspidValveNormalFunctioningMechanicalProsthesis { get; set; }
        public ResultReading<bool> TricuspidValveMalfunctioningBiologicalProsthesis { get; set; }
        public ResultReading<bool> TricuspidValveMalfunctioningMechanicalProsthesis { get; set; }
        public ResultReading<string> TricuspidComment { get; set; }

        public ResultReading<bool> ConsistentLvDiastolicFailure { get; set; }
        public ResultReading<bool> ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure { get; set; }
        public ResultReading<bool> ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure { get; set; }


        public AwvEchocardiogramTestResult()
            : this(0)
        { }

        public AwvEchocardiogramTestResult(long id)
            : base(id)
        {
            this.TestType = TestType.AwvEcho;
        }
    }
}
