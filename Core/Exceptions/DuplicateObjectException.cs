using System;

namespace Falcon.App.Core.Exceptions
{
    public class DuplicateObjectException<T> : ArgumentException
    {
        public DuplicateObjectException()
            : base(string.Format("Only one instance of {0} is allowed, but more than one was found.", typeof(T).Name))
        {}
    }
}