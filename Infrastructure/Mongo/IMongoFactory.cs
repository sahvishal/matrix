using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Infrastructure.Mongo.Domain;

namespace Falcon.App.Infrastructure.Mongo
{
    public interface IMongoFactory
    {
        ActivityLog CreateDomain(ActivityLogEditModel model);
        LoggedModel CreateDomain(ActivityLog log, LoggedEditModel model);

        LoggedCollectionModel CreateDomain(ActivityLog log, string modelFullname, string jsonString);
    }
}
