using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using FluentValidation;

namespace Falcon.App.DependencyResolution
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            if (validatorType.IsGenericType)
            {
                var args = validatorType.GetGenericArguments();
                foreach (var type in args)
                {
                    if (type.GetCustomAttributes(typeof(NoValidationResolveAtStartAttribute), false).Any() || type.GetCustomAttributes(typeof(NoValidationRequiredAttribute), false).Any() || type.IsPrimitive || type.IsValueType || type == typeof(string) || (type == typeof(Int64[]))) return null;
                }
            }

            if (validatorType.FullName.ToLower().Contains("falcon.app.core.valuetypes")) return null;

            var validator = IoC.Resolve(validatorType) as IValidator;
            return validator;
        }

    }
}