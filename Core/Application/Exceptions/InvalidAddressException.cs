using System;

namespace Falcon.App.Core.Application.Exceptions
{
    public class InvalidAddressException : ArgumentException
    {
        public InvalidAddressException(string message): base(message)
        {
            
        }

        public InvalidAddressException(string stateName, string cityName, string zipCode)
            : base(string.Format("{0},{1} and {2} is not valid.", stateName, cityName, zipCode))
        { }

        public InvalidAddressException(string addressName, string addressType)
            : base(string.Format("{0}, is not valid {1}.", addressName, addressType))
        { }
    }
}
