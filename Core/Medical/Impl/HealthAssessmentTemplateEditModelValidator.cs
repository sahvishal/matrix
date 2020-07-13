using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthAssessmentTemplateEditModel>))]
    public class HealthAssessmentTemplateEditModelValidator : AbstractValidator<HealthAssessmentTemplateEditModel>
    {
        private readonly IHealthAssessmentTemplateRepository _templateRepository;

        public HealthAssessmentTemplateEditModelValidator(IHealthAssessmentTemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;

            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must(CheckifNameisUnique).WithMessage("Please select a unique name");
            RuleFor(x => x.TemplateType).GreaterThan(0).WithMessage("select template type").When(m => m.Category == (long)HealthAssessmentTemplateCategory.HealthAssessmentTemplate);
            RuleFor(x => x.Category).GreaterThan(0).WithMessage("select template category");
            RuleFor(x => x.SelectedQuestionIds).NotNull().WithMessage("select altleast one question").NotEmpty().WithMessage("select altleast one question");
        }

        public bool CheckifNameisUnique(HealthAssessmentTemplateEditModel model, string templateName)
        {
            if (model.Id > 0)
            {
                var inDb = _templateRepository.GetById(model.Id);
                if (inDb.Name == templateName) return true;
            }

            if (string.IsNullOrEmpty(templateName))
                return false;

            var template = _templateRepository.GetByName(templateName.Trim());
            if (template != null)
                return false;

            return true;
        }
    }
}
