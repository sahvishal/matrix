using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Interfaces
{
    public interface IPersistenceLayer
    {
        IDataAccessAdapter GetDataAccessAdapter();
    }
}