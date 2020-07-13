using Falcon.App.Core.Application.Enum;

namespace Falcon.App.Core.Application.ViewModels
{
    public class FeedbackMessageModel
    {
        public string Message { get; set; }
        public UserInterfaceMessageType MessageType { get; set; }

        public static FeedbackMessageModel CreateSuccessMessage(string message)
        {
            return CreaetMessage(message, UserInterfaceMessageType.Success);
        }


        public static FeedbackMessageModel CreateFailureMessage(string message)
        {
            return CreaetMessage(message, UserInterfaceMessageType.Error);
        }

        public static FeedbackMessageModel CreateWarningMessage(string message)
        {
            return CreaetMessage(message, UserInterfaceMessageType.Warning);
        }

        public static FeedbackMessageModel CreateUnauthorizedMessage(string message)
        {
            return CreaetMessage(message, UserInterfaceMessageType.Unauthorized);
        }

        private static FeedbackMessageModel CreaetMessage(string message, UserInterfaceMessageType messageType)
        {
            return new FeedbackMessageModel
            {
                Message = message,
                MessageType = messageType
            };
        }
    }
}