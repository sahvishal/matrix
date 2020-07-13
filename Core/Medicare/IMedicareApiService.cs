namespace Falcon.App.Core.Medicare
{
    public interface IMedicareApiService
    {
        //void Connect(string token);
        void Connect(long userLoginLogId);
        T Post<T>(string url, object data);
        T Get<T>(string url);
        T PostAnonymous<T>(string url, object data, bool escapeAscii = false);
    }
}
