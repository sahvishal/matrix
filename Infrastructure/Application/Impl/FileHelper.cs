using System;
using System.IO;
using Falcon.App.Core.Application;


namespace Falcon.App.Infrastructure.Application.Impl
{
    public class FileHelper : IFileHelper
    {
        public  string AddTimeStampToFileName(string fileName)
        {
            return Path.GetFileNameWithoutExtension(fileName) +"-" + DateTime.Now.ToString("mm-dd-yyyy-mm-ss") +
            Path.GetExtension(fileName);
        }

        public string AddPostFixToFileName(string fileName, string postFix)
        {
            return Path.GetFileNameWithoutExtension(fileName) + "-" + postFix +
           Path.GetExtension(fileName);
        }
    }
}