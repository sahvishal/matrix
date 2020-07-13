using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SurveyTemplateEditModel>))]
    public class SurveyTemplateEditModelValidator : AbstractValidator<SurveyTemplateEditModel>
    {
        private readonly ISurveyTemplateRepository _templateRepository;
        public SurveyTemplateEditModelValidator(ISurveyTemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must(CheckifNameisUnique).WithMessage("Please select a unique name");
            RuleFor(x => x.Questions).Must((x, y) => !y.IsNullOrEmpty() && y.Any()).WithMessage("select altleast one question");
        }

        private bool CheckifNameisUnique(SurveyTemplateEditModel model, string templateName)
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
