using System;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Exceptions
{
    public class InvalidObjectException<T> : ArgumentException
    {
        private static readonly IValidationErrorMessageFormatter<T> _formatter = new ValidationErrorMessageFormatter<T>();

        public InvalidObjectException(IValidator<T> validator)
            : base(_formatter.FormatErrorMessages(validator))
        {}
    }
}