using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class KeyValueDictionaryFactory<KeyType, ValueType> : IKeyValueDictionaryFactory<KeyType, ValueType>
    {
        public Dictionary<KeyType, ValueType> GetDictionary(IEnumerable<ValueType> objects, Func<ValueType, KeyType> keyFunc)
        {
            var dictionary = new Dictionary<KeyType, ValueType>();
            
            foreach (var obj in objects)
            {
                dictionary.Add(keyFunc(obj), obj);
            }
            return dictionary;
        }
    }
}