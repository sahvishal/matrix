namespace Falcon.App.Core.Interfaces
{
    public interface IRandomStringGenerator
    {
        string GetRandomString(int length);
        string GetRandomNumericString(int length);
        string GetRandomUpperCaseNumericString(int length);
    }
}