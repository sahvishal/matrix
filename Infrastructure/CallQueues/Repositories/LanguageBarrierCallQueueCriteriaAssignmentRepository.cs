using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class LanguageBarrierCallQueueCriteriaAssignmentRepository : PersistenceRepository, ILanguageBarrierCallQueueCriteriaAssignmentRepository
    {
    }
}
