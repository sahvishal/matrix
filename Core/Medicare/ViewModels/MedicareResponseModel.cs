using System.Xml.Serialization;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareResponseModel
    {
        public MedicareMessageModel Message { get; set; }

        public int ErrorCode { get; set; }

        public object Data { get; set; }

        [XmlIgnore]
        public bool IsFeedbackSet
        {
            get
            {
                return Message != null;
            }
        }

       
        public MedicareResponseModel()
        {
            ErrorCode = 0;
        }

    }
}
