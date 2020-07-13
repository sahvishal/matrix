using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application
{
    public interface IUniqueItemRepository<Domain> : IRepository<Domain>
        where Domain : DomainObjectBase
    {
        Domain GetById(long id);
        IEnumerable<Domain> GetByIds(IEnumerable<long> ids);
    }
}