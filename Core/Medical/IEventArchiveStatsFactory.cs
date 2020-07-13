using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IEventArchiveStatsFactory
    {
        ListModelBase<EventArchiveStatsViewModel, EventArchiveStatsFilter> Create(IEnumerable<ResultArchive> resultArchives, IEnumerable<Event> events, IEnumerable<File> files, IEnumerable<Pod> pods,
           IEnumerable<OrderedPair<long, string>> userIdNamePairs);
    }
}
