using System;

namespace Falcon.App.Core.Exceptions
{
    public class EmptyCollectionException : ArgumentException
    {
        public EmptyCollectionException()
            : base("The given collection cannot be empty.")
        {}
    }
}