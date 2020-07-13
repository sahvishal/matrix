using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallCenter.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CampaignEditModel>))]
    public class CampaignEditModelValidator : AbstractValidator<CampaignEditModel>
    {
        private readonly ICampaignRepository _campaignRepository;        

        public CampaignEditModelValidator(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;           

            RuleFor(x => x.Name).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Length(1, 500).WithMessage("(1-500)chars").Must(IsUniqueName).WithMessage("Unique name required");
            RuleFor(x => x.CampaignCode).NotNull().WithMessage("required").NotEmpty().WithMessage("required").Length(1, 500).WithMessage("(1-500)chars").Must(IsUniqueCode).WithMessage("Unique code required");
            RuleFor(x => x.StartDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.EndDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required");

            RuleFor(x => x.EndDate).Must((x, y) => x.StartDate.HasValue && x.EndDate.HasValue && x.EndDate.Value >= x.StartDate.Value).WithMessage("invalid date range");
            RuleFor(x => x.TypeId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.ModeId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.AccountId).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.CustomTags).NotEmpty().WithMessage("required");
            RuleFor(x => x.Description).Length(1, 4000).WithMessage("(1-4000)chars").When(x => !string.IsNullOrEmpty(x.Description));
            RuleFor(x => x.CampaignActivity).Must(IsValidForPublish).WithMessage("Add atleast one activity").When(x => x.IsPublished);
            RuleFor(x => x.CampaignActivity).Must(IsValidActivity).WithMessage("First activity can not be Outbound Call");
            RuleFor(x => x.CampaignActivity).Must(IsValidActivityDate).WithMessage("activity date must be in range of campaign start date and end date");           
        }

        private bool IsValidForPublish(CampaignEditModel model, IEnumerable<CampaignActivityEditModel> activities)
        {
            return (activities != null && activities.Any());
        }

        private bool IsValidActivity(CampaignEditModel model, IEnumerable<CampaignActivityEditModel> activities)
        {
            if (activities == null || !activities.Any()) return true;

            var result = false;
            var activity = activities.OrderBy(x => x.Sequence).First();
            result = activity.ActivityType != (long)CampaignActivityType.OutboundCall;

            if (result)
            {
                activity = activities.Where(x => x.ActivityDate.HasValue).OrderBy(x => x.ActivityDate.Value).FirstOrDefault();
                result = activity != null && activity.ActivityType != (long)CampaignActivityType.OutboundCall;
            }

            return result;
        }

        private bool IsValidActivityDate(CampaignEditModel model, IEnumerable<CampaignActivityEditModel> activities)
        {
            if (activities == null || !activities.Any()) return true;

            var result = true;
            if (model.StartDate.HasValue && model.EndDate.HasValue)
                result = !activities.Any(x => x.ActivityDate < model.StartDate || x.ActivityDate > model.EndDate);

            return result;
        }

        private bool IsUniqueName(CampaignEditModel model, string campaignName)
        {
            if (!string.IsNullOrEmpty(campaignName))
                return _campaignRepository.IsCampaignNameUnique(campaignName, model.CampaignId);

            return false;
        }

        private bool IsUniqueCode(CampaignEditModel model, string campaignCode)
        {
            if (!string.IsNullOrEmpty(campaignCode))
                return _campaignRepository.IsCampaignCodeUnique(campaignCode, model.CampaignId);

            return false;
        }     
    }
}
