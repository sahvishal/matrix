namespace Falcon.App.Core.Domain.ViewData
{
    public class PodPerformanceViewData
    {
        public long PodId { get; set; }
        public decimal AverageRevenuePerCustomerAmount { get; set; }
        public decimal UpgradeAmount { get; set; }
        public decimal DowngradeAmount { get; set; }
        public decimal HIPAAPercentage { get; set; }

    }
}
