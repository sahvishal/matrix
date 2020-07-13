using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        public InvalidFileNameException()
            : base("Invalid File Name")
        {}
    }
}