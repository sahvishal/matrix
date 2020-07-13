using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PackageTestEditModel>))]
    public class PackageTestEditModelValidator : AbstractValidator<PackageTestEditModel>
    {
        public PackageTestEditModelValidator()
        {

        }
    }
}