using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Deprecated;

namespace Falcon.App.Core.Impl
{
    public class ValidationPrePersistenceStrategy<T> : IPrePersistenceStrategy<T>
    {
        private readonly IValidator<T> _validator;

        public ValidationPrePersistenceStrategy(IValidator<T> validator)
        {
            _validator = validator;
        }

        public void ApplyStrategy(T domainObjectToCheck)
        {
            if (!_validator.IsValid(domainObjectToCheck))
            {
                throw new InvalidObjectException<T>(_validator);
            }
        }
    }
}