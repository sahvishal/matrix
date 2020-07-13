using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<SourceCodeEventEditModel>))]
    public class SourceCodeEventEditModelValidator : AbstractValidator<SourceCodeEventEditModel>
    {
        public SourceCodeEventEditModelValidator()
        {
            
        }
    }
}
