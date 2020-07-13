using System;

namespace Falcon.App.Core.Exceptions
{
    public class ObjectNotFoundInPersistenceException<T> : ArgumentException
    {
        public ObjectNotFoundInPersistenceException()
            : base(string.Format("An instance of {0} could not be found using the given parameter.",
            typeof(T)))
        {}
        public ObjectNotFoundInPersistenceException(long invalidId)
            : base(string.Format("An instance of {0} could not be found for ID {1}.", 
            typeof(T), invalidId))
        {}
        public ObjectNotFoundInPersistenceException(Guid invalidGuid)
            : base(string.Format("An instance of {0} could not be found for ID {1}.",
            typeof(T), invalidGuid))
        {}
    }
}