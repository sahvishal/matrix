using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ProspectCustomerEditModel>))]
    public class ProspectCustomerEditModelValidator : AbstractValidator<ProspectCustomerEditModel>
    {
        public ProspectCustomerEditModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name can't be empty").NotNull().WithMessage("First name can't be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name can't be empty").NotNull().WithMessage("Last name can't be empty");
            RuleFor(x => x.CallBackPhoneNumber).NotNull().When(y => y.IsCallBackPhoneNumberRequired).NotEmpty().When(y => y.IsCallBackPhoneNumberRequired).WithMessage("required").SetValidator(new PhoneNumberRequiredValidator());
        }
    }
}