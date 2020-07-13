namespace Falcon.App.Core.Application
{
    public interface IBarCodeGenerator
    {
        byte[] GenerateCode39WithoutCheckSum(string plainText);
        byte[] GenerateCode128WithoutCheckSum(string plainText);
    }
}