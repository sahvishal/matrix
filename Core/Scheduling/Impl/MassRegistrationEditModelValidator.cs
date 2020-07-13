using System;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class MassRegistrationEditModelValidator : AbstractValidator<MassRegistrationEditModel>
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IEventSchedulingSlotService _slotService;

        public MassRegistrationEditModelValidator(IUserRepository<User> userRepository, IEventSchedulingSlotService slotService)
        {
            _userRepository = userRepository;
            _slotService = slotService;

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("'First Name' required")
                .NotEmpty().WithMessage("'First Name' required")
                .Length(1, 50).WithMessage("between 1-50 charaters")
                .Matches("^[a-zA-Z0-9_]*$").WithMessage("alhpa numeric only");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("'Last Name' required")
                .NotEmpty().WithMessage("'Last Name' required")
                .Length(1, 50).WithMessage("between 1-50 charaters")
                .Matches("^[a-zA-Z0-9_]*$").WithMessage("alhpa numeric only");

            RuleFor(x => x.FirstName).Must((x, firstName) => firstName != x.LastName).When(x => x.LastName != null)
                .WithMessage("First Name and Last Name Cannot be the same");

            RuleFor(x => x.HomeNumber).SetValidator(new PhoneNumberValidator());

            RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Email).Must((x, email) => EmailIsUnique(email)).When(x => !string.IsNullOrEmpty(x.Email)).
                WithMessage("'Email' is already in use");

            //RuleFor(x => x.Address).SetValidator(new AddressEditModelValidator());

            //RuleFor(x => x.DateOfBirth).NotNull().NotEmpty().WithMessage("'Date of Birth' is required.");
            RuleFor(x => x.DateOfBirth).Must(birthDate => birthDate < DateTime.Today).When(x => x.DateOfBirth.HasValue).WithMessage("'Date of Birth' should be less than today.");

            RuleFor(x => x.PackageId).GreaterThan(0).WithMessage("'Package' required");
            RuleFor(x => x.AppointmentId).GreaterThan(0).WithMessage("'Appointment time' required");
            RuleFor(x => x.AppointmentId).Must((x, appointmentId) => AppointmentValidation(appointmentId))
                .When(x => x.AppointmentId > 0).WithMessage("'Appointment' already booked");
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
