using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class HttpCache<T> : IHttpCache<T>
    {
        private const int DefaultCacheDurationInMinutes = 60;

        public int CacheDuration { get; set; }

        //private readonly string _host;
        private readonly IDatabase _redisDatabase;
        private readonly int _cacheDatabaseKey;

        //private ConnectionMultiplexer CacheConnectionMultiplexer
        //{
        //    get
        //    {
        //        var connectionMultiplexer = AppContextStore.GetObject(AppContextStore.KeyCacheConnection) as ConnectionMultiplexer;

        //        if (connectionMultiplexer == null || !connectionMultiplexer.IsConnected)
        //        {
        //            //connectionMultiplexer = ConnectionMultiplexer.Connect(Host);
        //            var config = ConfigurationOptions.Parse(_host);
        //            config.AbortOnConnectFail = false;
        //            config.KeepAlive = 10;
        //            config.ConnectTimeout = 5000;

        //            connectionMultiplexer = ConnectionMultiplexer.Connect(config);

        //            AppContextStore.SetObject(AppContextStore.KeyCacheConnection, connectionMultiplexer);
        //        }

        //        return connectionMultiplexer;
        //    }
        //}

        private readonly ILogger _logger;

        private IDatabase GetDatabase(int cacheDatabaseKey)
        {
            //var redisDataBase = AppContextStore.GetObject(AppContextStore.KeyRedisDB) as IDatabase;

            //if (redisDataBase == null)
            //{
            var redisDataBase = RedisConnection.ConnectionMultiplexer.GetDatabase(cacheDatabaseKey);
            //    AppContextStore.SetObject(AppContextStore.KeyRedisDB, redisDataBase);
            //}

            return redisDataBase;
        }

        public HttpCache(ILogManager logManager, ISettings settings)
        {
            //_host = settings.RedisServerHost;
            CacheDuration = DefaultCacheDurationInMinutes;
            _logger = logManager.GetLogger<T>();
            _cacheDatabaseKey = settings.RedisDatabaseKey;
            _redisDatabase = GetDatabase(_cacheDatabaseKey);
        }


        public bool Get(string key, out T value)
        {
            try
            {
                var obj = Get(key);

                if (obj == null)
                {
                    value = default(T);
                    return false;
                }

                value = obj;
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }

        private T Get(string key)
        {
            try
            {
                var serializedObject = _redisDatabase.StringGet(key);
                return JsonConvert.DeserializeObject<T>(serializedObject);
            }
            catch (Exception ex)
            {
                _logger.Error("Key: " + key + " Message: " + ex.Message + " Stack trace: " + ex.StackTrace);
            }
            return default(T);
        }

        public void Set(string key, T value)
        {
            try
            {
                _redisDatabase.StringSet(key, JsonConvert.SerializeObject(value));
            }
            catch (Exception ex)
            {
                _logger.Error("Key: " + key + " Message: " + ex.Message + " Stack trace: " + ex.StackTrace);
            }
        }

        public void Clear(string key)
        {
            try
            {
                _redisDatabase.KeyDelete(key);
            }
            catch (Exception ex)
            {
                _logger.Error("Key: " + key + " Message: " + ex.Message + " Stack trace: " + ex.StackTrace);
            }
        }

        //public IEnumerable<KeyValuePair<string, object>> GetAll()
        //{
        //    var result = new List<KeyValuePair<string, object>>();
        //    try
        //    {
        //        result.AddRange(from key in GetAllKeys()
        //                        let values = _redisDatabase.StringGet(key)
        //                        select new KeyValuePair<string, object>(key, values));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("Message: " + ex.Message + " Stack trace: " + ex.StackTrace);
        //    }

        //    return result;
        //}

        //public IEnumerable<string> GetAllKeys()
        //{
        //    var result = new List<string>();
        //    try
        //    {
        //        _redisServer.Keys(_cacheDatabaseKey, "*");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error("Message: " + ex.Message + " Stack trace: " + ex.StackTrace);
        //    }

        //    return result;
        //}
    }
}