using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class InvalidDirectoryPathException : Exception
    {
        public InvalidDirectoryPathException()
            : base("Invalid Directory Path")
        {}
    }
}