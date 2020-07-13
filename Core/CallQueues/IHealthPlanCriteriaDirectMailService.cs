using System;
using System.Collections.Generic;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCriteriaDirectMailService
    {
        IEnumerable<DirectMailDateEditModel> GetDirectMailDateEditModel(long criteriaId);
        IEnumerable<DirectMailDateEditModel> GetActivityDateForDropDown(long campaignId);
        bool ValidateByCampaign(CampaignDirectMailDatesEditModel model, long criteriaId);
        IEnumerable<OrderedPair<long, DateTime>> GetDirectMailDatesByCriteriaIds(IEnumerable<long> criteriaIds);
    }
}
