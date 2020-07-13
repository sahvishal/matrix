using System;
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
    public class PdfGeneratorPollingAgent : IPdfGeneratorPollingAgent
    {
        private IDatabase _db;
        private Process _process;
        private readonly string _host;

        private ConnectionMultiplexer _redis;
        private readonly int _redisDatabaseKey;

        private readonly ILogger _logger;

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

        public PdfGeneratorPollingAgent(ILogManager logManager, ISettings settings)
        {
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
            _logger = logManager.GetLogger("Pdf Generator PollingAgent");
        }

        private void ProcessPdfRequest(string mpegRequestJson)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GenerateMpegRequest>(mpegRequestJson);
            _process = new Process();

            var startInfo = new ProcessStartInfo
            {
                FileName = request.FileName,
                Arguments = request.Arguments,
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = request.DestinationPath
            };
            _process.StartInfo = startInfo;
            _process.Start();// read the output here...
            var output = _process.StandardOutput.ReadToEnd();
            //var error = _process.StandardError.ReadToEnd();

            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();
            _db.StringSet(request.Guid, returnCode == 0 ? "Completed" : "Failed");
        }

        public void PollForPdfGenerating()
        {
            _logger.Info("PdfGeneratorPollingAgent for Url Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.GeneratePdfRequestChannel, RequestSubcriberChannelNames.GeneratePdfRequestQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.GeneratePdfRequestChannel);
                    
                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.GeneratePdfRequestQueue);

                sub.Subscribe(RequestSubcriberChannelNames.GeneratePdfRequestChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.GeneratePdfRequestQueue);
                    while (item != null)
                    {
                        ProcessPdfRequest(item);
                        item = _db.ListRightPop(RequestSubcriberChannelNames.GeneratePdfRequestQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error("PdfGeneratorPollingAgent for Url : Pdf File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);

            }
        }

          
        private void ProcessHtmlStreamPdfRequest(string mpegRequestJson)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<HtmlStreamPdfRequest>(mpegRequestJson);

            _process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = request.FileName,
                Arguments = request.Arguments,
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = request.DestinationPath
            };


            _process.StartInfo = startInfo;
            _process.Start();

            var streamWriter = _process.StandardInput;
            streamWriter.Write(request.HtmlStream);
            streamWriter.Close();

            // read the output here...
            string output = _process.StandardOutput.ReadToEnd();

            // ...then wait n milliseconds for exit (as after exit, it can't read the output)
            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();

            _db.StringSet(request.Guid, returnCode == 0 ? "Completed" : "Failed");
        }

        public void PollForPdfFromHtmlStream()
        {
            _logger.Info("PdfGeneratorPollingAgent for HtmlStream Started");

            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.HtmlStreamPdfRequestChannel);
                    
                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.HtmlStreamPdfRequestQueue);

                sub.Subscribe(RequestSubcriberChannelNames.HtmlStreamPdfRequestChannel, delegate
                {
                    string item = _db.ListRightPop(RequestSubcriberChannelNames.HtmlStreamPdfRequestQueue);
                    while (item != null)
                    {
                        ProcessHtmlStreamPdfRequest(item);
                        item = _db.ListRightPop(RequestSubcriberChannelNames.HtmlStreamPdfRequestQueue);
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.Error("PdfGeneratorPollingAgent for HtmlStream : Pdf File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);

            }
        }
    }
}
