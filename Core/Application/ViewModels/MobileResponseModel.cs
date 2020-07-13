namespace Falcon.App.Core.Application.ViewModels
{
    public class MobileResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

        public void SetErrorMessage(string message)
        {
            Message = message;
            IsSuccess = false;
        }

        public void SetSuccessMessage(string message)
        {
            Message = message;
            IsSuccess = true;
        }

        public void SetUnauthorizedMessage(string message)
        {
            Message = message;
            IsSuccess = false;
        }
    }
}
