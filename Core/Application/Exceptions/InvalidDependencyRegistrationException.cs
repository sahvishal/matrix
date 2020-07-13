using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class InvalidDependencyRegistrationException : Exception
    {
        public InvalidDependencyRegistrationException(Type baseType, Type implType)
            : base(string.Format("Type {0} cannot be used to register type {1}", implType.Name, baseType.Name))
        {
        }
    }
}