using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CdImageStatusModelFilter>))]
    public class CdImageStatusModelFilterValidator: AbstractValidator<CdImageStatusModelFilter>
    {
        public CdImageStatusModelFilterValidator()
        {
            RuleFor(x => x.FromDate.Value).LessThan(x => x.ToDate.Value).When(
                x => x.FromDate.HasValue && x.ToDate.HasValue); 
        }
    }
}