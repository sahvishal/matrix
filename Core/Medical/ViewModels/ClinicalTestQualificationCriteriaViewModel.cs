using System;
using System.Linq;
using System.Text;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ClinicalTestQualificationCriteriaViewModel
    {
        public string GroupName { get; set; }
        public Gender Gender { get; set; }
        public int NumberOfQuestion { get; set; }
        public string Answer { get; set; }
        public bool OnMedication { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public long AgeCondition { get; set; }
        public long TemplateId { get; set; }
        public long TestId { get; set; }
        public bool IsPublished { get; set; }
        public long MedicationQuestionId { get; set; }

        public int TotalQuestionCount { get; set; }
        public bool HasSectionsInQuestion { get; set; }

        public string DisqualifierQuestionText { get; set; }
        public long DisqualifierQuestionId { get; set; }
        public string DisqualifierQuestionAnswer { get; set; }

        public string DisqualificationLogic
        {
            get
            {
                if (DisqualifierQuestionId <= 0) return string.Empty;
                return "Patient will be disqualified for screening if answer of \"" + DisqualifierQuestionText + "\" is  \"" + DisqualifierQuestionAnswer +"\".";
            }
        }

        public override string ToString()
        {
            var headerText = new StringBuilder();
            if (AgeCondition > 0)
            {
                if (Gender == Gender.Unspecified)
                {
                    headerText.Append("For patients ");
                }
                else
                {
                    headerText.Append(Gender == Gender.Male ? "Men " : "Females ");
                }


                if (AgeCondition == (long)ComparisonOperators.LessThan)
                {
                    headerText.Append("below the age of " + AgeMax + " ");
                }
                else if (AgeCondition == (long)ComparisonOperators.LessThanEqualTo)
                {
                    headerText.Append("below or equal to the age of " + AgeMax + " ");
                }
                else if (AgeCondition == (long)ComparisonOperators.GreaterThan)
                {
                    headerText.Append("over the age of " + AgeMin + " ");
                }
                else if (AgeCondition == (long)ComparisonOperators.GreaterThanEqualTo)
                {
                    headerText.Append("equal or over the age of " + AgeMin + " ");
                }
                else if (AgeCondition == (long)ComparisonOperators.Between)
                {
                    headerText.Append("between age of " + AgeMin + " and " + AgeMax + " ");
                }
            }

            if (MedicationQuestionId > 0)
            {
                if (headerText.Length == 0)
                {
                    if (Gender == Gender.Unspecified)
                    {
                        headerText.Append("For patients ");
                    }
                    else
                    {
                        headerText.Append(Gender == Gender.Male ? "Men " : "Females ");
                    }
                }
                headerText.Append("that do not already take medication for the treatment or prevention of ");

                if (TestGroup.OsteoTestIds.Contains(TestId))
                    headerText.Append("Osteoporosis ");
                else if (TestGroup.PadTestIds.Contains(TestId))
                    headerText.Append("ABI Index ");
                else if (TestGroup.AaaTestIds.Contains(TestId))
                    headerText.Append("Abdominal Aortic Aneurysm Ultrasound ");
                else if (TestGroup.StrokeTesIds.Contains(TestId))
                    headerText.Append("Carotid ");
                else if (TestGroup.EchoTestIds.Contains(TestId))
                    headerText.Append("Echocardiogram ");
                else if (TestGroup.SpiroTestIds.Contains(TestId))
                    headerText.Append("Spirometry ");
                else
                    headerText.Append(((TestType)TestId).GetDescription() + " ");
            }

            if (!String.IsNullOrEmpty(Answer) && NumberOfQuestion > 0)
            {

                if (headerText.Length > 0)
                {
                    headerText.Append(" and a ");
                }
                else
                {
                    if (Gender == Gender.Male || Gender == Gender.Female)
                    {
                        headerText.Append(Gender == Gender.Male ? "Men " : "Females ");
                        headerText.Append(" and a ");
                    }
                    else
                    {
                        headerText.Append("A ");
                    }

                }
                var countText = NumberOfQuestion == TotalQuestionCount && !HasSectionsInQuestion ? "all" : NumberOfQuestion.ToString();

                if (HasSectionsInQuestion)
                {
                    headerText.Append(Answer + " response for " + countText + " of the question(s) in each set will qualify");
                }
                else
                {
                    headerText.Append(Answer + " response for " + countText + " of the question(s) will qualify");
                }

            }
            else
            {
                if (headerText.Length > 0)
                {
                    headerText.Append(" will qualify");
                }
                else if (headerText.Length == 0)
                {
                    if (Gender == Gender.Male || Gender == Gender.Female)
                    {
                        headerText.Append(Gender == Gender.Male ? "Men " : "Females ");
                        headerText.Append("will qualify");
                    }
                }
            }

            return headerText.ToString();
        }


    }
}