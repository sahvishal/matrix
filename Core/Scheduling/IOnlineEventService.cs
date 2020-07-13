using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IOnlineEventService
    {
        IEnumerable<OnlineEventViewModel> GetEvents(OnlineSchedulingEventListModelFilter filter, int maxNumberofRecordstoFetch, int pageSize, out int totalRecords);
        TempCart SaveSelectedEvent(TempCart tempcart, OnlineSelectedEventEditModel model);
        PreQualificationViewModel SaveAnswer(PreQualificationViewModel model);
        PreQualificationViewModel GetPreQualificationAnswer(TempCart tempCart);
    }
}
