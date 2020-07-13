using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application
{
    public interface IDomainDictionaryFactory<Domain> where Domain : DomainObjectBase
    {
        Dictionary<long, Domain> GetDictionary(IEnumerable<Domain> domainObjects);
    }
}