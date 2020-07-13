using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IKeyValueDictionaryFactory<KeyType, ValueType>
    {
        Dictionary<KeyType, ValueType> GetDictionary(IEnumerable<ValueType> objects, Func<ValueType, KeyType> keyFunc);
    }
}