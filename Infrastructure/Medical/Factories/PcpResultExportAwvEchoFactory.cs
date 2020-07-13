using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvEchoFactory : IPcpResultExportAwvEchoFactory
    {
        public PcpResultExportModel SetAwvEchoData(PcpResultExportModel model, AwvEchocardiogramTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null)
                model.EchoResult = testResult.Finding.Label;

            if (testResult.EstimatedEjactionFraction != null)
                model.EchoEstimatedEjectionFraction = testResult.EstimatedEjactionFraction.Label;

            //Aortic
            model.EchoValveAortic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Aortic);

            if (testResult.AorticRegurgitation != null)
                model.EchoValveAorticRegurgitation = testResult.AorticRegurgitation.Label;

            if (testResult.AorticMorphology != null && testResult.AorticMorphology.Count > 0)
            {
                model.EchoValveAorticMorphologySclerosis = testResult.AorticMorphology.Where(am => am.Id == PcpResultExportHelper.Sclerosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

                model.EchoValveAorticMorphologyStenosis = testResult.AorticMorphology.Where(am => am.Id == PcpResultExportHelper.Stenosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EchoValveAorticMorphologySclerosis = PcpResultExportHelper.NoString;
                model.EchoValveAorticMorphologyStenosis = PcpResultExportHelper.NoString;
            }

            if (testResult.AoticVelocity != null)
                model.EchoValveAorticMorphologyVelocity = testResult.AoticVelocity.Reading;

            if (testResult.PeakGradient != null)
                model.EchoValveAorticMorphologyPeakGradient = testResult.PeakGradient.Reading;

            if (testResult.AorticEstimatedValveArea != null)
                model.EchoValveAorticMorphologyEstVa = testResult.AorticEstimatedValveArea.Reading;

            if (testResult.AorticEstimatedRightValve != null)
                model.EchoValveAorticMorphologyEstRv = testResult.AorticEstimatedRightValve.Reading;

            //Mitral
            model.EchoValveMitral = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Mitral);

            if (testResult.MitralRegurgitation != null)
                model.EchoValveMitralRegurgitation = testResult.MitralRegurgitation.Label;

            if (testResult.MitralMorphology != null && testResult.MitralMorphology.Count > 0)
            {
                model.EchoValveMitralMorphologySclerosis = testResult.MitralMorphology.Where(am => am.Id == PcpResultExportHelper.Sclerosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

                model.EchoValveMitralMorphologyStenosis = testResult.MitralMorphology.Where(am => am.Id == PcpResultExportHelper.Stenosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

                model.EchoValveMitralMorphologyMitralProlapse = testResult.MitralMorphology.Where(am => am.Id == PcpResultExportHelper.MitralProlapse).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EchoValveMitralMorphologySclerosis = PcpResultExportHelper.NoString;
                model.EchoValveMitralMorphologyStenosis = PcpResultExportHelper.NoString;
                model.EchoValveMitralMorphologyMitralProlapse = PcpResultExportHelper.NoString;
            }

            if (testResult.MitralPT != null)
                model.EchoValveMitralMorphologyP12T = testResult.MitralPT.Reading;

            if (testResult.MitralEstimatedValveArea != null)
                model.EchoValveMitralMorphologyEstVa = testResult.MitralEstimatedValveArea.Reading;

            if (testResult.MitralEstimatedRightValve != null)
                model.EchoValveAorticMorphologyEstRv = testResult.MitralEstimatedRightValve.Reading;

            //Pulmonic
            model.EchoValvePulmonic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Pulmonic, useBlankValue);

            if (testResult.PulmonicRegurgitation != null)
                model.EchoValvePulmonicRegurgitation = testResult.PulmonicRegurgitation.Label;

            if (testResult.PulmonicMorphology != null && testResult.PulmonicMorphology.Count > 0)
            {
                model.EchoValvePulmonicMorphologySclerosis = testResult.PulmonicMorphology.Where(am => am.Id == PcpResultExportHelper.Sclerosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

                model.EchoValvePulmonicMorphologyStenosis = testResult.PulmonicMorphology.Where(am => am.Id == PcpResultExportHelper.Stenosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EchoValvePulmonicMorphologySclerosis = PcpResultExportHelper.NoString;
                model.EchoValvePulmonicMorphologyStenosis = PcpResultExportHelper.NoString;
            }

            if (testResult.PulmonicVelocity != null)
                model.EchoValvePulmonicMorphologyVelocity = testResult.PulmonicVelocity.Reading;

            if (testResult.PulmonicEstimatedValveArea != null)
                model.EchoValvePulmonicMorphologyEstVa = testResult.PulmonicEstimatedValveArea.Reading;

            //Tricuspid
            model.EchoValveTricuspid = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Tricuspid, useBlankValue);

            if (testResult.TricuspidRegurgitation != null)
                model.EchoValveTricuspidRegurgitation = testResult.TricuspidRegurgitation.Label;

            if (testResult.TricuspidMorphology != null && testResult.TricuspidMorphology.Count > 0)
            {
                model.EchoValveTricuspidMorphologySclerosis = testResult.TricuspidMorphology.Where(am => am.Id == PcpResultExportHelper.Sclerosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

                model.EchoValveTricuspidMorphologyStenosis = testResult.TricuspidMorphology.Where(am => am.Id == PcpResultExportHelper.Stenosis).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EchoValveTricuspidMorphologySclerosis = PcpResultExportHelper.NoString;
                model.EchoValveTricuspidMorphologyStenosis = PcpResultExportHelper.NoString;
            }

            if (testResult.TricuspidPap != null)
                model.EchoValveTricuspidMorphologyPap = testResult.TricuspidPap.Reading;

            if (testResult.TricuspidVelocity != null)
                model.EchoValveTricuspidMorphologyVelocity = testResult.TricuspidVelocity.Reading;

            if (testResult.TricuspidEstimatedValveArea != null)
                model.EchoValveTricuspidMorphologyEstVa = testResult.TricuspidEstimatedValveArea.Reading;

            model.EchoValveTricuspidMorphologyHigh35MmHgGreater = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MorphologyTricuspidHighOrGreater);
            model.EchoValveTricuspidMorphologyNormal = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MorphologyTricuspidNormal);

            model.EchoDiastolicDysfunction = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.DiastolicDysfunction, useBlankValue);

            if (testResult.DistolicDysfunctionFinding != null)
                model.EchoDiastolicDysfunctionGrade = testResult.DistolicDysfunctionFinding.Label;

            if (testResult.DiastolicDysfunctionEeRatio != null)
                model.EchoDiastolicEbyERatio = testResult.DiastolicDysfunctionEeRatio.Reading;

            model.EchoPericardialEffusion = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PericardialEffusion, useBlankValue);

            if (testResult.PericardialEffusionFinding != null && testResult.PericardialEffusionFinding.Count > 0)
            {
                model.EchoPericardialEffusionPhysiologic = testResult.PericardialEffusionFinding.Where(am => am.Id == PcpResultExportHelper.Trival).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EchoPericardialEffusionSmall = testResult.PericardialEffusionFinding.Where(am => am.Id == PcpResultExportHelper.Small).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EchoPericardialEffusionModerate = testResult.PericardialEffusionFinding.Where(am => am.Id == PcpResultExportHelper.Moderate).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EchoPericardialEffusionLarge = testResult.PericardialEffusionFinding.Where(am => am.Id == PcpResultExportHelper.Large).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EchoPericardialEffusionPhysiologic = PcpResultExportHelper.NoString;
                model.EchoPericardialEffusionSmall = PcpResultExportHelper.NoString;
                model.EchoPericardialEffusionModerate = PcpResultExportHelper.NoString;
                model.EchoPericardialEffusionLarge = PcpResultExportHelper.NoString;
            }

            model.EchoAorticRoot = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AorticRoot, useBlankValue);
            model.EchoAorticRootSclerotic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Sclerotic, useBlankValue);
            model.EchoAorticRootCalcified = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Calcified, useBlankValue);
            model.EchoAorticRootEnlargedMeasurment = testResult.EnlargedValue != null ? testResult.EnlargedValue.Reading : "";

            model.EchoAscendingAortaArch = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AscendingAortaArch, useBlankValue);
            model.EchoAtherosclerosis = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Atherosclerosis, useBlankValue);

            model.EchoVentricularEnlargement = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VentricularEnlargement, useBlankValue);
            model.EchoVentricularEnlargementLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftVentricularEnlargment, useBlankValue);
            model.EchoVentricularEnlargementLeftMeasurement = testResult.LeftAtrialEnlargmentValue != null ? testResult.LeftAtrialEnlargmentValue.Reading : "";
            model.EchoVentricularEnlargementRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightVentricularEnlargment, useBlankValue);
            model.EchoVentricularEnlargementRightMeasurment = testResult.RightVentricularEnlargmentValue != null ? testResult.RightVentricularEnlargmentValue.Reading : "";

            model.EchoVentricularHypertrophy = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VentricularHypertrophy, useBlankValue);
            model.EchoVentricularHypertrophyLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftVHypertrophy, useBlankValue);
            model.EchoVentricularHypertrophyLeftMeasurment = testResult.LeftVHypertrophyValue != null ? testResult.LeftVHypertrophyValue.Reading : "";
            model.EchoVentricularHypertorophyRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightVHypertrophy, useBlankValue);
            model.EchoVentricularHypertrophyRightMeasurment = testResult.RightVHypertrophyValue != null ? testResult.RightVHypertrophyValue.Reading : "";
            model.EchoVentricularHypertrophyIVSH = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.IvshHypertrophy, useBlankValue);
            model.EchoVentricularHypertrophyIVSHMeasurment = testResult.IvshHypertrophyValue != null ? testResult.IvshHypertrophyValue.Reading : "";

            model.EchoAtrialEnlargement = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtrialEnlargement, useBlankValue);
            model.EchoAtrialEnlargementLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftAtrialEnlargment, useBlankValue);
            model.EchoAtrialEnlargementLeftMeasurement = testResult.LeftAtrialEnlargmentValue != null ? testResult.LeftAtrialEnlargmentValue.Reading : "";
            model.EchoAtrialEnlargementRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightAtrialEnlargment, useBlankValue);
            model.EchoAtrialEnlargementRightMeasurement = testResult.RightAtrialEnlargmentValue != null ? testResult.RightAtrialEnlargmentValue.Reading : "";

            model.EchoArrythmia = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Arrythmia, useBlankValue);
            model.EchoArrythmiaAFib = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AFib, useBlankValue);
            model.EchoArrythmiaAFlutter = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AFlutter, useBlankValue);
            model.EchoArrythmiaPAC = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PAC, useBlankValue);
            model.EchoArrythmiaPVC = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PVC, useBlankValue);

            model.EchoASD = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ASD, useBlankValue);
            model.EchoPFO = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PFO, useBlankValue);
            model.EchoAneurysmalAs = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.FlailAS, useBlankValue);
            model.EchoVsd = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VSD, useBlankValue);

            model.EchoMitralAnnularCa = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MitralAnnularCa, useBlankValue);

            model.EchoRestrictedLeafletMotion = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotion, useBlankValue);
            model.EchoRestrictedLeafletMotionAortic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionAortic, useBlankValue);
            model.EchoRestrictedLeafletMotionMitral = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionMitral, useBlankValue);
            model.EchoRestrictedLeafletMotionPulmonic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionPulmonic, useBlankValue);
            model.EchoRestrictedLeafletMotionTricuspid = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionTricuspid, useBlankValue);

            model.EchoWallMotionAnormalityHypokinetic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Hypokinetic, useBlankValue);
            model.EchoWallMotionAnormalityAkinetic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Akinetic, useBlankValue);
            model.EchoWallMotionAnormalityDyskinetic = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Dyskinetic, useBlankValue);
            model.EchoWallMotionAnormalityAnerior = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Anterior, useBlankValue);
            model.EchoWallMotionAnormalityPosterior = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Posterior, useBlankValue);
            model.EchoWallMotionAnormalityApical = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Apical, useBlankValue);
            model.EchoWallMotionAnormalitySeptal = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Septal, useBlankValue);
            model.EchoWallMotionAnormalityLateral = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Lateral, useBlankValue);
            model.EchoWallMotionAnormalityInferior = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Inferior, useBlankValue);


            model.EchoTechnicallyLimitedButReadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable, useBlankValue);
            model.EchoRepeatStudyUnreadable = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudyUnreadable, useBlankValue);

            model.EchoUnableToScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.EchoCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.EchoCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.EchoPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
