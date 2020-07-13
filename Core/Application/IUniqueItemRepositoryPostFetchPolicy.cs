using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IUniqueItemRepositoryPostFetchPolicy<Domain>
    {
        IEnumerable<Domain> Apply(IEnumerable<Domain> domainObjects);
        Domain Apply(Domain domainObject);
    }
}