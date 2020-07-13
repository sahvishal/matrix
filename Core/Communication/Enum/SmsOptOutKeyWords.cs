namespace Falcon.App.Core.Communication.Enum
{
    public static class SmsOptOutKeyWords
    {
        public const string Stop = "stop";
        public const string StopAll = "stopall";
        public const string Unsubscribe = "unsubscribe";
        public const string Cancel = "cancel";
        public const string End = "end";
        public const string Quit = "quit";

        public static readonly string[] OptOutKey = { Stop, StopAll, Unsubscribe, Cancel, End, Quit };
    }
}