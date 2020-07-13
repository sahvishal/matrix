using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class AppointmentsBookedListModelFilterValidator:AbstractValidator<AppointmentsBookedListModelFilter>
    {
        public AppointmentsBookedListModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue);

            RuleFor(x => x.EventFrom.Value).LessThan(x => x.EventTo.Value).When(
                x => x.EventFrom.HasValue && x.EventTo.HasValue);
        }
    }
}