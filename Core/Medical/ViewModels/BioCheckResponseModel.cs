namespace Falcon.App.Core.Medical.ViewModels
{
    public class BioCheckResponseModel
    {
        public string Question { get; set; }
        public string Value { get; set; }

        public BioCheckResponseModel()
        {
            
        }

        public BioCheckResponseModel(string question,string value)
        {
            Question = question;
            Value = value;
        }

    }
}