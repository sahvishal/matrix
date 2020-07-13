namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterRepStatisticsViewData
    {
        public CallCenterRepStatisticsViewData(int totalCustomers, int totalCancelledCustomers, 
            int totalNoShowCustomers, int totalAttendedCustomers, decimal totalAmount)
        {
            TotalCustomers = totalCustomers;
            TotalCancelledCustomers = totalCancelledCustomers;
            TotalNoShowCustomers = totalNoShowCustomers;
            TotalAttendedCustomers = totalAttendedCustomers;
            TotalAmount = totalAmount;
        }

        public int TotalCustomers { get; private set; }
        public int TotalCancelledCustomers { get; private set; }
        public int TotalNoShowCustomers { get; private set; }
        public int TotalAttendedCustomers { get; private set; }
        public decimal TotalAmount { get; private set; }

        public virtual decimal AverageAmount
        {
            get
            {
                return TotalAmount == 0m || TotalCustomers == 0m
                           ? 0m
                           : TotalAmount/((TotalCustomers - TotalCancelledCustomers) - TotalNoShowCustomers);
            }
        }
    }
}