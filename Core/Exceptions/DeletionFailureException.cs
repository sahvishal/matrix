using System;

namespace Falcon.App.Core.Exceptions
{
    public class DeletionFailureException<T> : Exception
    {
        public DeletionFailureException()
            : base(string.Format("The given {0} object(s) could not be deleted.", typeof(T).Name))
        {}

        public DeletionFailureException(string message)
            : base(message)
        {}
    }
}