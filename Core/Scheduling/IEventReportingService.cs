using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventReportingService
    {
        ListModelBase<EventVolumeModel, EventVolumeListModelFilter> GetEventVolumeForPublicPatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords);
        ListModelBase<EventVolumeModel, EventVolumeListModelFilter> GetEventVolumeForCorporatePatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords);

        EventVolumeListModel GetEventVolumeModel(long[] eventIds);
        ListModelBase<DetailOpenOrdersModel, DetailOpenOrderModelFilter> GetDetailOpenOrderModel(int pageNumber,
                                                                                                 int pageSize,
                                                                                                 ModelFilterBase filter,
                                                                                                 out int totalRecords);

        ListModelBase<DailyRecapModel, DailyRecapModelFilter> GetDailyRecapModel(int pageNumber, int pageSize,
                                                                                 ModelFilterBase filter,
                                                                                 out int totalRecords);

        ListModelBase<EventCancellationModel, EventCancellationModelFilter> GetCancelledEventsList(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        ListModelBase<ClientEventVolumeModel, ClientEventVolumeListModelFilter> GetEventVolumeForHealthPlanPatients(int pageNumber, int pageSize, ModelFilterBase eventVolumeModelFilter, out int totalRecords);

        ListModelBase<DailyVolumeModel, DailyVolumeListModelFilter> GetDailyVolumeReport(int pageNumber, int pageSize, ModelFilterBase dailyVolumeListModelFilter, out int totalRecords);

        ListModelBase<EventListGmsModel, EventListGmsModelFilter> GetEventListForGmsReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);

        IEnumerable<EventListGmsModel> GetFutureHealthPlanEvents(long healthPlanId, DateTime today);

        EventScheduleListModel GetEventScheduleReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}