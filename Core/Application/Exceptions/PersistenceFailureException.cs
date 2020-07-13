using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class PersistenceFailureException : Exception
    {
        public PersistenceFailureException()
            : base("The given object(s) could not be persisted to storage.")
        {}

        public PersistenceFailureException(string message)
            : base(message)
        {}
    }
}