
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.ViewModels;
using FluentValidation;
using System.Collections.Generic;
using System;
using System.Linq;
namespace Falcon.App.Core.CallCenter.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<UpdatePublishedCampaignEditModel>))]
    public class UpdatePublishedCampaignEditModelValidator : AbstractValidator<UpdatePublishedCampaignEditModel>
    {
        ICampaignActivityRepository _campaignActivityRepository;
        public UpdatePublishedCampaignEditModelValidator(ICampaignActivityRepository campaignActivityRepository)
        {
            _campaignActivityRepository = campaignActivityRepository;

            RuleFor(x => x.CampaignId).NotNull().WithMessage("required").NotEmpty().WithMessage("required");

            RuleFor(x => x.CampaignEndDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required");

            RuleFor(x => x.CampaignEndDate).Must((x, y) => x.CampaignStartDate.HasValue && x.CampaignEndDate.HasValue && x.CampaignEndDate.Value >= x.CampaignStartDate.Value).WithMessage("end date should be greater than start date");  

            RuleFor(x => x.CampaignEndDate).Must((x, y) => IsValidCampaignDate(x)).WithMessage("Please provide a valid date range.");                          
        }

        private bool IsValidCampaignDate(UpdatePublishedCampaignEditModel model)
        {                       
            var activities = _campaignActivityRepository.GetByCampaignId(model.CampaignId);

            if (activities == null || !activities.Any()) return false;

            var result = true;
            if (model.CampaignStartDate.HasValue && model.CampaignEndDate.HasValue)
                result = !activities.Any(x => x.ActivityDate < model.CampaignStartDate || x.ActivityDate > model.CampaignEndDate);

            return result;
        }
      
    }
}
