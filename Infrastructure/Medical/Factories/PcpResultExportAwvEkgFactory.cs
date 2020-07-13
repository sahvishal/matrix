using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvEkgFactory : IPcpResultExportAwvEkgFactory
    {
        public PcpResultExportModel SetAwvEkgData(PcpResultExportModel model, AwvEkgTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.EkgResult = testResult.Finding.Label;

            model.EkgRepeatStudy = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepeatStudy, useBlankValue);
            model.EkgReversedLeads = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ReversedLeads, useBlankValue);
            model.EkgArtifact = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Artifact, useBlankValue);
            model.EkgComparetoPreviousEkg = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ComparetoEkg, useBlankValue);

            model.EkgSinusRhythm = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SinusRythm, useBlankValue);
            model.EkgSinusArrhythmia = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SinusArrythmia, useBlankValue);
            model.EkgSinusBradycardia = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SinusBradycardia, useBlankValue);
            model.EkgSinusBradycardiaMarkLessFifty = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Marked, useBlankValue);
            model.EkgSinusTachycardia = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SinusTachycardia, useBlankValue);
            model.EkgAtrialFibrillation = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtrialFibrillation, useBlankValue);
            model.EkgAtrialFlutter = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtrialFlutter, useBlankValue);
            model.EkgSupraventricularArrhythmia = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SupraventricularArrythmia, useBlankValue);
            model.EkgSvt = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SVT, useBlankValue);
            model.EkgPac = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PACs, useBlankValue);
            model.EkgPvc = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PVCs, useBlankValue);
            model.EkgPacerRhythm = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PacerRythm, useBlankValue);
            model.EkgBundleBranchBlock = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.BundleBranchBlock, useBlankValue);
            if (testResult.BundleBranchBlockFinding != null && testResult.BundleBranchBlockFinding.Count > 0)
            {
                model.EkgBundleBranchBlockLeft = testResult.BundleBranchBlockFinding.Where(am => am.Id == PcpResultExportHelper.Left).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgBundleBranchBlockRight = testResult.BundleBranchBlockFinding.Where(am => am.Id == PcpResultExportHelper.Right).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgBundleBranchBlockIncomplete = testResult.BundleBranchBlockFinding.Where(am => am.Id == PcpResultExportHelper.Incomplete).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgBundleBranchBlockIvcdns = testResult.BundleBranchBlockFinding.Where(am => am.Id == PcpResultExportHelper.Ivcdns).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgBundleBranchBlockBifasc = testResult.BundleBranchBlockFinding.Where(am => am.Id == PcpResultExportHelper.Bifasc).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if (!useBlankValue)
            {
                model.EkgBundleBranchBlockLeft = PcpResultExportHelper.NoString;
                model.EkgBundleBranchBlockRight = PcpResultExportHelper.NoString;
                model.EkgBundleBranchBlockIncomplete = PcpResultExportHelper.NoString;
                model.EkgBundleBranchBlockIvcdns = PcpResultExportHelper.NoString;
                model.EkgBundleBranchBlockBifasc = PcpResultExportHelper.NoString;
            }



            model.EkgQrsWidening = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.QRSWidening, useBlankValue);
            model.EkgLeftAxis = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftAxis, useBlankValue);
            model.EkgRightAxis = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightAxis, useBlankValue);
            model.EkgAbnormalAxis = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AbnormalAxis, useBlankValue);
            model.EkgAbnormalAxisLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Left, useBlankValue);
            model.EkgAbnormalAxisRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.Right, useBlankValue);

            model.EkgLeftAnteriorFasicularBlock = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftAnteriorFasicularBlock, useBlankValue);
            model.EkgAvNodalHeartBlock = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.HeartBlock, useBlankValue);
            model.EkgAvNodalHeartBlockFirstDegree = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.FirstDegreeBlock, useBlankValue);
            model.EkgAvNodalHeartBlockSecondDegreeMobitzOne = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.SecondDegreeBlock, useBlankValue);
            model.EkgAvNodalHeartBlockSecondDegreeMobitzTwo = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.TypeII, useBlankValue);
            model.EkgAvNodalHeartBlockThirdDegree = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ThirdDegreeCompleteHeartBlock, useBlankValue);
            model.EkgShortPrIinterval = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ShortPrInterval, useBlankValue);

            model.EkgRoVentricularHypertrophy = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.VentricularHypertrophy, useBlankValue);
            model.EkgRoVentricularHypertrophyLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftVentricularHypertrophy, useBlankValue);
            model.EkgRoVentricularHypertrophyRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightVentricularHypertrophy, useBlankValue);

            model.EkgProlongedQTcInterval = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.ProlongedQTInterval, useBlankValue);
            model.EkgRoIschemicSttChanges = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.IschemicSTTChanges, useBlankValue);
            model.EkgNonSpecificSttChanges = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.NonSpecificSTTChanges, useBlankValue);
            model.EkgPoorRWaveProgression = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PoorRWaveProgression, useBlankValue);

            model.EkgRoInfarctionPattern = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.InfarctionPattern, useBlankValue);
            if (testResult.InfarctionPatternFinding != null && testResult.InfarctionPatternFinding.Count > 0)
            {
                model.EkgRoInfarctionPatternSeptal = testResult.InfarctionPatternFinding.Where(am => am.Id == PcpResultExportHelper.Septal).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgRoInfarctionPatternPosterior = testResult.InfarctionPatternFinding.Where(am => am.Id == PcpResultExportHelper.Posterior).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgRoInfarctionPatternAnterior = testResult.InfarctionPatternFinding.Where(am => am.Id == PcpResultExportHelper.Anterior).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgRoInfarctionPatternLateral = testResult.InfarctionPatternFinding.Where(am => am.Id == PcpResultExportHelper.Lateral).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
                model.EkgRoInfarctionPatternInferior = testResult.InfarctionPatternFinding.Where(am => am.Id == PcpResultExportHelper.Inferior).Select(am => am).Any() ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);
            }
            else if(!useBlankValue)
            {
                model.EkgRoInfarctionPatternSeptal = PcpResultExportHelper.NoString;
                model.EkgRoInfarctionPatternPosterior = PcpResultExportHelper.NoString;
                model.EkgRoInfarctionPatternAnterior = PcpResultExportHelper.NoString;
                model.EkgRoInfarctionPatternLateral = PcpResultExportHelper.NoString;
                model.EkgRoInfarctionPatternInferior = PcpResultExportHelper.NoString;
            }

            model.EkgAtypicalQWavelead = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtypicalQWaveLead, useBlankValue);
            model.EkgAtrialEnlargement = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.AtrialEnlargement, useBlankValue);
            model.EkgAtrialEnlargementLeft = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LeftAtrialEnlargement, useBlankValue);
            model.EkgAtrialEnlargementRight = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RightAtrialEnlargement, useBlankValue);
            model.EkgRepolarizationVariant = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.RepolarizationVariant, useBlankValue);
            model.EkgLowVoltage = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LowVoltage, useBlankValue);
            model.EkgLowVoltageLimbleads = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.LimbLeads, useBlankValue);
            model.EkgLowVoltagePrecordialleads = PcpResultExportHelper.GetOutputFromBoolTypeResultReading(testResult.PrecordialLeads, useBlankValue);





            model.EkgUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.EkgCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.EkgCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.EkgPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}
