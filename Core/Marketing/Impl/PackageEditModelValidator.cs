using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<PackageEditModel>))]
    public class PackageEditModelValidator : AbstractValidator<PackageEditModel>
    {
        private readonly IPackageRepository _packageRepository;
        public PackageEditModelValidator(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;

            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must(CheckifNameisUnique).WithMessage("Please select a unique name");
            RuleFor(x => x.Price).NotNull().WithMessage("required");
            RuleFor(x => x.Description).Length(1, 1000).When(x => !string.IsNullOrEmpty(x.Description)).WithMessage("not more 1000 chars allowed.");
            RuleFor(x => x.PackageTypeId).GreaterThan(0).WithMessage("select package type");
            RuleFor(x => x.SelectedTests).NotNull().WithMessage("select altleast one test").NotEmpty().WithMessage("select altleast one test");
            RuleFor(x => x.SelectedRoles).NotNull().WithMessage("select altleast one role").NotEmpty().WithMessage("select altleast one role");

            //RuleFor(x => x.ScreeningTime).GreaterThan(0).WithMessage("greater than 0").LessThanOrEqualTo(60).WithMessage("max 60 minutes");
        }

        public bool CheckifNameisUnique(PackageEditModel model, string packageName)
        {
            if (model.Id > 0)
            {
                var inDb = _packageRepository.GetById(model.Id);
                if (inDb.Name == packageName) return true;
            }

            if (string.IsNullOrEmpty(packageName))
                return false;

            var package = _packageRepository.GetByName(packageName.Trim());
            if (package != null)
                return false;

            return true;
        }

    }
}