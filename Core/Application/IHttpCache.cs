using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IHttpCache<T>
    {
        bool Get(string key, out T value);
        void Set(string key, T value);
        void Clear(string key);
        int CacheDuration { get; set; }
        //IEnumerable<KeyValuePair<string, object>> GetAll();
        //IEnumerable<string> GetAllKeys();
    }
}