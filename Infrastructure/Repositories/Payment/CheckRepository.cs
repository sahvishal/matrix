using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    [DefaultImplementation(Interface = typeof(ICheckRepository))]
    public class CheckRepository : UniqueItemRepository<Check, CheckEntity>, ICheckRepository
    {
        public CheckRepository()
            : base(new SqlPersistenceLayer(), new CheckMapper(),
            new CheckRepositoryStrategySetFactory().CreateRepositoryStrategySet())
        { }

        protected override EntityField2 EntityIdField
        {
            get { return CheckFields.CheckId; }
        }
    }
}