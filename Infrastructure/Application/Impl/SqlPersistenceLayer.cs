using Falcon.App.Core.Application.Attributes;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.Sql;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation(Interface = typeof(IPersistenceLayer))]
    public class SqlPersistenceLayer : IPersistenceLayer
    {
        public IDataAccessAdapter GetDataAccessAdapter()
        {
            return new DataAccessAdapter();
        }
    }
}