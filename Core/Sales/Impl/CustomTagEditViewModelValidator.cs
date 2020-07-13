using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;
using System;

namespace Falcon.App.Core.Sales.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CustomTagEditViewModel>))]
    public class CustomTagEditViewModelValidator : AbstractValidator<CustomTagEditViewModel>
    {
        private readonly ICorporateTagRepository _corporateTagRepository;

        public CustomTagEditViewModelValidator(ICorporateTagRepository corporateTagRepository)
        {
             
            _corporateTagRepository = corporateTagRepository;
            RuleFor(x => x.CustomTag).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.EndDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThanOrEqualTo( m=> m.StartDate ).WithMessage("End date should be greater or equal to Start Date.");
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(DateTime.Today.Date).WithMessage("End date should be of future date.");
            RuleFor(x => x.HealthPlanId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.CustomTag).Must((x, customTag) => CustomTagIsUnique(customTag)).When(x=> !string.IsNullOrEmpty(x.CustomTag) && x.TagId == 0).WithMessage("This CustomTag already exist.");
        }
        private bool CustomTagIsUnique(string customTag)
        {
            return _corporateTagRepository.CustomTagIsUnique(customTag);
        }
    }
}
