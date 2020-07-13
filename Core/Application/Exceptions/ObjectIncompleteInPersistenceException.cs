using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class ObjectIncompleteInPersistenceException<T> : ArgumentException 
    {        
        public ObjectIncompleteInPersistenceException(long invalidId, string missingDataMessage)
            : base(string.Format("Property missing or null in {0} for ID {1}. {2}", 
            typeof(T), invalidId,missingDataMessage))
        {}
    }
}