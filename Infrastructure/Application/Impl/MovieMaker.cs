using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using StackExchange.Redis;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class MovieMaker : IMovieMaker
    {
        private Process _process;
        private string _sourcePath;
        private string _destinationPath;
        private string _fileName;

        public string ExecutableDirectoryPath { get; set; }

        const int WaitForSeconds = 30;
        private readonly ISettings _settings;

        //private ConnectionMultiplexer _redis;

        private ILogger _logger;
        
        //private ConnectionMultiplexer ConnectionMultiplexer
        //{
        //    get
        //    {
        //        if (_redis == null || !_redis.IsConnected)
        //        {
        //            var config = ConfigurationOptions.Parse(_settings.RedisServerHost);
        //            config.KeepAlive = WaitForSeconds;
        //            config.ConnectTimeout = 5000;
        //            _redis = ConnectionMultiplexer.Connect(config);
        //        }
        //        return _redis;
        //    }
        //}

        public MovieMaker(string exceutableDirectoryPath, ILogger logger)
        {
            ExecutableDirectoryPath = exceutableDirectoryPath;
            _settings = new Settings();
            _logger = logger;
        }

        public string GenerateMoviefromImageGroup(string sourcePath, string destinationPath, string fileName = "")
        {
            sourcePath = sourcePath.Trim();
            _sourcePath = sourcePath.Trim().LastIndexOf("\\") == sourcePath.Length - 1 ? sourcePath : sourcePath + "\\";
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".flv" : (fileName.ToLower().IndexOf("flv") > 0) ? fileName : fileName + ".flv";

            if (string.IsNullOrEmpty(ExecutableDirectoryPath))
                throw new InvalidOperationException("Movie Maker: Please specify the path for Excutable Directory!");

            if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                throw new InvalidFileNameException();
            if (ExecutableDirectoryPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();

            _process = new Process();

            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
                            {
                                FileName = ExecutableDirectoryPath + "\\ffmpeg.exe",
                                Arguments = " -i \"" + _sourcePath + "Image%d.jpg\" -vf \"vflip\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                                UseShellExecute = false, // needs to be false in order to redirect output
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                                WorkingDirectory = _destinationPath
                            };
            _process.StartInfo = startInfo;
            _process.Start();

            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();

            // if 0, it worked
            return (returnCode == 0) ? _fileName : null;

        }


        public string GenerateMoviefromAvi(string sourceFilePath, string destinationPath, string fileName = "")
        {
            sourceFilePath = sourceFilePath.Trim();
            _sourcePath = sourceFilePath;
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".flv" : (fileName.ToLower().IndexOf("flv") > 0) ? fileName : fileName + ".flv";

            if (string.IsNullOrEmpty(ExecutableDirectoryPath))
                throw new InvalidOperationException("Movie Maker: Please specify the path for Excutable Directory!");

            if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                throw new InvalidFileNameException();
            if (ExecutableDirectoryPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();

            _sourcePath = _sourcePath.Replace(Environment.NewLine, "");
            _destinationPath = _destinationPath.Replace(Environment.NewLine, "");
            _fileName = _fileName.Replace(Environment.NewLine, "");
            ExecutableDirectoryPath = ExecutableDirectoryPath.Replace(Environment.NewLine, "");


            var args = String.Format(@" -i ""{0}"" -r 10 -b 1500k -ar 22050 ""{1}""",
                _sourcePath,
                _destinationPath + _fileName);


            /*
            _process = new Process();
            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
            {
                FileName = ExecutableDirectoryPath + "\\ffmpeg.exe",
                Arguments = args,// " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = _destinationPath
            };
            _process.StartInfo = startInfo;
            _process.Start();

            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();
            */
            var pub = new GenerateMpegRequest { FileName = ExecutableDirectoryPath + "\\ffmpeg.exe", Arguments = args, DestinationPath = _destinationPath };

            var success = GetMoviefromAviResponse(pub);

            // if 0, it worked
            //return (success) ? _fileName : null;

            if (success)
                return _fileName;
            throw new Exception("Could not generate flv file. File Path: " + _sourcePath + " ExecutableDirectoryPath: " + ExecutableDirectoryPath);
        }

        private bool GetMoviefromAviResponse(GenerateMpegRequest pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.MoviefromAviRequestQueue, serialisedObject);
            try
            {
                sub.Publish(RequestSubcriberChannelNames.MoviefromAviRequestChannel, "");
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.MoviefromAviRequestQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.MoviefromAviRequestQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.MoviefromAviRequestQueue);
                }
                throw ex;
            }
            

            string value = "";
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                try
                {
                    value = db.StringGet(pub.Guid);
                }
                catch(Exception ex)
                {
                    _logger.Error(string.Format("Attempt Count for {0} is {1}", pub.Guid, elapsedSeconds));
                    _logger.Info("Exception for StringGet. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                }
                
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

        public string GenerateMPEG(string sourceFilePath, string destinationPath, string fileName = "")
        {
            _sourcePath = sourceFilePath.Trim();
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".mp4" : (fileName.ToLower().IndexOf("mp4") > 0) ? fileName : fileName + ".mp4";

            if (string.IsNullOrEmpty(ExecutableDirectoryPath))
                throw new InvalidOperationException("Movie Maker: Please specify the path for Excutable Directory!");

            #region Commented

            //if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            //    throw new InvalidDirectoryPathException();
            //if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            //    throw new InvalidDirectoryPathException();
            //if (ExecutableDirectoryPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            //    throw new InvalidDirectoryPathException();

            //_sourcePath = _sourcePath.Replace(Environment.NewLine, "");
            //_destinationPath = _destinationPath.Replace(Environment.NewLine, "");
            //_fileName = _fileName.Replace(Environment.NewLine, "");
            //ExecutableDirectoryPath = ExecutableDirectoryPath.Replace(Environment.NewLine, "");



            //_process = new Process();
            //// -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            //var startInfo = new ProcessStartInfo
            //{
            //    FileName = ExecutableDirectoryPath + "\\ffmpeg.exe",
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
            //    Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 \"" + _destinationPath + _fileName + "\"",  //H.264
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_1
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -preset slow -crf 18 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_2
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 \"" + _destinationPath + _fileName + "\"",  //H.264_3
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -acodec aac \"" + _destinationPath + _fileName + "\"",  //H.264_4
            //    //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec mpeg4 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //mpeg4
            //    UseShellExecute = false, // needs to be false in order to redirect output
            //    //RedirectStandardOutput = true,
            //    //RedirectStandardError = true,
            //    //RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
            //    WorkingDirectory = _destinationPath
            //};
            //_process.StartInfo = startInfo;
            //_process.Start();

            //// read the output here...
            ////string output = _process.StandardOutput.ReadToEnd();

            //_process.WaitForExit(30000);

            //int returnCode = 0;
            //try
            //{
            //    returnCode = _process.ExitCode;
            //}
            //catch 
            //{
            //    _process.Kill();
            //    returnCode = 0;
            //}


            //_process.Close();

            //return (returnCode == 0) ? _fileName : null;

            #endregion

            var args = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 \"" + _destinationPath + _fileName + "\"";
            var pub = new GenerateMpegRequest { FileName = ExecutableDirectoryPath + "\\ffmpeg.exe", Arguments = args, DestinationPath = _destinationPath };

            var success = GetMpegResponse(pub);

            // if 0, it worked
            //return (success) ? _fileName : null;
            if (success)
                return _fileName;
            throw new Exception("Could not generate mp4 file. FilePath: " + _sourcePath);

        }

        private bool GetMpegResponse(GenerateMpegRequest pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.GenerateMpegRequestQueue, serialisedObject);
            try
            {
                sub.Publish(RequestSubcriberChannelNames.GenerateMpegRequestChannel, "");
            }
            catch (Exception ex)
            {
                var length = db.ListLength(RequestSubcriberChannelNames.GenerateMpegRequestQueue);
                if (length > 0)
                {
                    _logger.Error("Queue name:" + RequestSubcriberChannelNames.GenerateMpegRequestQueue + " and Length:" + length);
                    db.ListLeftPop(RequestSubcriberChannelNames.GenerateMpegRequestQueue);
                }
                throw ex;
            }
            

            string value = "";
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                try
                {
                    value = db.StringGet(pub.Guid);
                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Attempt Count for {0} is {1}", pub.Guid, elapsedSeconds));
                    _logger.Info("Exception for StringGet. Message: " + ex.Message + ".\n\t" + ex.StackTrace);
                }
                
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

        public string GenerateMoviefromAviWithoutRedis(string sourceFilePath, string destinationPath, string fileName = "")
        {
            sourceFilePath = sourceFilePath.Trim();
            _sourcePath = sourceFilePath;
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".flv" : (fileName.ToLower().IndexOf("flv") > 0) ? fileName : fileName + ".flv";

            if (string.IsNullOrEmpty(ExecutableDirectoryPath))
                throw new InvalidOperationException("Movie Maker: Please specify the path for Excutable Directory!");

            if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                throw new InvalidFileNameException();
            if (ExecutableDirectoryPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();

            _sourcePath = _sourcePath.Replace(Environment.NewLine, "");
            _destinationPath = _destinationPath.Replace(Environment.NewLine, "");
            _fileName = _fileName.Replace(Environment.NewLine, "");
            ExecutableDirectoryPath = ExecutableDirectoryPath.Replace(Environment.NewLine, "");


            var args = String.Format(@" -i ""{0}"" -r 10 -b 1500k -ar 22050 ""{1}""",
                _sourcePath,
                _destinationPath + _fileName);

            _process = new Process();
            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
            {
                FileName = ExecutableDirectoryPath + "\\ffmpeg.exe",
                Arguments = args,// " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = _destinationPath
            };
            _process.StartInfo = startInfo;
            _process.Start();

            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();

            return (returnCode == 0) ? _fileName : null;
        }

        public string GenerateMPEGWithoutRedis(string sourceFilePath, string destinationPath, string fileName = "")
        {
            _sourcePath = sourceFilePath.Trim();
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".mp4" : (fileName.ToLower().IndexOf("mp4") > 0) ? fileName : fileName + ".mp4";

            if (string.IsNullOrEmpty(ExecutableDirectoryPath))
                throw new InvalidOperationException("Movie Maker: Please specify the path for Excutable Directory!");

            if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (ExecutableDirectoryPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();

            _sourcePath = _sourcePath.Replace(Environment.NewLine, "");
            _destinationPath = _destinationPath.Replace(Environment.NewLine, "");
            _fileName = _fileName.Replace(Environment.NewLine, "");
            ExecutableDirectoryPath = ExecutableDirectoryPath.Replace(Environment.NewLine, "");



            _process = new Process();
            // -i [Source Dir]\image%d.jpg -vf "vflip"  -r 10 -b 1500k -ar 22050  [Output Dir]\[Filename].flv
            var startInfo = new ProcessStartInfo
            {
                FileName = ExecutableDirectoryPath + "\\ffmpeg.exe",
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 \"" + _destinationPath + _fileName + "\"",
                Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 \"" + _destinationPath + _fileName + "\"",  //H.264
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec libx264 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_1
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -preset slow -crf 18 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //H.264_2
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 \"" + _destinationPath + _fileName + "\"",  //H.264_3
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -sameq -vcodec libx264 -acodec aac \"" + _destinationPath + _fileName + "\"",  //H.264_4
                //Arguments = " -i \"" + _sourcePath + "\" -r 10 -b 1500k -ar 22050 -vcodec mpeg4 -pix_fmt yuv420p \"" + _destinationPath + _fileName + "\"",  //mpeg4
                UseShellExecute = false, // needs to be false in order to redirect output
                //RedirectStandardOutput = true,
                //RedirectStandardError = true,
                //RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = _destinationPath
            };
            _process.StartInfo = startInfo;
            _process.Start();

            // read the output here...
            //string output = _process.StandardOutput.ReadToEnd();

            _process.WaitForExit(30000);

            int returnCode = 0;
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

            return (returnCode == 0) ? _fileName : null;
        }
    }
}