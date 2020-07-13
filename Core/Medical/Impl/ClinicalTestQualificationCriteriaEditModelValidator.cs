using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Enum;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ClinicalTestQualificationCriteriaEditModel>))]
    public class ClinicalTestQualificationCriteriaEditModelValidator : AbstractValidator<ClinicalTestQualificationCriteriaEditModel>
    {
        public ClinicalTestQualificationCriteriaEditModelValidator()
        {
            RuleFor(x => x.Gender).Must((model, gender) => (gender == Gender.Male || gender == Gender.Female)).WithMessage("Gender must be selected").When(x => x.GenderCriteriaSelected);
            RuleFor(x => x.AgeMax).NotNull().WithMessage("Max Required").NotEmpty().WithMessage("Max Required").When(x => x.AgeCriteriaSelected && (x.AgeCondition == (long)ComparisonOperators.LessThan || x.AgeCondition == (long)ComparisonOperators.LessThanEqualTo || x.AgeCondition == (long)ComparisonOperators.Between));
            RuleFor(x => x.AgeMin).NotNull().WithMessage("Min Required").NotEmpty().WithMessage("Min Required").When(x => x.AgeCriteriaSelected && (x.AgeCondition == (long)ComparisonOperators.GreaterThan || x.AgeCondition == (long)ComparisonOperators.GreaterThanEqualTo || x.AgeCondition == (long)ComparisonOperators.Between));
            RuleFor(x => x.AgeCondition).GreaterThan(0).WithMessage("Required").When(x => x.AgeCriteriaSelected);
            RuleFor(x => x.AgeCondition).Must((m, p) => m.AgeMin.HasValue && m.AgeMax.HasValue && m.AgeMin.Value < m.AgeMax.Value).WithMessage("min age must be less then max age").When(x => x.AgeCriteriaSelected && x.AgeCondition == (long)ComparisonOperators.Between && x.AgeMax.HasValue && x.AgeMin.HasValue);
            RuleFor(x => x.MedicationQuestionId).GreaterThan(0).WithMessage("Required").When(x => x.OnMedication);
            RuleFor(x => x.NumberOfQuestion).GreaterThan(0).WithMessage("Number of Question must be selected").When(x => x.NumberOfQuestionCriteriaSelected);
            RuleFor(x => x.Answer).NotNull().WithMessage("Response must be selected").NotEmpty().WithMessage("Response must be selected").When(x => x.NumberOfQuestionCriteriaSelected);
            RuleFor(x => x.DisqualifierQuestionId).GreaterThan(0).WithMessage("Required").When(x => x.DisqualifierQuestionSelected);
            RuleFor(x => x.DisqualifierQuestionAnswer).NotNull().WithMessage("Response must be selected").NotEmpty().WithMessage("Response must be selected").When(x => x.DisqualifierQuestionSelected);
        }
    }
}