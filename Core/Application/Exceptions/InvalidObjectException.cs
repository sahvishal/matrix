using System;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Impl;


namespace Falcon.App.Core.Application.Exceptions
{
    public class InvalidObjectException<T> : ArgumentException
    {
        private static readonly IValidationErrorMessageFormatter<T> _formatter = new ValidationErrorMessageFormatter<T>();

        public InvalidObjectException(IValidator<T> validator)
            : base(_formatter.FormatErrorMessages(validator))
        {}
    }
}