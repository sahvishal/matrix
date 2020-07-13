using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core;
using Falcon.App.Core.CallCenter.Impl;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.CallCenter.Repositories;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class CallCenterRepMetricController : WebService, ICallCenterRepMetricController
    {
        private readonly ICallCenterRepRepository _callCenterRepRepository;
        private readonly ICallCenterRepMetricFactory _callCenterRepMetricFactory;

        public CallCenterRepMetricController()
            : this(new CallCenterRepRepository(), new CallCenterRepMetricFactory())
        { }

        public CallCenterRepMetricController(ICallCenterRepRepository callCenterRepRepository, ICallCenterRepMetricFactory callCenterRepMetricFactory)
        {
            _callCenterRepRepository = callCenterRepRepository;
            _callCenterRepMetricFactory = callCenterRepMetricFactory;
        }

        [WebMethod (EnableSession = true)]
        public CallCenterRepMetricViewData GetMetricForUser(long callCenterCallCenterUserId, DateTime startDate, DateTime endDate)
        {
            ICallCenterRepMetricRepository callCenterRepMetricRepository =
                new CallCenterRepMetricRepository(callCenterCallCenterUserId, startDate, endDate);
            int numberOfCalls = callCenterRepMetricRepository.GetNumberOfCallsForRep(callCenterCallCenterUserId, startDate, endDate);
            int numberOfBookings = callCenterRepMetricRepository.GetNumberOfBookingsForRep(callCenterCallCenterUserId, startDate, endDate);
            int numberOfSpouseBookings = 0;
            //callCenterRepMetricRepository.GetNumberOfSpouseBookingsForRep(callCenterCallCenterUserId, startDate,
            //                                                              endDate);
            int numberOfClosings = callCenterRepMetricRepository.GetNumberOfClosingsForRep(callCenterCallCenterUserId, startDate, endDate);
            decimal averageSalesAmount = callCenterRepMetricRepository.GetAverageSaleAmountForRep(callCenterCallCenterUserId, startDate, endDate);
            return _callCenterRepMetricFactory.CreateCallCenterMetric
                (callCenterCallCenterUserId, numberOfCalls, numberOfBookings, numberOfSpouseBookings, numberOfClosings,
                 averageSalesAmount);
        }

        [WebMethod (EnableSession = true)]
        public GlobalCallCenterRepMetricViewData GetMetricsForAllUsers(DateTime startDate, DateTime endDate)
        {
            ICallCenterRepMetricRepository callCenterRepMetricRepository = new CallCenterRepMetricRepository();
            List<OrderedPair<long, int>> listOfNumberOfCalls = callCenterRepMetricRepository.GetListOfNumberOfCalls(startDate, endDate);
            List<OrderedPair<long, int>> listOfNumberOfBookings = callCenterRepMetricRepository.GetListOfNumberOfBookings(startDate, endDate);
            var listOfNumberOfSpouseBookings = callCenterRepMetricRepository.GetListOfNumberOfSpouseBookings(startDate, endDate);
            listOfNumberOfSpouseBookings = listOfNumberOfSpouseBookings ?? new List<OrderedPair<long, int>>();
            List<OrderedPair<long, int>> listOfNumberOfClosings = callCenterRepMetricRepository.GetListOfNumberOfClosings(startDate, endDate);
            List<OrderedPair<long, decimal>> listOfAverageSaleAmounts = callCenterRepMetricRepository.GetListOfAverageSaleAmounts(startDate, endDate);
            List<CallCenterRepMetricViewData> callCenterMetrics = _callCenterRepMetricFactory.CreateCallCenterMetrics
                (listOfNumberOfCalls, listOfNumberOfBookings, listOfNumberOfSpouseBookings, listOfNumberOfClosings,
                 listOfAverageSaleAmounts);

            try
            {
                List<long> callCenterCallCenterUserIds = callCenterMetrics.Select(ccm => ccm.CallCenterRepId).ToList();
                List<CallCenterRep> callCenterReps = _callCenterRepRepository.GetCallCenterReps(callCenterCallCenterUserIds);
                List<OrderedPair<CallCenterRep, CallCenterRepMetricViewData>> globalMetrics =
                    callCenterMetrics.Select(ccm => new OrderedPair<CallCenterRep, CallCenterRepMetricViewData>
                    (callCenterReps.SingleOrDefault(ccr => ccr.CallCenterRepId == ccm.CallCenterRepId), ccm)).
                    Where(ccm => ccm.FirstValue != null).ToList();

                return new GlobalCallCenterRepMetricViewData(globalMetrics);
            }
            catch (Exception)
            {
                // TODO: We need to log the issue, this is probably we dont have any records for the filters provided.
                return null;
            }

        }
    }
}
