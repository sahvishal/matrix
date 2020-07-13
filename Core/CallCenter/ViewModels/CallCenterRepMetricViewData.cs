namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterRepMetricViewData
    {
        public long CallCenterRepId { get; set; }
        public int BookingCallCount { get; set; }
        public int SpouseBookingCallCount { get; set; }
        public int TotalSignUpCallCount { get; set; }
        public int ClosingCallCount { get; set; }

        public decimal BookingPercentage
        {
            get
            {
                if (TotalSignUpCallCount > 0) 
                    return BookingCallCount / (decimal)TotalSignUpCallCount; 
                return decimal.Zero;
            }
        }

        public decimal SpouseBookingPercentage
        {
            get
            {
                if (BookingCallCount > 0)
                    return SpouseBookingCallCount / (decimal)BookingCallCount;
                return decimal.Zero;
            }
        }

        public decimal ClosingPercentage
        {
            get
            {
                if (BookingCallCount > 0) 
                    return ClosingCallCount / (decimal)BookingCallCount;
                return decimal.Zero;
            }
        }

        public decimal AverageSaleAmount { get; set; }
    }
}