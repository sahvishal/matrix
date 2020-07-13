using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ZipRadiusCustomerCriteriaEditModel>))]
    public class ZipRadiusCustomerCriteriaEditModelValidator : AbstractValidator<ZipRadiusCustomerCriteriaEditModel>
    {
        private readonly IZipCodeRepository _zipCodeRepository;

        public ZipRadiusCustomerCriteriaEditModelValidator(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
            RuleFor(x => x.CallQueueId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("must be greater than zero.");
            RuleFor(x => x.ZipCode).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must((model, zipcode) => IsValidZipCode(zipcode)).WithMessage("provide a valid ZipCode.");
            RuleFor(x => x.HealthPlanId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
        }

        private bool IsValidZipCode(string zipCode)
        {
            var zipCodeList = _zipCodeRepository.GetZipCode(zipCode);

            return !zipCodeList.IsNullOrEmpty();
        }
    }
}