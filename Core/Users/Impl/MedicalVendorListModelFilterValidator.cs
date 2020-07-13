using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class MedicalVendorListModelFilterValidator : AbstractValidator<MedicalVendorListModelFilter>
    {
        public MedicalVendorListModelFilterValidator()
        {
            RuleFor(x => x.Name).Length(2, 50).When(x => !string.IsNullOrEmpty(x.Name));
        }
    }
}
