using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventEndofDayService
    {
        EventEndofDayListModel GetforEvent(long eventId);
        EventEndofDayListModel GetforEventMyBioCheckAssessment(long eventId);
    }
}