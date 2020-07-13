using System.Runtime.Serialization;
using Falcon.App.Core.Medicare.Enum;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [DataContract]
    public class MedicareMessageModel
    {
        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public MedicareResponseMessageType MessageType { get; private set; }

        public static MedicareMessageModel CreateSuccessMessage(string message)
        {
            return CreateModel(message, MedicareResponseMessageType.Success);
        }

        public static MedicareMessageModel CreateWarningMessage(string message)
        {
            return CreateModel(message, MedicareResponseMessageType.Warning);
        }

        public static MedicareMessageModel CreateErrorMessage(string message)
        {
            return CreateModel(message, MedicareResponseMessageType.Error);
        }

        private static MedicareMessageModel CreateModel(string message, MedicareResponseMessageType messageType)
        {
            return new MedicareMessageModel { Message = message, MessageType = messageType };
        }

        private MedicareMessageModel()
        {

        }
    }
}
