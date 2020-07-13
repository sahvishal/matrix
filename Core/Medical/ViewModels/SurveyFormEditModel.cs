using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class SurveyFormEditModel : ViewModelBase
    {
        public long EventCustomerId { get; set; }
        public long CustomerId { get; set; }
        public Name Name { get; set; }
        public long EventId { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DoB { get; set; }
        public bool IsPrintable { get; set; }
        public bool IsEditable { get; set; }
        public IEnumerable<SurveyQuestionAnswerEditModel> SurveyQuestion { get; set; }
        public int Age
        {
            get
            {
                if (!DoB.HasValue) return 0;

                var today = DateTime.Today;
                var age = today.Year - DoB.Value.Year;

                //in case of a leap year
                if (DoB > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}