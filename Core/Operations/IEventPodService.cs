using System.Collections.Generic;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IEventPodService
    {
        void SaveEventPod(IEnumerable<EventPodEditModel> models, long eventId);
        IEnumerable<EventPodEditModel> GetEventPodEditModels(long eventId, IEnumerable<long> podIds);
    }
}
