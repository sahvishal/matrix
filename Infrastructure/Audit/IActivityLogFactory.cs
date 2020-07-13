using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Infrastructure.Mongo.Domain;

namespace Falcon.App.Infrastructure.Audit
{
    public interface IActivityLogFactory
    {
        ActivityLogViewModel CreateViewModel(ActivityLog mongoEntity);
    }
}
