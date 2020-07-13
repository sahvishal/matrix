using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ClinicalTestQualificationCriteriaEditModel
    {

        public bool GenderCriteriaSelected { get; set; }
        public Gender Gender { get; set; }

        public bool NumberOfQuestionCriteriaSelected { get; set; }
        public int NumberOfQuestion { get; set; }
        public string Answer { get; set; }

        public bool OnMedication { get; set; }
        public long MedicationQuestionId { get; set; }

        public bool AgeCriteriaSelected { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public long AgeCondition { get; set; }

        public long TestId { get; set; }
        public string GroupName { get; set; }
        public int TotalQuestionCount { get; set; }

        public bool DisqualifierQuestionSelected { get; set; }
        public long DisqualifierQuestionId { get; set; }
        public string DisqualifierQuestionAnswer { get; set; }

        public long TemplateId { get; set; }
    }
}