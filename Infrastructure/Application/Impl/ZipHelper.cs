using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Helper;
using ICSharpCode.SharpZipLib.Zip;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation(Interface = typeof(IZipHelper))]
    public class ZipHelper : IZipHelper
    {

        public string ExtractZipFiles(string zipFilePath)
        {
            string path = Path.GetDirectoryName(zipFilePath);
            path = path + "\\" + Path.GetFileNameWithoutExtension(zipFilePath);

            return ExtractZipFiles(zipFilePath, path);
        }

        public string ExtractZipFiles(string zipFilePath, string destinationFolderPath)
        {
            var s = new ZipInputStream(File.OpenRead(zipFilePath));
            string returnpath = "";
            try
            {

                ZipEntry theEntry;
                int i = 0;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);
                    Directory.CreateDirectory(destinationFolderPath + "\\" + directoryName);
                    if (i == 0)
                    {
                        i++;
                        returnpath = Directory.GetParent(destinationFolderPath + "\\" + directoryName).FullName;
                    }

                    if (fileName != String.Empty)
                    {
                        FileStream streamWriter = File.Create(destinationFolderPath + "\\" + theEntry.Name);
                        try
                        {
                            long collectiveSize = 0;
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                collectiveSize += size;
                                if (size > 0 && collectiveSize <= theEntry.Size)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        finally
                        {
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                    }
                }
            }
            finally
            {
                s.Close();
                s.Dispose();
            }

            return returnpath;
        }

        public string CreateZipFiles(string inputFolderPath, bool pickRecursive = false)
        {
            var destinationDir = Directory.GetParent(inputFolderPath).FullName;

            var outputPath = destinationDir + ".zip";
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            CreateZipFiles(inputFolderPath, outputPath, pickRecursive);
            return outputPath;
        }

        public void CreateZipFiles(string inputFolderPath, string outputPath, bool pickRecursive = false, string fileSearchPattern = "", string password = "")
        {
            var fileList = GenerateFileList(inputFolderPath, fileSearchPattern, pickRecursive); // generate file list
            int trimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove     // from orginal file path
            trimLength += 1; //remove '\'

            byte[] obuffer;

            FileStream fsOut = File.Create(outputPath);

            var oZipStream = new ZipOutputStream(fsOut); // create zip stream

            if (!string.IsNullOrEmpty(password))
                oZipStream.Password = password;

            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string fil in fileList) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(fil.Remove(0, trimLength));
                oZipStream.PutNextEntry(oZipEntry);

                if (!fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    var ostream = File.OpenRead(fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);

                    ostream.Close();
                    ostream.Dispose();
                }
            }

            oZipStream.Finish();
            oZipStream.Close();
            oZipStream.Dispose();

            fsOut.Close();
            fsOut.Dispose();
        }

        private static IEnumerable<string> GenerateFileList(string dir, string fileSearchPattern = "", bool pickRecursive = false)
        {
            var fileList = new List<string>();
            bool empty = true;

            var files = string.IsNullOrEmpty(fileSearchPattern)
                            ? Directory.GetFiles(dir).Where(file => !file.EndsWith(".zip"))
                            : Directory.GetFiles(dir, fileSearchPattern).Where(file => !file.EndsWith(".zip"));

            foreach (string file in files) // add each file in directory
            {
                fileList.Add(file);
                empty = false;
            }

            if (pickRecursive)
            {
                if (empty)
                {
                    if (Directory.GetDirectories(dir).Length == 0)
                    {
                        fileList.Add(dir + @"/");
                    }
                }

                fileList.AddRange(Directory.GetDirectories(dir).SelectMany(dirs => GenerateFileList(dirs, fileSearchPattern, pickRecursive)));
            }

            return fileList; // return file list
        }

        public void CreateZipOfSingleFileWithOutputPath(string inputFilePath, string outputFilePath, string password = "")
        {
            if (inputFilePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            if (outputFilePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new InvalidDirectoryPathException();
            int trimLength = (Directory.GetParent(inputFilePath)).ToString().Length;
            trimLength += 1; 

            byte[] obuffer;

            using (var oZipStream = new ZipOutputStream(DirectoryOperationsHelper.Create(outputFilePath)))
            {
                oZipStream.SetLevel(3); // maximum compression

                if (!string.IsNullOrEmpty(password))
                    oZipStream.Password = password;

                var fileInfo = new FileInfo(inputFilePath);

                var oZipEntry = new ZipEntry(inputFilePath.Remove(0, trimLength));
                oZipEntry.DateTime = fileInfo.LastWriteTime;
                oZipEntry.Size = fileInfo.Length;

                oZipStream.UseZip64 = UseZip64.Off;
                oZipStream.PutNextEntry(oZipEntry);

                if (!inputFilePath.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    using (var ostream = DirectoryOperationsHelper.OpenRead(inputFilePath))
                    {
                        obuffer = new byte[ostream.Length];
                        ostream.Read(obuffer, 0, obuffer.Length);
                        oZipStream.Write(obuffer, 0, obuffer.Length);

                        ostream.Close();
                    }
                }
                oZipStream.CloseEntry();
                oZipStream.Finish();
                oZipStream.Close();
            }
        }

        public string CreateZipOfSingleFile(string inputFilePath, string password)
        {
            var outputFilePath = Directory.GetParent(inputFilePath).FullName + @"\" + Path.GetFileNameWithoutExtension(inputFilePath) + ".zip";

            CreateZipOfSingleFileWithOutputPath(inputFilePath, outputFilePath, password);

            return outputFilePath;
        }

    }
}