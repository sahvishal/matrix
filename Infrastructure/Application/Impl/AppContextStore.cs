using System.Web;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public static class AppContextStore
    {
        public static string KeyCacheConnection = "_CacheConnectionManager_";
        public static string KeyRedisDB = "_RedisDatabase_";

        public static object GetObject(object key)
        {
            if (HttpContext.Current != null && HttpContext.Current.Items[key] != null)
            {
                return HttpContext.Current.Items[key];
            }

            return null;
        }

        public static void SetObject(object key, object value)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[key] != null)
                    HttpContext.Current.Items[key] = value;
                else
                    HttpContext.Current.Items.Add(key, value);
            }
        }

        public static void ClearAll()
        {
            //var cacheConnection = (HttpContext.Current.Items[KeyCacheConnection] as ConnectionMultiplexer);
            //if (cacheConnection != null)
            //{
            //    cacheConnection.Close(false);
            //    cacheConnection.Dispose();
            //}
        }

    }
}