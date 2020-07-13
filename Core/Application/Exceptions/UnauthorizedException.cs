using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base("Unauthorized access")
        {}
    }
}