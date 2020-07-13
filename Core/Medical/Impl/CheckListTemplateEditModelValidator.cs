using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CheckListTemplateEditModel>))]
    public class CheckListTemplateEditModelValidator : AbstractValidator<CheckListTemplateEditModel>
    {
        private readonly ICheckListTemplateRepository _templateRepository;
        public CheckListTemplateEditModelValidator(ICheckListTemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must(CheckifNameisUnique).WithMessage("Please select a unique name");
            RuleFor(x => x.Type).NotNull().WithMessage("required").GreaterThan(0).WithMessage("required");
            //RuleFor(x => x.HealthPlanId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Questions).Must((x, y) => !y.IsNullOrEmpty() && y.Any()).WithMessage("select altleast one question");
            
        }

        public bool CheckifNameisUnique(CheckListTemplateEditModel model, string templateName)
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