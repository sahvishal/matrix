using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    public class DetailOpenOrderModelFilterValidator : AbstractValidator<DetailOpenOrderModelFilter>
    {
        public DetailOpenOrderModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue); 
        }
    }
}