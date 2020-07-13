using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SchedulingCustomerEditModel>))]
    public class SchedulingCustomerEditModelValidator : AbstractValidator<SchedulingCustomerEditModel>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IToolTipRepository _toolTipRepository;

        public SchedulingCustomerEditModelValidator(IUserRepository<User> userRepository, ICustomerRepository customerRepository, IToolTipRepository toolTipRepository)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _toolTipRepository = toolTipRepository;

            RuleFor(x => x.Email).NotNull().WithMessage("required").When(x => !x.IsRegisteringForCorporateEvent).EmailAddress().When(x => x.Id < 1);
            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email, x.Id)).WithMessage("Already in use");

            RuleFor(x => x.FullName).SetValidator(new NameValidator());
            RuleFor(x => x.Password).NotNull().NotEmpty().Length(6, 64).WithMessage("required, 6-64 chars").When(x => x.Id < 1);

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).When(x => x.Id < 1);


            RuleFor(x => x.HomeNumber).NotNull().NotEmpty().WithMessage("required");

            RuleFor(x => x.InsuranceId)
                .Must((x, insuranceId) => !string.IsNullOrEmpty(insuranceId))
                .WithMessage(InsuranceIdMessage())
                .When(x => x.InsuranceIdRequired);

            RuleFor(x => x.ConfirmationToEnablTexting).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.EnableTexting);
            RuleFor(x => x.PhoneCell).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.EnableTexting && x.ConfirmationToEnablTexting.HasValue && x.ConfirmationToEnablTexting.Value);
            
            RuleFor(x => x.ConfirmationToEnableVoiceMail).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.EnableVoiceMail);
            RuleFor(x => x.HomeNumber).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.EnableVoiceMail && x.ConfirmationToEnableVoiceMail.HasValue && x.ConfirmationToEnableVoiceMail.Value);
        }


        private bool EmailIsUnique(string email, long excludedCustomerId)
        {
            var customer = excludedCustomerId > 0 ? _customerRepository.GetCustomer(excludedCustomerId) : null;

            return excludedCustomerId == 0
                       ? _userRepository.UniqueEmail(email)
                       : _userRepository.UniqueEmail(customer.Id, email);
        }

        private string InsuranceIdMessage()
        {
            var insuranceIdLabel = _toolTipRepository.GetToolTipContentByTag(ToolTipType.InsuranceIdLabel);
            insuranceIdLabel = string.IsNullOrEmpty(insuranceIdLabel) ? "Insurance Id" : insuranceIdLabel;
            return insuranceIdLabel + " must not be empty";
        }

    }
}