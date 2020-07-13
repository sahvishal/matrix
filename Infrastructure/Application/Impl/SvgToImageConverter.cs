using System;
using System.IO;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class SvgToImageConverter : ISvgToImageConverter
    {
        const int WaitForSeconds = 30;
        private ConnectionMultiplexer _redis;
        private ConnectionMultiplexer ConnectionMultiplexer
        {
            get
            {
                if (_redis == null || !_redis.IsConnected)
                {
                    var settings = new Settings();
                    var config = ConfigurationOptions.Parse(settings.RedisServerHost);
                    config.KeepAlive = WaitForSeconds;
                    config.ConnectTimeout = 5000;
                    _redis = ConnectionMultiplexer.Connect(config);
                }
                return _redis;
            }
        }

        public string GenerateImage(string svgFilePath)
        {
            var returnFileName = Path.GetDirectoryName(svgFilePath) + "\\" + Path.GetFileNameWithoutExtension(svgFilePath)
                                 + ".png";

            if (svgFilePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (returnFileName.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();



            svgFilePath = svgFilePath.Replace(Environment.NewLine, "");
            returnFileName = returnFileName.Replace(Environment.NewLine, "");
            /*
            var process = new Process();
            var startInfo = new ProcessStartInfo("inkscape")
            {
                Arguments = " -z -f \"" + svgFilePath + "\" -e \"" + returnFileName + "\"",
                UseShellExecute = false, // needs to be false in order to redirect output
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                //WorkingDirectory = "D:\\"
            };

            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            int returnCode = process.ExitCode;
            process.Close();
            */

            var args = " -z -f \"" + svgFilePath + "\" -e \"" + returnFileName + "\"";
            var pub = new ConvertSvgToImageRequest { Arguments = args };

            var success = GetConvertResponse(pub);

            // if 0, it worked
            return (success) ? returnFileName : null;

        }

        public bool GetConvertResponse(ConvertSvgToImageRequest pub)
        {
            var settings = new Settings();

            IDatabase db = ConnectionMultiplexer.GetDatabase(settings.RedisDatabaseKey);
            ISubscriber sub = ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.ConvertSvgRequestQueue, serialisedObject);
            sub.Publish(RequestSubcriberChannelNames.ConvertSvgRequestChannel, "");

            string value = db.StringGet(pub.Guid);
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                value = db.StringGet(pub.Guid);
                if (!string.IsNullOrEmpty(value))
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return value == "Completed";
                }
                Thread.Sleep(1000);
                if (elapsedSeconds == WaitForSeconds)
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return false;
                }
            }
            return true;
        }

    }
}