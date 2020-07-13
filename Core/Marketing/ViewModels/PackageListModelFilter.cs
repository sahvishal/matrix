using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class PackageListModelFilter
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Inactive { get; set; }
        public int PackageType { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<PackageListModelFilter>))]
    public class PackageListModelFilterValidator : AbstractValidator<PackageListModelFilter>
    {
        public PackageListModelFilterValidator()
        {
            
        }
    }
}