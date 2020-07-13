using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class EventArchiveStatsService : IEventArchiveStatsService
    {
        private readonly IResultArchiveUploadRepository _resultArchiveUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPodRepository _podRepository;
        private readonly IEventArchiveStatsFactory _eventArchiveStatsFactory;

        public EventArchiveStatsService(IResultArchiveUploadRepository resultArchiveUploadRepository, IUniqueItemRepository<File> fileRepository, IEventRepository eventRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IPodRepository podRepository, IEventArchiveStatsFactory eventArchiveStatsFactory)
        {
            _resultArchiveUploadRepository = resultArchiveUploadRepository;
            _fileRepository = fileRepository;
            _eventRepository = eventRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _podRepository = podRepository;
            _eventArchiveStatsFactory = eventArchiveStatsFactory;
        }

        public ListModelBase<EventArchiveStatsViewModel, EventArchiveStatsFilter> GetEventArchiveStats(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords)
        {
            filter = filter ?? new EventArchiveStatsFilter();
            var resultArchives = _resultArchiveUploadRepository.GetForEventArchiveStatsReport(filter as EventArchiveStatsFilter, pageNumber, pageSize, out totalRecords);
            if (resultArchives == null || !resultArchives.Any()) return null;

            var fileIds = resultArchives.Where(r => r.FileId.HasValue).Select(r => r.FileId.Value).ToArray();
            var files = _fileRepository.GetByIds(fileIds);

            var events = _eventRepository.GetEventswithPodbyIds(resultArchives.Select(r => r.EventId).ToArray());

            var orgRoleUserIds = resultArchives.Select(r => r.UploadedByOrgRoleUserId).ToArray();
            var userIdNamePairs = _organizationRoleUserRepository.GetNameIdPairofUsers(orgRoleUserIds);

            var pods = _podRepository.GetPodsForEvents(events.Select(e => e.Id).ToArray());

            return _eventArchiveStatsFactory.Create(resultArchives, events, files, pods, userIdNamePairs);
        }
    }
}
