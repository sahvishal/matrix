using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<TemplateCriteriaEditModel>))]
    public class TemplateCriteriaEditModelValidator : AbstractValidator<TemplateCriteriaEditModel>
    {
        public TemplateCriteriaEditModelValidator(IValidator<ClinicalTestQualificationCriteriaEditModel> criteriaValidator,IClinicalTemplateService clinicalTemplateService)
        {
            RuleFor(x => x.TemplateId).GreaterThan(0).WithMessage("Required");
            RuleFor(x => x.Criteria).SetCollectionValidator(criteriaValidator);
            RuleFor(x => x.IsPublished).Must((x, y) => clinicalTemplateService.IsValidForPublish(x.Criteria))
                .WithMessage("please provide at least one criteria for each test").When(x=>x.IsPublished);
        }
    }
}
