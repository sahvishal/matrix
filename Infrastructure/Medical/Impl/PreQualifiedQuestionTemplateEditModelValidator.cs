using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PreQualifiedQuestionTemplateEditModel>))]
    public class PreQualifiedQuestionTemplateEditModelValidator : AbstractValidator<PreQualifiedQuestionTemplateEditModel>
    {
        private readonly IPreQualificationTestTemplateRepository _preQualificationTestTemplateRepository;
        public PreQualifiedQuestionTemplateEditModelValidator(IPreQualificationTestTemplateRepository preQualificationTestTemplateRepository)
        {
            _preQualificationTestTemplateRepository = preQualificationTestTemplateRepository;
            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must(CheckifNameisUnique).WithMessage("Please select a unique name");
            RuleFor(x => x.TestId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Questions).Must((x, y) => !y.IsNullOrEmpty() && y.Any(q => q.IsSelected)).WithMessage("select altleast one question");
        }

        public bool CheckifNameisUnique(PreQualifiedQuestionTemplateEditModel model, string templateName)
        {
            if (string.IsNullOrEmpty(templateName)) return false;
            templateName = templateName.ToLower();
            if (model.Id > 0)
            {
                var templateInDb = _preQualificationTestTemplateRepository.GetById(model.Id);
                if (templateInDb.TemplateName.ToLower() == templateName) return true;
            }

            var template = _preQualificationTestTemplateRepository.GetByName(templateName.Trim());
            if (template != null)
                return false;

            return true;
        }
    }
}
