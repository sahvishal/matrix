using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Renci.SshNet;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class ProcessFtp
    {
        private readonly string _host;
        private readonly string _username;
        private readonly string _password;

        private readonly ILogger _logger;

        public ProcessFtp(ILogger logger, string sftpHost, string sftpUserName, string sftpPassword)
        {
            _logger = logger;
            _host = sftpHost;
            _username = sftpUserName;
            _password = sftpPassword;
        }

        private void UploadFile(string sourceFilePath, string destinationFolder, string destinationFileName)
        {
            if (!File.Exists(sourceFilePath)) return;

            using (var client = OpenChannel())
            {
                if (!string.IsNullOrEmpty(destinationFolder))
                {
                    ChangeDirectory(client, destinationFolder);
                }

                if (string.IsNullOrEmpty(destinationFileName))
                    destinationFileName = Path.GetFileName(sourceFilePath);

                using (var fileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    client.UploadFile(fileStream, destinationFileName, null);
                };
            }
        }

        private void ChangeDirectory(SftpClient client, string destinationFolder)
        {
            destinationFolder = destinationFolder.Replace("/", "\\");

            var directoryList = destinationFolder.Split('\\');

            foreach (var directory in directoryList)
            {
                try
                {
                    client.CreateDirectory(directory);
                }
                catch (Exception)
                {
                    //_logger.Error(ex.Message);
                }

                client.ChangeDirectory(directory);
            }
        }

        public void RemoveFile(string destinationFolder, string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(destinationFolder)) return;

            try
            {
                using (var client = OpenChannel())
                {
                    var directoryList = destinationFolder.Split('\\');

                    var isDirectoryFound = true;
                    foreach (var directory in directoryList)
                    {
                        try
                        {
                            client.ChangeDirectory(directory);
                        }
                        catch (Exception)
                        {
                            isDirectoryFound = false;
                        }

                        if (!isDirectoryFound) break;

                        client.DeleteFile(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }
        }

        private SftpClient OpenChannel()
        {
            var client = new SftpClient(_host, _username, _password);
            client.Connect();

            return client;
        }

        public void UploadMultipleFiles(IEnumerable<string> files)
        {
            if (files == null || !files.Any()) return;

            try
            {
                foreach (var file in files)
                {
                    UploadFile(file, "", "");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }
        }

        public bool UploadSingleFile(string sourceFilePath, string destinationFolder, string destinationFileName)
        {
            try
            {
                UploadFile(sourceFilePath, destinationFolder, destinationFileName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return false;
            }
        }

        public void DownloadFiles(string sourceDirectory, string destinationDirectory)
        {
            try
            {
                using (var client = OpenChannel())
                {
                    var files = client.ListDirectory(sourceDirectory);
                    if (files != null && files.Any())
                    {
                        foreach (var sftpFile in files)
                        {

                            if (!sftpFile.IsDirectory && !sftpFile.IsSymbolicLink)
                            {
                                _logger.Info(string.Format("Downloading file Path: {0}", sourceDirectory + "/" + sftpFile.Name));
                                using (Stream fileStream = File.OpenWrite(Path.Combine(destinationDirectory, sftpFile.Name)))
                                {
                                    client.DownloadFile(sftpFile.FullName, fileStream);
                                }
                                _logger.Info(string.Format("Downloaded file Source Path: {0} to Destination Path: {1}", sourceDirectory + "/" + sftpFile.Name, destinationDirectory + sftpFile.Name));
                            }
                        }
                    }
                    else
                    {
                        _logger.Info(string.Format("No files found in Path: {0}", sourceDirectory));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while downloading files from Path: {0}", sourceDirectory));
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }
        }

        public void DownloadFiles(IEnumerable<string> filesToBeDownlaoded, string sourceDirectory, string destinationDirectory, string prefix = "")
        {
            try
            {
                using (var client = OpenChannel())
                {
                    var sftpFiles = client.ListDirectory(sourceDirectory);
                    client.ChangeDirectory(sourceDirectory);

                    if (sftpFiles != null && sftpFiles.Any())
                    {
                        foreach (var downloadFile in filesToBeDownlaoded)
                        {
                            if (sftpFiles.Any(s => !s.IsSymbolicLink && !s.IsDirectory && s.Name.Contains(downloadFile)))
                            {
                                var fileNames = sftpFiles.Where(s => s.Name.Contains(downloadFile)).Select(s => s.Name);

                                foreach (var fileName in fileNames)
                                {
                                    var newFileName = string.IsNullOrEmpty(prefix) ? fileName : prefix + "_" + fileName;

                                    _logger.Info(string.Format("Downloading file Path: {0}", sourceDirectory + "/" + fileName));

                                    using (Stream fileStream = File.OpenWrite(Path.Combine(destinationDirectory, newFileName)))
                                    {
                                        client.DownloadFile(fileName, fileStream);
                                    }

                                    _logger.Info(string.Format("Downloaded file Source Path: {0} to Destination Path: {1}", sourceDirectory + "/" + downloadFile, destinationDirectory + newFileName));
                                }

                            }
                        }
                    }
                    else
                    {
                        _logger.Info(string.Format("No files found in Path: {0}", sourceDirectory));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while downloading files from Path: {0}", sourceDirectory));
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }
        }

        public void DownloadFilesFromSubdirectories(IEnumerable<string> filesToBeDownlaoded, string sourceDirectory, string destinationDirectory, string prefix = "", string subDirPrefix = "")
        {
            try
            {
                using (var client = OpenChannel())
                {
                    var sftpDirs = client.ListDirectory(sourceDirectory);
                    client.ChangeDirectory(sourceDirectory);

                    if (!string.IsNullOrEmpty(subDirPrefix))
                        sftpDirs = sftpDirs.Where(s => !s.IsSymbolicLink && s.IsDirectory && s.Name.Contains(subDirPrefix));

                    if (sftpDirs != null && sftpDirs.Any())
                    {
                        foreach (var dir in sftpDirs)
                        {
                            var sftpSourcePath = Path.Combine(sourceDirectory, dir.Name);
                            DownloadFiles(filesToBeDownlaoded, sftpSourcePath, destinationDirectory, prefix);
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("No files found in Path: {0}", sourceDirectory));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error while downloading files from Path: {0}", sourceDirectory));
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void UploadSingleFileUsingSftp(string sourceFilePath, string destinationFolder, string fileName)
        {
            try
            {
                UploadFile(sourceFilePath, destinationFolder, fileName);
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while downloading files from Path: {0}", fileName));
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }

        }

        public string[] ListDirectory(string sourceDirectory)
        {
            try
            {
                using (var client = OpenChannel())
                {
                    var sftpFiles = client.ListDirectory(sourceDirectory);
                    client.ChangeDirectory(sourceDirectory);

                    if (sftpFiles != null && sftpFiles.Any())
                    {
                        return sftpFiles.Where(s => !s.IsSymbolicLink && !s.IsDirectory).Select(s => s.Name).ToArray();
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error while downloading files from Path: {0}", sourceDirectory));
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }

            return null;
        }

        public bool UploadSingleFileOnSftp(string sourceFilePath, string destinationFolder, string destinationFileName)
        {
            try
            {
                UploadFile(sourceFilePath, destinationFolder, destinationFileName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return false;
            }
            return true;
        }

    }

    //public class ProcessFtp
    //{
    //    private readonly string _host;
    //    private readonly string _username;
    //    private readonly string _password;

    //    private Session _session;
    //    private Channel _channel;
    //    private readonly ILogger _logger;

    //    public ProcessFtp(ILogger logger, string sftpHost, string sftpUserName, string sftpPassword)
    //    {
    //        _logger = logger;
    //        _host = sftpHost;
    //        _username = sftpUserName;
    //        _password = sftpPassword;
    //    }

    //    private void UploadFile(string filePath, string destinationFolder, string destinationFileName)
    //    {
    //        if (!File.Exists(filePath)) return;

    //        var c = (ChannelSftp)_channel;

    //        if (!string.IsNullOrEmpty(destinationFolder))
    //        {
    //            var directoryList = destinationFolder.Split('\\');

    //            foreach (var directory in directoryList)
    //            {
    //                try
    //                {
    //                    c.mkdir(directory);
    //                }
    //                catch (Exception)
    //                {
    //                    //_logger.Error(ex.Message);
    //                }

    //                c.cd(directory);
    //            }

    //        }

    //        if (string.IsNullOrEmpty(destinationFileName))
    //            destinationFileName = Path.GetFileName(filePath);

    //        c.put(filePath, destinationFileName);
    //    }

    //    public void RemoveFile(string destinationFolder, string filePath)
    //    {
    //        if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(destinationFolder)) return;

    //        try
    //        {
    //            OpenChannel();
    //            var c = (ChannelSftp)_channel;

    //            var directoryList = destinationFolder.Split('\\');

    //            var isDirectoryFound = true;
    //            foreach (var directory in directoryList)
    //            {
    //                try
    //                {
    //                    c.cd(directory);
    //                }
    //                catch (Exception)
    //                {
    //                    isDirectoryFound = false;
    //                    //_logger.Error(ex.Message);
    //                }

    //                if (!isDirectoryFound) break;
    //            }

    //            if (isDirectoryFound)
    //                c.rm(filePath);
    //        }
    //        catch (Exception exception)
    //        {
    //            _logger.Error("Remove Error for FilePath : " + destinationFolder + "\\" + filePath + "\n Message :" + exception.Message + "\n" + exception.StackTrace);

    //        }
    //        finally
    //        {
    //            CloseChannel();
    //        }
    //    }

    //    private void OpenChannel()
    //    {
    //        var jsch = new JSch();
    //        _session = jsch.getSession(_username, _host, 22);

    //        _session.setUserInfo(new UInfo(_password));
    //        _session.connect();

    //        _channel = _session.openChannel("sftp");
    //        _channel.connect();
    //    }

    //    private void CloseChannel()
    //    {
    //        try
    //        {
    //            if (_channel != null && _channel.isConnected() && !_channel.isClosed())
    //            {
    //                _channel.disconnect();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Info("Some issue while closing channel. Message: " + ex.Message);
    //        }

    //        try
    //        {
    //            if (_session != null && _session.isConnected())
    //            {
    //                _session.disconnect();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Info("Some issue while closing session. Message: " + ex.Message);
    //        }
    //    }

    //    public void UploadMultipleFiles(IEnumerable<string> files)
    //    {
    //        if (files == null || !files.Any()) return;

    //        try
    //        {
    //            OpenChannel();
    //            foreach (var file in files)
    //            {
    //                UploadFile(file, "", "");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Error(ex.Message);
    //            _logger.Error(ex.StackTrace);
    //        }
    //        finally
    //        {
    //            CloseChannel();
    //        }
    //    }

    //    public void UploadSingleFile(string sourceFilePath, string destinationFolder, string destinationFileName)
    //    {
    //        try
    //        {
    //            try
    //            {
    //                OpenChannel();
    //            }
    //            catch (Exception)
    //            {
    //                _logger.Info("retrying to create connection");
    //                OpenChannel();
    //            }

    //            UploadFile(sourceFilePath, destinationFolder, destinationFileName);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Error(ex.Message);
    //            _logger.Error(ex.StackTrace);
    //        }
    //        finally
    //        {
    //            CloseChannel();
    //        }
    //    }

    //    public void DownloadFiles(string sourceDirectory, string destinationDirectory)
    //    {
    //        Sftp sftp = null;
    //        try
    //        {
    //            sftp = new Sftp(_host, _username, _password);
    //            sftp.Connect();
    //            var files = sftp.GetFileList(sourceDirectory);// + "*.pdf"
    //            if (files != null && files.Count > 0)
    //            {
    //                foreach (var item in files)
    //                {
    //                    if (item.ToString() != "." && item.ToString() != "..")
    //                    {
    //                        _logger.Info(string.Format("Downloading file Path: {0}", sourceDirectory + "/" + item));
    //                        //File Copy from Remote
    //                        sftp.Get(sourceDirectory + "/" + item, destinationDirectory + item);
    //                        _logger.Info(string.Format("Downloaded file Source Path: {0} to Destination Path: {1}", sourceDirectory + "/" + item, destinationDirectory + item));
    //                    }

    //                }
    //            }
    //            else
    //            {
    //                _logger.Info(string.Format("No files found in Path: {0}", sourceDirectory));
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Error(string.Format("Error while downloading files from Path: {0}", sourceDirectory));
    //            _logger.Error(ex.Message);
    //            _logger.Error(ex.StackTrace);
    //        }
    //        finally
    //        {
    //            if (sftp != null)
    //            {
    //                sftp.Close();
    //            }
    //        }
    //    }

    //    public void UploadSingleFileUsingSftp(string sourceFilePath, string destinationFolder, string fileName)
    //    {
    //        Sftp sftp = null;
    //        try
    //        {
    //            sftp = new Sftp(_host, _username, _password);
    //            sftp.Connect();

    //            if (!string.IsNullOrEmpty(destinationFolder))
    //            {
    //                var directoryList = destinationFolder.Split('/');
    //                var directoryPath = string.Empty;
    //                foreach (var directory in directoryList)
    //                {
    //                    try
    //                    {
    //                        if (string.IsNullOrEmpty(directoryPath))
    //                        {
    //                            directoryPath = directory;
    //                        }
    //                        else
    //                        {
    //                            directoryPath = directoryPath + "/" + directory;
    //                        }

    //                        sftp.Mkdir(directoryPath);
    //                    }
    //                    catch (Exception)
    //                    {
    //                        //_logger.Error(ex.Message);
    //                    }
    //                }

    //            }
    //            sftp.Put(sourceFilePath, destinationFolder + "/" + fileName);
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.Error(string.Format("Error while downloading files from Path: {0}", fileName));
    //            _logger.Error(ex.Message);
    //            _logger.Error(ex.StackTrace);
    //        }
    //        finally
    //        {
    //            if (sftp != null)
    //            {
    //                sftp.Close();
    //            }
    //        }
    //    }
    //}

    //class UInfo : UserInfo
    //{
    //    private readonly string _password;

    //    public UInfo(string password)
    //    {
    //        _password = password;
    //    }

    //    public string getPassphrase()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public string getPassword()
    //    {
    //        return _password;
    //    }

    //    public bool promptPassphrase(string message)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public bool promptPassword(string message)
    //    {
    //        return true;
    //    }

    //    public bool promptYesNo(string message)
    //    {
    //        return true;
    //    }

    //    public void showMessage(string message)
    //    {
    //        //throw new System.NotImplementedException();
    //    }
    //}
}
