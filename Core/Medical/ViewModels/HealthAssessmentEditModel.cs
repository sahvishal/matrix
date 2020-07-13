using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HealthAssessmentEditModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<HealthAssessmentQuestionEditModel> QuestionEditModels { get; set; }
        public bool IsMammoPurchased { get; set; }
        public bool IsKynPurchased { get; set; }
        public bool IsHKynPurchased { get; set; }
        public bool IsPhq9Purchased { get; set; }

        public bool ShowNewHKynForm { get; set; }


        public KynHealthAssessmentEditModel KynHealthAssessmentEditModel { get; set; }

        public QualificationRecommendationLogic BoneDensityRecommendationLogic { get; set; }
        public QualificationRecommendationLogic ABIndexRecommendationLogic { get; set; }
        public QualificationRecommendationLogic AAARecommendationLogic { get; set; }
        public QualificationRecommendationLogic CarotidRecommendationLogic { get; set; }
        public QualificationRecommendationLogic EchocardiogramRecommendationLogic { get; set; }
        public QualificationRecommendationLogic SpirometryRecommendationLogic { get; set; }
        public QualificationRecommendationLogic DiabetesPanelRecommendationLogic { get; set; }
        public QualificationRecommendationLogic BmpRecommendationLogic { get; set; }
        public QualificationRecommendationLogic LipidProfileRecommendationLogic { get; set; }
        public QualificationRecommendationLogic MicroAlbuminCreatinineRecommendationLogic { get; set; }
        public QualificationRecommendationLogic HepatitisCRecommendationLogic { get; set; }
        public QualificationRecommendationLogic IFOBTRecommendationLogic { get; set; }

        public long[] mammogramQuestionIds = new long[] { 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137 };
        public long[] kynQuestionIds = new long[] { 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171 };
        public long[] phq9QuestionIds = new long[] { 271, 273, 275, 277, 279, 281, 283, 285, 287, 289 };
        public long[] hcpClinicalQuestionIds = new long[] { 350, 351, 352, 355, 356, 357, 358, 360, 361, 362, 365, 366, 367, 368, 370, 371, 372, 373, 374, 375, 376, 377, 470, 471, 472, 473, 474, 475, 476, 477, 478, 479, 480, 481, 482, 483, 484, 485, 486, 487 };

        public long[] hcpSecondaryRiskAssessmentQuestions = { 381, 383, 385, 387, 389, 391, 393, 395, 397, 399, 401, 403, 405, 407, 409, 411, 415, 417, 419, 421, 423, 425, 427, 429 };
        public long[] hcpSecondaryImmunizations = { 427, 429 };

        public long[] levelOneQuestions_Parent = { 488, 489, 490, 491, 492, 493, 551, 494, 495, 496, 497, 498, 499, 500, 501, 502, 503, 504, 505, 506, 507, 508, 509, 510, 511, 512, 513, 514, 515, 516, 517, 518, 519, 520, 521, 522, 523, 524, 525, 526, 527, 528, 529, 530, 531, 532, 533, 534, 535, 536, 537, 538, 539, 540, 541, 542, 543, 544, 545, 546, 552, 547, 548, 549, 550 };

        public bool ShowMammogramQuestionnarire { get; set; }
        public bool IsBioCheckAssessmentPurchased { get; set; }

        public long[] bioCheckQuestionIds = { 1021, 1022, 1024, 1025, 1026, 1027, 1028, 1029, 1030, 1031, 1032, 1033, 1034, 1035, 1036, 1037, 1038, 1039, 1040, 1041, 1042, 1043, 1044, 1045, 1046, 1047, 1048 };

        long[] physicalActivityHkynQuestions = new long[] { 1049, 1050, 1051, 1052 };
        long[] nutritionHkynQuestions = new long[] { 1053, 1054, 1055, 1056, 1057, 1058 };
        long[] stressHkynQuestions = new long[] { 1059, 1060, 1061, 1062, 1063 };
        long[] tobacoHkynQuestions = new long[] { 1064, 1065, 1066, 1067 };
        long[] alcoholAndDrugHkynQuestions = new long[] { 1068, 1069, 1070, 1071 };

        public bool HasPhysicalActivityHkynQuestions
        {
            get
            {
                return !QuestionEditModels.IsNullOrEmpty() && QuestionEditModels.Any(x => physicalActivityHkynQuestions.Contains(x.QuestionId));
            }
        }
        public bool HasNutritionHkynQuestions
        {
            get
            {
                return !QuestionEditModels.IsNullOrEmpty() && QuestionEditModels.Any(x => nutritionHkynQuestions.Contains(x.QuestionId));
            }
        }
        public bool HasStressHkynQuestions
        {
            get
            {
                return !QuestionEditModels.IsNullOrEmpty() && QuestionEditModels.Any(x => stressHkynQuestions.Contains(x.QuestionId));
            }
        }
        public bool HasTobacoHkynQuestions
        {
            get
            {
                return !QuestionEditModels.IsNullOrEmpty() &&  QuestionEditModels.Any(x => tobacoHkynQuestions.Contains(x.QuestionId));
            }
        }
        public bool HasAlcoholAndDrugHkynQuestions
        {
            get
            {
                return !QuestionEditModels.IsNullOrEmpty() &&  QuestionEditModels.Any(x => alcoholAndDrugHkynQuestions.Contains(x.QuestionId));
            }
        }
    }
}
