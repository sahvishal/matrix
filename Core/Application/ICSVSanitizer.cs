namespace Falcon.App.Core.Application
{
    public interface ICSVSanitizer
    {
        string EscapeString(string toEscape);
    }
}