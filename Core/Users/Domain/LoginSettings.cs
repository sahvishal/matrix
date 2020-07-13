namespace Falcon.App.Core.Users.Domain
{
    public class LoginSettings
    {
        public long UserLoginId { get; set; }
        public string GoogleAuthenticatorSecretKey { get; set; }
        public string DownloadFilePin { get; set; } 
        public long AuthenticationModeId { get; set; }
        public bool IsFirstLogin { get; set; }
    }
}
