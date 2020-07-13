using System;
using FluentValidation;

namespace Falcon.App.Core.Application
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
        IValidator GetValidator(Type type);
    }
}