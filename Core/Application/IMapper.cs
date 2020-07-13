using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IMapper<T, N>
    {
        T Map(N objectToMapFrom);
        N Map(T objectToMapFrom);

        IEnumerable<T> MapMultiple(IEnumerable<N> entities);
        IEnumerable<N> MapMultiple(IEnumerable<T> domainObjects);
    }
}