using Falcon.App.Core.Scheduling.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class CustomerScheduleModelFilterValidator:AbstractValidator<CustomerScheduleModelFilter>
    {
        public CustomerScheduleModelFilterValidator()
        {
            RuleFor(x => x.Vehicle).Length(3, 50);
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue); 
        }    
    }
}