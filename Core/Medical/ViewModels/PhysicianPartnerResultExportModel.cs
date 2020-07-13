using System;
using System.Collections.Generic;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianPartnerResultExportModel
    {
        [DisplayName("ID")]
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

        public string Gender { get; set; }

        public string Race { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Ssn { get; set; }

        [DisplayName("Member Id")]
        public string MemberId { get; set; }

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

        [DisplayName("Echo Valve Aortic Morphology Bicuspid AV")]
        public string EchoValveAorticMorphologyBicuspidAv { get; set; }

        [DisplayName("Echo Valve Aortic Morphology Velocity")]
        public string EchoValveAorticMorphologyVelocity { get; set; }

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

        [DisplayName("Echo Valve Tricuspid Morphology  High, 35mmHg or greater")]
        public string EchoValveTricuspidMorphologyHigh35MmHgGreater { get; set; }

        [DisplayName("Echo Valve Tricuspid Morphology  Normal")]
        public string EchoValveTricuspidMorphologyNormal { get; set; }

        [DisplayName("Echo Diastolic Dysfunction")]
        public string EchoDiastolicDysfunction { get; set; }

        [DisplayName("Echo Diastolic Dysfunction Grade")]
        public string EchoDiastolicDysfunctionGrade { get; set; }

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

        [DisplayName("Echo Aortic Root")]
        public string EchoAorticRoot { get; set; }

        [DisplayName("Echo Aortic Root Sclerotic")]
        public string EchoAorticRootSclerotic { get; set; }

        [DisplayName("Echo Aortic Root Calcified")]
        public string EchoAorticRootCalcified { get; set; }

        [DisplayName("Echo Aortic Root Enlarged")]
        public string EchoAorticRootEnlarged { get; set; }

        [DisplayName("Echo Aortic Root Enlarged Measurment")]
        public string EchoAorticRootEnlargedMeasurment { get; set; }

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

        [DisplayName("Echo Arrythmia ASD")]
        public string EchoArrythmiaASD { get; set; }

        [DisplayName("Echo Arrythmia PFO")]
        public string EchoArrythmiaPFO { get; set; }

        [DisplayName("Echo Arrythmia Flail AS")]
        public string EchoArrythmiaFlailAS { get; set; }

        [DisplayName("Echo Wall Motion Anormality Hypokinetic")]
        public string EchoWallMotionAnormalityHypokinetic { get; set; }

        [DisplayName("Echo Wall Motion Anormality Akinetic")]
        public string EchoWallMotionAnormalityAkinetic { get; set; }

        [DisplayName("Echo Wall Motion Anormality Dyskinetic")]
        public string EchoWallMotionAnormalityDyskinetic { get; set; }

        [DisplayName("Echo Wall Motion Anormality Anerior")]
        public string EchoWallMotionAnormalityAnerior { get; set; }

        [DisplayName("Echo Wall Motion Anormality Posterior")]
        public string EchoWallMotionAnormalityPosterior { get; set; }

        [DisplayName("Echo Wall Motion Anormality Apical")]
        public string EchoWallMotionAnormalityApical { get; set; }

        [DisplayName("Echo Wall Motion Anormality Septal")]
        public string EchoWallMotionAnormalitySeptal { get; set; }

        [DisplayName("Echo Wall Motion Anormality Lateral")]
        public string EchoWallMotionAnormalityLateral { get; set; }

        [DisplayName("Echo Wall Motion Anormality Inferior")]
        public string EchoWallMotionAnormalityInferior { get; set; }

        [DisplayName("Echo VSD")]
        public string EchoVSD { get; set; }

        [DisplayName("Echo Systolic Anterior Motion")]
        public string EchoSAM { get; set; }

        [DisplayName("Echo Left Ventricular Outflow Tract Obstruction")]
        public string EchoLVOTO { get; set; }

        [DisplayName("Echo Manual Annular C++")]
        public string EchoManualAnnularC { get; set; }

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

        public IEnumerable<OrderedPair<string, string>> EchoDiagnosisCodes { get; set; }



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

        public IEnumerable<OrderedPair<string, string>> AaaDiagnosisCodes { get; set; }



        [DisplayName("Lead Right Result")]
        public string LeadRightResult { get; set; }

        [DisplayName("Lead Left Result")]
        public string LeadLeftResult { get; set; }

        [DisplayName("Lead Right CFA Measurement")]
        public string LeadRightCfaMeasurement { get; set; }

        [DisplayName("Lead Right PSFA Measurement")]
        public string LeadRightPsfaMeasurement { get; set; }

        [DisplayName("Lead Left CFA Measurement")]
        public string LeadLeftCfaMeasurement { get; set; }

        [DisplayName("Lead Left PSFA Measurement")]
        public string LeadLeftPsfaMeasurement { get; set; }

        [DisplayName("Lead Unuaually Low Velocity Right")]
        public string LeadUnuauallyLowVelocityRight { get; set; }

        [DisplayName("Lead Unuaually Low Velocity Left")]
        public string LeadUnuauallyLowVelocityLeft { get; set; }

        [DisplayName("Lead Technically Limited, but Readable")]
        public string LeadTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Lead Unreadable")]
        public string LeadRepeatStudyUnreadable { get; set; }

        [DisplayName("Lead Unable to Screen")]
        public string LeadUnabletoScreen { get; set; }

        [DisplayName("Lead Critical")]
        public string LeadCritical { get; set; }

        [DisplayName("Lead Physician Notes")]
        public string LeadPhysicianNotes { get; set; }

        public IEnumerable<OrderedPair<string, string>> LeadDiagnosisCodes { get; set; }



        [DisplayName("Spiro Result")]
        public string SpiroResult { get; set; }

        [DisplayName("Spiro Poor Effort")]
        public string SpiroPoorEffort { get; set; }

        [DisplayName("Spiro Restrictive")]
        public string SpiroRestrictive { get; set; }

        [DisplayName("Spiro Obstructive")]
        public string SpiroObstructive { get; set; }

        [DisplayName("Spiro Technically Limited, but Readable")]
        public string SpiroTechnicallyLimitedButReadable { get; set; }

        [DisplayName("Spiro Unreadable")]
        public string SpiroRepeatStudyUnreadable { get; set; }

        [DisplayName("Spiro Unable to Screen")]
        public string SpiroUnabletoScreen { get; set; }

        [DisplayName("Spiro Critical")]
        public string SpiroCritical { get; set; }

        [DisplayName("Spiro Physician Notes")]
        public string SpiroPhysicianNotes { get; set; }
        
    }
}
