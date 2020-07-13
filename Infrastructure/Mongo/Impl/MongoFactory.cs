using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Infrastructure.Mongo.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace Falcon.App.Infrastructure.Mongo.Impl
{
    [DefaultImplementation]
    public class MongoFactory : IMongoFactory
    {
        public ActivityLog CreateDomain(ActivityLogEditModel model)
        {
            return new ActivityLog
            {
                Action = model.Action,
                UrlAccessed = model.UrlAccessed,
                ModelFullName = model.ModelFullName,
                ModelName = model.ModelName,
                RequestType = model.RequestType,
                UserLogId = model.UserLogId,
                Timestamp = model.Timestamp,
                AccessById = model.AccessById,
                CustomerId = model.CustomerId
            };
        }

        public LoggedModel CreateDomain(ActivityLog log, LoggedEditModel model)
        {
            return new LoggedModel
            {
                  LogId = log.Id,
                  ModelFullName = model.ModelFullName,
                  Model = BsonSerializer.Deserialize<BsonDocument>(model.JsonString)
            };
        }

        public LoggedCollectionModel CreateDomain(ActivityLog log, string modelFullname,string jsonString)
        {
            return new LoggedCollectionModel
            {
                LogId = log.Id,
                ModelFullName = modelFullname,
                Model = BsonSerializer.Deserialize<BsonDocument>(jsonString)
            };
        }
    }
}
