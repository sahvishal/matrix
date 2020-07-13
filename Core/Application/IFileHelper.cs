namespace Falcon.App.Core.Application
{
    public interface IFileHelper
    {
        string AddTimeStampToFileName(string fileName);
        string AddPostFixToFileName(string fileName, string postFix);
    }
}