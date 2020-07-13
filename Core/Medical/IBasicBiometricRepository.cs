using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IBasicBiometricRepository
    {
        BasicBiometric Get(long id);
        IEnumerable<BasicBiometric> Get(IEnumerable<long> ids);

        BasicBiometric Get(long eventId, long customerId);
        IEnumerable<BasicBiometric> GetAll(long customerId);

        void Delete(long id);
        void Delete(long eventId, long customerId);
    }
}