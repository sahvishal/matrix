using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application
{
    public interface IRepository<Domain>
        where Domain : DomainObjectBase
    {
        Domain Save(Domain domainObject);
        
        void Delete(Domain domainObject);
        void Delete(IEnumerable<Domain> domainObjects);
        
    }
}