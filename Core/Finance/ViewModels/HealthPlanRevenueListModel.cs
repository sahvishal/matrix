using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueListModel : ListModelBase<HealthPlanRevenueViewModel, HealthPlanRevenueListModelFilter>
    {
        public override IEnumerable<HealthPlanRevenueViewModel> Collection
        {
            get;
            set;
        }

        public override HealthPlanRevenueListModelFilter Filter
        {
            get;
            set;
        }
    }
}