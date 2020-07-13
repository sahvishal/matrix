
namespace Falcon.App.Core.Application.Impl
{
    public class PasswordCryptographyService : CryptographyService
    {
        //TODO:Will be moved to config file
        public const string securityKey = "BMS";

        protected override string SecurityKey
        {
            get { return securityKey; }
        } 
    }
}
