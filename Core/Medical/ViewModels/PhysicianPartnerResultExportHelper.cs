using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianPartnerResultExportHelper
    {
        public const long Sclerosis = 154;
        public const long Stenosis = 155;
        public const long BicuspidAv = 156;
        public const long MitralProlapse = 157;
        

        public const long Trival = 146;
        public const long Small = 147;
        public const long Moderate = 148;
        public const long Large = 149;
        

        public static IEnumerable<OrderedPair<long, string>> Questions
        {
            get
            {
                return new[]
                           {
                               new OrderedPair<long, string>(8, "HAF Had Heart Attack"),
                               new OrderedPair<long, string>(10, "HAF Had Coronary Bypass Surgery"),
                               new OrderedPair<long, string>(11, "HAF Had Heart Valve Surgery"),
                               new OrderedPair<long, string>(14, "HAF Had been told they have Mitral Valve Prolapse"),
                               new OrderedPair<long, string>(16, "HAF Had Carotid Surgery"),
                               new OrderedPair<long, string>(17, "HAF Had Carotid Surgery on Left Cartotid"),
                               new OrderedPair<long, string>(18, "HAF Had Carotid Surgery on Right Carotid"),
                               new OrderedPair<long, string>(19, "HAF Had a known Abdominal Aneurysm"),
                               new OrderedPair<long, string>(24, "HAF HAD active tuberculosis or is being treeted for active tuberculosis"),
                               new OrderedPair<long, string>(26, "HAF Have documented high cholesterol"),
                               new OrderedPair<long, string>(28, "HAF Diabetic"),
                               new OrderedPair<long, string>(29, "HAF Smoker"),
                               new OrderedPair<long, string>(30, "HAF Suffer from unexplained pain in the chest"),
                               new OrderedPair<long, string>(46, "HAF Currently Experiencing pain"),
                               new OrderedPair<long, string>(47, "HAF Level of Pain (1-10)"),
                               new OrderedPair<long, string>(57, "HAF Advanced Directive"),
                               new OrderedPair<long, string>(1000, "HAF Have primary care physician or a family doctor"),
                               new OrderedPair<long, string>(1001, "HAF Had a mammogram or prostate screening in last 12 months"),
                               new OrderedPair<long, string>(1002, "HAF Had colonoscopy in last 12 months"),
                               new OrderedPair<long, string>(1003, "HAF Have family history of any type of cancer"),
                               new OrderedPair<long, string>(1004, "HAF Struggle with managing your weight"),
                               new OrderedPair<long, string>(1005, "HAF History of Blood Clots, phlebitis, or Deep Vein Thromobosis"),
                               new OrderedPair<long, string>(1006, "HAF High Blood Pressure"),
                           };
            }
        }

        public static IEnumerable<long> QuestionIds
        {
            get { return Questions.Select(Q => Q.FirstValue).ToArray(); }
        }

        public static string Delimiter
        {
            get { return ","; }
        }

        public static string YesString
        {
            get
            {
                return "Yes";
            }
        }

        public static string NoString
        {
            get
            {
                return "No";
            }
        }

        public static string GetOutputFromBoolTypeResultReading(ResultReading<bool> reading)
        {
            return reading != null && reading.Reading ? YesString : NoString;
        }

        public static string[] EchoDiagnosisCodes
        {
            get
            {
                return new[]
                {
                    "Normal study",
                    "425.8 cardiomyopathy in other dis class elsewhere",
                    "428.20 unspec systolic heart failure",
                    "428.0 congestive heart failure, unspec",
                    "416.0 primary pulmonary hypertension (RV pressure of 35 mmHg or greater)",
                    "425.11 hypertrophic obstructive cardiomyopathy",
                    "428.30 unspec diastolic heart failure",
                    "412 old myocardial infarction",
                    "414.01 coronary artery disease native vessels",
                    "427.31 atrial fibrillation (afib)",
                    "427.32 atrial flutter"
                };
            }
        }

        public static string[] AaaDiagnosisCodes
        {
            get
            {
                return new[]
                {
                    "Normal study",
                    "447.72 abdominal aortic ectasia",
                    "441.4 abdominal aortic aneurysm without mention of rupture",
                    "440.0 atherosclerosis of aorta",
                    "441.0 aortic dissection"
                };
            }
        }

        public static string[] LeadDiagnosisCodes
        {
            get
            {
                return new[]
                {
                    "Normal study",
                    "443.89  peripheral arterial/vascular disease",
                    "440.20 atherosclerosis of native arteries of the extremities, unspecified",
                    "440.4 chronic total occlusion of the artery of extremities"
                };
            }
        }
    }
}
