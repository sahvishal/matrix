namespace Falcon.App.Core.Application.ViewModels
{
    public class SecureHash
    {
        public string HashedText { get; set; }
        public string Salt { get; set; }

        public SecureHash(string hashedText, string salt)
        {
            HashedText = hashedText;
            Salt = salt;
        }
    }
}
