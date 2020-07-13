using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class EmptyCollectionException : ArgumentException
    {
        public EmptyCollectionException()
            : base("The given collection cannot be empty.")
        {}
    }
}