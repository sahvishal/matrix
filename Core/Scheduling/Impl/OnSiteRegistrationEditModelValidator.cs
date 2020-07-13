using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<OnSiteRegistrationEditModel>))]
    public class OnSiteRegistrationEditModelValidator : AbstractValidator<OnSiteRegistrationEditModel>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventSchedulingSlotService _slotService;

        public OnSiteRegistrationEditModelValidator(IUserRepository<User> userRepository, IEventSchedulingSlotService slotService)
        {
            _userRepository = userRepository;
            _slotService = slotService;

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .Length(2, 50).WithMessage("between 2-50 charaters")
                .Matches("^[a-zA-Z0-9_]*$").WithMessage("alhpa numeric only");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("required")
                .NotEmpty().WithMessage("required")
                .Length(2, 50).WithMessage("between 2-50 charaters")
                .Matches("^[a-zA-Z0-9_]*$").WithMessage("alhpa numeric only");

            RuleFor(x => x.FirstName).Must((x, firstName) => firstName != x.LastName).When(x => x.LastName != null)
                .WithMessage("First Name and Last Name Cannot be the same");

            RuleFor(x => x.HomeNumber).NotNull().NotEmpty().WithMessage("required").SetValidator(new PhoneNumberRequiredValidator());

            RuleFor(x => x.Gender).GreaterThan(0).WithMessage("Gender is required");

            //RuleFor(x => x.Email).NotNull().WithMessage("required").EmailAddress();
            //RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email)).WithMessage("Email Already in use");
            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email)).When(x => !string.IsNullOrEmpty(x.Email)).
                WithMessage("'Email Already in use");

            RuleFor(x => x.Address).SetValidator(new AddressEditModelValidator());

            RuleFor(m => m.SelectedPackageId).GreaterThan(0).WithMessage("Please select a Package/Test.").When(m => m.SelectedTestIds == null || m.SelectedTestIds.Count() < 1);
            RuleFor(m => m.SelectedTestIds).NotNull().WithMessage("Please select a Package/Test.").NotEmpty().WithMessage("Please select a Package/Test.").When(m => m.SelectedPackageId == 0);

            RuleFor(x => x.SelectedAppointmentId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.SelectedAppointmentId).Must((x, appointmentId) => AppointmentValidation(appointmentId))
                .When(x => x.SelectedAppointmentId > 0).WithMessage("'Appointment' already booked");
        }

        private bool EmailIsUnique(string email)
        {
            return _userRepository.UniqueEmail(email);
        }

        private bool AppointmentValidation(long appointmentId)
        {
            return !_slotService.IsSlotBooked(new[] { appointmentId });
        }
    }
}
