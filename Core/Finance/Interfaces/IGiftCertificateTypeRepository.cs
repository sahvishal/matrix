using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IGiftCertificateTypeRepository : IUniqueItemRepository<GiftCertificateType>
    {
        IEnumerable<GiftCertificateType> GetAllGiftCertificateTypes();
    }
}