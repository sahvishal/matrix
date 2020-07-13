using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class GlobalCallCenterRepMetricViewData
    {
        private readonly List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> _globalMetrics;

        public GlobalCallCenterRepMetricViewData(List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> globalMetrics)
        {
            if (globalMetrics == null || globalMetrics.Where(gm => gm.SecondValue == null).Count() > 0)
            {
                throw new ArgumentNullException("globalMetrics");
            }
            _globalMetrics = globalMetrics;
        }

        public List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> BookingPercentageViewData
        {
            get
            {
                var bookingPercentageViewData= _globalMetrics.OrderByDescending(gm => gm.SecondValue.BookingPercentage).ToList();
                return bookingPercentageViewData;
            }
        }

        public List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> SpouseBookingPercentageViewData
        {
            get { return _globalMetrics.OrderByDescending(gm => gm.SecondValue.SpouseBookingPercentage).ToList(); }
        }

        public List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> ClosingPercentageViewData
        {
            get { return _globalMetrics.OrderByDescending(gm => gm.SecondValue.ClosingPercentage).ToList(); }
        }

        public List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> AverageSaleAmountViewData
        {
            get { return _globalMetrics.OrderByDescending(gm => gm.SecondValue.AverageSaleAmount).ToList(); }
        }
    }
}