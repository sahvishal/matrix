using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Extensions;
using FluentValidation;
using System;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanCallQueueCriteriaEditModel>))]
    public class HealthPlanCallQueueCriteriaEditModelValidator : AbstractValidator<HealthPlanCallQueueCriteriaEditModel>
    {
        private readonly IZipCodeRepository _zipCodeRepository;

        public HealthPlanCallQueueCriteriaEditModelValidator(IZipCodeRepository zipCodeRepository, IHealthPlanCriteriaDirectMailService healthPlanCriteriaDirectMailService)
        {
            _zipCodeRepository = zipCodeRepository;

            RuleFor(x => x.HealthPlanId).GreaterThan(0).WithMessage("required");

            RuleFor(x => x.CallQueue).Must((x, y) => isValidCallQueue(y)).WithMessage("required").When(x => x.HealthPlanId > 0);

            //validation moved in controller
            //RuleFor(x => x.Assignments).NotNull().WithMessage("required").When(x => x.HealthPlanId > 0 && isValidCallQueue(x.CallQueue));

            RuleFor(x => x.Radius).GreaterThan(-1).WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.ZipRadius);

            RuleFor(x => x.Zipcode).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Must((x, y) => IsValidZipCode(y)).WithMessage("invalid zip code").When(x => x.CallQueue == HealthPlanCallQueueCategory.ZipRadius);

            RuleFor(x => x.NoOfDaysOfEvents).NotNull().WithMessage("required").GreaterThan(0).WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan);

            RuleFor(x => x.Percentage).GreaterThanOrEqualTo(0).WithMessage("required").Must((x, y) => y > 0 && y < 100).WithMessage("must be between 0 and 100").When(x => x.CallQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan); ;

            RuleFor(x => x.RoundOfCalls).GreaterThanOrEqualTo(0).WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.CallRound);

            RuleFor(x => x.NoOfDays).GreaterThanOrEqualTo(0).WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.CallRound);

            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.NoShows);

            RuleFor(x => x.EndDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.NoShows);

            RuleFor(x => x.EndDate).Must((model, endDate) => endDate.HasValue && model.StartDate.HasValue && endDate.Value.Date >= model.StartDate.Value).WithMessage("end date must be greater than start date.").When(x => x.EndDate.HasValue);

            RuleFor(x => x.CampaignDirectMailDates).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.MailRound);

            RuleForEach(x => x.CampaignDirectMailDates).Must((x, y) => healthPlanCriteriaDirectMailService.ValidateByCampaign(y, x.Id)).WithMessage("Dates overlapping with another criteria for same campaign.").When(x => x.CallQueue == HealthPlanCallQueueCategory.MailRound);

            RuleFor(x => x.CriteriaName).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan);

            RuleFor(x => x.LanguageId).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("required").When(x => x.CallQueue == HealthPlanCallQueueCategory.AppointmentConfirmation);
        }

        private bool IsValidZipCode(string zipCode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipCode))
                    return false;

                var zipCodeList = _zipCodeRepository.GetZipCode(zipCode);

                return !zipCodeList.IsNullOrEmpty();
            }
            catch (Exception)
            {
                return false;
            }

        }

        private bool isValidCallQueue(string callQueue)
        {
            return callQueue == HealthPlanCallQueueCategory.ZipRadius || callQueue == HealthPlanCallQueueCategory.UncontactedCustomers || callQueue == HealthPlanCallQueueCategory.NoShows
                || callQueue == HealthPlanCallQueueCategory.FillEventsHealthPlan || callQueue == HealthPlanCallQueueCategory.CallRound || callQueue == HealthPlanCallQueueCategory.LanguageBarrier
                || callQueue == HealthPlanCallQueueCategory.MailRound || callQueue == HealthPlanCallQueueCategory.AppointmentConfirmation;
        }

    }
}
