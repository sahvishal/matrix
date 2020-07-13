using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpResultExportModel
    {
        [DisplayName("Id")]
        public long CustomerId { get; set; }

        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Address")]
        public string Address1 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        [DisplayName("DOB")]
        [Format("MM/dd/yyyy")]
        public DateTime? Dob { get; set; }

        public string Age { get; set; }

        [DisplayName("Height(inches)")]
        public string Height { get; set; }

        [DisplayName("Weight(lbs)")]
        public string Weight { get; set; }

        [DisplayName("BMI")]
        public string BMIndex { get; set; }

        public string Gender { get; set; }

        public string Race { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [DisplayName("Group Name")]
        public string GroupName { get; set; }

        public string Ssn { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

        [Hidden]
        public string Mrn { get; set; }

        [DisplayName("Medicare Id")]
        public string Hicn { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Event Date")]
        [Format("MM/dd/yyyy")]
        public DateTime EventDate { get; set; }

        [DisplayName("Event Loaction")]
        public string EventLocation { get; set; }

        public string Pod { get; set; }

        [DisplayName("Hospital Partner")]
        public string HospitalPartner { get; set; }

        [DisplayName("Corporate Account")]
        public string CorporateAccount { get; set; }

        [DisplayName("HIPAA")]
        public string Hipaa { get; set; }

        [DisplayName("Partner Release")]
        public string PartnerRelease { get; set; }

        [DisplayName("Check-In Time")]
        public string CheckinTime { get; set; }

        [DisplayName("Check-Out Time")]
        public string CheckoutTime { get; set; }

        [DisplayName("Primary Physician Name")]
        public string PrimaryPhysicianName { get; set; }

        [DisplayName("Care Coordinator Status")]
        public string CareCoordinatorStatus { get; set; }

        [DisplayName("Care Coordinator Outcome")]
        public string CareCoordinatorOutcome { get; set; }

        [DisplayName("Care Coordinator")]
        public string CareCoordinator { get; set; }

        [Hidden]
        [DisplayName("Care Coordinator Notes")]
        public string CareCoordinatorNotes { get; set; }

        public IEnumerable<OrderedPair<long, string>> HealthAssesmentAnswer { get; set; }

        [DisplayName("Result Summary")]
        public string ResultSummary { get; set; }

        [DisplayName("Blood Pressure")]
        public string BloodPressure { get; set; }

        [DisplayName("Pulse Rate")]
        public string PulseRate { get; set; }

        [DisplayName("Is Abnormal Blood Pressure")]
        public string IsAbnormalBloodPressure { get; set; }




        [DisplayName("Echo Result")]
        public string EchoResult { get; set; }

        [DisplayName("Echo Estimated Ejection Fraction")]
        public string EchoEstimatedEjectionFraction { get; set; }

        [DisplayName("Echo Valve Aortic")]
        public string EchoValveAortic { get; set; }

        [DisplayName("Echo Valve Aortic Regurgitation")]
        public string EchoValveAorticRegurgitation { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Sclerosis")]
        public string EchoValveAorticMorphologySclerosis { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Stenosis")]
        public string EchoValveAorticMorphologyStenosis { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Velocity")]
        public string EchoValveAorticMorphologyVelocity { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Peak Gradient")]
        public string EchoValveAorticMorphologyPeakGradient { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Est. VA")]
        public string EchoValveAorticMorphologyEstVa { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Est. RV")]
        public string EchoValveAorticMorphologyEstRv { get; set; }

        [DisplayName("Echo Valve Mitral")]
        public string EchoValveMitral { get; set; }

        [DisplayName("Echo Valve Mitral Regurgitation")]
        public string EchoValveMitralRegurgitation { get; set; }

        [DisplayName("Echo Valve Mitral Morphology Sclerosis")]
        public string EchoValveMitralMorphologySclerosis { get; set; }

        [DisplayName("Echo Valve Mitral Morphology Stenosis")]
        public string EchoValveMitralMorphologyStenosis { get; set; }

        [DisplayName("Echo Valve Mitral Morphology Mitral Prolapse")]
        public string EchoValveMitralMorphologyMitralProlapse { get; set; }

        [DisplayName("Echo Valve Mitral Morphology P1/2T")]
        public string EchoValveMitralMorphologyP12T { get; set; }

        [DisplayName("Echo Valve Mitral Morphology Est. VA")]
        public string EchoValveMitralMorphologyEstVa { get; set; }

        [DisplayName("Echo Valve Mitral Morphology Est. RV")]
        public string EchoValveMitralMorphologyEstRv { get; set; }

        [DisplayName("Echo Valve Pulmonic")]
        public string EchoValvePulmonic { get; set; }

        [DisplayName("Echo Valve Pulmonic Regurgitation")]
        public string EchoValvePulmonicRegurgitation { get; set; }

        [DisplayName("Echo Valve Pulmonic Morphology Sclerosis")]
        public string EchoValvePulmonicMorphologySclerosis { get; set; }

        [DisplayName("Echo Valve Pulmonic Morphology Stenosis")]
        public string EchoValvePulmonicMorphologyStenosis { get; set; }

        [DisplayName("Echo Valve Pulmonic Morphology Velocity")]
        public string EchoValvePulmonicMorphologyVelocity { get; set; }

        [DisplayName("Echo Valve Pulmonic Morphology Est. VA")]
        public string EchoValvePulmonicMorphologyEstVa { get; set; }

        [DisplayName("Echo Valve Tricuspid")]
        public string EchoValveTricuspid { get; set; }

        [DisplayName("Echo Valve Tricuspid Regurgitation")]
        public string EchoValveTricuspidRegurgitation { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology Sclerosis")]
        public string EchoValveTricuspidMorphologySclerosis { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology Stenosis")]
        public string EchoValveTricuspidMorphologyStenosis { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology PAP")]
        public string EchoValveTricuspidMorphologyPap { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology Velocity")]
        public string EchoValveTricuspidMorphologyVelocity { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology Est. VA")]
        public string EchoValveTricuspidMorphologyEstVa { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology High, 35mmHg or greater")]
        public string EchoValveTricuspidMorphologyHigh35MmHgGreater { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology Normal")]
        public string EchoValveTricuspidMorphologyNormal { get; set; }

        [DisplayName("Echo Diastolic Dysfunction")]
        public string EchoDiastolicDysfunction { get; set; }

        [DisplayName("Echo Diastolic Dysfunction Grade")]
        public string EchoDiastolicDysfunctionGrade { get; set; }

        [DisplayName("Echo Diastolic E/e' Ratio")]
        public string EchoDiastolicEbyERatio { get; set; }

        [DisplayName("Echo Pericardial Effusion")]
        public string EchoPericardialEffusion { get; set; }

        [DisplayName("Echo Pericardial Effusion Physiologic")]
        public string EchoPericardialEffusionPhysiologic { get; set; }

        [DisplayName("Echo Pericardial Effusion Small")]
        public string EchoPericardialEffusionSmall { get; set; }

        [DisplayName("Echo Pericardial Effusion Moderate")]
        public string EchoPericardialEffusionModerate { get; set; }

        [DisplayName("Echo Pericardial Effusion Large")]
        public string EchoPericardialEffusionLarge { get; set; }

        [DisplayName("Echo Aortic Root")]
        public string EchoAorticRoot { get; set; }

        [DisplayName("Echo Aortic Root Sclerotic")]
        public string EchoAorticRootSclerotic { get; set; }

        [DisplayName("Echo Aortic Root Calcified")]
        public string EchoAorticRootCalcified { get; set; }

        [DisplayName("Echo Aortic Root Dimension")]
        public string EchoAorticRootEnlargedMeasurment { get; set; }

        [DisplayName("Echo Aortic Root Ascending Aorta/Arch")]
        public string EchoAscendingAortaArch { get; set; }

        [DisplayName("Echo Aortic Root Atherosclerosis")]
        public string EchoAtherosclerosis { get; set; }

        [DisplayName("Echo Ventricular Enlargement")]
        public string EchoVentricularEnlargement { get; set; }

        [DisplayName("Echo Ventricular Enlargement Left")]
        public string EchoVentricularEnlargementLeft { get; set; }

        [DisplayName("Echo Ventricular Enlargement Left Measurement")]
        public string EchoVentricularEnlargementLeftMeasurement { get; set; }

        [DisplayName("Echo Ventricular Enlargement Right")]
        public string EchoVentricularEnlargementRight { get; set; }

        [DisplayName("Echo Ventricular Enlargement Right Measurment")]
        public string EchoVentricularEnlargementRightMeasurment { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy")]
        public string EchoVentricularHypertrophy { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy Left")]
        public string EchoVentricularHypertrophyLeft { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy left measurment")]
        public string EchoVentricularHypertrophyLeftMeasurment { get; set; }

        [DisplayName("Echo Ventricular Hypertorophy Right")]
        public string EchoVentricularHypertorophyRight { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy Right Measurment")]
        public string EchoVentricularHypertrophyRightMeasurment { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy IVSH")]
        public string EchoVentricularHypertrophyIVSH { get; set; }

        [DisplayName("Echo Ventricular Hypertrophy IVSH Measurment")]
        public string EchoVentricularHypertrophyIVSHMeasurment { get; set; }

        [DisplayName("Echo Atrial Enlargement")]
        public string EchoAtrialEnlargement { get; set; }

        [DisplayName("Echo Atrial Enlargement Left")]
        public string EchoAtrialEnlargementLeft { get; set; }

        [DisplayName("Echo Atrial Enlargement Left Measurement")]
        public string EchoAtrialEnlargementLeftMeasurement { get; set; }

        [DisplayName("Echo Atrial Enlargement Right")]
        public string EchoAtrialEnlargementRight { get; set; }

        [DisplayName("Echo Atrial Enlargement Right Measurement")]
        public string EchoAtrialEnlargementRightMeasurement { get; set; }

        [DisplayName("Echo Arrythmia")]
        public string EchoArrythmia { get; set; }

        [DisplayName("Echo Arrythmia A-Fib")]
        public string EchoArrythmiaAFib { get; set; }

        [DisplayName("Echo Arrythmia A-Flutter")]
        public string EchoArrythmiaAFlutter { get; set; }

        [DisplayName("Echo Arrythmia PAC")]
        public string EchoArrythmiaPAC { get; set; }

        [DisplayName("Echo Arrythmia PVC")]
        public string EchoArrythmiaPVC { get; set; }

        [DisplayName("Echo ASD")]
        public string EchoASD { get; set; }

        [DisplayName("Echo PFO")]
        public string EchoPFO { get; set; }

        [DisplayName("Echo Aneurysmal AS")]
        public string EchoAneurysmalAs { get; set; }

        [DisplayName("Echo VSD")]
        public string EchoVsd { get; set; }

        [DisplayName("Echo Mitral Annular Ca++")]
        public string EchoMitralAnnularCa { get; set; }

        [DisplayName("Echo Restricted Leaflet Motion")]
        public string EchoRestrictedLeafletMotion { get; set; }

        [DisplayName("Echo Restricted Leaflet Motion Aortic")]
        public string EchoRestrictedLeafletMotionAortic { get; set; }

        [DisplayName("Echo Restricted Leaflet Motion Mitral")]
        public string EchoRestrictedLeafletMotionMitral { get; set; }

        [DisplayName("Echo Restricted Leaflet Motion Pulmonic")]
        public string EchoRestrictedLeafletMotionPulmonic { get; set; }

        [DisplayName("Echo Restricted Leaflet Motion Tricuspid")]
        public string EchoRestrictedLeafletMotionTricuspid { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Hypokinetic")]
        public string EchoWallMotionAnormalityHypokinetic { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Akinetic")]
        public string EchoWallMotionAnormalityAkinetic { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Dyskinetic")]
        public string EchoWallMotionAnormalityDyskinetic { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Anterior")]
        public string EchoWallMotionAnormalityAnerior { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Posterior")]
        public string EchoWallMotionAnormalityPosterior { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Apical")]
        public string EchoWallMotionAnormalityApical { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Septal")]
        public string EchoWallMotionAnormalitySeptal { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Lateral")]
        public string EchoWallMotionAnormalityLateral { get; set; }

        [DisplayName("Echo Wall Motion Abnormality Inferior")]
        public string EchoWallMotionAnormalityInferior { get; set; }

        [DisplayName("Echo Technically Limited, but Readable")]
        public string EchoTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Echo Unreadable")]
        public string EchoRepeatStudyUnreadable { get; set; }

        [DisplayName("Echo Unable to Screen")]
        public string EchoUnableToScreen { get; set; }

        [DisplayName("Echo Critical")]
        public string EchoCritical { get; set; }

        [DisplayName("Echo Physician Notes")]
        public string EchoPhysicianNotes { get; set; }




        [DisplayName("AAA Result")]
        public string AaaResult { get; set; }

        [DisplayName("AAA Largest Sagittal Measurement")]
        public string AaaLargestSagittalMeasurement { get; set; }

        [DisplayName("AAA Largest Sagittal Location")]
        public string AaaLargestSagittalLocation { get; set; }

        [DisplayName("AAA Largest Transverse Measurement 1")]
        public string AaaLargestTransverseMeasurement1 { get; set; }

        [DisplayName("AAA Largest Transverse Measurement 2")]
        public string AaaLargestTransverseMeasurement2 { get; set; }

        [DisplayName("AAA Largest Measurement Transverse Location")]
        public string AaaLargestMeasurementTransverseLocation { get; set; }

        [DisplayName("AAA Peak Systolic Velocity Measurement")]
        public string AaaPeakSystolicVelocityMeasurement { get; set; }

        [DisplayName("AAA Peak Systolic Velocity Location")]
        public string AaaPeakSystolicVelocityLocation { get; set; }

        [DisplayName("AAA Residual Lumen(Transverse View) Measurement 1")]
        public string AaaResidualLumenMeasurement1 { get; set; }

        [DisplayName("AAA Residual Lumen(Transverse View) Measurement 2")]
        public string AaaResidualLumenMeasurement2 { get; set; }

        [DisplayName("AAA Aortic Dissection")]
        public string AaaAorticDissection { get; set; }

        [DisplayName("AAA Plaque/Atherosclerosis")]
        public string AaaPlaque { get; set; }

        [DisplayName("AAA Thrombus")]
        public string AaaThrombus { get; set; }

        [DisplayName("AAA Aortic Stenosis")]
        public string AaaAorticStenosis { get; set; }

        [DisplayName("AAA Technically Limited, but Readable")]
        public string AaaTechnicallyLimitedButReadable { get; set; }

        [DisplayName("AAA Unreadable")]
        public string AaaRepeatStudyUnreadable { get; set; }

        [DisplayName("AAA Unable to Screen")]
        public string AaaUnabletoScreen { get; set; }

        [DisplayName("AAA Critical")]
        public string AaaCritical { get; set; }

        [DisplayName("AAA Physician Notes")]
        public string AaaPhysicianNotes { get; set; }



        [DisplayName("Carotid Stenosis Right")]
        public string CarotidRightResult { get; set; }

        [DisplayName("Carotid Stenosis Left")]
        public string CarotidLeftResult { get; set; }

        [DisplayName("Carotid Right CCA Proximal PSV")]
        public string CarotidRightCcaProximalPsv { get; set; }

        [DisplayName("Carotid Right CCA Proximal EDV")]
        public string CarotidRightCcaProximalEdv { get; set; }

        [DisplayName("Carotid Left CCA Proximal PSV")]
        public string CarotidLeftCcaProximalPsv { get; set; }

        [DisplayName("Carotid Left CCA Proximal EDV")]
        public string CarotidLeftCcaProximalEdv { get; set; }

        [DisplayName("Carotid Right CCA Distal PSV")]
        public string CarotidRightCcaDistalPsv { get; set; }

        [DisplayName("Carotid Right CCA Distal EDV")]
        public string CarotidRightCcaDistalEdv { get; set; }

        [DisplayName("Carotid Left CCA Distal PSV")]
        public string CarotidLeftCcaDistalPsv { get; set; }

        [DisplayName("Carotid Left CCA Distal EDV")]
        public string CarotidLeftCcaDistalEdv { get; set; }

        [DisplayName("Carotid Right Bulb PSV")]
        public string CarotidRightBulbPsv { get; set; }

        [DisplayName("Carotid Right Bulb EDV")]
        public string CarotidRightBulbEdv { get; set; }

        [DisplayName("Carotid Left Bulb PSV")]
        public string CarotidLeftBulbPsv { get; set; }

        [DisplayName("Carotid Left Bulb EDV")]
        public string CarotidLeftBulbEdv { get; set; }

        [DisplayName("Carotid Right Ext Carotid Art PSV")]
        public string CarotidRightExtCarotidArtPsv { get; set; }

        [DisplayName("Carotid Left Ext Carotid Art PSV")]
        public string CarotidLeftExtCarotidArtPsv { get; set; }

        [DisplayName("Carotid Right ICA Proximal PSV")]
        public string CarotidRightIcaProximalPsv { get; set; }

        [DisplayName("Carotid Right ICA Proximal EDV")]
        public string CarotidRightIcaProximalEdv { get; set; }

        [DisplayName("Carotid Left ICA Proximal PSV")]
        public string CarotidLeftIcaProximalPsv { get; set; }

        [DisplayName("Carotid Left ICA Proximal EDV")]
        public string CarotidLeftIcaProximalEdv { get; set; }

        [DisplayName("Carotid Right ICA Distal PSV")]
        public string CarotidRightIcaDistalPsv { get; set; }

        [DisplayName("Carotid Right ICA Distal EDV")]
        public string CarotidRightIcaDistalEdv { get; set; }

        [DisplayName("Carotid Left ICA Distal PSV")]
        public string CarotidLeftIcaDistalPsv { get; set; }

        [DisplayName("Carotid Left ICA Distal EDV")]
        public string CarotidLeftIcaDistalEdv { get; set; }

        [DisplayName("Carotid Right Vertebral Art PSV")]
        public string CarotidRightVertebralArtPsv { get; set; }

        [DisplayName("Carotid Right Vertebral Art EDV")]
        public string CarotidRightVertebralArtEdv { get; set; }

        [DisplayName("Carotid Left Vertebral Art PSV")]
        public string CarotidLeftVertebralArtPsv { get; set; }

        [DisplayName("Carotid Left Vertebral Art EDV")]
        public string CarotidLeftVertebralArtEdv { get; set; }

        [DisplayName("Carotid Unusually Low Velocity RICA")]
        public string CarotidLowVelocityRica { get; set; }

        [DisplayName("Carotid Unusually Low Velocity LICA")]
        public string CarotidLowVelocityLica { get; set; }

        [DisplayName("Carotid Technically Limited, but Readable")]
        public string CarotidTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Carotid Unreadable")]
        public string CarotidRepeatStudyUnreadable { get; set; }

        [DisplayName("Carotid Unable to Screen")]
        public string CarotidUnabletoScreen { get; set; }

        [DisplayName("Carotid Critical")]
        public string CarotidCritical { get; set; }

        [DisplayName("Carotid Physician Notes")]
        public string CarotidPhysicianNotes { get; set; }



        [DisplayName("Spirometry Result")]
        public string SpirometryResult { get; set; }

        [DisplayName("Spirometry Incidental Finding Restrictive")]
        public string SpirometryIncidentalFindingRestrictive { get; set; }

        [DisplayName("Spirometry Incidental Finding  Obstructive")]
        public string SpirometryIncidentalFindingObstructive { get; set; }

        [DisplayName("Spirometry Poor Effort")]
        public string SpirometryPoorEffort { get; set; }

        [DisplayName("Spirometry Technically Limited, but Readable")]
        public string SpirometryTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Spirometry Unreadable")]
        public string SpirometryRepeatStudyUnreadable { get; set; }

        [DisplayName("Spirometry Unable to Screen")]
        public string SpirometryUnabletoScreen { get; set; }

        [DisplayName("Spirometry Critical")]
        public string SpirometryCritical { get; set; }

        [DisplayName("Spirometry Physician Notes")]
        public string SpirometryPhysicianNotes { get; set; }



        [DisplayName("ABI Result")]
        public string AbiResult { get; set; }

        [DisplayName("ABI Systolic R Arm")]
        public string AbiSystolicRArm { get; set; }

        [DisplayName("ABI Systolic L Arm")]
        public string AbiSystolicLArm { get; set; }

        [DisplayName("ABI Systolic R Ankle")]
        public string AbiSystolicRAnkle { get; set; }

        [DisplayName("ABI Systolic L Ankle")]
        public string AbiSystolicLAnkle { get; set; }

        [DisplayName("ABI Right ABI")]
        public string AbiRightAbi { get; set; }

        [DisplayName("ABI Left ABI")]
        public string AbiLeftAbi { get; set; }

        [DisplayName("ABI Unreadable")]
        public string AbiRepeatStudyUnreadable { get; set; }

        [DisplayName("ABI Unable to Screen")]
        public string AbiUnabletoScreen { get; set; }

        [DisplayName("ABI Critical")]
        public string AbiCritical { get; set; }

        [DisplayName("ABI Physician Notes")]
        public string AbiPhysicianNotes { get; set; }




        [DisplayName("EKG Result")]
        public string EkgResult { get; set; }

        [DisplayName("EKG Repeat Study")]
        public string EkgRepeatStudy { get; set; }

        [DisplayName("EKG Reversed Leads")]
        public string EkgReversedLeads { get; set; }

        [DisplayName("EKG Artifact")]
        public string EkgArtifact { get; set; }

        [DisplayName("EKG Compare to Previous EKG")]
        public string EkgComparetoPreviousEkg { get; set; }

        [DisplayName("EKG Sinus Rhythm")]
        public string EkgSinusRhythm { get; set; }

        [DisplayName("EKG  Sinus Arrhythmia")]
        public string EkgSinusArrhythmia { get; set; }

        [DisplayName("EKG Sinus Bradycardia")]
        public string EkgSinusBradycardia { get; set; }

        [DisplayName("EKG Sinus Bradycardia Marked Less Than 50")]
        public string EkgSinusBradycardiaMarkLessFifty { get; set; }

        [DisplayName("EKG Sinus Tachycardia")]
        public string EkgSinusTachycardia { get; set; }

        [DisplayName("EKG Atrial Fibrillation")]
        public string EkgAtrialFibrillation { get; set; }

        [DisplayName("EKG  Atrial Flutter")]
        public string EkgAtrialFlutter { get; set; }

        [DisplayName("EKG Supraventricular Arrhythmia")]
        public string EkgSupraventricularArrhythmia { get; set; }

        [DisplayName("EKG SVT")]
        public string EkgSvt { get; set; }

        [DisplayName("EKG PAC(s)")]
        public string EkgPac { get; set; }

        [DisplayName("EKG PVC(s)")]
        public string EkgPvc { get; set; }

        [DisplayName("EKG Pacer Rhythm")]
        public string EkgPacerRhythm { get; set; }

        [DisplayName("EKG Bundle Branch Block")]
        public string EkgBundleBranchBlock { get; set; }

        [DisplayName("EKG Bundle Branch Block Left")]
        public string EkgBundleBranchBlockLeft { get; set; }

        [DisplayName("EKG Bundle Branch Block Right")]
        public string EkgBundleBranchBlockRight { get; set; }

        [DisplayName("EKG Bundle Branch Block Incomplete")]
        public string EkgBundleBranchBlockIncomplete { get; set; }

        [DisplayName("EKG Bundle Branch Block IVCD-NS")]
        public string EkgBundleBranchBlockIvcdns { get; set; }

        [DisplayName("EKG Bundle Branch Block Bifasc")]
        public string EkgBundleBranchBlockBifasc { get; set; }

        [DisplayName("EKG QRS widening")]
        public string EkgQrsWidening { get; set; }

        [DisplayName("EKG Left Axis")]
        public string EkgLeftAxis { get; set; }

        [DisplayName("EKG Right Axis")]
        public string EkgRightAxis { get; set; }

        [DisplayName("EKG Abnormal Axis")]
        public string EkgAbnormalAxis { get; set; }

        [DisplayName("EKG Abnormal Axis Left")]
        public string EkgAbnormalAxisLeft { get; set; }

        [DisplayName("EKG Abnormal Axis Right")]
        public string EkgAbnormalAxisRight { get; set; }

        [DisplayName("EKG Left Anterior Fasicular Block")]
        public string EkgLeftAnteriorFasicularBlock { get; set; }

        [DisplayName("EKG AV Nodal Heart Block")]
        public string EkgAvNodalHeartBlock { get; set; }

        [DisplayName("EKG AV Nodal Heart Block 1st Degree AV Block")]
        public string EkgAvNodalHeartBlockFirstDegree { get; set; }

        [DisplayName("EKG AV Nodal Heart Block 2nd Degree Mobitz I AV Block")]
        public string EkgAvNodalHeartBlockSecondDegreeMobitzOne { get; set; }

        [DisplayName("EKG AV Nodal Heart Block 2nd Degree Mobitz II AV Block")]
        public string EkgAvNodalHeartBlockSecondDegreeMobitzTwo { get; set; }

        [DisplayName("EKG AV Nodal Heart Block 3rd Degree Complete AV Block")]
        public string EkgAvNodalHeartBlockThirdDegree { get; set; }

        [DisplayName("EKG Short P-R interval for rate")]
        public string EkgShortPrIinterval { get; set; }

        [DisplayName("EKG R/O Ventricular Hypertrophy")]
        public string EkgRoVentricularHypertrophy { get; set; }

        [DisplayName("EKG R/O Ventricular Hypertrophy Left")]
        public string EkgRoVentricularHypertrophyLeft { get; set; }

        [DisplayName("EKG R/O Ventricular Hypertrophy Right")]
        public string EkgRoVentricularHypertrophyRight { get; set; }

        [DisplayName("EKG Prolonged QTc Interval")]
        public string EkgProlongedQTcInterval { get; set; }

        [DisplayName("EKG R/O Ischemic ST-T changes")]
        public string EkgRoIschemicSttChanges { get; set; }

        [DisplayName("EKG Non Specific ST-T changes")]
        public string EkgNonSpecificSttChanges { get; set; }

        [DisplayName("EKG Poor R Wave Progression")]
        public string EkgPoorRWaveProgression { get; set; }

        [DisplayName("EKG R/O Infarction Pattern")]
        public string EkgRoInfarctionPattern { get; set; }

        [DisplayName("EKG R/O Infarction Pattern Septal")]
        public string EkgRoInfarctionPatternSeptal { get; set; }

        [DisplayName("EKG R/O Infarction Pattern Posterior")]
        public string EkgRoInfarctionPatternPosterior { get; set; }

        [DisplayName("EKG R/O Infarction Pattern Anterior")]
        public string EkgRoInfarctionPatternAnterior { get; set; }

        [DisplayName("EKG R/O Infarction Pattern Lateral")]
        public string EkgRoInfarctionPatternLateral { get; set; }

        [DisplayName("EKG R/O Infarction Pattern Inferior")]
        public string EkgRoInfarctionPatternInferior { get; set; }

        [DisplayName("EKG Atypical Q Wave lead III")]
        public string EkgAtypicalQWavelead { get; set; }

        [DisplayName("EKG Atrial Enlargement")]
        public string EkgAtrialEnlargement { get; set; }

        [DisplayName("EKG Atrial Enlargement Left")]
        public string EkgAtrialEnlargementLeft { get; set; }

        [DisplayName("EKG Atrial Enlargement Right")]
        public string EkgAtrialEnlargementRight { get; set; }

        [DisplayName("EKG Repolarization Variant")]
        public string EkgRepolarizationVariant { get; set; }

        [DisplayName("EKG Low Voltage")]
        public string EkgLowVoltage { get; set; }

        [DisplayName("EKG Low Voltage Limb leads")]
        public string EkgLowVoltageLimbleads { get; set; }

        [DisplayName("EKG Low Voltage Precordial leads")]
        public string EkgLowVoltagePrecordialleads { get; set; }

        [DisplayName("EKG Unable to Screen")]
        public string EkgUnabletoScreen { get; set; }

        [DisplayName("EKG Critical")]
        public string EkgCritical { get; set; }

        [DisplayName("EKG Physician Notes")]
        public string EkgPhysicianNotes { get; set; }



        [DisplayName("Vision Result")]
        public string VisionResult { get; set; }

        [DisplayName("Vision Level Right Eye")]
        public string VisionLevelRightEye { get; set; }

        [DisplayName("Vision Level Left Eye")]
        public string VisionLevelLeftEye { get; set; }

        [DisplayName("Vision Technically Limited, but Readable")]
        public string VisionTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Vision Unreadable")]
        public string VisionRepeatStudyUnreadable { get; set; }

        [DisplayName("Vision Unable to Screen")]
        public string VisionUnabletoScreen { get; set; }

        [DisplayName("Vision Critical")]
        public string VisionCritical { get; set; }

        [DisplayName("Vision Physician Notes")]
        public string VisionPhysicianNotes { get; set; }



        [DisplayName("Quality Measures Functional Assessment Score (Katz)")]
        public string QualityMeasuresFunctionalAssessmentScore { get; set; }

        [DisplayName("Quality Measures Pain Assessment Score")]
        public string QualityMeasuresPainAssessmentScore { get; set; }

        [DisplayName("Quality Measures Memory Recall Score")]
        public string QualityMeasuresMemoryRecallScore { get; set; }

        [DisplayName("Quality Measures Clock Drawing")]
        public string QualityMeasuresClock { get; set; }

        [DisplayName("Quality Measures Gait")]
        public string QualityMeasuresGait { get; set; }

        [DisplayName("Quality Measures Unable to Screen")]
        public string QualityMeasuresUnabletoScreen { get; set; }

        [DisplayName("Quality Measures Critical")]
        public string QualityMeasuresCritical { get; set; }

        [DisplayName("Quality Measures Physician Notes")]
        public string QualityMeasuresPhysicianNotes { get; set; }



        [DisplayName("PHQ-9 Depression Assessment Score")]
        public string Phq9Score { get; set; }

        [DisplayName("PHQ-9  Unable to Screen")]
        public string Phq9UnabletoScreen { get; set; }

        [DisplayName("PHQ-9 Critical")]
        public string Phq9Critical { get; set; }

        [DisplayName("PHQ-9 Physician Notes")]
        public string Phq9PhysicianNotes { get; set; }



        [DisplayName("Bone Mass Result")]
        public string BoneMassResult { get; set; }

        [DisplayName("Bone Mass EstimatedTScore")]
        public string BoneMassEstimatedTScore { get; set; }

        [DisplayName("Bone Mass Unable to Screen")]
        public string BoneMassUnabletoScreen { get; set; }

        [DisplayName("Bone Mass Critical")]
        public string BoneMassCritical { get; set; }

        [DisplayName("Bone Mass Physician Notes")]
        public string BoneMassPhysicianNotes { get; set; }


        [DisplayName("Screening mammography-digital Finding")]
        public string MammographyFinding { get; set; }

        [DisplayName("Screening mammography-digital Unable to Screen")]
        public string MammographyUnabletoScreen { get; set; }

        [DisplayName("Screening mammography-digital Critical")]
        public string MammographyCritical { get; set; }


        [DisplayName("LEAD Result")]
        public string LeadResult { get; set; }

        [DisplayName("LEAD Right No visual plaque shown")]
        public string LeadRightNoVisualPlaque { get; set; }

        [DisplayName("LEAD Right Visually demonstrated plaque/calcification")]
        public string LeadRightVisuallyDemonstratedPlaque { get; set; }

        [DisplayName("LEAD Right Moderate stenosis or greater(PSV Greater than 200cm/s)")]
        public string LeadRightModerateStenosis { get; set; }

        [DisplayName("LEAD Right Possible Occlusion")]
        public string LeadRightPossibleOcclusion { get; set; }

        [DisplayName("LEAD Right CFA (Common femoral artery) PSV")]
        public string LeadRightCfaPsv { get; set; }

        [DisplayName("LEAD Right PSFA (Proximal femoral artery) PSV")]
        public string LeadRightPsfaPsv { get; set; }

        [DisplayName("LEAD Unusually Low Velocity Right - Possible aorto-iliac disease")]
        public string LeadRightLowVelocity { get; set; }


        [DisplayName("LEAD Left No visual plaque shown")]
        public string LeadLeftNoVisualPlaque { get; set; }

        [DisplayName("LEAD Left Visually demonstrated plaque/calcification")]
        public string LeadLeftVisuallyDemonstratedPlaque { get; set; }

        [DisplayName("LEAD Left Moderate stenosis or greater(PSV Greater than 200cm/s)")]
        public string LeadLeftModerateStenosis { get; set; }

        [DisplayName("LEAD Left Possible Occlusion")]
        public string LeadLeftPossibleOcclusion { get; set; }

        [DisplayName("LEAD Left CFA (Common femoral artery) PSV")]
        public string LeadLeftCfaPsv { get; set; }

        [DisplayName("LEAD Left PSFA (Proximal femoral artery) PSV")]
        public string LeadLeftPsfaPsv { get; set; }

        [DisplayName("LEAD Unusually Low Velocity Left - Possible aorto-iliac disease")]
        public string LeadLeftLowVelocity { get; set; }


        [DisplayName("LEAD Technically Limited, but Readable")]
        public string LeadTechnicallyLimitedButReadable { get; set; }

        [DisplayName("LEAD Unreadable")]
        public string LeadRepeatStudyUnreadable { get; set; }

        [DisplayName("LEAD Unable to Screen")]
        public string LeadUnabletoScreen { get; set; }

        [DisplayName("LEAD Critical")]
        public string LeadCritical { get; set; }

        [DisplayName("LEAD Physician Notes")]
        public string LeadPhysicianNotes { get; set; }



        [DisplayName("Urine Microalbumin Result")]
        public string UrineMicroalbuminResult { get; set; }

        [DisplayName("Urine Microalbumin Serial Key")]
        public string UrineMicroalbuminSerialKey { get; set; }

        [DisplayName("Urine Microalbumin Value")]
        public string UrineMicroalbuminValue { get; set; }

        [DisplayName("Urine Microalbumin Technically Limited, but Readable")]
        public string UrineMicroalbuminTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Urine Microalbumin Unreadable")]
        public string UrineMicroalbuminRepeatStudyUnreadable { get; set; }

        [DisplayName("Urine Microalbumin Unable to Screen")]
        public string UrineMicroalbuminUnabletoScreen { get; set; }

        [DisplayName("Urine Microalbumin Critical")]
        public string UrineMicroalbuminCritical { get; set; }

        [DisplayName("Urine Microalbumin Physician Notes")]
        public string UrineMicroalbuminPhysicianNotes { get; set; }



        //[DisplayName("Diabetic Retinopathy Highest Level Of Specificity")]
        //public string DiabeticRetinopathyLevel { get; set; }

        //[DisplayName("Diabetic Retinopathy Macular Edema Highest Level Of Specificity")]
        //public string DiabeticRetinopathyMacularEdemaLevel { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected VeinOcclusion")]
        //public string DiabeticRetinopathyHasSuspectedVeinOcclusion { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Wet Amd")]
        //public string DiabeticRetinopathyHasSuspectedWetAmd { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Dry Amd")]
        //public string DiabeticRetinopathyHasSuspectedDryAmd { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Htn Retinopathy")]
        //public string DiabeticRetinopathyHasSuspectedHtnRetinopathy { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Epiretinal Membrane")]
        //public string DiabeticRetinopathyHasSuspectedEpiretinalMembrane { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Macular Hole")]
        //public string DiabeticRetinopathyHasSuspectedMacularHole { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Cataract")]
        //public string DiabeticRetinopathyHasSuspectedCataract { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Other Disease")]
        //public string DiabeticRetinopathyHasSuspectedOtherDisease { get; set; }

        //[DisplayName("Diabetic Retinopathy Has Suspected Glaucoma")]
        //public string DiabeticRetinopathyHasSuspectedGlaucoma { get; set; }

        //[DisplayName("Diabetic Retinopathy Technically Limited, but Readable")]
        //public string DiabeticRetinopathyTechnicallyLimitedButReadable { get; set; }

        //[DisplayName("Diabetic Retinopathy Unreadable")]
        //public string DiabeticRetinopathyRepeatStudyUnreadable { get; set; }

        //[DisplayName("Diabetic Retinopathy Unable to Screen")]
        //public string DiabeticRetinopathyUnabletoScreen { get; set; }

        //[DisplayName("Diabetic Retinopathy Critical")]
        //public string DiabeticRetinopathyCritical { get; set; }

        //[DisplayName("Diabetic Retinopathy Physician Notes")]
        //public string DiabeticRetinopathyPhysicianNotes { get; set; }


        [DisplayName("Hemoglobin A1C")]
        public string HemoglobinReading { get; set; }

        [DisplayName("Hemoglobin Unable to Screen")]
        public string HemoglobinUnabletoScreen { get; set; }

        [DisplayName("Hemoglobin Critical")]
        public string HemoglobinCritical { get; set; }

        [DisplayName("Hemoglobin Physician Notes")]
        public string HemoglobinPhysicianNotes { get; set; }


        [DisplayName("IFOBT Result")]
        public string IfobtFinding { get; set; }

        [DisplayName("IFOBT Serial Key")]
        public string IfobtSerialKey { get; set; }

        [DisplayName("IFOBT Unable to Screen")]
        public string IfobtUnabletoScreen { get; set; }

        [DisplayName("IFOBT Critical")]
        public string IfobtCritical { get; set; }

        [DisplayName("IFOBT Physician Notes")]
        public string IfobtPhysicianNotes { get; set; }


        [DisplayName("FluShot Manufacturer")]
        public string FluShotManufacturer { get; set; }

        [DisplayName("FluShot Lot Number")]
        public string FluShotLotNumber { get; set; }

        [DisplayName("FluShot Unable to Screen")]
        public string FluShotUnabletoScreen { get; set; }

        [DisplayName("FluShot Critical")]
        public string FluShotCritical { get; set; }

        [DisplayName("FluShot Physician Notes")]
        public string FluShotPhysicianNotes { get; set; }


        [DisplayName("DPN Result")]
        public string DpnResult { get; set; }

        [DisplayName("DPN Amplitude")]
        public string DpnAmplitude { get; set; }

        [DisplayName("DPN Conduction Velocity")]
        public string DpnConductionVelocity { get; set; }

        [DisplayName("DPN Right Leg")]
        public string DpnRightLeg { get; set; }

        [DisplayName("DPN Left Leg")]
        public string DpnLeftLeg { get; set; }

        [DisplayName("DPN Unable to Screen")]
        public string DpnUnabletoScreen { get; set; }

        [DisplayName("DPN Critical")]
        public string DpnCritical { get; set; }

        [DisplayName("DPN Technically Limited, but Readable")]
        public string DpnTechnicallyLimitedButReadable { get; set; }

        [DisplayName("DPN Unreadable")]
        public string DpnRepeatStudyUnreadable { get; set; }


        [DisplayName("AwvLipid Total Cholesterol")]
        public string AwvLipidTotalCholesterol { get; set; }

        [DisplayName("AwvLipid Total Cholesterol Summary Finding")]
        public string AwvLipidTotalCholesterolFinding { get; set; }

        [DisplayName("AwvLipid HDL")]
        public string AwvLipidHdl { get; set; }

        [DisplayName("AwvLipid HDL Summary Finding")]
        public string AwvLipidHdlFinding { get; set; }

        [DisplayName("AwvLipid LDL")]
        public string AwvLipidLdl { get; set; }

        [DisplayName("AwvLipid LDL Summary Finding")]
        public string AwvLipidLdlFinding { get; set; }

        [DisplayName("AwvLipid TriGlycerides")]
        public string AwvLipidTriGlycerides { get; set; }

        [DisplayName("AwvLipid Triglycerides Summary Finding")]
        public string AwvLipidTriglyceridesFinding { get; set; }

        [DisplayName("AwvLipid TC/HDL Ratio")]
        public string AwvLipidTchdlRatio { get; set; }

        [DisplayName("AwvLipid TC/HDL Ratio Summary Finding")]
        public string AwvLipidTcHdlFinding { get; set; }

        [DisplayName("AwvLipid Unable to Screen")]
        public string AwvLipidUnabletoScreen { get; set; }

        [DisplayName("AwvLipid Critical")]
        public string AwvLipidCritical { get; set; }


        [DisplayName("Diabetic Neuropathy Result")]
        public string DiabeticNeuropathyResult { get; set; }

        [DisplayName("Diabetic Neuropathy Amplitude")]
        public string DiabeticNeuropathyAmplitude { get; set; }

        [DisplayName("Diabetic Neuropathy Conduction Velocity")]
        public string DiabeticNeuropathyConductionVelocity { get; set; }

        [DisplayName("Diabetic Neuropathy Right Leg")]
        public string DiabeticNeuropathyRightLeg { get; set; }

        [DisplayName("Diabetic Neuropathy Left Leg")]
        public string DiabeticNeuropathyLeftLeg { get; set; }

        [DisplayName("Diabetic Neuropathy Unable to Screen")]
        public string DiabeticNeuropathyUnabletoScreen { get; set; }

        [DisplayName("Diabetic Neuropathy Critical")]
        public string DiabeticNeuropathyCritical { get; set; }

        [DisplayName("Diabetic Neuropathy Technically Limited, but Readable")]
        public string DiabeticNeuropathyTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Diabetic Neuropathy Unreadable")]
        public string DiabeticNeuropathyRepeatStudyUnreadable { get; set; }


        [DisplayName("QuantaFlo-ABI Result")]
        public string QuantaFloAbiResult { get; set; }

        [DisplayName("QuantaFlo-ABI Unable to Screen")]
        public string QuantaFloAbiUnableToScreen { get; set; }

        [DisplayName("QuantaFlo-ABI Critical")]
        public string QuantaFloAbiCritical { get; set; }


        [Hidden]
        public string AdditionalField1 { get; set; }

        [Hidden]
        public string AdditionalField2 { get; set; }

        [Hidden]
        public string AdditionalField3 { get; set; }

        [Hidden]
        public string AdditionalField4 { get; set; }

    }
}
