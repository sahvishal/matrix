using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class HealthPlanRevenueEditModel : ViewModelBase
    {
        public long HealthPlanId { get; set; }
        public DateTime? DateFrom { get; set; }
        public long RevenueItemTypeId { get; set; }
        public long SelectedAccountId { get; set; }

        public IEnumerable<HealthPlanRevenueByTestModel> TestList { get; set; }
        public IEnumerable<HealthPlanRevenueByPackageModel> PackageList { get; set; }
        public HealthPlanRevenueByCustomerModel Customer { get; set; }

        public IEnumerable<OrderedPair<long, string>> PackageMasterList { get;set; }
        public IEnumerable<OrderedPair<long, string>> TestMasterList { get;set; }
    }
}
