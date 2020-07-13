using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianPartnerResultExportEchoFactory : IPhysicianPartnerResultExportEchoFactory
    {
        public PhysicianPartnerResultExportModel SetEchoData(PhysicianPartnerResultExportModel model, PpEchocardiogramTestResult testResult)
        {
            if (testResult.Finding != null)
                model.EchoResult = testResult.Finding.Label;

            if (testResult.EstimatedEjactionFraction != null)
                model.EchoEstimatedEjectionFraction = testResult.EstimatedEjactionFraction.Label;

            model.EchoValveAortic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Aortic);

            if (testResult.AorticRegurgitation != null)
                model.EchoValveAorticRegurgitation = testResult.AorticRegurgitation.Label;

            if (testResult.AorticMorphology != null && testResult.AorticMorphology.Count > 0)
            {
                model.EchoValveAorticMorphologySclerosis = testResult.AorticMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Sclerosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValveAorticMorphologyStenosis = testResult.AorticMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Stenosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValveAorticMorphologyBicuspidAv = testResult.AorticMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.BicuspidAv).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            }
            else
            {
                model.EchoValveAorticMorphologySclerosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValveAorticMorphologyStenosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValveAorticMorphologyBicuspidAv = PhysicianPartnerResultExportHelper.NoString;
            }
            if (testResult.AoticVelocity != null)
                model.EchoValveAorticMorphologyVelocity = testResult.AoticVelocity.Reading;

            model.EchoValveMitral = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Mitral);

            if (testResult.MitralRegurgitation != null)
                model.EchoValveMitralRegurgitation = testResult.MitralRegurgitation.Label;

            if (testResult.MitralMorphology != null && testResult.MitralMorphology.Count > 0)
            {
                model.EchoValveMitralMorphologySclerosis = testResult.MitralMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Sclerosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValveMitralMorphologyStenosis = testResult.MitralMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Stenosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValveMitralMorphologyMitralProlapse = testResult.MitralMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.MitralProlapse).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            }
            else
            {
                model.EchoValveMitralMorphologySclerosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValveMitralMorphologyStenosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValveMitralMorphologyMitralProlapse = PhysicianPartnerResultExportHelper.NoString;
            }

            if (testResult.MitralPT != null)
                model.EchoValveMitralMorphologyP12T = testResult.MitralPT.Reading;


            model.EchoValvePulmonic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Pulmonic);

            if (testResult.PulmonicRegurgitation != null)
                model.EchoValvePulmonicRegurgitation = testResult.PulmonicRegurgitation.Label;

            if (testResult.PulmonicMorphology != null && testResult.PulmonicMorphology.Count > 0)
            {
                model.EchoValvePulmonicMorphologySclerosis = testResult.PulmonicMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Sclerosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValvePulmonicMorphologyStenosis = testResult.PulmonicMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Stenosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            }
            else
            {
                model.EchoValvePulmonicMorphologySclerosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValvePulmonicMorphologyStenosis = PhysicianPartnerResultExportHelper.NoString;
            }

            if (testResult.PulmonicVelocity != null)
                model.EchoValvePulmonicMorphologyVelocity = testResult.PulmonicVelocity.Reading;

            model.EchoValveTricuspid = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Tricuspid);

            if (testResult.TricuspidRegurgitation != null)
                model.EchoValveTricuspidRegurgitation = testResult.TricuspidRegurgitation.Label;

            if (testResult.TricuspidMorphology != null && testResult.TricuspidMorphology.Count > 0)
            {
                model.EchoValveTricuspidMorphologySclerosis = testResult.TricuspidMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Sclerosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

                model.EchoValveTricuspidMorphologyStenosis = testResult.TricuspidMorphology.Where(am => am.Id == PhysicianPartnerResultExportHelper.Stenosis).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            }
            else
            {
                model.EchoValveTricuspidMorphologySclerosis = PhysicianPartnerResultExportHelper.NoString;
                model.EchoValveTricuspidMorphologyStenosis = PhysicianPartnerResultExportHelper.NoString;
            }

            if (testResult.TricuspidPap != null)
                model.EchoValveTricuspidMorphologyPap = testResult.TricuspidPap.Reading;

            if (testResult.TricuspidVelocity != null)
                model.EchoValveTricuspidMorphologyVelocity = testResult.TricuspidVelocity.Reading;

            model.EchoValveTricuspidMorphologyHigh35MmHgGreater = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MorphologyTricuspidHighOrGreater);
            model.EchoValveTricuspidMorphologyNormal = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MorphologyTricuspidNormal);

            model.EchoDiastolicDysfunction = testResult.DiastolicDysfunction != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if (testResult.DistolicDysfunctionFinding != null)
            {
                model.EchoDiastolicDysfunctionGrade = testResult.DistolicDysfunctionFinding.Label;
            }


            model.EchoPericardialEffusion = testResult.PericardialEffusion != null ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if (testResult.PericardialEffusionFinding != null && testResult.PericardialEffusionFinding.Count > 0)
            {
                model.EchoPericardialEffusionPhysiologic = testResult.PericardialEffusionFinding.Where(am => am.Id == PhysicianPartnerResultExportHelper.Trival).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionSmall = testResult.PericardialEffusionFinding.Where(am => am.Id == PhysicianPartnerResultExportHelper.Small).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionModerate = testResult.PericardialEffusionFinding.Where(am => am.Id == PhysicianPartnerResultExportHelper.Moderate).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionLarge = testResult.PericardialEffusionFinding.Where(am => am.Id == PhysicianPartnerResultExportHelper.Large).Select(am => am).Any() ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;
            }
            else
            {
                model.EchoPericardialEffusionPhysiologic = PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionSmall = PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionModerate = PhysicianPartnerResultExportHelper.NoString;
                model.EchoPericardialEffusionLarge = PhysicianPartnerResultExportHelper.NoString;
            }

            model.EchoVentricularEnlargement = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VentricularEnlargement);
            model.EchoVentricularEnlargementLeft = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftVentricularEnlargment);
            model.EchoVentricularEnlargementLeftMeasurement = testResult.LeftAtrialEnlargmentValue != null ? testResult.LeftAtrialEnlargmentValue.Reading : "";
            model.EchoVentricularEnlargementRight = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightVentricularEnlargment);
            model.EchoVentricularEnlargementRightMeasurment = testResult.RightVentricularEnlargmentValue != null ? testResult.RightVentricularEnlargmentValue.Reading : "";

            model.EchoAorticRoot = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AorticRoot);
            model.EchoAorticRootSclerotic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Sclerotic);
            model.EchoAorticRootCalcified = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Calcified);
            model.EchoAorticRootEnlarged = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Enlarged);
            model.EchoAorticRootEnlargedMeasurment = testResult.EnlargedValue != null ? testResult.EnlargedValue.Reading : "";

            model.EchoVentricularHypertrophy = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VentricularHypertrophy);
            model.EchoVentricularHypertrophyLeft = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftVHypertrophy);
            model.EchoVentricularHypertrophyLeftMeasurment = testResult.LeftVHypertrophyValue != null ? testResult.LeftVHypertrophyValue.Reading : "";
            model.EchoVentricularHypertorophyRight = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightVHypertrophy);
            model.EchoVentricularHypertrophyRightMeasurment = testResult.RightVHypertrophyValue != null ? testResult.RightVHypertrophyValue.Reading : "";
            model.EchoVentricularHypertrophyIVSH = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.IvshHypertrophy);
            model.EchoVentricularHypertrophyIVSHMeasurment = testResult.IvshHypertrophyValue != null ? testResult.IvshHypertrophyValue.Reading : "";

            model.EchoAtrialEnlargement = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtrialEnlargement);
            model.EchoAtrialEnlargementLeft = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftAtrialEnlargment);
            model.EchoAtrialEnlargementLeftMeasurement = testResult.LeftAtrialEnlargmentValue != null ? testResult.LeftAtrialEnlargmentValue.Reading : "";
            model.EchoAtrialEnlargementRight = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightAtrialEnlargment);
            model.EchoAtrialEnlargementRightMeasurement = testResult.RightAtrialEnlargmentValue != null ? testResult.RightAtrialEnlargmentValue.Reading : "";

            model.EchoArrythmia = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Arrythmia);

            model.EchoArrythmiaAFib = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AFib);
            model.EchoArrythmiaAFlutter = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AFlutter);
            model.EchoArrythmiaPAC = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PAC);
            model.EchoArrythmiaPVC = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PVC);

            model.EchoArrythmiaASD = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ASD);
            model.EchoArrythmiaPFO = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PFO);
            model.EchoArrythmiaFlailAS = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.FlailAS);

            model.EchoWallMotionAnormalityHypokinetic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Hypokinetic);
            model.EchoWallMotionAnormalityAkinetic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Akinetic);
            model.EchoWallMotionAnormalityDyskinetic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Dyskinetic);
            model.EchoWallMotionAnormalityAnerior = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Anterior);
            model.EchoWallMotionAnormalityPosterior = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Posterior);
            model.EchoWallMotionAnormalityApical = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Apical);
            model.EchoWallMotionAnormalitySeptal = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Septal);
            model.EchoWallMotionAnormalityLateral = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Lateral);
            model.EchoWallMotionAnormalityInferior = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Inferior);


            model.EchoVSD = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VSD);
            model.EchoSAM = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SAM);
            model.EchoLVOTO = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LVOTO);
            model.EchoManualAnnularC = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.MitralAnnularCa);

            model.EchoRestrictedLeafletMotion = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotion);
            model.EchoRestrictedLeafletMotionAortic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionAortic);
            model.EchoRestrictedLeafletMotionMitral = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionMitral);
            model.EchoRestrictedLeafletMotionPulmonic = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionPulmonic);
            model.EchoRestrictedLeafletMotionTricuspid = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RestrictedLeafletMotionTricuspid);

            model.EchoTechnicallyLimitedButReadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TechnicallyLimitedbutReadable);
            model.EchoRepeatStudyUnreadable = PhysicianPartnerResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudyUnreadable);

            model.EchoUnableToScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PhysicianPartnerResultExportHelper.YesString : PhysicianPartnerResultExportHelper.NoString;

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.EchoCritical = PhysicianPartnerResultExportHelper.YesString;
            else
                model.EchoCritical = PhysicianPartnerResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.EchoPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            var echoDiagnosisCodes = new System.Collections.Generic.List<OrderedPair<string, string>>();
            if (testResult.DiagnosisCode != null)
            {
                foreach (var diagnosisCode in PhysicianPartnerResultExportHelper.EchoDiagnosisCodes)
                {
                    if (testResult.DiagnosisCode.Reading.Contains(diagnosisCode))
                        echoDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.YesString));
                    else
                        echoDiagnosisCodes.Add(new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString));
                }
            }
            else
            {
                echoDiagnosisCodes.AddRange(PhysicianPartnerResultExportHelper.EchoDiagnosisCodes.Select(diagnosisCode => new OrderedPair<string, string>(diagnosisCode, PhysicianPartnerResultExportHelper.NoString)));
            }

            model.EchoDiagnosisCodes = echoDiagnosisCodes;

            return model;
        }
    }
}
