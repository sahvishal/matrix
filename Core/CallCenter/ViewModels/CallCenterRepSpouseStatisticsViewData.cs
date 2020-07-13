namespace Falcon.App.Core.CallCenter.ViewModels
{
    public sealed class CallCenterRepSpouseStatisticsViewData : CallCenterRepStatisticsViewData
    {
        private readonly int _totalCustomerCountForSales;

        public CallCenterRepSpouseStatisticsViewData(int totalCustomerPairs, int totalCancelledCustomerPairs,
            int totalNoShowCustomerPairs, int totalAttendedCustomerPairs, int totalCustomers,
            int totalCancelledCustomers, int totalNoShowCustomers, int totalAttendedCustomers,
            int totalCustomerCountForSales, decimal totalAmount)
            : base(totalCustomers, totalCancelledCustomers,
                totalNoShowCustomers, totalAttendedCustomers, totalAmount)
        {
            TotalAttendedCustomerPairs = totalAttendedCustomerPairs;
            TotalCancelledCustomerPairs = totalCancelledCustomerPairs;
            TotalCustomerPairs = totalCustomerPairs;
            TotalNoShowCustomerPairs = totalNoShowCustomerPairs;
            _totalCustomerCountForSales = totalCustomerCountForSales;
        }

        public int TotalCustomerPairs { get; private set; }
        public int TotalCancelledCustomerPairs { get; private set; }
        public int TotalNoShowCustomerPairs { get; private set; }
        public int TotalAttendedCustomerPairs { get; private set; }

        public override decimal AverageAmount
        {
            get
            {
                return TotalAmount == 0m || _totalCustomerCountForSales == 0m
                           ? 0m
                           : TotalAmount / _totalCustomerCountForSales;
            }
        }
    }
}