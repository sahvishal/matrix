using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HouseCallHafResultExportHelper
    {
        public static IEnumerable<OrderedPair<long, string>> Questions
        {
            get
            {
                return new[]
                           {
                               new OrderedPair<long, string>( 1075, "Do you have a caregiver (Mother, Daughter, Nurse etc.)?" ),
                               new OrderedPair<long, string>( 1076, "First and Last name:" ),
                               new OrderedPair<long, string>( 1077, "Phone:" ),
                               new OrderedPair<long, string>( 1078, "Relationship:" ),

                               new OrderedPair<long, string>( 1079, "Have you seen a specialist in the past year?" ),
                               new OrderedPair<long, string>( 1080, "1. Provider Name/Name of Clinic:" ),
                               new OrderedPair<long, string>( 1081, "Date of last visit:" ),
                               new OrderedPair<long, string>( 1082, "Specialty:" ),
                               new OrderedPair<long, string>( 1083, "2. Provider Name/Name of Clinic:" ),
                               new OrderedPair<long, string>( 1084, "Date of last visit:" ),
                               new OrderedPair<long, string>( 1085, "Specialty:" ),
                               new OrderedPair<long, string>( 1086, "3. Provider Name/Name of Clinic:" ),
                               new OrderedPair<long, string>( 1087, "Date of last visit:" ),
                               new OrderedPair<long, string>( 1088, "Specialty:" ),

                               new OrderedPair<long, string>( 1089, "Are you currently taking any medications including any OTCs and/or herbal medications?" ),
                               new OrderedPair<long, string>( 1090, "Medication Name:" ),
                               new OrderedPair<long, string>( 1091, "Dose:" ),
                               new OrderedPair<long, string>( 1092, "Medication Name:" ),
                               new OrderedPair<long, string>( 1093, "Dose:" ),
                               new OrderedPair<long, string>( 1094, "Medication Name:" ),
                               new OrderedPair<long, string>( 1095, "Dose:" ),
                               new OrderedPair<long, string>( 1096, "Medication Name:" ),
                               new OrderedPair<long, string>( 1097, "Dose:" ),
                               new OrderedPair<long, string>( 1098, "Medication Name:" ),
                               new OrderedPair<long, string>( 1099, "Dose:" ),
                               new OrderedPair<long, string>( 1100, "Medication Name:" ),
                               new OrderedPair<long, string>( 1101, "Dose:" ),
                               new OrderedPair<long, string>( 1102, "Medication Name:" ),
                               new OrderedPair<long, string>( 1103, "Dose:" ),
                               new OrderedPair<long, string>( 1104, "Medication Name:" ),
                               new OrderedPair<long, string>( 1105, "Dose:" ),

                               new OrderedPair<long, string>( 1106, "Have you had the current vaccine for the flu (influenza)?" ),
                               new OrderedPair<long, string>( 1107, "If yes, when" ),
                               new OrderedPair<long, string>( 1108, "If no, why?" ),

                               new OrderedPair<long, string>( 1109, "Have you had the vaccine for Pneumonia (Pneumovax)?" ),
                               new OrderedPair<long, string>( 1110, "If yes, did you" ),
                               new OrderedPair<long, string>( 1111, "If no" ),

                               new OrderedPair<long, string>( 1112, "Have you received the Herpes Zoster vaccine?" ),
                               new OrderedPair<long, string>( 1113, "If yes, when" ),
                               new OrderedPair<long, string>( 1114, "If no" ),

                               new OrderedPair<long, string>( 1115, "Have you received a Tdap/TD vaccine (a combination of Tetanus, Diphtheria, and Whooping Cough)?" ),
                               new OrderedPair<long, string>( 1116, "If yes, did you" ),
                               new OrderedPair<long, string>( 1117, "If no" ),

                               new OrderedPair<long, string>( 1118, "Have you received the Prevnar 13 vaccine (a special type of flu shot for those who need a booster)?" ),
                               new OrderedPair<long, string>( 1119, "If yes" ),
                               new OrderedPair<long, string>( 1120, "If no" ),

                               new OrderedPair<long, string>( 1121, "Have you had a Colonoscopy?" ),
                               new OrderedPair<long, string>( 1122, "If yes, when?" ),
                               new OrderedPair<long, string>( 1123, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1124, "Result:" ),
                               new OrderedPair<long, string>( 1125, "If no" ),

                               new OrderedPair<long, string>( 1126, "Have you had a Flexible Sigmoidoscopy?" ),
                               new OrderedPair<long, string>( 1127, "If yes, when?" ),
                               new OrderedPair<long, string>( 1128, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1129, "Result:" ),
                               new OrderedPair<long, string>( 1130, "If no" ),

                               new OrderedPair<long, string>( 1131, "Have you been tested for FOBT (Fecal Occult Blood Test - Guaiac or Immunochemical)?" ),
                               new OrderedPair<long, string>( 1132, "If yes, when?" ),
                               new OrderedPair<long, string>( 1133, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1134, "Result:" ),
                               new OrderedPair<long, string>( 1135, "If no" ),

                               new OrderedPair<long, string>( 1136, "Have you had a mammogram?" ),
                               new OrderedPair<long, string>( 1137, "If yes, when?" ),
                               new OrderedPair<long, string>( 1138, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1139, "Result:" ),
                               new OrderedPair<long, string>( 1140, "If no" ),

                               new OrderedPair<long, string>( 1141, "Have you had a DEXA Scan for osteoporosis?" ),
                               new OrderedPair<long, string>( 1142, "If yes, when?" ),
                               new OrderedPair<long, string>( 1143, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1144, "Result:" ),
                               new OrderedPair<long, string>( 1145, "If no" ),

                               new OrderedPair<long, string>( 1146, "Have you had a Dilated Retinal Exam?" ),
                               new OrderedPair<long, string>( 1147, "If yes, when?" ),
                               new OrderedPair<long, string>( 1148, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1149, "Result:" ),
                               new OrderedPair<long, string>( 1150, "If no" ),

                               new OrderedPair<long, string>( 1151, "Have you had a Glaucoma Exam?" ),
                               new OrderedPair<long, string>( 1152, "If yes, when?" ),
                               new OrderedPair<long, string>( 1153, "Received - Date Unknown" ),
                               new OrderedPair<long, string>( 1154, "Result:" ),
                               new OrderedPair<long, string>( 1155, "If no" ),

                               new OrderedPair<long, string>( 1156, "Have you ever used cigarettes?" ),
                               new OrderedPair<long, string>( 1157, "Current Smoker" ),
                               new OrderedPair<long, string>( 1158, "How many packs do you smoke per day?" ),
                               new OrderedPair<long, string>( 1159, "How many years have you been smoking?" ),
                               new OrderedPair<long, string>( 1160, "Are you interested in quitting?" ),
                               new OrderedPair<long, string>( 1161, "Former Smoker" ),
                               new OrderedPair<long, string>( 1162, "When did you quit?" ),
                               new OrderedPair<long, string>( 1163, "How many packs did you smoke per day?" ),
                               new OrderedPair<long, string>( 1164, "How many years did you smoke?" ),

                               new OrderedPair<long, string>( 1165, "Have you ever used other tobacco products?" ),
                               new OrderedPair<long, string>( 1166, "Currently using" ),
                               new OrderedPair<long, string>( 1167, "What type of tobacco do you use?" ),
                               new OrderedPair<long, string>( 1168, "Former user" ),
                               new OrderedPair<long, string>( 1169, "What type of tobacco did you use?" ),
                               new OrderedPair<long, string>( 1170, "Are you interested in quitting?" ),


                               new OrderedPair<long, string>( 1171, "Have you ever used any drugs?" ),
                               new OrderedPair<long, string>( 1172, "If yes," ),

                               new OrderedPair<long, string>( 1173, "Do you have an Advanced Directive?" ),

                               new OrderedPair<long, string>( 1174, "Are you interested in an Advanced Care Planning pamphlet?" ),

                               new OrderedPair<long, string>( 1175, "Have you had more than 3 falls in the past 6 months?" ),

                               new OrderedPair<long, string>( 1176, "Do you use assistive devices (ex: cane, wheelchair)?" ),
                               new OrderedPair<long, string>( 1177, "If yes, select devices used:" ),

                               new OrderedPair<long, string>( 1182, "Do you use any outside assistance services?" ),
                               new OrderedPair<long, string>( 1248, "If yes, please select the services" ),

                               new OrderedPair<long, string>( 1192, "Do you have problems with your Bowels?" ),
                               new OrderedPair<long, string>( 1193, "If yes," ),

                               new OrderedPair<long, string>( 1194, "Do you have problems with your Bladder?" ),
                               new OrderedPair<long, string>( 1195, "If yes," ),

                               new OrderedPair<long, string>( 1196, "Are you able to groom yourself independently? (face, hair, teeth, shaving)" ),
                               new OrderedPair<long, string>( 1197, "If no," ),

                               new OrderedPair<long, string>( 1198, "Are you able to use the toilet independently?" ),
                               new OrderedPair<long, string>( 1199, "If no," ),

                               new OrderedPair<long, string>( 1200, "Are you able to feed yourself independently?" ),

                               new OrderedPair<long, string>( 1201, "Do you have complications being transferred?" ),
                               new OrderedPair<long, string>( 1202, "If yes," ),

                               new OrderedPair<long, string>( 1203, "Do you have mobility issues?" ),
                               new OrderedPair<long, string>( 1204, "If yes," ),

                               new OrderedPair<long, string>( 1205, "Are you able to dress yourself independently?" ),
                               new OrderedPair<long, string>( 1206, "If no," ),

                               new OrderedPair<long, string>( 1207, "Are you able to walk up and down stairs independently?" ),
                               new OrderedPair<long, string>( 1208, "If no," ),

                               new OrderedPair<long, string>( 1209, "Are you able to bath yourself independently?" ),

                               new OrderedPair<long, string>( 1210, "Do you currently have any pain?" ),
                               new OrderedPair<long, string>( 1211, "If yes," ),
                               new OrderedPair<long, string>( 1212, "Can you describe the pain?" ),
                               new OrderedPair<long, string>( 1213, "On a scale of 0 to 10, please choose a pain level. 0-No Pain, 1-3-Mild Pain, 4-7-Moderate Pain, 8-10 Intense, Unbearable, Severe Pain." ),
                               new OrderedPair<long, string>( 1214, "What makes the pain better?" ),
                               new OrderedPair<long, string>( 1215, "What makes the pain worse?" ),
                               new OrderedPair<long, string>( 1216, "How would you describe how much pain has been relieved in the past week?" ),
                               new OrderedPair<long, string>( 1217, "Is the amount of relief that you are receiving high enough to make a real difference in your life?" ),                               
                               new OrderedPair<long, string>( 1218, "Are you meeting your pain goals?" ),

                               new OrderedPair<long, string>( 1219, "Have you been discharged from the armed forces of the United States?" ),

                               new OrderedPair<long, string>( 1220, "Do you receive care from a VA clinic?" ),
                               //new OrderedPair<long, string>( 1221, "If yes, please comeplete the below VA clinic information" ),
                               new OrderedPair<long, string>( 1222, "If yes, Name:" ),
                               new OrderedPair<long, string>( 1223, "Address:" ),
                               new OrderedPair<long, string>( 1224, "State:" ),
                               new OrderedPair<long, string>( 1225, "City:" ),
                               new OrderedPair<long, string>( 1226, "Zip Code:" ),

                               new OrderedPair<long, string>( 1227, "Do you need more assistance at home than you currently receive? " ),

                               new OrderedPair<long, string>( 1228, "Are you afraid of losing your housing?" ),

                               new OrderedPair<long, string>( 1229, "Are you currently employed?" ),
                               new OrderedPair<long, string>( 1230, "If no, are you:" ),

                               new OrderedPair<long, string>( 1231, "Do you feel physically and emotionally safe where you currently live?" ),

                               new OrderedPair<long, string>( 1232, "In the past year, have you or any family members been unable to get any of the following items when it was needed?" ),
                               new OrderedPair<long, string>( 1233, "If yes,"),

                               new OrderedPair<long, string>( 1243, "Has lack of transportation kept you from any of the following?" ),
                               new OrderedPair<long, string>( 1244, "If yes,"),

                               new OrderedPair<long, string>( 1247, "How often do you see or talk to people that you care about and feel close to? (ex: talking to friends/family on the phone, visiting friends/family, church, meetings)?" ),

                               new OrderedPair<long, string>(553, "Have you ever felt you needed to Cut down on your drinking?"),
                               new OrderedPair<long, string>(554, "Have people Annoyed you by criticizing your drinking?"),
                               new OrderedPair<long, string>(555, "Have you ever felt Guilty about drinking?"),
                               new OrderedPair<long, string>(556, "Have you ever felt you needed a drink first thing in the morning (Eye-opener) to steady your nerves or to get rid of a hangover?"),

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

        public static string Delimiter
        {
            get { return ","; }
        }
    }
}
