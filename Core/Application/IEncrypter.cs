namespace Falcon.App.Core.Application
{
    public interface IEncrypter
    {
        string Encrypt(string plainText);
        string Decrypt(string cypherText);
    }
}