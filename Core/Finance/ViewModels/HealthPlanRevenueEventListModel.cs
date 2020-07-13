using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueEventListModel : ListModelBase<HealthPlanRevenueEventInfoModel, HealthPlanRevenueEventModelFilter>
    {
        public override IEnumerable<HealthPlanRevenueEventInfoModel> Collection
        {
            get;
            set;
        }

        public override HealthPlanRevenueEventModelFilter Filter
        {
            get;
            set;
        }
    }
}
