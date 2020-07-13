using System;

namespace Falcon.App.Core.Exceptions
{
    public class ObjectAlreadyPersistedException<T> : ArgumentException
    {
        public ObjectAlreadyPersistedException()
            : base (string.Format("The given {0} has already been persisted.", typeof(T).Name))
        {}
    }
}