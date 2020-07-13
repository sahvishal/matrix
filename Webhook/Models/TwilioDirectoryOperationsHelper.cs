using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Webhook.Models
{
    public static class TwilioDirectoryOperationsHelper
    {
        public static void CreateDirectory(string filePath)
        {
            if (IsDirectoryNameValid(filePath))
                Directory.CreateDirectory(filePath);
        }

        public static FileStream Create(string filePath)
        {
            return VaidateFullPath(filePath) ? File.Create(filePath) : null;
        }

        public static void Delete(string filePath)
        {
            if (VaidateFullPath(filePath))
                File.Delete(filePath);
        }

        public static void Copy(string sourceFileName, string destFileName)
        {
            if (VaidateFullPath(sourceFileName) && VaidateFullPath(destFileName))
                File.Copy(sourceFileName, destFileName);
        }

        public static void Move(string sourceFileName, string destFileName)
        {
            if (VaidateFullPath(sourceFileName) && VaidateFullPath(destFileName))
                File.Move(sourceFileName, destFileName);
        }

        public static void DirectoryMove(string sourceDirectory, string destDirectory)
        {
            if (IsDirectoryExist(sourceDirectory))
            {
                if (VaidateFullPath(sourceDirectory) && VaidateFullPath(destDirectory))
                    Directory.Move(sourceDirectory, destDirectory);
            }
        }

        public static void AppendAllText(string path, string contents)
        {
            if (VaidateFullPath(path))
                File.AppendAllText(path, contents);
        }

        public static byte[] ReadAllBytes(string filePath)
        {
            return VaidateFullPath(filePath) ? File.ReadAllBytes(filePath) : null;
        }

        public static FileStream OpenRead(string filePath)
        {
            return VaidateFullPath(filePath) ? File.OpenRead(filePath) : null;
        }

        public static bool IsDirectoryExist(string dirPath)
        {
            return IsDirectoryNameValid(dirPath) && Directory.Exists(dirPath);
        }

        public static bool CreateDirectoryIfNotExist(string dirPath)
        {
            if (IsDirectoryNameValid(dirPath) && !Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
                return true;
            }
            if (IsDirectoryNameValid(dirPath))
            {
                return true;
            }

            return false;
        }

        public static string[] GetFiles(string dirPath, string pattern = "")
        {
            if (IsDirectoryNameValid(dirPath))
            {
                if (string.IsNullOrEmpty(pattern))
                    return Directory.GetFiles(dirPath);
                return Directory.GetFiles(dirPath, pattern);
            }
            return null;
        }

        public static string[] GetFilesOrderByDateCreated(string dirPath, string pattern = "")
        {
            if (IsDirectoryNameValid(dirPath))
            {
                if (string.IsNullOrEmpty(pattern))
                {
                    var directoryInfo = new DirectoryInfo(dirPath);
                    var fileInfo = directoryInfo.GetFiles("*.*");
                    if (fileInfo != null && !fileInfo.Any())
                        return fileInfo.OrderBy(x => x.LastWriteTime).Select(x => x.Name).ToArray();
                }
                else
                {
                    var directoryInfo = new DirectoryInfo(dirPath);
                    var fileInfo = directoryInfo.GetFiles(pattern);
                    if (fileInfo != null && !fileInfo.Any())
                        return fileInfo.OrderBy(x => x.LastWriteTime).Select(x => x.Name).ToArray();
                }
            }
            return null;
        }

        public static bool DeleteFileIfExist(string inputfilePath)
        {
            if (!IsDirectoryNameValid(inputfilePath)) return false;

            if (File.Exists(inputfilePath))
                File.Delete(inputfilePath);

            return true;
        }

        public static bool DeleteDirectory(string directoryPath, bool deleteRecursive = false)
        {
            if (!IsDirectoryNameValid(directoryPath)) return false;

            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, deleteRecursive);

            return true;
        }

        public static void DeleteFiles(string dirPath, string searchPattern = "")
        {
            if (!IsDirectoryNameValid(dirPath)) return;
            if (Directory.Exists(dirPath))
            {
                try
                {
                    var files = !string.IsNullOrEmpty(searchPattern) ? Directory.GetFiles(dirPath, searchPattern) : Directory.GetFiles(dirPath);
                    if (files.Any())
                    {
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public static string[] GetDirectories(string dirPath)
        {
            if (!IsDirectoryNameValid(dirPath)) return null;
            if (Directory.Exists(dirPath))
            {
                return Directory.GetDirectories(dirPath);

            }
            return null;
        }

        public static DirectoryInfo GetDirectoryInfo(string dirPath)
        {
            if (!IsDirectoryNameValid(dirPath)) return null;
            if (Directory.Exists(dirPath))
            {
                return new DirectoryInfo(dirPath);
            }

            return null;
        }

        public static string GetParentDirectoryPath(string dirPath, bool createDirectory = true)
        {
            if (!IsDirectoryNameValid(dirPath)) return null;

            if (!Directory.Exists(dirPath) && !createDirectory)
            {
                return string.Empty;
            }

            CreateDirectoryIfNotExist(dirPath);

            return (new DirectoryInfo(dirPath).Parent).FullName;
        }

        public static bool IsFileExist(string inputfilePath)
        {
            if (!IsDirectoryNameValid(inputfilePath)) return false;

            return File.Exists(inputfilePath);
        }

        public static void SaveFileBase64Text(string directoryPath, string fileName, string base64Text)
        {
            if (!CreateDirectoryIfNotExist(directoryPath)) return;

            if (!CreateDirectoryIfNotExist(directoryPath)) return;

            DeleteFileIfExist(String.Format("{0}\\{1}", directoryPath, fileName));

            File.WriteAllBytes(String.Format("{0}\\{1}", directoryPath, fileName), Convert.FromBase64String(base64Text));
        }

        public static void SaveFile(string directoryPath, string fileName, string text)
        {
            if (!CreateDirectoryIfNotExist(directoryPath)) return;

            if (!CreateDirectoryIfNotExist(directoryPath)) return;

            DeleteFileIfExist(String.Format("{0}\\{1}", directoryPath, fileName));

            File.WriteAllText(String.Format("{0}\\{1}", directoryPath, fileName), text);
        }

        private static bool IsDirectoryNameValid(string dirPath)
        {
            if (dirPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                throw new TwilioInvalidDirectoryPathException();

            while (true)
            {
                var folder = dirPath.Split(Path.DirectorySeparatorChar).Last();
                if (!string.IsNullOrEmpty(folder))
                    IsFileNameValid(folder);
                var directoryName = Path.GetDirectoryName(dirPath);
                if (directoryName == null) return true;

                dirPath = directoryName;
            }
        }

        private static bool IsFileNameValid([NotNull] string fileName, bool platformIndependent = false)
        {
            var sPattern = @"^(?!^(PRN|AUX|CLOCK\$|NUL|CON|COM\d|LPT\d|\..*)(\..+)?$)[^\x00-\x1f\\?*:\"";|/]+$";
            if (platformIndependent)
            {
                sPattern = @"^(([a-zA-Z]:|\\)\\)?(((\.)|(\.\.)|([^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?))\\)*[^\\/:\*\?""\|<>\. ](([^\\/:\*\?""\|<>\. ])|([^\\/:\*\?""\|<>]*[^\\/:\*\?""\|<>\. ]))?$";
            }
            if (!Regex.IsMatch(fileName, sPattern, RegexOptions.CultureInvariant))
            {
                throw new TwilioInvalidFileNameException();
            }
            return true;
        }

        private static bool VaidateFullPath(string inputFilePath)
        {
            var filePath = Directory.GetParent(inputFilePath).FullName;
            if (!IsDirectoryNameValid(filePath)) return false;
            var fileName = Path.GetFileName(inputFilePath);
            return fileName != null && IsFileNameValid(fileName);
        }


    }
}