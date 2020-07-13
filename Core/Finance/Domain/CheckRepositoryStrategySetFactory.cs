using Falcon.App.Core.Application;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.Domain
{
    public class CheckRepositoryStrategySetFactory : IRepositoryStrategySetFactory<Check>
    {
        private readonly IValidator<Check> _checkValidator;

        public CheckRepositoryStrategySetFactory()
            : this(new Validator<Check>(new CheckValidationRuleFactory()))
        {}

        public CheckRepositoryStrategySetFactory(IValidator<Check> checkValidator)
        {
            _checkValidator = checkValidator;
        }

        public RepositoryStrategySet<Check> CreateRepositoryStrategySet()
        {
            IPrePersistenceStrategy<Check> validationPrePersistenceStrategy = new ValidationPrePersistenceStrategy<Check>(_checkValidator);
            var strategySet = new RepositoryStrategySet<Check>().WithPrePersistenceStrategy(validationPrePersistenceStrategy);
            return strategySet;
        }
    }
}