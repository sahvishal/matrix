namespace Falcon.App.Core.Communication
{
    public interface ISmtpCredentials
    {
        string Host { get; }
        int Port { get; }
        string SmtpUserName { get; }
        string SmtpPassword { get; }
    }
}