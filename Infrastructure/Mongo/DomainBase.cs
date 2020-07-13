using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Mongo
{
	public abstract class DomainBase
	{
        public ObjectId Id { get; set; }
	}
}

