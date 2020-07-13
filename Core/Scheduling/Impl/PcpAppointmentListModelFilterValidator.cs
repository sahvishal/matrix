using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PcpAppointmentListModelFilter>))]
    public class PcpAppointmentListModelFilterValidator : AbstractValidator<PcpAppointmentListModelFilter>
    {
        public PcpAppointmentListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThanOrEqualTo(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue).WithMessage("From date should be less To date");

            RuleFor(x => x.DateType).GreaterThan(0).When(x => x.FromDate.HasValue || x.ToDate.HasValue)
                .WithMessage("Select date type");

            RuleFor(x => x.DateType).LessThanOrEqualTo(0).When(x => !x.FromDate.HasValue && !x.ToDate.HasValue)
                .WithMessage("Enter date");
        }
    }
}