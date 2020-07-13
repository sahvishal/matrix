using System.Xml.Serialization;

namespace Falcon.App.Core.Application.ViewModels
{
    public class ResponseModel
    {
        public FeedbackMessageModel Message { get; set; }
        public object Data { get; set; }

        [XmlIgnore]
        public bool IsFeedbackSet
        {
            get
            {
                return Message != null;
            }
        }

        public void SetErrorMessage(string message)
        {
            Message = FeedbackMessageModel.CreateFailureMessage(message);
        }

        public void SetSuccessMessage(string message)
        {
            Message = FeedbackMessageModel.CreateSuccessMessage(message);
        }

        public void SetUnauthorizedMessage(string message)
        {
            Message = FeedbackMessageModel.CreateUnauthorizedMessage(message);
        }
    }
}
