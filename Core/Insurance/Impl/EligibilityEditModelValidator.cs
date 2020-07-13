using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Insurance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EligibilityEditModel>))]
    public class EligibilityEditModelValidator: AbstractValidator<EligibilityEditModel>
    {
        public EligibilityEditModelValidator()
        {
            RuleFor(x => x.Request).SetValidator(new EligibilityRequestEditModelValidator());
        }
    }
}
