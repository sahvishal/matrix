using System;

namespace Falcon.App.Core.Exceptions
{
    public class ObjectDeactivatedException<T> : ArgumentException
    {
        public ObjectDeactivatedException()
            : base(string.Format("The specified {0} is deactivated.", typeof(T).Name))
        {}
    }
}