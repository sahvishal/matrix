using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class VanEditModelValidator : AbstractValidator<VanEditModel>
    {
          private readonly IVanRepository _vanRepository;
          public VanEditModelValidator(IVanRepository vanRepository)
        {
            _vanRepository = vanRepository;

            RuleFor(x => x.Name).NotNull()
                .NotEmpty().Length(3, 20);

            RuleFor(x => x.Name).Must( (x, name) => IsUniqueVanName(name, x.Id)).WithMessage("Name Already Used");

              RuleFor(x => x.StateId).NotNull().NotEmpty().GreaterThan(0).WithMessage(
                  "Vehicle Registration State Required");

        }



        private bool IsUniqueVanName(string vanName, long excludedId)
        {
            return _vanRepository.IsVanNameUnique(vanName, excludedId);
        }
    }
}