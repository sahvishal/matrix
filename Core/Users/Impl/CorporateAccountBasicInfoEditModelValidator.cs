using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CorporateAccountBasicInfoEditModel>))]
    public class CorporateAccountBasicInfoEditModelValidator : AbstractValidator<CorporateAccountBasicInfoEditModel>
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHostRepository _hostRepository;

        public CorporateAccountBasicInfoEditModelValidator(ICorporateAccountRepository corporateAccountRepository,IHostRepository hostRepository)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _hostRepository = hostRepository;
            //RuleFor(x => x.ContractNotes).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Length(2, 250).WithMessage("Required, 2-250 chars");
            RuleFor(x => x.OrganizationEditModel).SetValidator(new OrganizationEditModelValidator());
            RuleFor(x => x.CorpCode).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Length(2, 50).WithMessage("Required, 2-50 chars");

            RuleFor(x => x.CorpCode).Must((x, accountCode) => AccountCodeIsUnique(accountCode, x.OrganizationEditModel.Id)).WithMessage("Already in use");

            RuleFor(x => x.CreateHost)
               .Must((x, createHost) => IsHostAttachedWithEvent(x.ConvertedHostId.Value))
               .When(x => !x.CreateHost && x.ConvertedHostId.HasValue && x.ConvertedHostId.Value > 0)
               .WithMessage("Can not delete host since it is attached with event.");
        }

        private bool AccountCodeIsUnique(string accountCode, long excludedAccountId)
        {
            return !_corporateAccountRepository.AccountCodeExists(excludedAccountId, accountCode);
        }

        private bool IsHostAttachedWithEvent(long hostId)
        {
            return !_hostRepository.IsHostAttachedWithEvent(hostId);
        }
    }
}