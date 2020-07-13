using Falcon.App.Core.Deprecated.Enum;

namespace Falcon.App.Core.Application.Impl
{
    public class DigitalDeliveryCryptographyService : CryptographyService
    {
        //TODO:Will be moved to config file
        public const string securityKey = "AXT5NTPQDS7899BRSHG";

        protected override string SecurityKey
        {
            get { return securityKey; }
        }

        public string GetKey(long eventId, long customerId, EPDFType type)
        {
            var key = type + "~" + eventId + "~" + customerId + "~" + "SINGLE";
            return Encrypt(key);
        }

        public string GetKey(long eventId, EPDFType type)
        {
            var key = type + "~" + eventId + "~" + 0 + "~" + "ALL";
            return Encrypt(key);
        }
    }
}
