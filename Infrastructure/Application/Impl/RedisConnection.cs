using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class RedisConnection
    {
        private static string _host;
        private static bool _useSentinel;

        static RedisConnection()
        {
            var settings = new Settings();
            _host = settings.RedisServerHost;
            _useSentinel = settings.UseSentinel;
        }
        private static ConnectionMultiplexer _redis;

        public static ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    if (_useSentinel)
                    {
                        var config = ConfigurationOptions.Parse(_host);
                        config.AbortOnConnectFail = false;
                        config.KeepAlive = 10;
                        config.ConnectTimeout = 5000;

                        _redis = ConnectionMultiplexer.Connect(config);
                    }
                    else
                    {
                        var config = ConfigurationOptions.Parse(_host);
                        config.AbortOnConnectFail = false;
                        config.KeepAlive = 10;
                        config.ConnectTimeout = 5000;

                        _redis = ConnectionMultiplexer.Connect(config);
                    }
                    
                }

                return _redis;
            }
        }
    }
}
