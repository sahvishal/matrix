using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Application.Impl
{
    public abstract class Mapper<T, N> : IMapper<T,N>
    {
        public abstract T Map(N objectToMap);
        public abstract N Map(T objectToMap);

        public IEnumerable<T> MapMultiple(IEnumerable<N> objectsToMap)
        {
            NullArgumentChecker.CheckIfNull(objectsToMap, "objectsToMap");
            return objectsToMap.Select(Map).ToList();
        }

        public IEnumerable<N> MapMultiple(IEnumerable<T> objectsToMap)
        {
            NullArgumentChecker.CheckIfNull(objectsToMap, "objectsToMap");
            return objectsToMap.Select(Map).ToList();
        }
    }
}