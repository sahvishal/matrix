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
    public class MovieMakerPollingAgent : IMovieMakerPollingAgent
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

        public MovieMakerPollingAgent(ILogManager logManager, ISettings settings)
        {
            _host = settings.RedisServerHost;
            _redisDatabaseKey = settings.RedisDatabaseKey;
            _logger = logManager.GetLogger("Movie Maker Polling Agent");
        }

        public void ProcessMpegRequest(string mpegRequestJson)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GenerateMpegRequest>(mpegRequestJson);
            _process = new Process();
            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
            {
                FileName = request.FileName,
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                Arguments = request.Arguments, //H.264
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_1
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -preset slow -crf 18 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_2
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 \"" + _destinationPath + _fileName + "\"",  //H.264_3
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -acodec aac \"" + _destinationPath + _fileName + "\"",  //H.264_4
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec mpeg4 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //mpeg4
                UseShellExecute = false, // needs to be false in order to redirect output
                //RedirectStandardOutput = true,
                //RedirectStandardError = true,
                //RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = request.DestinationPath
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

        public void PollForMpegMaking()
        {
            _logger.Info("Avi to MP4 Video File Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.GenerateMpegRequestChannel, RequestSubcriberChannelNames.GenerateMpegRequestQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.GenerateMpegRequestChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.GenerateMpegRequestQueue);

                sub.Subscribe(RequestSubcriberChannelNames.GenerateMpegRequestChannel, delegate
                {

                    string work = _db.ListRightPop(RequestSubcriberChannelNames.GenerateMpegRequestQueue);
                    if (!string.IsNullOrEmpty(work)) ProcessMpegRequest(work);
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Avi to MP4 Video File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
            }
        }

        public void PollForMoviefromAviMaking()
        {
            _logger.Info("Avi to Flv Video File Started");
            _logger.Info(string.Format("Subscriber: Channel-{0}, Queue-{1}", RequestSubcriberChannelNames.MoviefromAviRequestChannel, RequestSubcriberChannelNames.MoviefromAviRequestQueue));
            try
            {
                var redis = ConnectionMultiplexer;

                var sub = redis.GetSubscriber();
                sub.Unsubscribe(RequestSubcriberChannelNames.MoviefromAviRequestChannel);

                _db = redis.GetDatabase(_redisDatabaseKey);
                _db.KeyDelete(RequestSubcriberChannelNames.MoviefromAviRequestQueue);

                sub.Subscribe(RequestSubcriberChannelNames.MoviefromAviRequestChannel, delegate
                {
                    string work = _db.ListRightPop(RequestSubcriberChannelNames.MoviefromAviRequestQueue);
                    if (!string.IsNullOrEmpty(work)) ProcessMoviefromAviRequest(work);
                });
            }
            catch (Exception ex)
            {
                _logger.Error("Avi to Flv Video File Not Generated. Message: " + ex.Message + ".\n\t" + ex.StackTrace);

            }
        }

        public void ProcessMoviefromAviRequest(string mpegRequestJson)
        {
            var request = Newtonsoft.Json.JsonConvert.DeserializeObject<GenerateMpegRequest>(mpegRequestJson);
            _process = new Process();
            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
            {
                FileName = request.FileName,
                Arguments = request.Arguments,// " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = request.DestinationPath
            };
            _process.StartInfo = startInfo;
            _process.Start();

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
