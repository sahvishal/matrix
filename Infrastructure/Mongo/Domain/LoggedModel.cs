using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Mongo.Domain
{
    public class LoggedModel : DomainBase
    {
        public ObjectId LogId { get; set; }
        public string ModelFullName { get; set; }
        public BsonDocument Model { get; set; }
    }
}
