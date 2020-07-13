using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Falcon.App.Infrastructure.Audit
{
    public interface IReflectionFactory
    {
        BsonDocument CreateFromEditModel(dynamic model, bool fromAPI = false);

        IEnumerable<BsonDocument> ListProperty(dynamic collection, bool fromAPI = false);

        bool IsNumericType(Type type);
        bool IsPrimitiveType(Type type);
    }
}
