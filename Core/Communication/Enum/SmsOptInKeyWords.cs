namespace Falcon.App.Core.Communication.Enum
{
    public sealed class SmsOptInKeyWords
    {
        public const string Start = "start";
        public const string Yes = "yes";
        public const string Unstop = "unstop";

        public static readonly string[] OptInKey = { Start, Yes, Unstop};
    }
}