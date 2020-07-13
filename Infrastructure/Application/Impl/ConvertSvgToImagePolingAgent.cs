using System.Diagnostics;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using JetBrains.Annotations;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    [UsedImplicitly]
    public class ConvertSvgToImagePolingAgent : IConvertSvgToImagePolingAgent
    {
        private IDatabase _db;
        private Process _process;
        private readonly string _host;
        private ConnectionMultiplexer _redis;
        private readonly int _redisDatabaseKey;
        private ILogger _logger;

        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var config = ConfigurationOptions.Parse(_host);
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public ConvertSvgToImagePolingAgent(ILogManager logManager,ISettings settings)
        {
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
            _logger = logManager.GetLogger("Convert Svg PolingAgent");
        }

        public void PollForConvertSvgToImage()
        {
            _logger.Info("Convert Svg Started");

            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.ConvertSvgRequestChannel);
                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.ConvertSvgRequestQueue);

                _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.ConvertSvgRequestChannel, RequestSubcriberChannelNames.ConvertSvgRequestQueue));
                sub.Subscribe(RequestSubcriberChannelNames.ConvertSvgRequestChannel, delegate
                {

                    string item = _db.ListRightPop(RequestSubcriberChannelNames.ConvertSvgRequestQueue);
                    while (item != null)
                    {
                        ProcessConvertRequest(item);
                        item = _db.ListRightPop(RequestSubcriberChannelNames.ConvertSvgRequestQueue);
                    }
                });
            }
            catch (System.Exception ex)
            {
                _logger.Error("Convert Svg Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);

            }
        }

        public void ProcessConvertRequest(string mpegRequestJson)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<ConvertSvgToImageRequest>(mpegRequestJson);
            _process = new Process();
            
            var startInfo = new ProcessStartInfo("inkscape")
            {
                Arguments = request.Guid,
                UseShellExecute = false, // needs to be false in order to redirect output
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                //WorkingDirectory = "D:\\"
            };
            _process.StartInfo = startInfo;
            _process.Start();

            // read the output here...
            //string output = _process.StandardOutput.ReadToEnd();

            _process.WaitForExit(30000);

            var returnCode = 0;
            try
            {
                returnCode = _process.ExitCode;
            }
            catch
            {
                _process.Kill();
                returnCode = 0;
            }

            _process.Close();
            _db.StringSet(request.Guid, returnCode == 0 ? "Completed" : "Failed");
        }
    }
}
