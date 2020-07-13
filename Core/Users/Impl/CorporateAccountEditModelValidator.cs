using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class CorporateAccountEditModelValidator : AbstractValidator<CorporateAccountEditModel>
    {
        private readonly IHostRepository _hostRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        //TODO put more rules
        public CorporateAccountEditModelValidator(IHostRepository hostRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _hostRepository = hostRepository;
            _corporateAccountRepository = corporateAccountRepository;

            //RuleFor(x => x.ContractNotes).NotNull().WithMessage("Required");
            //RuleFor(x => x.ContractNotes).NotEmpty().WithMessage("Required");
            //RuleFor(x => x.ContractNotes).Length(2, 250).WithMessage("Required, 2-250 chars");
            //RuleFor(x => x.DefaultPackages).NotNull().NotEmpty().WithMessage("Packages can't be null");

            //RuleFor(x => x.OrganizationEditModel).SetValidator(new OrganizationEditModelValidator());

            //RuleFor(x => x.AccountCode).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required");
            //RuleFor(x => x.AccountCode).Must((x, accountCode) => AccountCodeIsUnique(accountCode, x.OrganizationEditModel.Id)).WithMessage("Already in use");

            //RuleFor(x => x.CreateHost)
            //    .Must((x, createHost) => IsHostAttachedWithEvent(x.ConvertedHostId.Value))
            //    .When(x => !x.CreateHost && x.ConvertedHostId.HasValue && x.ConvertedHostId.Value > 0)
            //    .WithMessage("Can not delete host since it is attached with event.");


        }

        private bool IsHostAttachedWithEvent(long hostId)
        {
            return !_hostRepository.IsHostAttachedWithEvent(hostId);
        }

        private bool AccountCodeIsUnique(string accountCode, long excludedAccountId)
        {
            return !_corporateAccountRepository.AccountCodeExists(excludedAccountId, accountCode);
        }
    }
}