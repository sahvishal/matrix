using System.Collections.Generic;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentInstrumentRepositoryListFactory
    {
        IEnumerable<IPaymentInstrumentRepository> GetPaymentInstrumentRepositories();
    }
}