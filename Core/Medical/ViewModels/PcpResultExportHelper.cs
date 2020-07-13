using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PcpResultExportHelper
    {
        public const long Sclerosis = 154;
        public const long Stenosis = 155;
        public const long BicuspidAv = 156;
        public const long MitralProlapse = 157;


        public const long Trival = 146;
        public const long Small = 147;
        public const long Moderate = 148;
        public const long Large = 149;

        public const long Left = 158;
        public const long Right = 159;
        public const long Incomplete = 160;
        public const long Ivcdns = 161;
        public const long Bifasc = 162;

        public const long Septal = 163;
        public const long Posterior = 164;
        public const long Anterior = 165;
        public const long Lateral = 166;
        public const long Inferior = 167;

        //public static IEnumerable<OrderedPair<long, string>> Questions
        //{
        //    get; set;
        //}

        public static IEnumerable<OrderedPair<long, string>> AllQuestions
        {
            get
            {
                return new[]
                           {
                               //Clinical Questions
                               //Bone Density Ultrasound
                               new OrderedPair<long, string>( 350, "CIQ Within the last 10 years have you had a bone fracture that was not caused by an accident?" ),
                               new OrderedPair<long, string>( 351, "CIQ Do you have a family history (mother or a sister) of osteoporosis?" ),
                               new OrderedPair<long, string>( 352, "CIQ Do you have a history of taking multiple courses of steroids?" ),
                               new OrderedPair<long, string>( 470, "CIQ Are you being currently treated with a medication to increase the strength of your bones?" ),

                               //A/B Index
                               new OrderedPair<long, string>( 355, "CIQ Do you experience leg pain/cramping when walking or wake from it at night?" ),
                               new OrderedPair<long, string>( 356, "CIQ Do you have any non-healing leg/ankle sores?" ),
                               new OrderedPair<long, string>( 357, "CIQ Are you diabetic and do your feet/toes look pale or feel numb?" ),
                               new OrderedPair<long, string>( 358, "CIQ Are you currently a smoker?" ),
                               new OrderedPair<long, string>( 487, "CIQ Do you have a history of blood clots, phlebitis, or Deep Vein Thrombosis (DVT)?" ),

                               //AAA
                               new OrderedPair<long, string>( 360, "CIQ Have you ever smoked?" ),
                               new OrderedPair<long, string>( 361, "CIQ Do you have a high blood pressure?" ),
                               new OrderedPair<long, string>( 362, "CIQ Have you ever been told you had a heart attack or stroke?" ),
                               new OrderedPair<long, string>( 471, "CIQ Have you smoked more than 100 cigs in your lifetime?" ),

                               //Carotid
                               new OrderedPair<long, string>( 365, "CIQ Do you have a history of previous stroke or TIA (mini stroke)?" ),
                               new OrderedPair<long, string>( 366, "CIQ Have you experienced sudden loss of vision in one eye?" ),
                               new OrderedPair<long, string>( 367, "CIQ Have you ever had garbled speech or temporary weakness on 1 side of your body?" ),
                               new OrderedPair<long, string>( 368, "CIQ Have you had previous carotid surgery?" ),

                               //Echocardiogram
                               new OrderedPair<long, string>( 370, "CIQ Do you have a history of heart attack?" ),
                               new OrderedPair<long, string>( 371, "CIQ Have you ever been told you have heart valve disease?" ),
                               new OrderedPair<long, string>( 372, "CIQ Have you had Coronary artery bypass grafting/surgery (CABG) (pronounced \"cabbage\")?" ),
                               new OrderedPair<long, string>( 373, "CIQ Have you ever been told you have COPD?" ),
                               new OrderedPair<long, string>( 374, "CIQ Are you currently taking Inhalers?" ),
                               new OrderedPair<long, string>( 375, "CIQ Are you currently using Oxygen?" ),
                               new OrderedPair<long, string>( 376, "CIQ Do you experience shortness of breath with minimal activity?" ),
                               new OrderedPair<long, string>( 377, "CIQ Do you experience shortness of breath when lying down?" ),
                               
                               //Spirometry
                               new OrderedPair<long, string>( 472, "CIQ Do any of the following apply to you?" ),
                               new OrderedPair<long, string>( 473, "CIQ Do you Smoke or Have you been exposed to smoke for more than 5 years?" ),
                               new OrderedPair<long, string>( 474, "CIQ Do you have a history of asthma?" ),
                               new OrderedPair<long, string>( 475, "CIQ Have you been exposed to occupational dusts or chemicals?" ),
                               new OrderedPair<long, string>( 476, "CIQ Do you have a genetic disorder called alpha-1-antitrypsin deficiency?" ),
                               new OrderedPair<long, string>( 477, "CIQ Do you have any of the following symptoms?" ),
                               new OrderedPair<long, string>( 478, "CIQ Shortness of breath especially during physical activity?" ),
                               new OrderedPair<long, string>( 479, "CIQ Wheezing, chest tightness, excess mucus in your lungs, chronic productive cough?" ),
                               new OrderedPair<long, string>( 480, "CIQ Blue lips or nails?" ),

                               //Diabetes Panel
                               new OrderedPair<long, string>( 481, "CIQ Do you have diabetes or are considered borderline diabetic?" ),

                               //BMP
                               new OrderedPair<long, string>( 482, "CIQ Do you have a history of hypertension (high blood pressure)?" ),

                               //Lipid Profile
                               new OrderedPair<long, string>( 483, "CIQ Do you have a history of CAD (coronary artery disease)?" ),

                               //Micro-Albumin and Creatinine
                               new OrderedPair<long, string>( 484, "CIQ Are you diabetic and have high blood pressure?" ),

                               //Hepatitis C
                               new OrderedPair<long, string>( 486, "CIQ Have you been tested for Hepatitis C?" ),

                               //iFOBT
                               new OrderedPair<long, string>( 485, "CIQ Have you had a fecal (stool sample) tested in the past year?" ),


                              //Risk Assessment
                              new OrderedPair<long, string>( 381, "Risk Assessment Do you always fasten your seat belt when you are in the car?" ),
                              new OrderedPair<long, string>( 383, "Risk Assessment Do you have any problems with hearing?" ),
                              new OrderedPair<long, string>( 385, "Risk Assessment Do you have a problem with balance?" ),
                              new OrderedPair<long, string>( 387, "Risk Assessment Do you have a problem walking?" ),
                              new OrderedPair<long, string>( 389, "Risk Assessment A fall is when your body goes to the ground without being pushed. Have you fallen in the last 12 months?" ),
                              new OrderedPair<long, string>( 391, "Risk Assessment Where you injured in the fall?" ),
                              new OrderedPair<long, string>( 393, "Risk Assessment Have you had more the one fall?" ),
                              new OrderedPair<long, string>( 395, "Risk Assessment In the past 7 days, did you need help from others to perform everyday activities such as eating, getting dressed, grooming, bathing, walking, getting in or out of bed or a chair, or using the toilet?" ),
                              new OrderedPair<long, string>( 397, "Risk Assessment Eating" ),
                              new OrderedPair<long, string>( 399, "Risk Assessment Getting dressed" ),
                              new OrderedPair<long, string>( 401, "Risk Assessment Bathing" ),
                              new OrderedPair<long, string>( 403, "Risk Assessment Walking" ),
                              new OrderedPair<long, string>( 405, "Risk Assessment Getting in or out of Bed or a Chair" ),
                              new OrderedPair<long, string>( 407, "Risk Assessment Using the Toilet" ),
                              new OrderedPair<long, string>( 409, "Risk Assessment In the past 7 days, did you need help from others to take care of things such as laundry and housekeeping, banking, shopping, using the telephone, food preparation, transportation or taking your own medications?" ),
                              new OrderedPair<long, string>( 411, "Risk Assessment Do you use Assistive Devices?" ),
                              new OrderedPair<long, string>( 415, "Risk Assessment Continence :Are you able to control the use of your Bladder" ),
                              new OrderedPair<long, string>( 417, "Risk Assessment Continence :Are you able to control the use of your Bowel" ),
                              new OrderedPair<long, string>( 419, "Risk Assessment Do you have a Hearing Impairment" ),
                              new OrderedPair<long, string>( 421, "Risk Assessment Do you use a Hearing Aid" ),
                              new OrderedPair<long, string>( 423, "Risk Assessment Do you live alone or with others?" ),
                              new OrderedPair<long, string>( 425, "Risk Assessment Others" ),

                              //Immunizations
                              new OrderedPair<long, string>( 427, "Immunizations Date of last Flu Vaccine:" ),
                              new OrderedPair<long, string>( 429, "Immunizations Date of last Pneumococcal Vaccine:" ),


                               //HRA
                               new OrderedPair<long, string>(8, "HAF Have you ever had a heart attack?"),
                               new OrderedPair<long, string>(10, "HAF Have you ever had coronary bypass surgery?"),
                               new OrderedPair<long, string>(11, "HAF Have you ever had heart valve surgery?"),
                               new OrderedPair<long, string>(196, "HAF Do you have a family history of Heart Disease?"),

                               new OrderedPair<long, string>(14, "HAF Have you ever been told that you have Mitral Valve Prolapse?"),

                               new OrderedPair<long, string>(16, "HAF Have you ever had carotid artery surgery?"),
                               new OrderedPair<long, string>(17, "HAF Had Carotid Surgery on Left Cartotid"),
                               new OrderedPair<long, string>(18, "HAF Had Carotid Surgery on Right Carotid"),
                               new OrderedPair<long, string>(19, "HAF Do you have a known abdominal aneurysm?"),
                               new OrderedPair<long, string>(185, "HAF Have you had an Echocardiogram Ultrasound?"),
                               new OrderedPair<long, string>(186, "HAF If yes when?"),
                               new OrderedPair<long, string>(187, "HAF Have you had an ECG(Electrocardiogram)?"),
                               new OrderedPair<long, string>(188, "HAF If yes when?"),
                               new OrderedPair<long, string>(189, "HAF Have you had a Carotid Artery Ultrasound?"),
                               new OrderedPair<long, string>(190, "HAF If yes when?"),
                               new OrderedPair<long, string>(191, "HAF Have you ever had an ABI(PAD) screening?"),
                               new OrderedPair<long, string>(192, "HAF If yes when?"),
                               
                               new OrderedPair<long, string>(24, "HAF Do you have active tuberculosis or are you being treated for active tuberculosis?"),
                               new OrderedPair<long, string>(26, "HAF Do you have documented high cholesterol?"),

                                new OrderedPair<long, string>(28, "HAF Are you a diabetic?"),
                               new OrderedPair<long, string>(29, "HAF Do you smoke?"),

                               new OrderedPair<long, string>(87, "HAF Are you ready to quit smoking?"),
                               new OrderedPair<long, string>(30, "HAF Do you suffer from unexplained pain in the chest?"),
                               new OrderedPair<long, string>(46, "HAF Currently Experiencing pain"),
                               new OrderedPair<long, string>(47, "HAF Level of Pain (1-10)"),
                               new OrderedPair<long, string>(57, "HAF Do you have an advanced directive?"),

                               new OrderedPair<long, string>(1000, "HAF Do you have a primary care physician or a family doctor?"),
                               new OrderedPair<long, string>(1007, "HAF If yes, have you visited them in the past 12 months?"),
                               new OrderedPair<long, string>(1001, "HAF Have you had a mammogram (for women) or prostate screening (for men) in the last 12 months?"),
                               new OrderedPair<long, string>(1002, "HAF Have you had a colonoscopy in the last 12 months?"),
                               new OrderedPair<long, string>(1003, "HAF Do you have a family history of any type of cancer?"),

                               new OrderedPair<long, string>(1004, "HAF Do you struggle with managing your weight?"),
                               new OrderedPair<long, string>(1005, "HAF Do you have a history of blood clots, phlebitis, or Deep Vein Thrombosis (DVT)"),
                               new OrderedPair<long, string>(1006, "HAF Do you have high blood pressure?"),

                               new OrderedPair<long, string>(553, "HAF Have you ever felt you needed to Cut down on your drinking?"),
                               new OrderedPair<long, string>(554, "HAF Have people Annoyed you by criticizing your drinking?"),
                               new OrderedPair<long, string>(555, "Have you ever felt Guilty about drinking?"),
                               new OrderedPair<long, string>(556, "Have you ever felt you needed a drink first thing in the morning (Eye-opener) to steady your nerves or to get rid of a hangover?"),
                               new OrderedPair<long, string>(58, "HAF Do you have any other medical conditions we should be aware of? If so, what is the condition?"),
                               
                               //Level1 
                               //HPI: HM – Senior Visit
                               new OrderedPair<long, string>(488, "Level 1 Will a caregiver accompany to your visit?"),
                               new OrderedPair<long, string>(489, "Level 1 Are you the primary historian?"),
                               new OrderedPair<long, string>(490, "Level 1 Who is the primary historian for the patient?"),

                               //Medication and Hospitalization
                               new OrderedPair<long, string>(491, "Level 1 Do you have any concerns regarding your medication?"),
                               new OrderedPair<long, string>(492, "Level 1 Dose or Allergy or Use"),
                               new OrderedPair<long, string>(493, "Level 1 Have you been hospitalized overnight in the last 90 days?"),
                               new OrderedPair<long, string>(551, "Level 1 For How many days(0, 1, 2 etc.)?"),
                               new OrderedPair<long, string>(494, "Level 1 What was the date(s) of the hospitalization?"),

                               new OrderedPair<long, string>(495, "Level 1 Have you been to the Emergency Department or an Urgent Care Clinic in the 90 days?"),
                               new OrderedPair<long, string>(496, "Level 1 For What?"),

                               //Cognitive
                               new OrderedPair<long, string>(497, "Level 1 Do you have any memory problems?"),
                               new OrderedPair<long, string>(498, "Level 1 Short term or Long term or Dementia"),
                               new OrderedPair<long, string>(499, "Level 1 Are the memory problems worsening over the past year?"),
                               new OrderedPair<long, string>(500, "Level 1 Have you been depressed or lost interest in normal activities in the past 2 weeks?"),

                               //Continence
                               new OrderedPair<long, string>(501, "Level 1 Do you have difficulty holding your urine?"),
                               new OrderedPair<long, string>(502, "Level 1 Mild or Moderate or Urinate while asleep"),
                               new OrderedPair<long, string>(503, "Level 1 If you have difficulty holding you urine, how many times in a 24 hour hour period due you lose your urine(0-10)?"),
                               new OrderedPair<long, string>(504, "Level 1 If you have difficulty holding you urine, do you wear pads?"),
                               new OrderedPair<long, string>(505, "Level 1 Are your daily bowel habits normal?"),
                               new OrderedPair<long, string>(506, "Level 1 Constipated/hard and difficult passing stool or Loose/not firm or Incontinent/unable to control when you have a bowel movement"),

                               //Hearing and vision
                               new OrderedPair<long, string>(507, "Level 1 When was your last eye exam (month-day-year)?"),
                               new OrderedPair<long, string>(508, "Level 1 Do you wear glasses or contacts?"),
                               new OrderedPair<long, string>(509, "Level 1 Contacts or  Glasses"),
                               new OrderedPair<long, string>(510, "Level 1 Do you have any new vision problems?"),
                               new OrderedPair<long, string>(511, "Level 1 Near vision or Far vision"),
                               new OrderedPair<long, string>(512, "Level 1 Do you have any new hearing problems?"),
                               new OrderedPair<long, string>(513, "Level 1 Normal or Mild hearing loss"),
                               new OrderedPair<long, string>(514, "Level 1 Have you noticed any loss of hearing?"),
                               new OrderedPair<long, string>(515, "Level 1 If yes, do you use any hearing aids?"),

                               //Mobility
                               new OrderedPair<long, string>(516, "Level 1 Have you had a fall in the last 6 months?"),
                               new OrderedPair<long, string>(517, "Level 1 Due to tripping on an object or Loss of balance"),
                               new OrderedPair<long, string>(518, "Level 1 When you walk do you use an assistive device?"),
                               new OrderedPair<long, string>(519, "Level 1 Single point cane or 4 point cane or Front wheel walker or 4 wheel walker or Rollator/walker wi wheels or  Wheelchair"),
                               new OrderedPair<long, string>(520, "Level 1 What type of home do you live in?"),
                               new OrderedPair<long, string>(521, "Level 1 Do you have stairs in your home?"),
                               new OrderedPair<long, string>(522, "Level 1 Can you go up and down several stairs?"),
                               new OrderedPair<long, string>(523, "Level 1 Do you live alone?"),
                               new OrderedPair<long, string>(524, "Level 1 Are you able to drive?"),
                               
                               //Quality of life
                               new OrderedPair<long, string>(525, "Level 1 Do you have any sleep problems?"),
                               new OrderedPair<long, string>(526, "Level 1 Early awakening or Frequent awakening or Unable to fall asleep or Sleeping too much or Day/night reversal"),
                               new OrderedPair<long, string>(527, "Level 1 How is your appetite?"),
                               new OrderedPair<long, string>(528, "Level 1 Have you lost any weight in the past year?"),
                               new OrderedPair<long, string>(529, "Level 1 How Many Pounds?"),
                               new OrderedPair<long, string>(530, "Level 1 When?"),
                               new OrderedPair<long, string>(531, "Level 1 Do you have any consistent pain or discomfort in any part of your body?"),
                               new OrderedPair<long, string>(532, "Level 1 If you do have pain, where is it at(arms, legs, joints, spine ect)?"),
                               new OrderedPair<long, string>(533, "Level 1 What would you rate your average daily pain scale out of 10?"),
                               new OrderedPair<long, string>(534, "Level 1 Do you currently use any prescription pain medication other than Motrin/anti-inflammatory?"),
                               new OrderedPair<long, string>(535, "Level 1 No of Time?"),
                               new OrderedPair<long, string>(536, "Level 1 In how many week?"),
                               new OrderedPair<long, string>(537, "Level 1 Do you currently use any prescription medication to treat anxiety, depression, or panic attacks?"),
                               new OrderedPair<long, string>(538, "Level 1 No of Time?"),
                               new OrderedPair<long, string>(539, "Level 1 In how many days/week?"),
                               new OrderedPair<long, string>(540, "Level 1 Do you have any swelling in your hands or feet?"),
                               new OrderedPair<long, string>(541, "Level 1 Do you have any swelling in your hands"), 
                               new OrderedPair<long, string>(552, "Level 1 Do you have any swelling in your Feet"),
                               new OrderedPair<long, string>(542, "Level 1 Do you have any open wounds on your feet?"),
                               new OrderedPair<long, string>(543, "Level 1 Do you have any numbness in your hands or feet?"),
                               new OrderedPair<long, string>(544, "Level 1 Do you smoke?"),
                               new OrderedPair<long, string>(545, "Level 1 How many cigs per day?"),
                               new OrderedPair<long, string>(546, "Level 1 Do you drink alcohol?"),
                               

                               //Annual exams
                               new OrderedPair<long, string>(547, "Level 1 Have you had a stool sample test in the past year?"),
                               new OrderedPair<long, string>(548, "Level 1 Have you had a Mammo test in the past year?"),
                               new OrderedPair<long, string>(549, "Level 1 Have you had a PAP test in the past year?"),
                               new OrderedPair<long, string>(550, "Level 1 Have you had a Upper of lower scope of the bowels/intestines test in the past year?"),

                               //PHQ9
                               new OrderedPair<long, string>(271, "PHQ9 Over the last 2 weeks how often have you had little interest or pleasure in doing things?"),
                               new OrderedPair<long, string>(273, "PHQ9 Over the last 2 weeks how often have you felt down, depressed or hopeless?"),
                               new OrderedPair<long, string>(275, "PHQ9 Over the last 2 weeks how often have you had trouble falling or staying asleep, or slept too much"),
                               new OrderedPair<long, string>(277, "PHQ9 Over the last 2 weeks how often have you been bothered by feeling tired or having little energy"),
                               new OrderedPair<long, string>(279, "PHQ9 Over the last 2 weeks how often have you had a poor appetite or overate?"),
                               new OrderedPair<long, string>(281, "PHQ9 Over the last 2 weeks how often have you felt bad about yourself - or that you are a failure or have let yourself or your family down?"),
                               new OrderedPair<long, string>(283, "PHQ9 Over the last 2 weeks how often have you had trouble concentrating on things, such as reading the newspaper or watching television?"),
                               new OrderedPair<long, string>(285, "PHQ9 Over the last 2 weeks how often have you been moving or speaking so slowly that other people could have noticed. Or the opposite - being so fidgety or restless that you have been moving around a lot more than usual?"),
                               new OrderedPair<long, string>(287, "PHQ9 Over the last 2 weeks how often have you had thoughts that you would be better off dead, or hurting yourself?"),
                               new OrderedPair<long, string>(289, "PHQ9 If you have had any problems in the past questions 1-9, how difficult have these problems made it for you to do your work, take care of things at home, or get along with other people?"),
                           };
            }
        }

        //public static IEnumerable<long> QuestionIds
        //{
        //    get { return Questions.Select(Q => Q.FirstValue).ToArray(); }
        //}

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

        public static string GetOutputFromBoolTypeResultReading(ResultReading<bool> reading, bool useBalnkValue = false)
        {
            return reading != null && reading.Reading ? YesString : (useBalnkValue ? "" : NoString);
        }

        public static string GetOutputFromNullableBoolTypeResultReading(ResultReading<bool?> reading, bool useBalnkValue = false)
        {
            return reading != null && reading.Reading.HasValue && reading.Reading.Value ? YesString : (useBalnkValue ? "" : NoString);
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
