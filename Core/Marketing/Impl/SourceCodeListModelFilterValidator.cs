using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SourceCodeListModelFilter>))]
    public class SourceCodeListModelFilterValidator : AbstractValidator<SourceCodeListModelFilter>
    {
        
    }
}